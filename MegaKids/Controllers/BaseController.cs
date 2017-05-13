using MegaKids.IServices;
using MegaKids.IServices.Models;
using MegaKids.WebUI.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Controllers
{
    /// <summary>
    /// Базовый контроллер с внедрением зависимости.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BaseController : Controller
    {
        public IMainServices MainServices { get; set; }

        public IAdminServices AdminServices { get; set; }

        /// <summary>
        /// Конструктор класса <see cref="BaseController"/>.
        /// </summary>
        public BaseController()
        {
            MainServices = DependencyResolver.Current.GetService<IMainServices>();
            AdminServices = DependencyResolver.Current.GetService<IAdminServices>();
            User = WebUser.CurrentUser;
        }

        /// <summary>
        /// Получает сведения о безопасности пользователя для текущего HTTP-запроса.
        /// </summary>
        /// <value>Пользователь</value>
        public new ModelUser User { get; set; }

        public static string HostName = string.Empty;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }
            base.Initialize(requestContext);
        }
    }
}