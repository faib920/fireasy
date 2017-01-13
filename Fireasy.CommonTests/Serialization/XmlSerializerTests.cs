using Fireasy.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;

namespace Fireasy.Common.Serialization.Test
{
    [TestClass()]
    public class XmlSerializerTests
    {
        private DateTime DEFAULT_DATE = new DateTime(2012, 6, 7, 12, 45, 33);

        /// <summary>
        /// 测试构造器。
        /// </summary>
        [TestMethod()]
        public void XmlSerializerTest()
        {
            var serializer = new XmlSerializer();

            Assert.IsNotNull(serializer);
        }

        /// <summary>
        /// 使用整型测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeIntTest()
        {
            var serializer = new XmlSerializer();

            var json = serializer.Serialize(89);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用整型测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeIntArrayTest()
        {
            var serializer = new XmlSerializer();

            var json = serializer.Serialize(new[] { 78, 82, 59 });

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用字符串测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeStringTest()
        {
            var serializer = new XmlSerializer();

            var json = serializer.Serialize("fireasy");

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用字符串测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeStringHtmlTest()
        {
            var serializer = new XmlSerializer();

            var json = serializer.Serialize("<html><body><a href=\"a.html\">A</a></body></html>");

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用布尔测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeBooleanTest()
        {
            var serializer = new XmlSerializer();

            var json = serializer.Serialize(false);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用日期测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeDateTimeTest()
        {
            var serializer = new XmlSerializer();

            var json = serializer.Serialize(DEFAULT_DATE);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用日期及Converters测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeDateTimeWithConverterTest()
        {
            var option = new XmlSerializeOption { Converters = new ConverterList { new DateTimeXmlConverter("yyyy/MM") } };
            var serializer = new XmlSerializer(option);

            var json = serializer.Serialize(DEFAULT_DATE);

            Console.WriteLine(json);
        }

        private class DateTimeXmlConverter : XmlConverter
        {
            private string format;

            public DateTimeXmlConverter(string format)
            {
                this.format = format;
            }

            public override bool CanConvert(Type type)
            {
                return type == typeof(DateTime);
            }

            public override string WriteXml(XmlSerializer serializer, object obj)
            {
                var date = (DateTime)obj;
                return date.ToUniversalTime().ToString(format);
            }
        }

        [TestMethod()]
        public void SerializeBytesTest()
        {
            var b = new byte[] { 45, 66, 11, 133, 45, 232 };
            var serializer = new XmlSerializer();

            Console.WriteLine(serializer.Serialize(b));
        }

        /// <summary>
        /// 使用object测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeObjectTest()
        {
            var option = new XmlSerializeOption { Converters = new ConverterList { new DateTimeXmlConverter("yyyy/MM") } };
            var serializer = new XmlSerializer(option);

            var obj = new JsonData
                {
                    Age = 12,
                    Name = "huangxd",
                    Birthday = DateTime.Parse("1982-9-20")
                };

            var json = serializer.Serialize(obj);

            using (var s = new StringWriter())
            {
                new System.Xml.Serialization.XmlSerializer(typeof(JsonData)).Serialize(s, obj);
                Console.WriteLine(s.ToString());
            }

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用object及Camel命名选项测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeObjectWithCamelTest()
        {
            var option = new XmlSerializeOption { CamelNaming = true };
            var serializer = new XmlSerializer(option);

            var obj = new JsonData
                {
                    Age = 12,
                    Name = "huangxd",
                    Birthday = DateTime.Parse("1982-9-20"),
                    WorkRecords = new List<WorkRecord> {  new  WorkRecord { Company = "dd" } }
                };

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);

            using (var s = new StringWriter())
            {
                new System.Xml.Serialization.XmlSerializer(typeof(JsonData)).Serialize(s, obj);
                Console.WriteLine(s.ToString());
            }
        }

        /// <summary>
        /// 使用包含选项测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeObjectWithInclusiveNamesTest()
        {
            var option = new XmlSerializeOption { InclusiveNames = new string[] { "Name" } };
            var serializer = new XmlSerializer(option);

            var obj = new JsonData
                {
                    Age = 12,
                    Name = "huangxd",
                    Birthday = DateTime.Parse("1982-9-20")
                };

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用排除选项测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeObjectWithExclusiveNamesTest()
        {
            var option = new XmlSerializeOption { ExclusiveNames = new string[] { "Birthday" } };
            var serializer = new XmlSerializer(option);

            var obj = new JsonData
                {
                    Age = 12,
                    Name = "huangxd",
                    Birthday = DateTime.Parse("1982-9-20")
                };

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用复杂对象测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeObjectDetailTest()
        {
            var serializer = new XmlSerializer();

            var obj = new JsonData
                {
                    Age = 12,
                    Name = "huangxd",
                    Birthday = DateTime.Parse("1982-9-20"),
                    WorkRecords = new List<WorkRecord> 
                        { 
                            new WorkRecord {  Company = "company1", StartDate = DateTime.Parse("2009-3-4"), EndDate = DateTime.Parse("2012-3-4") },
                            new WorkRecord {  Company = "company2", StartDate = DateTime.Parse("2012-4-14") } 
                        }
                };

            using (var s = new StringWriter())
            {
                new System.Xml.Serialization.XmlSerializer(typeof(JsonData)).Serialize(s, obj);
                Console.WriteLine(s.ToString());
            }

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用TextSerializeElement特性测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeObjectWithElementTest()
        {
            var serializer = new XmlSerializer();

            var obj = new ElementData
                {
                    Name = "huangxd"
                };

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用TextSerializeElement特性测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeObjectWithElementTest1()
        {
            var serializer = new XmlSerializer();

            var obj = new ElementData<string, ElementData<int, int>>
                {
                    Data = "huangxd"
                };

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);

            using (var s = new StringWriter())
            {
                new System.Xml.Serialization.XmlSerializer(typeof(ElementData<string, ElementData<int, int>>)).Serialize(s, obj);
                Console.WriteLine(s.ToString());
            }

        }

        /// <summary>
        /// 使用Type测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeTypeIgnoreTest()
        {
            var serializer = new XmlSerializer();

            var obj = new JsonData
                {
                    DataType = typeof(WorkRecord)
                };

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用Type测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeTypeTest()
        {
            var serializer = new XmlSerializer(new XmlSerializeOption { IgnoreType = false });

            var obj = new JsonData
                {
                    DataType = typeof(WorkRecord)
                };

            var json = serializer.Serialize(obj);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用列表测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeListTest()
        {
            var serializer = new XmlSerializer();
            var list = new List<JsonData>();
            for (var i = 0; i < 2; i++)
            {
                list.Add(new JsonData
                    {
                        Age = 12,
                        Name = "huangxd",
                        Birthday = DateTime.Parse("1982-9-20")
                    });
            }

            Console.WriteLine("使用Fireasy序列化 50000 个对象");

            var time = TimeWatcher.Watch(() =>
                {
                    var xml = serializer.Serialize(list);
                    Console.WriteLine(xml);
                });

            Console.WriteLine("耗时: {0} 毫秒", time.Milliseconds);
            Console.WriteLine("使用Xml序列化 50000 个对象");

            var time2 = TimeWatcher.Watch(() =>
                {
                    using (var s = new StringWriter())
                    {
                        new System.Xml.Serialization.XmlSerializer(typeof(List<JsonData>)).Serialize(s, list);
                        Console.WriteLine(s.ToString());
                    }

                });

            Console.WriteLine("耗时: {0} 毫秒", time2.Milliseconds);
        }

        /// <summary>
        /// 使用字典测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeDictonaryTest()
        {
            var serializer = new XmlSerializer();

            var dictionary = new Dictionary<string, JsonData>
                {
                    { 
                        "huangxd", 
                        new JsonData
                            {
                                Age = 12,
                                Name = "huangxd",
                                Birthday = DateTime.Parse("1982-9-20")
                            } 
                    },                
                    {
                        "liping", 
                        new JsonData
                            {
                                Age = 22,
                                Name = "liping",
                                Birthday = DateTime.Parse("1972-5-10")
                            }  
                    }              
                };

            var json = serializer.Serialize(dictionary);

            Console.WriteLine(json);

            /* 不支持
            var sb = new StringBuilder();
            using (var s = new StringWriter(sb))
            {
                new System.Xml.Serialization.XmlSerializer(typeof(Dictionary<string, JsonData>)).Serialize(s, dictionary);
            }

            Console.WriteLine(sb.ToString());
             */

        }

        /// <summary>
        /// 使用数据集测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeDataSetTest()
        {
            var serializer = new XmlSerializer();

            var ds = new DataSet();

            var tb = new DataTable("table1");
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Age", typeof(int));
            tb.Columns.Add("Birthday", typeof(DateTime));

            tb.Rows.Add("huangxd", 12, DateTime.Parse("1982-9-20"));
            tb.Rows.Add("liping", 22, DateTime.Parse("1972-9-20"));

            ds.Tables.Add(tb);

            var json = serializer.Serialize(ds);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用数据表测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeDataTableTest()
        {
            var serializer = new XmlSerializer();

            var tb = new DataTable("table1");
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Age", typeof(int));
            tb.Columns.Add("Birthday", typeof(DateTime));

            tb.Rows.Add("huangxd", 12, DateTime.Parse("1982-9-20"));

            var json = serializer.Serialize(tb);

            Console.WriteLine(json);
        }

        /// <summary>
        /// 使用数组测试Serialize方法。
        /// </summary>
        [TestMethod()]
        public void SerializeArrayTest()
        {
            var serializer = new XmlSerializer(new XmlSerializeOption { Indent = true });

            var array = new JsonData[] 
                {
                    new JsonData
                        {
                            Age = 12,
                            Name = "huangxd",
                            Birthday = DateTime.Parse("1982-9-20")
                        },                
                    new JsonData
                        {
                            Age = 22,
                            Name = "liping",
                            Birthday = DateTime.Parse("1972-5-10")
                        }                
                };

            var json = serializer.Serialize(array);

            Console.WriteLine(json);

            using (var s = new StringWriter())
            {
                new System.Xml.Serialization.XmlSerializer(typeof(JsonData[])).Serialize(s, array);
                Console.WriteLine(s.ToString());
            }
        }

        [TestMethod()]
        public void SerializeArrayListTest()
        {
            var serializer = new XmlSerializer(new XmlSerializeOption { Indent = true });
            
            var array = new ArrayList();
            array.Add(3444);
            array.Add("ddddd");

            var json = serializer.Serialize(array);
            Console.WriteLine(json);

            using (var s = new StringWriter())
            {
                new System.Xml.Serialization.XmlSerializer(typeof(ArrayList)).Serialize(s, array);
                Console.WriteLine(s.ToString());
            }
        }

        [TestMethod()]
        public void SerializeColorTest()
        {
            var serializer = new XmlSerializer();

            var json = serializer.Serialize(Color.Red);

            Console.WriteLine(json);
        }

        [TestMethod()]
        public void SerializeExpressionTest()
        {
            var age = 44;
            var l = new[] { 34m, 55m, 66m };
            var aaa = new { DD = new { Age = 34 } };
            Expression<Func<JsonData, bool>> expression = (s) => s.Age == age ||
                s.Age == aaa.DD.Age && s.Age == new { Age = 34 }.Age &&
                s.Name.Substring(1, 2) == "12" ||
                l.Contains((decimal)s.Age) ||
                s.Name == new JsonData("12") { Age = 12 }.Name;

            //var option = new XmlSerializeOption();
            //option.Converters.Add(new ExpressionJsonConverter());
            //var serializer = new XmlSerializer(option);

            //var json = serializer.Serialize(expression);
            //Console.WriteLine(json);
        }

        [TestMethod()]
        public void SerializeExpandoObjectTest()
        {
            dynamic obj = new ExpandoObject();
            obj.Name = "aaaa";
            obj.IsOld = true;
            obj.Age = 12.5;
            obj.Items = new[] { 34, 55, 66 };

            var dd = new { A = 43434 };

            var serializer = new XmlSerializer();

            var json = serializer.Serialize(GenericExtension.Extend(obj, dd));
            Console.WriteLine(json);
        }


        public interface IJsonData
        {
            decimal? Age { get; set; }
            DateTime Birthday { get; set; }
            Type DataType { get; set; }
            string Name { get; set; }
            List<WorkRecord> WorkRecords { get; set; }
        }

        /// <summary>
        /// 测试数据的结构。
        /// </summary>
        public class JsonData : IJsonData
        {
            public JsonData()
            {

            }

            public JsonData(string name)
            {
                this.Name = name;
            }

            public string Name { get; set; }

            public DateTime Birthday { get; set; }

            public decimal? Age { get; set; }

            public List<WorkRecord> WorkRecords { get; set; }

            public Type DataType { get; set; }
        }

        public class WorkRecord
        {
            public string Company { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime? EndDate { get; set; }
        }

        public class ElementData
        {
            [TextSerializeElement("xm")]
            public string Name { get; set; }
        }

        public class ElementData<T, T2>
        {
            public T Data { get; set; }
        }

        /// <summary>
        /// Json转换类，由于双引号比较麻烦，因此可以使用单引号来替代，在ToString时再转换为双引号。
        /// </summary>
        private class JsonText
        {
            public JsonText(string json)
            {
                Content = json.Replace("'", "\"");
            }

            public string Content { get; set; }

            public override string ToString()
            {
                return Content;
            }
        }

        private enum TestEnum
        {
            A,
            B,
            C
        }
    }
}
