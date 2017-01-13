// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Fireasy.Common.Ioc.Registrations
{
    internal abstract class AbstractRegistration : IRegistration
    {
        private Func<Container, object> m_instanceCreator;

        protected AbstractRegistration(Type serviceType)
        {
            ServiceType = serviceType;
            ParameterExpression = Expression.Parameter(typeof(Container), "s");
        }

        public Type ServiceType { get; private set; }

        internal Container Container { get; set; }

        internal ParameterExpression ParameterExpression { get; private set; }

        public object Resolve()
        {
            if (m_instanceCreator == null)
            {
                m_instanceCreator = BuildInstanceCreator();
            }

            var instance = m_instanceCreator(Container);

            return instance;
        }

        private Func<Container, object> BuildInstanceCreator()
        {
            var expression = BuildExpression();
            var newInstanceMethod = Expression.Lambda<Func<Container, object>>(expression, ParameterExpression);
            return newInstanceMethod.Compile();
        }

        internal abstract Expression BuildExpression();
    }
}
