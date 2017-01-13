using Fireasy.Common.Configuration;
using System;

namespace Fireasy.Web.Configuration
{
    public class HttpModuleConfigurationSetting : IConfigurationSettingItem
    {
        public string Name { get; set; }

        public Type Type { get; set; }
    }
}
