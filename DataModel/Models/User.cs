using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    /// <summary>
    /// Класс модели пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        /// <value>Имя пользователя</value>
        public string UserName { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        /// <value>Эл.адрес</value>
        public string Email { get; set; }
        /// <summary>
        /// Фото пользователя
        /// </summary>
        /// <value>Фото</value>
        public string Photo { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        /// <value>Пароль</value>
        public string Password { get; set; }
        /// <summary>
        /// Соль пользователя
        /// </summary>
        /// <value>Соль</value>
        public string Salt { get; set; }
        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        /// <value>Дата регистрации</value>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Дата последний авторизции пользователя
        /// </summary>
        /// <value>Дата последний авторизции</value>
        public DateTime LastLoginDate { get; set; }
        /// <summary>
        /// Идентификатор статуса пользователя
        /// </summary>
        /// <value>Идентификатор статуса пользователя</value>
        public EnumStatusUser StatusUserId { get; set; }
        /// <summary>
        /// Ссылка на список ролей
        /// </summary>
        /// <value>Список ролей</value>
        public List<Role> Roles { get; set; }
    }
    /// <summary>
    /// Возможные статусы пользователя
    /// </summary>
    public enum EnumStatusUser
    {
        /// <summary>
        /// Заблокирован
        /// </summary>
        [Description("Заблокирован")]
        Locked,
        /// <summary>
        /// Подтвержден
        /// </summary>
        [Description("Подтвержден")]
        Confirmed,
        /// <summary>
        /// Не подтвержден
        /// </summary>
        [Description("Не подтвержден")]
        NotConfirmed
    }
}
