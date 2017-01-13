using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Fireasy.Data.Entity.Linq.Translators
{
    public class AccessTranslateProvider : TranslateProviderBase
    {
        public override TranslatorBase CreateTranslator()
        {
            return new AccessTranslator();
        }

        protected override Expression BuildExpression(Expression expression)
        {
            // fix up any order-by's
            expression = OrderByRewriter.Rewrite(expression);
            expression = base.BuildExpression(expression);
            expression = CrossJoinIsolator.Isolate(expression);
            expression = SkipToNestedOrderByRewriter.Rewrite(expression);
            expression = OrderByRewriter.Rewrite(expression);
            expression = UnusedColumnRemover.Remove(expression);
            //expression = RedundantColumnRemover.Remove(expression);
            return expression;
        }
    }
}
