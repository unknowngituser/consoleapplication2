using MegaKids.IServices.Subinterface.Admin;

namespace MegaKids.IServices
{
    /// <summary>
    /// Определяет методы публичной части сайта
    /// </summary>
    public interface IAdminServices
    {
        /// <summary>
        /// Определяет методы связанные с пользователями
        /// </summary>
        IAdminUserServices Users { get; set; }
        /// <summary>
        /// Определяет методы связанные с новостями
        /// </summary>
        IAdminNewsServices News { get; set; }
        /// <summary>
        /// Определяет методы связанные с альбомами
        /// </summary>
        IAdminAlbumServices Albums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IAdminModulesServices Modules { get; set; }
    }
}
