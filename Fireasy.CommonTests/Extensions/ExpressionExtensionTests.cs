using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass()]
    public class ExpressionExtensionTests
    {
        /// <summary>
        /// 测试数据的结构。
        /// </summary>
        private class TestData
        {
            public TestData()
            {

            }

            public TestData(string name)
            {
                this.Name = name;
            }

            public string Name { get; set; }

            public DateTime Birthday { get; set; }

            public decimal? Age { get; set; }

            public Type DataType { get; set; }
        }

    }
}
