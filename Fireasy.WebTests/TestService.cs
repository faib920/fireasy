using Fireasy.Common.Serialization;
using Fireasy.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fireasy.WebTests
{
    [Service("test")]
    public class TestService : IHttpService
    {
        public object HelloWorld(string t, int s = 99)
        {
            throw new Fireasy.Common.ClientNotificationException("dfasdfsfsaf");
            return "hello world!!" + s;
        }
    }
}