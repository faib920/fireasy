using Fireasy.Web.Http;
using Fireasy.Web.Http.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fireasy.WebTests
{
    public class TestFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}