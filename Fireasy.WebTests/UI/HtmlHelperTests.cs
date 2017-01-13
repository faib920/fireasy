using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
namespace Fireasy.Web.UI.Tests
{
    [TestClass()]
    public class HtmlHelperTests
    {
        [TestMethod()]
        public void ReadonlyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ParallelTest()
        {
            Parallel.For(1, 50, i =>
                {
                    var s = HtmlHelper.Default.Label("M" + i).AddAttribute("d", i.ToString()).AddStyle("width", i + "px").ToString();
                    Console.WriteLine(i + ":" + s);
                });
        }
    }
}
