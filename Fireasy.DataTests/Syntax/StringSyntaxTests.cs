// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Data.Syntax.Test
{
    [TestClass()]
    public class StringSyntaxTests : SyntaxTestBase
    {
        [TestMethod()]
        public void SubstringTest()
        {
            AreEqual("bcdefg", syntax => syntax.String.Substring("'abcdefg'", 2));
        }

        [TestMethod()]
        public void SubstringWithLengthTest()
        {
            AreEqual("bc", syntax => syntax.String.Substring("'abcdefg'", 2, 2));
        }

        [TestMethod()]
        public void LengthTest()
        {
            AreEqual(7, syntax => syntax.String.Length("'abcdefg'"));
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            AreEqual(4, syntax => syntax.String.IndexOf("'abcdefg'", "'d'"));
        }

        [TestMethod()]
        public void IndexOfWithStartIndexTest()
        {
            AreEqual(4, syntax => syntax.String.IndexOf("'defdcabc'", "'d'", 4));
        }

        [TestMethod()]
        public void ToLowerTest()
        {
            AreEqual("abcd", syntax => syntax.String.ToLower("'AbCd'"));
        }

        [TestMethod()]
        public void ToUpperTest()
        {
            AreEqual("ABCD", syntax => syntax.String.ToUpper("'AbCd'"));
        }

        [TestMethod()]
        public void TrimStartTest()
        {
            AreEqual("abcd ", syntax => syntax.String.TrimStart("' abcd '"));
        }

        [TestMethod()]
        public void TrimEndTest()
        {
            AreEqual(" abcd", syntax => syntax.String.TrimEnd("' abcd '"));
        }

        [TestMethod()]
        public void TrimTest()
        {
            AreEqual("abcd", syntax => syntax.String.Trim("' abcd '"));
        }

        [TestMethod()]
        public void ReplaceTest()
        {
            AreEqual("fbcd", syntax => syntax.String.Replace("'abcd'", "'a'", "'f'"));
        }

        [TestMethod()]
        public void ConcatTest()
        {
            AreEqual("abcdef", syntax => syntax.String.Concat("'ab'", "'cd'", "'ef'"));
        }

        [TestMethod()]
        public void ReverseTest()
        {
            AreEqual("dcba", syntax => syntax.String.Reverse("'abcd'"));
        }
    }
}
