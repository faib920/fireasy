using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fireasy.Common.Extensions.Tests
{
    [TestClass]
    public class BytesExtensionTests
    {
        [TestMethod]
        public void ToHexTest()
        {
            var bytes = Encoding.GetEncoding(0).GetBytes("帆易动力");
            Console.WriteLine(bytes.ToHex());
        }

        [TestMethod]
        public void FromHexTest()
        {
            var hex = "B7ABD2D7B6AFC1A6";
            var bytes = hex.FromHex();
            Console.WriteLine(Encoding.GetEncoding(0).GetString(bytes));
        }
    }
}
