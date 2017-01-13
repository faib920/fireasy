using Fireasy.Common.Extensions;
using System.Collections.Generic;
using System.Reflection;

namespace Fireasy.Web.Http.Definitions
{
    public class ReflectionParameterDescriptor : ParameterDescriptor
    {
        public override IEnumerable<T> GetCustomAttributes<T>()
        {
            return ReflectionParameter.GetCustomAttributes<T>();
        }

        public ParameterInfo ReflectionParameter { get; set; }
    }
}
