// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Fireasy.Common.Extensions;
using Fireasy.Data.Extensions;
using Fireasy.Data.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Data.Syntax.Test
{
    public class SyntaxTestBase : DbTestBase
    {
        protected void Invoke(Func<ISyntaxProvider, string> func)
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();
                    SqlCommand sql = string.Format("SELECT {0} {1}", func(syntax), syntax.FakeSelect);
                    Console.WriteLine(sql);
                    var result = database.ExecuteScalar(sql);
                    Console.WriteLine(result);
                });
        }

        protected void AreEqual<T>(T target, Func<ISyntaxProvider, string> func)
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();
                    SqlCommand sql = string.Format("SELECT {0} {1}", func(syntax), syntax.FakeSelect);
                    Console.WriteLine(sql);
                    Assert.AreEqual(target, database.ExecuteScalar(sql).To<T>());
                });
        }
    }
}
