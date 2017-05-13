namespace MegaKids.IServices.Subinterface.Public
{
    /// <summary>
    /// Определяет методы связанные с пользователями
    /// </summary>
    public interface IUserServices
    {
        #region Авторизация/Регистрация
        /// <summary>
        /// Проверка существования пользователя в БД
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns><c>true</c> если пользователь имеется в базе данных, <c>false</c> иначе.</returns>
        bool Login(string userName, string password);
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="email">Эл. адрес</param>
        /// <param name="password">Пароль</param>
        /// <param name="salt">Соль</param>
        /// <returns><c>true</c> если регистрация прошла успешно, <c>false</c> иначе.</returns>
        bool Register(string userName, string email, string password, string salt);
        #endregion

        #region Действия над аккаунтом
        
        /// <summary>
        /// Проверка роли пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="role">Роль пользователя</param>
        /// <returns><c>true</c> если роль совпадает, <c>false</c> иначе.</returns>
        bool CheckRole(string userName, string role);
        /// <summary>
        /// Замена старого пароля на новый
        /// </summary>
        /// <param name="email">Эл.адрес</param>
        /// <param name="password">Новый пароль</param>
        /// <param name="salt">Новая соль</param>
       
        #endregion
    }
}
