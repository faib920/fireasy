using Fireasy.Common.Ioc;
using Fireasy.Utilities.Web;
using Fireasy.Web.UI;
using MvcDemo.Common;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcDemo
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //配置 bundler
            BundleHelper.Config();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //easyui验证绑定
            SettingsBindManager.RegisterBinder("validatebox", new ValidateBoxSettingBinder());
            SettingsBindManager.RegisterBinder("numberbox", new NumberBoxSettingBinder());

            //IOC容器测试
            var container = ContainerUnity.GetContainer();
            container.Register<IMessageTest, MessageTest>();

            //MVC控制器工厂添加IOC容器
            ControllerBuilder.Current.SetControllerFactory(new Fireasy.Web.Mvc.ControllerFactory(container));
        }
    }
}