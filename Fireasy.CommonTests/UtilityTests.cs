using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Test
{
    [TestClass()]
    public class UtilityTests
    {
        [TestMethod()]
        public void ResolveDirectoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCacheKeyTest()
        {
            Console.WriteLine(typeof(A).GUID.GetHashCode());
            Console.WriteLine(typeof(B).GUID.GetHashCode());
        }
    }

    public class A
    {

    }

    public class B
    {

    }
}
