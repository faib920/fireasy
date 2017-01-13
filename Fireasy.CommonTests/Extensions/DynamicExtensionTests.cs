using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
using Fireasy.Common.Dynamic;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass]
    public class DynamicExtensionTests
    {
        [TestMethod]
        public void TryGetMemberTest()
        {
            dynamic d = new ExpandoObject();
            d.Name = "abc";
            object value;
            new DynamicManager().TryGetMember(d, "Name", out value);
            Assert.AreEqual("abc", value);
        }
    }
}
