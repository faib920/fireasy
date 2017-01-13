// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Fireasy.Common.Configuration;
using Fireasy.Common.Serialization;

namespace Fireasy.Data.Configuration.Tests
{
    [TestClass()]
    public class RegisterInstanceTests
    {
        [TestMethod()]
        public void ReadTest()
        {
            var regKey = Registry.CurrentUser.OpenSubKey("software\\fireasy", true);
            if (regKey == null)
            {
                regKey = Registry.CurrentUser.CreateSubKey("software\\fireasy");
            }

            var stream = new BinaryCompressSerializer();
            var data = new BinaryConnectionStore { ConnectionString = "test", ProviderType = "mysql" };
            regKey.SetValue("test1", stream.Serialize(data));
            regKey.Close();

            var section = ConfigurationUnity.GetSection<InstanceConfigurationSection>();
            Assert.AreEqual("test", section.Settings["reg1"].ConnectionString);
        }
    }
}
