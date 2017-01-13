// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fireasy.Common.Ioc.Test
{
    [TestClass()]
    public class ContainerUnityTests
    {
        /// <summary>
        /// 使用默认参数测试GetContainer方法。
        /// </summary>
        [TestMethod()]
        public void GetContainerTest()
        {
            var container = ContainerUnity.GetContainer();

            Assert.IsNotNull(container);
        }

        /// <summary>
        /// 使用不存在的配置名称测试GetContainer方法。
        /// </summary>
        [TestMethod()]
        public void GetContainerForNoneTest()
        {
            var container = ContainerUnity.GetContainer("none");
            Console.WriteLine(container.Options.AllowOverriding);

            Assert.IsNotNull(container);
        }

        /// <summary>
        /// 使用具有服务/组件配置的名称测试GetContainer方法。
        /// </summary>
        [TestMethod()]
        public void GetContainerForDefault()
        {
            var container = ContainerUnity.GetContainer();

            Assert.IsFalse(container.GetRegistrations().IsNullOrEmpty());
            Assert.AreEqual(typeof(IocService1), container.Resolve<IIocService>().GetType());
        }

        /// <summary>
        /// 使用具有服务/组件配置的名称测试GetContainer方法。
        /// </summary>
        [TestMethod()]
        public void GetContainerForLocalTest()
        {
            var container = ContainerUnity.GetContainer("local");

            Assert.IsFalse(container.GetRegistrations().IsNullOrEmpty());
            Assert.AreEqual(typeof(IocService), container.Resolve<IIocService>().GetType());
        }
    }

    internal interface IIocService
    {
    }

    internal class IocService : IIocService
    {
    }

    internal class IocService1 : IIocService
    {
    }
}
