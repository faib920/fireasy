using System;

namespace Fireasy.Data.Test
{
    public abstract class DbTestBase
    {
        protected string instanceName = "mysql";
        //protected string instanceName = "mssql1";
        //protected string instanceName = "oracle";
        //protected string instanceName = "sqlite1";
        //protected string instanceName = "oracle2";
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
