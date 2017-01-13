using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Validation
{
    /// <summary>
    /// 对电话号码的验证，配置文件对应的键为 Telphone。
    /// </summary>
    public sealed class TelphoneAttribute : ConfigurableRegularExpressionAttribute
    {
        /// <summary>
        /// 初始化 <see cref="TelphoneAttribute"/> 类的新实例。
        /// </summary>
        public TelphoneAttribute()
            : base("Telphone", "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$")
        {
            ErrorMessage = "{0} 字段不符合电话号码的格式";
        }
    }
}
