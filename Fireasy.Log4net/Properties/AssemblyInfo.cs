using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("Fireasy logfnet Provider.")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Fireasy Software")]
[assembly: AssemblyProduct("Fireasy.Log4net")]
[assembly: AssemblyCopyright("Copyright © Fireasy 2013")]
[assembly: AssemblyTrademark("")]
[assembly: NeutralResourcesLanguage("zh-CN")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("2a5e6f33-9fa3-4899-9aff-46abe6bcbe17")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.5.40.42020")]
[assembly: AssemblyFileVersion("1.5.40.42021")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]