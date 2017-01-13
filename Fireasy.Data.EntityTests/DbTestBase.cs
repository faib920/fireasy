using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fireasy.Data.Entity.Test
{
    public abstract class DbTestBase
    {
        //protected string instanceName = "mysql";
        //protected string instanceName = "mssql";
        //protected string instanceName = "oracle";
        protected string instanceName = "sqlite";
        //protected string instanceName = "firebird";

        protected void UseDatabase(Action<IDatabase> action)
        {
            using (var database = DatabaseFactory.CreateDatabase(instanceName))
            {
                action(database);
            }
        }
    }

}
