using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Validation
{
    /// <summary>
    /// 对电子邮件的验证，配置文件对应的键为 Email。
    /// </summary>
    public sealed class EmailAttribute : ConfigurableRegularExpressionAttribute
    {
        /// <summary>
        /// 初始化 <see cref="EmailAttribute"/> 类的新实例。
        /// </summary>
        public EmailAttribute()
            : base("Email", "^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$")
        {
            ErrorMessage = "{0} 字段不符合电子邮件的格式";
        }
    }
}
