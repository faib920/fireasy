// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Linq.Expressions;

namespace Fireasy.Web.UI
{
    /// <summary>
    /// 从表达式中发现所绑定模型的属性名称。
    /// </summary>
    public class ModelPropertyBinder
    {
        /// <summary>
        /// 初始化 <see cref="ModelPropertyBinder"/> 类的新实例。
        /// </summary>
        /// <param name="expression"></param>
        public ModelPropertyBinder(Expression expression)
        {
            PropertyName = MemberVisitor.GetPropertyName(expression);
        }

        /// <summary>
        /// 获取表达式中的属性名称。
        /// </summary>
        public string PropertyName { get; set; }

        private class MemberVisitor : ExpressionVisitor
        {
            private string propertyName;

            public static string GetPropertyName(Expression expression)
            {
                var visitor = new MemberVisitor();
                visitor.Visit(expression);
                return visitor.propertyName;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                propertyName = node.Member.Name;

                return base.VisitMember(node);
            }
        }
    }
}
