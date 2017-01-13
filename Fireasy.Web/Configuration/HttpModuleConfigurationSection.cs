using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;
using System.Xml;

namespace Fireasy.Web.Configuration
{
    [ConfigurationSectionStorage("thinker/web/httpModules")]
    public class HttpModuleConfigurationSection : ConfigurationSection<HttpModuleConfigurationSetting>
    {
        public override void Initialize(XmlNode section)
        {
            base.InitializeNode(section, "add", null, node =>
                {
                    var setting = new HttpModuleConfigurationSetting();
                    setting.Name = node.GetAttributeValue("name");
                    setting.Type = node.GetAttributeValue("type").ParseType();
                    return setting;
                });
        }
    }
}
