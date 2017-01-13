
namespace MvcDemo.Common
{
    /// <summary>
    /// 用于演示ioc注入的接口。查看 HomeController。
    /// </summary>
    public interface IMessageTest
    {
        string GetMessage(); 
    }

    public class MessageTest : IMessageTest
    {
        public string GetMessage()
        {
            return "Hello World!!";
        }
    }
}