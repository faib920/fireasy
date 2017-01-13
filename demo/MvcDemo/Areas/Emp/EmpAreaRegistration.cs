using System.Web.Mvc;

namespace MvcDemo.Areas.Emp
{
    public class EmpAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Emp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Emp_default",
                "Emp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
