// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Fireasy.Common.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Ioc.Test
{
    [TestClass()]
    public class ContainerTests
    {
        /// <summary>
        /// 测试构造函数。
        /// </summary>
        [TestMethod()]
        public void ContainerTest()
        {
            var container = new Container();

            Assert.IsNotNull(container);
        }

        /// <summary>
        /// 覆盖选项测试。
        /// </summary>
        [TestMethod()]
        public void ContainerWithOverrideTest()
        {
            var container = new Container { Options = new ContainerOptions { AllowOverriding = true } };

            container.Register<IMainService, MainService>();
            container.Register<IMainService, MainServiceSecond>();

            var obj = container.Resolve<IMainService>();

            Assert.IsNotNull(obj);
            Assert.AreEqual(typeof(MainServiceSecond), obj.GetType());
        }

        /// <summary>
        /// 不覆盖选项不测试。
        /// </summary>
        [TestMethod()]
        public void ContainerWithDisoverrideTest()
        {
            var container = new Container();
            container.Register<IMainService, MainService>();
            container.Register(typeof(IMainService), typeof(MainServiceSecond));

            var obj = container.Resolve<IMainService>();

            Console.WriteLine(obj.GetType().Name);

            Assert.IsNotNull(obj);
            Assert.AreEqual(typeof(MainService), obj.GetType());
        }

        [TestMethod()]
        public void RegisterTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();

            Assert.AreEqual(1, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void RegisterForTypeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register(typeof(IMainService), typeof(MainService));

            Assert.AreEqual(1, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void RegisterForFuncTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService>(() => new MainService());

            Assert.AreEqual(1, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void RegisterSingletonTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService>(() => new MainService());

            //第一次反转
            var obj1 = container.Resolve<IMainService>();

            //再次反转
            var obj2 = container.Resolve<IMainService>();
            Console.WriteLine(obj1 == obj2);
        }

        [TestMethod()]
        public void RegisterSingletonForTypeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.RegisterSingleton(typeof(IMainService), () => new MainService());

            Assert.AreEqual(1, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void RegisterSingletonForInstanceTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.RegisterSingleton<IMainService>(new MainService());

            Assert.AreEqual(1, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void UnRegisterTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();
            container.UnRegister<IMainService>();

            Assert.AreEqual(0, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void UnRegisterForTypeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();
            container.UnRegister(typeof(IMainService));

            Assert.AreEqual(0, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void ClearTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();
            container.Register<ISubService, SubService>();
            container.Clear();

            Assert.AreEqual(0, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void ResolveTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();

            Assert.IsNotNull(container.Resolve<IMainService>());
        }

        [TestMethod()]
        public void ResolveForTypeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();

            Assert.IsNotNull(container.Resolve(typeof(IMainService)));
        }

        /// <summary>
        /// 使用单例模式测试Resolve方法。
        /// </summary>
        [TestMethod()]
        public void ResolveForSingletonTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.RegisterSingleton<IIdentitySerice>(() => new IdentitySerice());

            var obj1 = container.Resolve<IIdentitySerice>();
            var obj2 = container.Resolve<IIdentitySerice>();

            Assert.AreEqual(obj1, obj2);
            Assert.AreEqual(obj1.Name, obj2.Name);
        }

        /// <summary>
        /// 使用实例一致性测试Resolve方法。
        /// </summary>
        [TestMethod()]
        public void ResolveForInstanceTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IIdentitySerice, IdentitySerice>();

            var obj1 = container.Resolve<IIdentitySerice>();
            var obj2 = container.Resolve<IIdentitySerice>();

            Assert.AreNotEqual(obj1, obj2);
            Assert.AreNotEqual(obj1.Name, obj2.Name);
        }

        /// <summary>
        /// 使用属性注入测试Resolve方法。
        /// </summary>
        [TestMethod()]
        public void ResolveForPropertyInjectTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();
            //container.Register<AA, BB>();

            var sub = container.Resolve<AA>();

            Console.WriteLine(sub.Main);
        }

        /// <summary>
        /// 使用构造函数注入测试Resolve方法。
        /// </summary>
        [TestMethod()]
        public void ResolveForConstructionInjectTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            //container.Register<IMainService, MainService>();
            container.Register<IProvierService, ProviderService>();

            var provider = container.Resolve<IProvierService>();

            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.HasMainService);
        }

        /// <summary>
        /// 使用忽略属性注入特性测试Resolve方法。
        /// </summary>
        [TestMethod()]
        public void ResolveForIgnoreInjectTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();
            container.Register<ISubService, IgnoreInjectSubService>();

            var sub = container.Resolve<ISubService>();

            Assert.IsNotNull(sub);
            Assert.IsNotNull(sub.MainService);
        }

        [TestMethod()]
        public void GetRegistrationsTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();
            container.Register<ISubService, SubService>();

            Assert.AreEqual(2, container.GetRegistrations().Count());
        }

        [TestMethod()]
        public void GetRegistrationTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();

            Assert.IsNotNull(container.GetRegistration<IMainService>());
            Assert.IsNull(container.GetRegistration<ISubService>());
        }

        [TestMethod()]
        public void GetRegistrationForTypeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IMainService, MainService>();

            Assert.IsNotNull(container.GetRegistration(typeof(IMainService)));
            Assert.IsNull(container.GetRegistration(typeof(ISubService)));
        }

        [TestMethod()]
        public void RegisterInitializerTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IIdentitySerice, IdentitySerice>();
            container.RegisterInitializer<IIdentitySerice>(s => s.Name = "fireasy");

            var obj = container.Resolve<IIdentitySerice>();
            Console.WriteLine(obj.Name);

            Assert.IsNotNull(obj);
            Assert.AreEqual("none", obj.Name);
        }

        [TestMethod()]
        public void GetInitializerTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var container = ContainerUnity.GetContainer(key);

            container.Register<IIdentitySerice, IdentitySerice>();
            container.RegisterInitializer<IIdentitySerice>(s => s.Name = "none");

            var initializer = container.GetInitializer<IIdentitySerice>();

            Assert.IsNotNull(initializer);

            var obj = new IdentitySerice();
            initializer(obj);

            Assert.AreEqual("none", obj.Name);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            var container = new Container();

            container.Dispose();
        }

        public class AA
        {
            public IMainService Main { get; private set; }
        }

        public interface IMainService
        {
            string Name { get; set; }
        }

        private interface ISubService
        {
            IMainService MainService { get; set; }
        }

        private interface IProvierService
        {
            bool HasMainService { get; }
        }

        private interface IIdentitySerice
        {
            string Name { get; set; }
        }

        private class MainService : IMainService
        {
            public string Name { get; set; }
        }

        private class MainServiceSecond : IMainService
        {
            public string Name { get; set; }
        }

        private class SubService : ISubService
        {
            public IMainService MainService { get; set; }
        }

        /// <summary>
        /// 忽略属性注入的子服务。
        /// </summary>
        private class IgnoreInjectSubService : ISubService
        {
            [IgnoreInjectProperty()]
            public IMainService MainService { get; set; }
        }

        private class IdentitySerice : IIdentitySerice
        {
            public IdentitySerice()
            {
                Name = Guid.NewGuid().ToString();
            }

            public string Name { get; set; }
        }

        [TestMethod]
        public void Test1()
        {
            var c1 = ContainerUnity.GetContainer("c1");
            var c2 = ContainerUnity.GetContainer("c2");

            var b1 = c1.Resolve<IBClass>();
            var b2 = c2.Resolve<IBClass>();

            Console.WriteLine(b1);
            Console.WriteLine(b2);
        }



        private class ProviderService : IProvierService
        {
            private readonly IMainService mainService;

            public ProviderService(IMainService mainService)
            {
                this.mainService = mainService;
            }

            /// <summary>
            /// 判断是否包含 <see cref="IMainService"/> 对象。
            /// </summary>
            public bool HasMainService
            {
                get
                {
                    return mainService != null;
                }
            }
        }

    }

    public interface IAClass
    {
        IBClass B { get; set; }
    }

    public interface IBClass
    {
    }

    public class BClass1 : IBClass
    {

    }

    public class BClass2 : IBClass
    {

    }

    public class AClass : IAClass
    {
        [IgnoreInjectProperty()]
        public IBClass B { get; set; }
    }

    public class BClass : IBClass
    {
    }

}
