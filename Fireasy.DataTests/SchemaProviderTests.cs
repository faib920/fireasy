// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Fireasy.Data.Extensions;
using Fireasy.Data.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Data.Test
{
    /// <summary>
    /// SchemaProviderTests类。
    /// </summary>
    [TestClass()]
    public class SchemaProviderTests : DbTestBase
    {
         /// <summary>
        /// 测试GetSchemas方法获取Database集合。
        /// </summary>
        [TestMethod()]
        public void GetSchemasForDataBaseTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var db in provider.GetSchemas<DataBase>(database))
                    {
                        Console.WriteLine("{0}", db.Name);
                    }
                });
        }
                

        /// <summary>
        /// 测试GetSchemas方法获取DataType集合。
        /// </summary>
        [TestMethod()]
        public void GetSchemasForDbTypeTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var dataType in provider.GetSchemas<DataType>(database))
                    {
                        Console.WriteLine("{0} => {1} \t\t{2}", dataType.Name, dataType.SystemType, dataType.CreateFormat);
                    }
                });
        }
                
        [TestMethod]
        public void GetSchemaFoMetadataCollectionTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var metadata in provider.GetSchemas<MetadataCollection>(database))
                    {
                        Console.WriteLine("{0} {1}", metadata.CollectionName, metadata.NumberOfRestrictions);
                    }
                });
        }

        [TestMethod]
        public void GetSchemaFoRestrictionTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var res in provider.GetSchemas<Restriction>(database))
                    {
                        Console.WriteLine("{0}.{1} {2}", res.CollectionName, res.Name, res.Number);
                    }
                });
        }

        /// <summary>
        /// 测试GetSchemas方法获取Table集合。
        /// </summary>
        [TestMethod()]
        public void GetSchemasForTableTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var table in provider.GetSchemas<Table>(database))
                    {
                        Console.WriteLine("{0}({1}):{2}", table.Name, table.Description, table.Type);
                    }
                });
        }

        /// <summary>
        /// 使用Linq测试GetSchemas方法获取Table集合。
        /// </summary>
        [TestMethod()]
        public void GetSchemasForTableUseLinqTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var table in provider.GetSchemas<Table>(database, s => s.Name == "NEW_TABLE"))
                    {
                        Console.WriteLine("{0}({1}):{2}", table.Name, table.Description, table.Type);
                    }
                });
        }

        /// <summary>
        /// 测试GetSchemas方法获取View集合。
        /// </summary>
        [TestMethod()]
        public void GetSchemasForViewTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var table in provider.GetSchemas<View>(database))
                    {
                        Console.WriteLine("{0}({1})", table.Name, table.Description);
                    }
                });
        }

        /// <summary>
        /// 测试GetSchemas方法获取Column集合。
        /// </summary>
        [TestMethod()]
        public void GetSchemasForColumnTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var column in provider.GetSchemas<Column>(database))
                    {
                        Console.WriteLine("{0}({1}):{2} {3}", column.Name, column.Description, column.DataType, column.IsPrimaryKey);
                    }
                });
        }

        /// <summary>
        /// 使用Linq测试GetSchemas方法获取Column集合。
        /// </summary>
        [TestMethod()]
        public void GetSchemasForColumnUseLinqTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var column in provider.GetSchemas<Column>(database, s => s.TableName == "NEW_TABLE"))
                    {
                        Console.WriteLine("{0}({1}):{2}{3}", column.Name, column.Description, column.DataType, column.IsPrimaryKey);
                    }
                });
        }

        [TestMethod]
        public void GetSchemasForForeignKeyTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var fk in provider.GetSchemas<ForeignKey>(database))
                    {
                        Console.WriteLine("{0}({1}.{2}) -> ({3}.{4})", fk.Name, fk.TableName, fk.ColumnName, fk.PKTable, fk.PKColumn);
                    }
                });
        }

        [TestMethod]
        public void GetSchemasForForeignKeyUseLinqTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var fk in provider.GetSchemas<ForeignKey>(database, s => s.TableName == "order details"))
                    {
                        Console.WriteLine("{0}({1}.{2})", fk.Name, fk.PKTable, fk.PKColumn);
                    }
                });
        }
        
        [TestMethod]
        public void GetSchemaFoIndexTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var index in provider.GetSchemas<Index>(database))
                    {
                        Console.WriteLine("{0}.{1} {2} {3}", index.TableName, index.Name, index.IsUnique, index.IsPrimaryKey);
                    }
                });
        }

        
        [TestMethod]
        public void GetSchemaFoIndexUseLinqTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var index in provider.GetSchemas<Index>(database, s => s.TableName == "products"))
                    {
                        Console.WriteLine("{0}.{1} {2} {3}", index.TableName, index.Name, index.IsUnique, index.IsPrimaryKey);
                    }
                });
        }

        [TestMethod]
        public void GetSchemaForIndexColumnTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var index in provider.GetSchemas<IndexColumn>(database))
                    {
                        Console.WriteLine("{0}.{1}", index.TableName, index.ColumnName);
                    }
                });
        }

        [TestMethod]
        public void GetSchemaForIndexColumnUseLinqTest()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var index in provider.GetSchemas<IndexColumn>(database, s => s.TableName == "products"))
                    {
                        Console.WriteLine("{0}.{1}", index.TableName, index.ColumnName);
                    }
                });
        }

        [TestMethod]
        public void GetSchemaForUser()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var user in provider.GetSchemas<User>(database))
                    {
                        Console.WriteLine("{0}", user.Name);
                    }
                });
        }

        [TestMethod]
        public void GetSchemaForProcedure()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var prod in provider.GetSchemas<Procedure>(database))
                    {
                        Console.WriteLine("{0}", prod.Name);
                    }
                });
        }

        [TestMethod]
        public void GetSchemaForProcedureUseLinq()
        {
            UseDatabase(database =>
            {
                var provider = database.Provider.GetService<ISchemaProvider>();

                foreach (var prod in provider.GetSchemas<Procedure>(database, s => s.Schema == "northwind" && s.Name == "InsertOrder"))
                {
                    Console.WriteLine("{0}", prod.Name);
                }
            });
        }

        [TestMethod]
        public void GetSchemaForProcedureParameter()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var par in provider.GetSchemas<ProcedureParameter>(database))
                    {
                        Console.WriteLine("{0} {1}", par.ProcedureName, par.Name);
                    }
                });
        }

        [TestMethod]
        public void GetSchemaForProcedureParameterUseLinq()
        {
            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<ISchemaProvider>();

                    foreach (var par in provider.GetSchemas<ProcedureParameter>(database, s => s.Schema == "northwind" && s.ProcedureName == "InsertOrder"))
                    {
                        Console.WriteLine("{0} {1}", par.Name, par.DataType);
                    }
                });
        }

        //[TestMethod]
        //public void GetSchemaForTrigger()
        //{
        //    UseDatabase(database =>
        //        {
        //            var provider = database.Provider.GetService<ISchemaProvider>();

        //            foreach (var trigger in provider.GetSchemas<Trigger>(database))
        //            {
        //                Console.WriteLine("{0} {1}", trigger.Name, trigger.ObjectTable);
        //            }
        //        });
        //}
        
        //[TestMethod]
        //public void GetSchemaForTriggerUseLinq()
        //{
        //    UseDatabase(database =>
        //        {
        //            var provider = database.Provider.GetService<ISchemaProvider>();

        //            foreach (var trigger in provider.GetSchemas<Trigger>(database, s => s.Schema == "northwind" && s.ObjectTable == "orders" && s.Name == "tg1"))
        //            {
        //                Console.WriteLine("{0}", trigger.Name);
        //            }
        //        });
        //}

    }
}
