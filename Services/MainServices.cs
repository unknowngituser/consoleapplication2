using MegaKids.IServices.Subinterface.Public;
using MegaKids.IServices;
using MegaKids.Services.Public;

namespace MegaKids.Services
{
    /// <summary>
    /// Управление публичной частью
    /// </summary>
    public class MainServices : IMainServices
    {
        public MainServices()
        {
            Users = new UserServices();
            News = new NewsServices();
            Albums = new AlbumServices();
            Modules = new ModulesServices();
        }
        public IUserServices Users { get; set; }

        public INewsServices News { get; set; }

        public IAlbumServices Albums { get; set; }

        public IModulesServices Modules { get; set; }
    }
}
