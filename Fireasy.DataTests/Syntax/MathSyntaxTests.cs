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
    public class MathSyntaxTests : SyntaxTestBase
    {
        [TestMethod()]
        public void AndTest()
        {
            AreEqual(32, syntax => syntax.Math.And(34, 44));
        }
                [TestMethod()]
        public void OrTest()
        {
            AreEqual(46, syntax => syntax.Math.Or(34, 44));
        }

        [TestMethod()]
        public void ModuloTest()
        {
            AreEqual(1, syntax => syntax.Math.Modulo(34, 3));
        }

        [TestMethod()]
        public void ExclusiveOrTest()
        {
            AreEqual(14, syntax => syntax.Math.ExclusiveOr(34, 44));
        }

        [TestMethod()]
        public void CeilingTest()
        {
            AreEqual(35, syntax => syntax.Math.Ceiling(34.64));
        }

        [TestMethod()]
        public void RoundTest()
        {
            AreEqual(35, syntax => syntax.Math.Round(34.64));
        }

        [TestMethod()]
        public void Round1Test()
        {
            AreEqual(34.6, syntax => syntax.Math.Round(34.65, 1));
        }

        [TestMethod()]
        public void TruncateTest()
        {
            AreEqual(35, syntax => syntax.Math.Truncate(34.65));
        }

        [TestMethod()]
        public void FloorTest()
        {
            AreEqual(35, syntax => syntax.Math.Truncate(34.65));
        }

        [TestMethod()]
        public void LogTest()
        {
            AreEqual(0.6931, syntax => syntax.Math.Round(syntax.Math.Log(2), 4));
        }

        [TestMethod()]
        public void Log10Test()
        {
            AreEqual(0.301, syntax => syntax.Math.Round(syntax.Math.Log10(2), 4));
        }

        [TestMethod()]
        public void ExpTest()
        {
            AreEqual(2.7183, syntax => syntax.Math.Round(syntax.Math.Exp(1), 4));
        }

        [TestMethod()]
        public void AbsTest()
        {
            AreEqual(34.65, syntax => syntax.Math.Abs(-34.65));
        }

        [TestMethod()]
        public void NegateTest()
        {
            AreEqual(-4, syntax => syntax.Math.Negate(3));
        }

        [TestMethod()]
        public void PowerTest()
        {
            AreEqual(8, syntax => syntax.Math.Power(2, 3));
        }

        [TestMethod()]
        public void SqrtTest()
        {
            AreEqual(2, syntax => syntax.Math.Sqrt(4));
        }

        [TestMethod()]
        public void SinTest()
        {
            AreEqual(0.894, syntax => syntax.Math.Round(syntax.Math.Sin(90), 4));
        }

        [TestMethod()]
        public void CosTest()
        {
            AreEqual(0.1543, syntax => syntax.Math.Round(syntax.Math.Cos(30), 4));
        }

        [TestMethod()]
        public void TanTest()
        {
            AreEqual(-1.9952, syntax => syntax.Math.Round(syntax.Math.Tan(90), 4));
        }

        [TestMethod()]
        public void AsinTest()
        {
            AreEqual(0.7208, syntax => syntax.Math.Round(syntax.Math.Asin(0.66), 4));
        }

        [TestMethod()]
        public void AcosTest()
        {
            AreEqual(0.85, syntax => syntax.Math.Round(syntax.Math.Acos(0.66), 4));
        }

        [TestMethod()]
        public void AtanTest()
        {
            AreEqual(0.5834, syntax => syntax.Math.Round(syntax.Math.Atan(0.66), 4));
        }

        [TestMethod()]
        public void SignTest()
        {
            AreEqual(-1, syntax => syntax.Math.Sign(-90));
        }

        [TestMethod()]
        public void LeftShiftTest()
        {
            AreEqual(9288, syntax => syntax.Math.LeftShift(2322, 2));
        }

        [TestMethod()]
        public void RightShiftTest()
        {
            AreEqual(580.5, syntax => syntax.Math.RightShift(2322, 2));
        }
    }
}
