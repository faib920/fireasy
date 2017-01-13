using AopAlliance.Intercept;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Aop.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fireasy.CommonTests.AOP
{
    [TestClass]
    public class SpringNetAopTests
    {
        [TestMethod]
        public void Test()
        {
            ICommand target = new BusinessCommand();
            ProxyFactory factory = new ProxyFactory(target);
            factory.AddAdvice(new ConsoleLoggingAroundAdvice());
            object obj = factory.GetProxy();


            ICommand business = (ICommand)obj;
            Console.WriteLine(obj.GetType().ToString());
            //ICommand command = (ICommand)factory.GetProxy();
            business.Execute("tyb");
            target.Execute("This is the argument");
        }
    }

    public interface ICommand
    {
        object Execute(object context);

    }
    public class BusinessCommand : ICommand
    {
        public object Execute(object context)
        {
            Console.WriteLine("Service implementation is :{0}", context);
            return context;
        }

    }

    public class ConsoleLoggingAroundAdvice : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            Console.WriteLine("Method in ConsoleLoggingAroundAdvice");

            object obj = invocation.Proceed();
            Console.WriteLine("invocation type is :{0}", invocation.GetType().ToString());
            Console.WriteLine("Method name is {0}", invocation.Method.ToString());
            return obj;
        }
    }
}
