using Autofac;
using Autofac.Integration.Mvc;
using MegaKids.IServices;
using MegaKids.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.App_Start
{
    /// <summary>
    /// Определяет один статический метод ConfigureContainer(), который и выполняет настройку зависимости.
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<MainServices>().As<IMainServices>();
            builder.RegisterType<AdminServices>().As<IAdminServices>();


            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}