using MegaKids.IServices;
using MegaKids.IServices.Subinterface.Admin;
using MegaKids.Services.Admin;

namespace MegaKids.Services
{
    /// <summary>
    /// Управление админкой
    /// </summary>
    public class AdminServices : IAdminServices
    {
        public AdminServices()
        {
            Users = new AdminUserServices();
            News = new AdminNewsServices();
            Albums = new AdminAlbumServices();
            Modules = new AdminModulesServices();
        }
        public IAdminUserServices Users { get; set; }
        public IAdminNewsServices News { get; set; }
        public IAdminAlbumServices Albums { get; set; }
        public IAdminModulesServices Modules { get; set; }
    }
}
