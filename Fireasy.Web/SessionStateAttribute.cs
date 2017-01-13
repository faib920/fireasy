using System;
using System.Web.SessionState;

namespace Fireasy.Web
{
    /// <summary>
    /// 用于标识 Session 的读取行为。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SessionStateAttribute : Attribute
    {
        /// <summary>
        /// 初始化 <see cref="SessionStateAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="behavior"></param>
        public SessionStateAttribute(SessionStateBehavior behavior)
        {
            Behavior = behavior;
        }

        public SessionStateBehavior Behavior { get; private set; }
    }
}
