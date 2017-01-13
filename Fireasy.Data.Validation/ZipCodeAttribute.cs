using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Validation
{
    /// <summary>
    /// 对邮政编码的验证，配置文件对应的键为 ZipCode。
    /// </summary>
    public sealed class ZipCodeAttribute : ConfigurableRegularExpressionAttribute
    {
        /// <summary>
        /// 初始化 <see cref="ZipCodeAttribute"/> 类的新实例。
        /// </summary>
        public ZipCodeAttribute()
            : base("ZipCode", "^\\d{6}$")
        {
            ErrorMessage = "{0} 字段不符合邮政编码的格式";
        }
    }
}
