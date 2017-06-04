using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AnimeCore.Areas.Admin.Controllers;

namespace AnimeCore.Common
{
    public class Constant
    {
        public static string DefaultRole => "Default User";

        public static string ImagesFolderPath => "/upload";

        public static string RootPath => "wwwroot";

        public static string Title => "Title";

        public static string ReturnUrl => "ReturnUrl";

        public static string LoginProvider => "LoginProvider";

        public static string PageSize => "PageSize";

        public static string SearchString => "SearchString";

        public static string SlideTitle => "SlideTitle";

        public static string DateFormat => "MM/dd/yyyy";

        public static IEnumerable<Claim> Claims
        {
            get
            {
                return
                    Helper.GetControllers(typeof(AdminController).Namespace)
                        .SelectMany(controller => Helper.GetActions(controller).Distinct(),
                            (controller, action) =>
                                new Claim(controller.Name.Replace("Controller", ""), action));
            }
        }
    }
}