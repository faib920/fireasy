using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Fireasy.Common.Extensions.Test
{
    [TestClass()]
    public class MathExtensionTests
    {
        [TestMethod()]
        public void RoundTest()
        {
            Assert.AreEqual(855.58, (855.575).Round());
            Assert.AreEqual(855.57, (855.574).Round());
        }

        [TestMethod()]
        public void RoundOneTowTest()
        {
            Assert.AreEqual(855.58, (855.572).Round(2, RoundType.OneTow));
            Assert.AreEqual(855.57, (855.571).Round(2, RoundType.OneTow));
        }

        [TestMethod()]
        public void RoundTowThreeTest()
        {
            Assert.AreEqual(855.58, (855.573).Round(2, RoundType.TowThree));
            Assert.AreEqual(855.57, (855.572).Round(2, RoundType.TowThree));
        }

        [TestMethod()]
        public void RoundThreeFourTest()
        {
            Assert.AreEqual(855.58, (855.574).Round(2, RoundType.ThreeFour));
            Assert.AreEqual(855.57, (855.573).Round(2, RoundType.ThreeFour));
        }

        [TestMethod()]
        public void RoundFiveSixTest()
        {
            Assert.AreEqual(855.58, (855.576).Round(2, RoundType.FiveSix));
            Assert.AreEqual(855.57, (855.575).Round(2, RoundType.FiveSix));
        }

        [TestMethod()]
        public void RoundSixSevenTest()
        {
            Assert.AreEqual(855.58, (855.577).Round(2, RoundType.SixSeven));
            Assert.AreEqual(855.57, (855.576).Round(2, RoundType.SixSeven));
        }

        [TestMethod()]
        public void RoundSevenEightTest()
        {
            Assert.AreEqual(855.58, (855.578).Round(2, RoundType.SevenEight));
            Assert.AreEqual(855.57, (855.577).Round(2, RoundType.SevenEight));
        }

        [TestMethod()]
        public void RoundEightNineTest()
        {
            Assert.AreEqual(855.58, (855.579).Round(2, RoundType.EightNine));
            Assert.AreEqual(855.57, (855.578).Round(2, RoundType.EightNine));
        }

        [TestMethod()]
        public void VarianceTest()
        {
            var data = new int[] { 4, 5, 6, 7, 9 };

            //(4 - 6.2)^2 + (5 - 6.2)^2 + (6 - 6.2)^2 + (7 - 6.2)^2 + (9 - 6.2)^2
            //4.84 + 1.44 + 0.04 + 0.64 + 3.84 = 14.8
            Assert.AreEqual(data.Variance().Round(3), 3.847);
        }

        [TestMethod()]
        public void MedianEvenTest()
        {
            var data = new int[] { 9, 7, 4, 5, 6, 13 };

            Assert.AreEqual(6.5, data.Median());
        }

        [TestMethod()]
        public void MedianOddTest()
        {
            var data = new int[] { 9, 7, 4, 5, 6, 13, 22 };

            Assert.AreEqual(7, data.Median());
        }
    }
}
