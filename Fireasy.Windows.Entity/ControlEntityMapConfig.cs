// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fireasy.Windows.Entity
{
    public static class ControlEntityMapConfig
    {
        private static Dictionary<Type, IControlEntityMapper> mappers = new Dictionary<Type, IControlEntityMapper>();

        static ControlEntityMapConfig()
        {
            mappers.Add(typeof(TextBox), new TextBoxMapper());
            mappers.Add(typeof(DateTimePicker), new DateTimePickerMapper());
            //mappers.Add(typeof(ComplexComboBox), new ComplexComboBoxMapper());
            mappers.Add(typeof(ComboBox), new ComboBoxMapper());
            mappers.Add(typeof(CheckBox), new CheckBoxMapper());
        }

        public static void AddOrReplace(Type controlType, IControlEntityMapper mapper)
        {
            mappers.AddOrReplace(controlType, mapper);
        }

        public static IControlEntityMapper Get(Type controlType)
        {
            foreach (var k in mappers)
            {
                if (k.Key.IsAssignableFrom(controlType))
                {
                    return k.Value;
                }
            }

            return null;
        }
    }
}
