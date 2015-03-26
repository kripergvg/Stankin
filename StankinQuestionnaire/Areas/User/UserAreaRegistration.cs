using System.Web.Mvc;

namespace StankinQuestionnaire.Areas.User
{
    public class UserAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "User_default",
                "{controller}/{action}/{id}",
                new {controller="Home", action = "Index", id = UrlParameter.Optional },
                       constraints: new { controller = "(?!getmoreactivity)" }
            );
        }
    }
}