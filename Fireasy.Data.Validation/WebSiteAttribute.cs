using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Validation
{
    /// <summary>
    /// 对网址的验证，配置文件对应的键为 WebSite。
    /// </summary>
    public sealed class WebSiteAttribute : ConfigurableRegularExpressionAttribute
    {
        /// <summary>
        /// 初始化 <see cref="WebSiteAttribute"/> 类的新实例。
        /// </summary>
        public WebSiteAttribute()
            : base("WebSite", "^http[s]?:\\/\\/([\\w-]+\\.)+[\\w-]+([\\w-./?%&=]*)?$")
        {
            ErrorMessage = "{0} 字段不符合网址的格式";
        }
    }
}
