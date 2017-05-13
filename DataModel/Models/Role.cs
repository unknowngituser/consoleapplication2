using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    /// <summary>
    /// Класс модели ролей пользователя
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        /// <value>Идентификатор</value>
        public TypeRoles Id { get; set; }
        /// <summary>
        /// Наименование роли
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на список пользователей
        /// </summary>
        /// <value>Список пользователей</value>
        public List<User> Users { get; set; }
    }
    /// <summary>
    /// Возможные роли
    /// </summary>
    public enum TypeRoles
    {
        /// <summary>
        /// Администратор
        /// </summary>
        Admin,
        /// <summary>
        /// Модератор
        /// </summary>
        Moderator,
        /// <summary>
        /// Пользователь
        /// </summary>
        User
    }
}
