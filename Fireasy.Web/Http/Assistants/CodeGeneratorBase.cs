
using Fireasy.Web.Http.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fireasy.Web.Http.Assistants
{
    public abstract class CodeGeneratorBase : IDescriptorTextFormatter
    {
        public abstract void Write(System.IO.TextWriter writer, ServiceDescriptor serviceDescriptor);
    }
}
