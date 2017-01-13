// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fireasy.Common.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Fireasy.Common.Serialization.Test
{
	[TestClass()]
	public class BinaryCompressSerializerTests
	{
		[TestMethod()]
		public void SerializeTest()
		{
			var serializer = new BinaryCompressSerializer();

			var obj = new BinaryCryptoData
				{
					Age = 12,
					Name = "huangxd",
					Birthday = DateTime.Parse("1982-9-20")
				};

			var bytes = serializer.Serialize(obj);

			Assert.IsNotNull(bytes);
		}

		[TestMethod()]
		public void DeserializeTest()
		{
			var serializer = new BinaryCompressSerializer();

			#region
			var bytes = new byte[] {
				101,
				144,
				203,
				74,
				3,
				65,
				16,
				69,
				59,
				137,
				49,
				1,
				31,
				43,
				93,
				184,
				155,
				189,
				67,
				99,
				92,
				207,
				136,
				78,
				66,
				22,
				10,
				33,
				144,
				224,
				54,
				148,
				51,
				197,
				164,
				152,
				126,
				132,
				126,
				128,
				237,
				194,
				181,
				63,
				227,
				79,
				228,
				199,
				180,
				91,
				116,
				161,
				222,
				130,
				170,
				197,
				189,
				156,
				11,
				197,
				122,
				140,
				177,
				143,
				168,
				116,
				147,
				142,
				251,
				113,
				221,
				207,
				201,
				32,
				216,
				192,
				167,
				90,
				74,
				173,
				214,
				104,
				157,
				205,
				179,
				71,
				52,
				150,
				180,
				42,
				39,
				252,
				42,
				77,
				158,
				77,
				189,
				112,
				222,
				96,
				169,
				208,
				59,
				3,
				34,
				207,
				150,
				254,
				73,
				80,
				253,
				128,
				97,
				173,
				59,
				84,
				165,
				242,
				66,
				12,
				19,
				120,
				249,
				155,
				199,
				87,
				104,
				8,
				4,
				189,
				128,
				139,
				60,
				158,
				240,
				188,
				34,
				5,
				38,
				68,
				127,
				103,
				208,
				218,
				159,
				0,
				154,
				175,
				238,
				203,
				111,
				215,
				132,
				157,
				211,
				51,
				112,
				48,
				136,
				208,
				243,
				98,
				1,
				18,
				111,
				186,
				205,
				166,
				130,
				186,
				35,
				213,
				206,
				9,
				69,
				115,
				81,
				84,
				100,
				220,
				182,
				129,
				240,
				215,
				57,
				43,
				238,
				218,
				127,
				241,
				30,
				27,
				156,
				156,
				174,
				130,
				117,
				40,
				249,
				12,
				107,
				146,
				32,
				210,
				3,
				14,
				83,
				193,
				104,
				235,
				65,
				181,
				207,
				13,
				187,
				125,
				125,
				59,
				216,
				191,
				143,
				199,
				195,
				254,
				228,
				250,
				232,
				19 };
			#endregion

			var obj = serializer.Deserialize<BinaryCryptoData>(bytes);

			Assert.IsNotNull(obj);
		}

		/// <summary>
		/// 测试数据的结构。
		/// </summary>
		[Serializable]
		private class BinaryCryptoData
		{
			public string Name { get; set; }

			public DateTime Birthday { get; set; }

			public decimal? Age { get; set; }
		}
	}
}
