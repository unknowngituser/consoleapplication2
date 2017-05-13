using MegaKids.IServices.Subinterface.Public;

namespace MegaKids.IServices
{
    /// <summary>
    /// Определяет методы публичной части сайта
    /// </summary>
    public interface IMainServices
    {
        /// <summary>
        /// Определяет методы связанные с пользователями
        /// </summary>
        IUserServices Users { get; set; }
        /// <summary>
        /// Определяет методы связанные с новостями
        /// </summary>
        INewsServices News { get; set; }
        /// <summary>
        /// Определяет методы связанные с альбомами
        /// </summary>
        IAlbumServices Albums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IModulesServices Modules { get; set; }
    }
}
