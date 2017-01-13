// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Data.Entity.Properties;
using Fireasy.Data.Entity.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Fireasy.Data.Entity.Test
{
    [TestClass()]
    public class PropertyUnityTests
    {
        [TestMethod()]
        public void RegisterPropertyTest()
        {
            var property = PropertyUnity.RegisterProperty("Name", typeof(string), typeof(Company), new PropertyMapInfo
                {
                    FieldName = "Name",
                    Length = 20,
                    Description = "公司名称",
                });

            Assert.IsNotNull(property);
        }

        [TestMethod()]
        public void RegisterPropertyByLinqTest()
        {
            var property = PropertyUnity.RegisterProperty<Company>(s => s.Name, new PropertyMapInfo
                {
                    FieldName = "Name",
                    Length = 20,
                    Description = "公司名称",
                });

            Assert.IsNotNull(property);
        }

        [TestMethod()]
        public void RegisterSupposedPropertyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterSupposedPropertyTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterPropertyByPropertyTest()
        {
            var property = PropertyUnity.RegisterProperty(typeof(Company), 
                new GeneralProperty
                    {
                        Name = "Name",
                        Info =
                            new PropertyMapInfo
                            {
                                FieldName = "Name",
                                Length = 20,
                                Description = "公司名称",
                            }
                    });

            Assert.IsNotNull(property);
        }

        [TestMethod()]
        public void GetPropertyTest()
        {
            var p = PropertyUnity.GetProperty(typeof(Products), "ProductName");
            Console.WriteLine(p);
            //Assert.IsNotNull(PropertyUnity.GetProperty(typeof(Orders1), "OrderID"));
        }

        [TestMethod()]
        public void GetPropertyTest1()
        {
            Assert.IsNotNull(PropertyUnity.GetProperty(typeof(Orders), "CustomerID"));
        }

        [TestMethod()]
        public void GetPropertyParallelTest()
        {
            Parallel.For(0, 100, (i) =>
                {
                    Assert.IsNotNull(PropertyUnity.GetProperty(typeof(Products), "Productname"));
                });
        }

        [TestMethod()]
        public void GetPropertiesTest()
        {
            foreach (var property in PropertyUnity.GetProperties(typeof(Products)))
            {
                Console.WriteLine(property.Name);
            }
        }

        [TestMethod()]
        public void GetPrimaryPropertiesTest()
        {
            foreach (var property in PropertyUnity.GetPrimaryProperties(typeof(OrderDetails)))
            {
                Console.WriteLine(property.Name);
            }
        }

        [TestMethod()]
        public void GetPersistentPropertiesTest()
        {
            foreach (var property in PropertyUnity.GetPersistentProperties(typeof(Products)))
            {
                Console.WriteLine(property.Name);
            }
        }

        [TestMethod()]
        public void GetLoadedPropertiesTest()
        {
            foreach (var property in PropertyUnity.GetLoadedProperties(typeof(Products)))
            {
                Console.WriteLine(property.Name);
            }
        }

        [TestMethod()]
        public void GetRelatedPropertiesTest()
        {
            foreach (var property in PropertyUnity.GetRelatedProperties(typeof(Products)))
            {
                Console.WriteLine(property.Name);
            }
        }

        private class Company : EntityObject
        {
            public string Name { get; set; }
        }
    }
}
