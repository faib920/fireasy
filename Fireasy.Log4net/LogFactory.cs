using Fireasy.Common.Configuration;
using Fireasy.Common.Logging;

namespace Fireasy.Log4net
{
    public class LogFactory : IManagedFactory
    {
        object IManagedFactory.CreateInstance(string name)
        {
            return new Logger(name);
        }
    }
}
