using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Common.Subscribe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Fireasy.Common.Subscribe.Tests
{
    [TestClass()]
    public class SubscribeManagerTests
    {
        [TestMethod()]
        public void PublishTest()
        {
            SubscribeManager.Register<Subject>(new MySubscriber { Id = "huangxd" });
            SubscribeManager.Register<Subject>(new MySubscriber { Id = "liming" });

            SubscribeManager.Publish<Subject>("hello {0}");
        }

        [TestMethod()]
        public void RegisterTest()
        {
            SubscribeManager.Register<Subject>(new MySubscriber { Id = "huangxd" });
            SubscribeManager.Register<Subject>(new MySubscriber { Id = "huangxd" });
        }

        [TestMethod()]
        public void UnRegisterTest()
        {
            SubscribeManager.Register<Subject>(new MySubscriber { Id = "huangxd" });
            SubscribeManager.UnRegister<Subject>(new MySubscriber { Id = "huangxd" });
        }

        [TestMethod()]
        public void FilterTest()
        {
            SubscribeManager.Register<FilterSubject>(new MySubscriber { Id = "huangxd" });
            SubscribeManager.Register<FilterSubject>(new MySubscriber { Id = "liming" });

            SubscribeManager.Publish<FilterSubject>("hello {0}");
        }

        private class Subject : ISubject
        {
            public string Message;

            public virtual void Initialize(params object[] arguments)
            {
                Message = arguments[0].ToString();
            }

            public virtual Func<ISubscriber, bool> Filter { get; set; }
        }

        private class FilterSubject : Subject
        {
            public override void Initialize(params object[] arguments)
            {
                Filter = new Func<ISubscriber, bool>(s => ((MySubscriber)s).Id.StartsWith("h"));
                Message = arguments[0].ToString();
            }

            public override Func<ISubscriber, bool> Filter { get; set; }
        }

        private class MySubscriber : ISubscriber
        {
            public string Id { get; set; }

            public void Accept(ISubject subject)
            {
                var my = subject as Subject;
                Console.WriteLine(string.Format(my.Message, Id));
            }

            public override bool Equals(object obj)
            {
                return Id == ((MySubscriber)obj).Id;
            }
        }
    }
}
