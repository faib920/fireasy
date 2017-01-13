// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.CodeDom;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Compiler.Test
{
    /// <summary>
    /// CodeCompilerTests类。
    /// </summary>
    [TestClass()]
    public class CodeCompilerTests
    {
        private const string CODE1 = @"
public class TestClass1
{
    public void HelloWorld()
    {
    }

    public decimal Calcuate(int x, int y, decimal r)
    {
        return (x + y) * r;
    }
}
";

        private const string CODE2 = @"
using System.Data;
using System.IO;

public class TestClass2
{
    public void HelloWorld()
    {
    }

    public DataTable CreateNewDataTable(string name)
    {
        return new DataTable(name);
    }
}
";

        private const string CODE3 = @"
Imports System

Public Class TestClass3
    Public Sub HelloWorld()
    End Sub

    Public Function Calcuate(ByVal x As Integer, ByVal y As Integer, ByVal r As Decimal) As Decimal
        Return (x + y) * r
    End Function
End Class
";

        /// <summary>
        /// 测试构造器。
        /// </summary>
        [TestMethod()]
        public void CodeCompilerTest()
        {
            var compiler = new CodeCompiler();

            Assert.IsNotNull(compiler);
        }

        /// <summary>
        /// 测试CompileType方法。
        /// </summary>
        [TestMethod()]
        public void CompileTypeTest()
        {
            var compiler = new CodeCompiler();

            var type = compiler.CompileType(CODE1);

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, "TestClass1");
        }

        /// <summary>
        /// 测试CompileType方法，程序集保存到磁盘。
        /// </summary>
        [TestMethod()]
        public void CompileTypeOutputTest()
        {
            var compiler = new CodeCompiler();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "testclass.dll");
            compiler.OutputAssembly = fileName;

            var type = compiler.CompileType(CODE1);

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, "TestClass1");
            Assert.IsTrue(File.Exists(fileName));
        }

        /// <summary>
        /// 使用外部引用测试CompileType方法。
        /// </summary>
        [TestMethod()]
        public void CompileTypeWithReferenceTest()
        {
            var compiler = new CodeCompiler();
            compiler.Assemblies.Add("system.xml.dll");
            compiler.Assemblies.Add("system.data.dll");

            var type = compiler.CompileType(CODE2);

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, "TestClass2");
        }

        /// <summary>
        /// 使用外部文件测试CompileAssembly方法。
        /// </summary>
        [TestMethod()]
        public void CompileAssemblyTest()
        {
            var fileName1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code1.cs");

            if (!File.Exists(fileName1))
            {
                using (var stream = new StreamWriter(fileName1, false, Encoding.GetEncoding(0)))
                {
                    stream.WriteLine(CODE1);
                }
            }
            var fileName2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code2.cs");
            if (!File.Exists(fileName2))
            {
                using (var stream = new StreamWriter(fileName2, false, Encoding.GetEncoding(0)))
                {
                    stream.WriteLine(CODE2);
                }
            }

            var compiler = new CodeCompiler();
            compiler.Assemblies.Add("system.xml.dll");
            compiler.Assemblies.Add("system.data.dll");

            var assembly = compiler.CompileAssembly(new string[] { fileName1, fileName2 });

            Assert.IsNotNull(assembly);
            Assert.AreEqual(assembly.GetExportedTypes().Length, 2);
        }

        /// <summary>
        /// 使用VisualBasic测试CompileType方法。
        /// </summary>
        [TestMethod()]
        public void CompileTypeUseVbTest()
        {
            var compiler = new CodeCompiler();
            compiler.CodeProvider = new VBCodeProvider();

            var type = compiler.CompileType(CODE3, "TestClass3");

            Assert.IsNotNull(type);
            Assert.AreEqual(type.Name, "TestClass3");
        }

        /// <summary>
        /// 测试CompileDelegate方法。
        /// </summary>
        [TestMethod()]
        public void CompileDelegateTest()
        {
            var compiler = new CodeCompiler();

            var func = compiler.CompileDelegate<Func<int, int, decimal, decimal>>(CODE1, "Calcuate");

            Assert.IsNotNull(func);

            Assert.AreEqual(15, func(10, 20, 0.5m));
        }

        /// <summary>
        /// 不指定方法名称测试CompileDelegate方法。
        /// </summary>
        [TestMethod()]
        public void CompileDelegateUnassignMethodTest()
        {
            var compiler = new CodeCompiler();

            var action = compiler.CompileDelegate<Action>(CODE1);

            Assert.IsNotNull(action);
            Assert.AreEqual("HelloWorld", action.Method.Name);
        }

        /// <summary>
        /// 使用CodeDom测试CompileDelegate方法。
        /// </summary>
        [TestMethod()]
        public void CompileDelegateWithCodeDomTest()
        {
            var compiler = new CodeCompiler();
            var unit = new CodeCompileUnit();

            var ns = new CodeNamespace("Test");
            unit.Namespaces.Add(ns);

            var td = new CodeTypeDeclaration("TestClass");
            ns.Types.Add(td);

            var md = new CodeMemberMethod();
            md.Name = "HelloWorld";
            md.Attributes = MemberAttributes.Public;
            td.Members.Add(md);

            md.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "name"));
            md.Statements.Add(new CodeSnippetStatement("return \"Hello \" + name;"));
            md.ReturnType = new CodeTypeReference(typeof(string));

            var func = compiler.CompileDelegate<Func<string, string>>(unit);

            Assert.IsNotNull(func);

            Assert.AreEqual("Hello fireasy", func("fireasy"));
        }
    }
}
