// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Windows.Designer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Fireasy.Windows.Entity
{
    /// <summary>
    /// 扩展输入控件，使它们绑定到实体类中的某一个属性，以便能够自动化处理数据显示和数据保存。
    /// </summary>
    [ProvideProperty("PropertyName", typeof(Control))]
    [ProvideProperty("CanClear", typeof(Control))]
    [ProvideProperty("Format", typeof(Control))]
    public class EntityPropertyExtend : Component, IExtenderProvider
    {
        //控件与属性名称的键值对
        private Dictionary<Control, string> properties;
        private Dictionary<Control, bool> clearsets;
        private Dictionary<Control, string> formatters;

        public EntityPropertyExtend()
        {
            properties = new Dictionary<Control, string>();
            clearsets = new Dictionary<Control, bool>();
            formatters = new Dictionary<Control, string>();
        }

        public EntityPropertyExtend(IContainer container)
            : this()
        {
            container.Add(this);
        }

        /// <summary>
        /// 获取控件与属性名称的键值对。
        /// </summary>
        /// <returns></returns>
        public Dictionary<Control, string> GetProperties()
        {
            return properties;
        }

        /// <summary>
        /// 判断哪些控件能够被扩展。
        /// </summary>
        /// <param name="extendee"></param>
        /// <returns></returns>
        public bool CanExtend(object extendee)
        {
            return extendee is Control;
        }

        /// <summary>
        /// 获取控件所对应的属性的名称。此属性能够使用编辑器选择。
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        [Editor(typeof(EntityPropertyEditor), typeof(UITypeEditor))]
        public string GetPropertyName(Control control)
        {
            if (properties.ContainsKey(control))
            {
                return properties[control];
            }

            return string.Empty;
        }

        /// <summary>
        /// 设置控件所对应的属性名称。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyName"></param>
        public void SetPropertyName(Control control, string propertyName)
        {
            if (properties.ContainsKey(control))
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    properties.Remove(control);
                }
                else
                {
                    properties[control] = propertyName;
                }
            }
            else if (!string.IsNullOrEmpty(propertyName))
            {
                properties.Add(control, propertyName);
            }
        }

        /// <summary>
        /// 获取控件控件的值能否被清空。
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        [DefaultValue(true)]
        public bool GetCanClear(Control control)
        {
            if (clearsets.ContainsKey(control))
            {
                return clearsets[control];
            }

            return true;
        }

        /// <summary>
        /// 设置控件的值能否被清空。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="can"></param>
        public void SetCanClear(Control control, bool can)
        {
            if (clearsets.ContainsKey(control))
            {
                clearsets[control] = can;
            }
            else
            {
                clearsets.Add(control, can);
            }
        }

        /// <summary>
        /// 设置控件的输出格式。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="can"></param>
        public void SetFormat(Control control, string format)
        {
            if (clearsets.ContainsKey(control))
            {
                formatters[control] = format;
            }
            else
            {
                formatters.Add(control, format);
            }
        }

        /// <summary>
        /// 获取控件控件的输出格式。
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        [DefaultValue((string)null)]
        public string GetFormat(Control control)
        {
            if (formatters.ContainsKey(control))
            {
                return formatters[control];
            }

            return string.Empty;
        }
    }
}
