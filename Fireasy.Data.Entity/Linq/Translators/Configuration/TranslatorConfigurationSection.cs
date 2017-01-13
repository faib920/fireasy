// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Xml;
using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;

namespace Fireasy.Data.Entity.Linq.Translators.Configuration
{
    [ConfigurationSectionStorage("fireasy/dataTranslator")]
    public class TranslatorConfigurationSection : ConfigurationSection
    {
        public override void Initialize(XmlNode section)
        {
            var ndOption = section.SelectSingleNode("options");
            if (ndOption != null)
            {
                Options = new TranslateOptions
                    {
                        HideTableAliases = ndOption.GetAttributeValue("hideTableAliases", false),
                        HideColumnAliases = ndOption.GetAttributeValue("hideColumnAliases", false),
                        UseCache = ndOption.GetAttributeValue("useCache", true)
                    };
            }
        }

        public TranslateOptions Options { get; set; }
    }
}
