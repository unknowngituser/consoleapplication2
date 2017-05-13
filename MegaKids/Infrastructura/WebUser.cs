using MegaKids.IServices;
using MegaKids.IServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Numerics;
using System.Web.Mvc;
using System.Globalization;
using MegaKids.Infrastructura.Extensions;

namespace MegaKids.WebUI.Infrastructura
{
    /// <summary>
    /// Класс реализующий методы связанные с пользователем
    /// </summary>
    public class WebUser
    {
        /// <summary>
        /// The services
        /// </summary>
        private static IMainServices Services = DependencyResolver.Current.GetService<IMainServices>();
        /// <summary>
        ///  Модель пользователя содержащия сессию и куки в которой находится информация о пользователе
        /// </summary>
        public static ModelUser CurrentUser
        {
            get
            {
                if (!(HttpContext.Current.Session["MegaKids-session"] is ModelUser))
                {

                    var data = HttpContext.Current.Request.Cookies["MegaKids-auth"];
                    if (data == null || string.IsNullOrWhiteSpace(data.Value))
                    {
                        return new ModelUser();
                    }
                    else
                    {
                        var model = Decrypt(data.Value);
                        if (model != null)
                            Login(model.UserName, model.Password);
                        else return new ModelUser();
                    }
                }
                return HttpContext.Current.Session["MegaKids-session"] as ModelUser;
            }
            set
            {
                HttpContext.Current.Session["MegaKids-session"] = value;
            }
        }

        /// <summary>
        /// Метод выполняющий авторизацю на сайте
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="remember">Сохранение в куки</param>
        public static void Login(string userName, string password, bool remember = false)
        {
            if (Services.Users.Login(userName, password))
            {
                CurrentUser = new ModelUser { UserName = userName, IsAuth = true, Password = password };
                if (remember) HttpContext.Current.Response.Cookies.Add(new HttpCookie("MegaKids-auth") { Value = Encrypt(CurrentUser), Expires = DateTime.Now.AddDays(1) });
            }

        }
        /// <summary>
        /// Выполняет регистрацию пользователя на сайте
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="email">Эл. Адрес</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>System.String.</returns>
        public static string Register(string userName, string email, string password)
        {
            var salt = MyExtensions.GetSalt();
            Services.Users.Register(userName, email, password, salt);
            return salt;
        }
        /// <summary>
        /// Удаляет сессию и куки содержащию информацию о состоянии авторизации пользователя
        /// </summary>
        public static void LogOff()
        {
            HttpContext.Current.Session.Remove("MegaKids-session");
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("MegaKids-auth") { Expires = DateTime.Now.AddDays(-1) });
        }
        /// <summary>
        /// Проверка роли пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="role">Роль пользователя</param>
        /// <returns><c>true</c> если роль совпадает, <c>false</c> иначе.</returns>
        public static bool CheckRole(string userName, string role)
        {
            return Services.Users.CheckRole(userName, role);
        }
        

        #region Криптография

        static byte[] key = Encoding.UTF8.GetBytes("Some salt value0Some salt value0");

        static byte[] IV = Encoding.UTF8.GetBytes("Some salt value0");


        private static string Encrypt(ModelUser model)
        {
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = key;
                myAes.IV = IV;
                byte[] encrypted = EncryptStringToBytes_Aes($"{model.UserName},{model.Password}", myAes.Key, myAes.IV);
                return new BigInteger(encrypted).ToString("x2");
            }
        }

        private static ModelUser Decrypt(string encrypted)
        {
            using (Aes myAes = Aes.Create())
            {
                try
                {
                    myAes.Key = key;
                    myAes.IV = IV;
                    var number = BigInteger.Parse(encrypted, NumberStyles.HexNumber);
                    string roundtrip = DecryptStringFromBytes_Aes(number.ToByteArray(), myAes.Key, myAes.IV);
                    var mas = roundtrip.Split(',');
                    var model = new ModelUser() { UserName = mas[0], Password = mas[1] };
                    return model;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }


        #endregion
    }
}