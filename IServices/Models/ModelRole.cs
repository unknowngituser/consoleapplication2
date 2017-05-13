using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models
{
    /// <summary>
    /// Класс модели ролей пользователя
    /// </summary>
    public class ModelRole
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        /// <value>Идентификатор</value>
        public ModelEnumTypeRoles Id { get; set; }
        /// <summary>
        /// Наименование роли
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
    }
    /// <summary>
    /// Возможные роли
    /// </summary>
    public enum ModelEnumTypeRoles
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
