// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass()]
    public class EnumExtensionTests
    {
        [TestMethod()]
        public void GetDescriptionTest()
        {
            Console.WriteLine(TrafficTools.Automobile.GetDescription());
        }

        [TestMethod()]
        public void GetEnumListTest()
        {
            var dic = typeof(Sex).GetEnumList();
            Assert.AreEqual(2, dic.Count);

            foreach (var kvp in dic)
            {
                Console.WriteLine("值: {0}，文本: {1}", kvp.Key, kvp.Value);
            }
        }

        [TestMethod()]
        public void GetEnumListWithFlagsTest()
        {
            //高级职位 2
            var dic = typeof(Profession).GetEnumList(2);
            Assert.AreEqual(3, dic.Count);

            Console.WriteLine("----高级职位----");
            foreach (var kvp in dic)
            {
                Console.WriteLine("值: {0}，文本: {1}", kvp.Key, kvp.Value);
            }

            //管理岗位 4
            dic = typeof(Profession).GetEnumList(4);
            Assert.AreEqual(1, dic.Count);

            Console.WriteLine("----管理岗位----");
            foreach (var kvp in dic)
            {
                Console.WriteLine("值: {0}，文本: {1}", kvp.Key, kvp.Value);
            }
        }

        private enum Sex
        {
            [EnumDescription("男性")]
            Male,
            [EnumDescription("女性")]
            Female
        }

        private enum Profession
        {
            [EnumDescription("程序员")]
            Programmer,
            [EnumDescription("工程师")]
            Engineer,
            [EnumDescription("架构师", Flags = 2)]
            Architect,
            [EnumDescription("设计师", Flags = 2)]
            Designer,
            [EnumDescription("主管", Flags = 6)]
            Manager,
        }
    }

    [FlagsAttribute]
    public enum TrafficTools
    {
        [EnumDescription("步行")]
        Walking,
        [EnumDescription("汽车")]
        Automobile,
        [EnumDescription("火车")]
        Train,
        [EnumDescription("轮船")]
        Ship,
        [EnumDescription("飞机")]
        Aeroplane
    }

}
