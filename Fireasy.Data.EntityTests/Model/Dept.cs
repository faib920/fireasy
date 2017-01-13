using Fireasy.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fireasy.Data.Entity.Test.Model
{
    [EntityMapping("dept")]
    [EntityTreeMapping(InnerSign="Code")]
    public class Dept : LighEntityObject<Dept>
    {
        [PropertyMapping(GenerateType=IdentityGenerateType.AutoIncrement)]
        public virtual int Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }
    }
}
