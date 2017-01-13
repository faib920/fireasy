// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Aop;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 精简数据实体的 AOP 拦截器，用于注入 GetValue 和 SetValue 方法。
    /// </summary>
    public sealed class LighEntityInterceptor : IInterceptor
    {
        void IInterceptor.Initialize(InterceptContext context)
        {
        }

        void IInterceptor.Intercept(InterceptCallInfo info)
        {
            if (info.InterceptType == InterceptType.BeforeGetValue ||
                info.InterceptType == InterceptType.BeforeSetValue)
            {
                var entity = info.Target as IEntity;
                var entityType = entity.EntityType;
                var property = PropertyUnity.GetProperty(entityType, info.Member.Name);
                if (property == null)
                {
                    return;
                }

                info.Cancel = true;

                switch (info.InterceptType)
                {
                    case InterceptType.BeforeGetValue:
                        var value = (entity as IPropertyAccessorBypass).GetValue(property);
                        if (value != null && !value.IsEmpty)
                        {
                            info.ReturnValue = value.GetStorageValue();
                        }
                        break;
                    case InterceptType.BeforeSetValue:
                        (entity as IPropertyAccessorBypass).SetValue(property, info.Arguments[0]);
                        break;
                }
            }

        }
    }
}
