// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Data;
using Fireasy.Data.Extensions;
using Fireasy.Data.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Data.Test
{
    [TestClass()]
    public class SyntaxProviderTests : DbTestBase
    {
        /// <summary>
        /// 测试IdentitySelect属性。
        /// </summary>
        [TestMethod()]
        public void IdentitySelectTest()
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();

                    SqlCommand sql = "insert into products(productname, discontinued) values('桌椅', 1)" + syntax.IdentitySelect;

                    Console.WriteLine(sql);
                    var identity = database.ExecuteScalar(sql);
                    Console.WriteLine(identity);
                });
        }

        /// <summary>
        /// 测试ParameterPrefix属性。
        /// </summary>
        [TestMethod()]
        public void ParameterPrefixTest()
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();

                    var parameters = new ParameterCollection();
                    parameters.Add("Name", "车轮");

                    SqlCommand sql = string.Format("select * from products where ProductName = {0}Name", syntax.ParameterPrefix);

                    Console.WriteLine(sql);
                    Assert.IsNotNull(database.ExecuteScalar(sql, parameters));
                });
        }

        /// <summary>
        /// 测试Quote属性。
        /// </summary>
        [TestMethod()]
        public void QuoteTest()
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();

                    SqlCommand sql = string.Format("select {0}ProductName{1} from {0}products{1}", 
                        syntax.Quote[0], syntax.Quote[1]);

                    Console.WriteLine(sql);
                    Assert.IsNotNull(database.ExecuteScalar(sql));
                });
        }

        /// <summary>
        /// 测试Linefeed属性。
        /// </summary>
        [TestMethod()]
        public void LinefeedTest()
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();

                    SqlCommand sql = string.Format("select * from products{0}select * from orders",
                        syntax.Linefeed);

                    Console.WriteLine(sql);
                    var ds = new DataSet();
                    database.FillDataSet(ds, sql);

                    Assert.AreEqual(2, ds.Tables.Count);
                });
        }

        [TestMethod()]
        public void ColumnTest()
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();

                    Console.WriteLine("AnsiString:" + syntax.Column(DbType.AnsiString));
                    Console.WriteLine("AnsiString:" + syntax.Column(DbType.AnsiString, 200));
                    Console.WriteLine("String:" + syntax.Column(DbType.String));
                    Console.WriteLine("String:" + syntax.Column(DbType.String, 200));
                    Console.WriteLine("AnsiStringFixedLength:" + syntax.Column(DbType.AnsiStringFixedLength));
                    Console.WriteLine("AnsiStringFixedLength:" + syntax.Column(DbType.AnsiStringFixedLength, 200));
                    Console.WriteLine("StringFixedLength:" + syntax.Column(DbType.StringFixedLength));
                    Console.WriteLine("StringFixedLength:" + syntax.Column(DbType.StringFixedLength, 200));
                    Console.WriteLine("Boolean:" + syntax.Column(DbType.Boolean));
                    Console.WriteLine("Binary:" + syntax.Column(DbType.Binary));
                    Console.WriteLine("Binary:" + syntax.Column(DbType.Binary, 2000));
                    Console.WriteLine("Byte:" + syntax.Column(DbType.Byte));
                    Console.WriteLine("Currency:" + syntax.Column(DbType.Currency));
                    Console.WriteLine("Date:" + syntax.Column(DbType.Date));
                    Console.WriteLine("DateTime:" + syntax.Column(DbType.DateTime));
                    Console.WriteLine("DateTime2:" + syntax.Column(DbType.DateTime2));
                    Console.WriteLine("DateTimeOffset:" + syntax.Column(DbType.DateTimeOffset));
                    Console.WriteLine("Decimal:" + syntax.Column(DbType.Decimal, precision: 12, scale: 2));
                    Console.WriteLine("Decimal:" + syntax.Column(DbType.Decimal, precision: 12));
                    Console.WriteLine("Decimal:" + syntax.Column(DbType.Decimal, scale: 2));
                    Console.WriteLine("Double:" + syntax.Column(DbType.Double));
                    Console.WriteLine("Int16:" + syntax.Column(DbType.Int16));
                    Console.WriteLine("Int32:" + syntax.Column(DbType.Int32));
                    Console.WriteLine("Int64:" + syntax.Column(DbType.Int64));
                    Console.WriteLine("SByte:" + syntax.Column(DbType.SByte));
                    Console.WriteLine("Single:" + syntax.Column(DbType.Single));
                    Console.WriteLine("Time:" + syntax.Column(DbType.Time));
                    Console.WriteLine("UInt16:" + syntax.Column(DbType.UInt16));
                    Console.WriteLine("UInt32:" + syntax.Column(DbType.UInt32));
                    Console.WriteLine("UInt64:" + syntax.Column(DbType.UInt64));
                    Console.WriteLine("VarNumeric:" + syntax.Column(DbType.VarNumeric));
                    Console.WriteLine("Xml:" + syntax.Column(DbType.Xml));
                });
        }

        [TestMethod()]
        public void ConvertTest()
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();

                    Console.WriteLine("String:" + syntax.Convert(45, DbType.String));
                    Console.WriteLine("StringFixedLength:" + syntax.Convert(45, DbType.StringFixedLength));
                    Console.WriteLine("AnsiString:" + syntax.Convert(45, DbType.AnsiString));
                    Console.WriteLine("AnsiStringFixedLength:" + syntax.Convert(45, DbType.AnsiStringFixedLength));
                    Console.WriteLine("Boolean:" + syntax.Convert(45, DbType.Boolean));
                    Console.WriteLine("Binary:" + syntax.Convert(45, DbType.Binary));
                    Console.WriteLine("Byte:" + syntax.Convert(45, DbType.Byte));
                    Console.WriteLine("Currency:" + syntax.Convert(45, DbType.Currency));
                    Console.WriteLine("DateTime:" + syntax.Convert(45, DbType.Date));
                    Console.WriteLine("DateTime:" + syntax.Convert(45, DbType.DateTime));
                    Console.WriteLine("DateTime2:" + syntax.Convert(45, DbType.DateTime2));
                    Console.WriteLine("DateTimeOffset:" + syntax.Convert(45, DbType.DateTimeOffset));
                    Console.WriteLine("Decimal:" + syntax.Convert(45, DbType.Decimal));
                    Console.WriteLine("Double:" + syntax.Convert(45, DbType.Double));
                    Console.WriteLine("Int16:" + syntax.Convert(45, DbType.Int16));
                    Console.WriteLine("Int32:" + syntax.Convert(45, DbType.Int32));
                    Console.WriteLine("Int64:" + syntax.Convert(45, DbType.Int64));
                    Console.WriteLine("SByte:" + syntax.Convert(45, DbType.SByte));
                    Console.WriteLine("Single:" + syntax.Convert(45, DbType.Single));
                    Console.WriteLine("Time:" + syntax.Convert(45, DbType.Time));
                    Console.WriteLine("UInt16:" + syntax.Convert(45, DbType.UInt16));
                    Console.WriteLine("UInt32:" + syntax.Convert(45, DbType.UInt32));
                    Console.WriteLine("UInt64:" + syntax.Convert(45, DbType.UInt64));
                    Console.WriteLine("VarNumeric:" + syntax.Convert(45, DbType.VarNumeric));
                    Console.WriteLine("Xml:" + syntax.Convert(45, DbType.Xml));
                });
        }
    }
}
