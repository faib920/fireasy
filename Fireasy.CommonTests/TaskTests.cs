using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Fireasy.Common.Extensions;
using System.Collections.Concurrent;
using System.Threading;

namespace Fireasy.Common.Test
{
    [TestClass]
    public class TaskTests
    {

        [TestMethod()]
        public void TestTask()
        {
            //List<Uri> uris = new List<Uri>();

            //uris.Add(new Uri("http://ent.qq.com/a/20150505/026729.htm"));
            //uris.Add(new Uri("http://oversea.huanqiu.com/article/2015-05/6344122.html"));
            //uris.Add(new Uri("http://tw.cankaoxiaoxi.com/2015/0505/767958.shtml"));

            //Console.WriteLine(TimeWatcher.Watch(() => SumPageSizes(uris)));
            //Console.WriteLine(TimeWatcher.Watch(() => SumPageSizesAsync2(uris)));

            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            var s = new Student1 { StudentId = 34, StudentName = "dd" };
            s.Display();
            Console.WriteLine(s.StudentId);
        }

        [TestMethod]
        public void TestConcurrentDictionary()
        {
            var concurentDictionary = new ConcurrentDictionary<int, int>();

            var w = new ManualResetEvent(false);
            int timedCalled = 0;
            var threads = new List<Thread>();
            Lazy<int> lazy = new Lazy<int>(() => { Interlocked.Increment(ref timedCalled); return 1; });
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(() =>
                {
                    w.WaitOne();
                    concurentDictionary.GetOrAdd(1, i1 =>
                    {
                        return lazy.Value;
                    });
                }));
                threads.Last().Start();
            }
            w.Set();//release all threads to start at the same time         
            Thread.Sleep(100);
            Console.WriteLine(timedCalled);// output is 4, means call initial 4 times        
        }

        [TestMethod()]
        public void test()
        {
            foreach (var fieldInfo in typeof(AA).GetFields())
            {
                if (fieldInfo.Name == "AAm")
                {
                    Console.WriteLine((AA)fieldInfo.GetValue(null));
                }
            }
        }

        [TestMethod]
        public void Test11()
        {
            dynamic d = new System.Dynamic.ExpandoObject();
            d.name = "dadfsafasdf";
            //var d = new product { name = "dfaf" };

            var p1 = GenericExtension.To<product1>(d);
            Console.WriteLine((string)p1.name);
        }

        internal enum AA
        {
            AAm,
            BBm,
        }

        public async Task<int> SumPageSizesAsync2(IList<Uri> uris)
        {
            var tasks = uris.Select(uri => new WebClient().DownloadDataTaskAsync(uri));
            var data = await Task.WhenAll(tasks);
            return await Task.Run(() =>
            {
                return data.Sum(s => s.Length);
            });
        }

        public int SumPageSizes(IList<Uri> uris)
        {
            int total = 0;
            foreach (var uri in uris)
            {
                var data = new WebClient().DownloadData(uri);
                total += data.Length;
            }
            return total;
        }
    }

    public class product
    {
        public string name { get; set; }
    }

    public class product1 : product
    {
        public new string name { get; set; }
    }


    public class Student
    {
        public Student()
        { }

        public Student(string studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }

        public string StudentId { get; set; }

        public string StudentName { get; set; }

        public void Display()
        {
            Console.WriteLine("学号:{0}, 姓名:{1}", StudentId, StudentName);
        }
    }

    public class Student1 : Student
    {
        public new int StudentId { get; set; }
    }
}
