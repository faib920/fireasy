using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass]
    public class StreamExtensionTests
    {
        [TestMethod]
        public void TestRead()
        {
            using (var source = new FileStream("f:\\gcd.rar", FileMode.Open))
            using (var dest = new FileStream("f:\\gcd_1.rar", FileMode.Create))
            {
                source.Read((buffer, offset, count) =>
                    {
                        dest.Write(buffer, 0, count);
                    });
            }
        }

        [TestMethod]
        public void TestWriteTo()
        {
            using (var source = new FileStream("f:\\gcd.rar", FileMode.Open))
            using (var dest = new FileStream("f:\\gcd_1.rar", FileMode.Create))
            {
                source.WriteTo(dest);
            }
        }

        [TestMethod]
        public void TestCopyToMemory()
        {
            using (var source = new FileStream("f:\\gcd.rar", FileMode.Open))
            using (var memory = source.CopyToMemory())
            {
                Console.WriteLine(memory.Length);
            }
        }
    }
}
