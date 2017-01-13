// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
namespace Fireasy.Web.UI
{
    public class RadioGroupSettings : SettingsBase
    {
        public object Value { get; set; }

        public int? ItemWidth { get; set; }

        public Dictionary<string, string> Items { get; set; }
    }
}
