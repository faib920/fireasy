// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Fireasy.Windows.Designer
{
    public class EnumTypeEditor : UITypeEditor
    {
        EnumTypeListBox modelUI;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                var support = (ITypeEditSupport)context.Instance;
                if (edSvc == null)
                {
                    return value;
                }

                modelUI = new EnumTypeListBox(support);
                modelUI.Start(edSvc, value);

                edSvc.DropDownControl(modelUI);
                value = modelUI.Value;
                modelUI.End();
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }

        private class EnumTypeListBox : ListView
        {
            private ITypeEditSupport support;
            private IWindowsFormsEditorService edSvc;

            public EnumTypeListBox(ITypeEditSupport support)
            {
                View = System.Windows.Forms.View.Details;
                Columns.Add(new ColumnHeader { Text = "", Width = 160 });
                HeaderStyle = ColumnHeaderStyle.None;
                FullRowSelect = true;
                HideSelection = false;
                Height = 400;

                Click += EnumTypeListBox_Click;
                this.support = support;
                LoadTypes();
            }

            void EnumTypeListBox_Click(object sender, EventArgs e)
            {
                Value = base.SelectedItems[0].Tag;
                edSvc.CloseDropDown();
            }

            /// <summary>
            /// 加载所有可选择的类型。
            /// </summary>
            private void LoadTypes()
            {
                //循环所引用的所有程序集
                foreach (var assemblyName in support.GetType().Assembly.GetReferencedAssemblies())
                {
                    try
                    {
                        var assembly = Assembly.Load(assemblyName.FullName);
                        if (!IsFireasyEntityAssembly(assembly))
                        {
                            continue;
                        }

                        foreach (var type in GetEnumTypes(assembly))
                        {
                            var item = new ListViewItem(type.Name);
                            item.Tag = type;
                            Items.Add(item);
                        }
                    }
                    catch
                    {
                    }
                }
            }

            /// <summary>
            /// 判断程序集是否是 Fireasy Entity 实体程序集。
            /// </summary>
            /// <param name="assembly"></param>
            /// <returns></returns>
            private bool IsFireasyEntityAssembly(Assembly assembly)
            {
                return assembly.IsDefined<EntityDiscoverAssemblyAttribute>();
            }

            /// <summary>
            /// 获取指定程序集中的枚举类集合。
            /// </summary>
            /// <param name="assembly"></param>
            /// <returns></returns>
            private IEnumerable<Type> GetEnumTypes(Assembly assembly)
            {
                return assembly.GetExportedTypes().Where(s => s.IsEnum && s.IsPublic);
            }

            public void Start(IWindowsFormsEditorService edSvc, object value)
            {
                SelectedItems.Clear();
                this.edSvc = edSvc;
                Value = value;

                if (value == null)
                {
                    return;
                }

                //循环所有项，选中
                foreach (ListViewItem item in base.Items)
                {
                    if (item.Tag != null && item.Tag.Equals(value))
                    {
                        item.Focused = true;
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
            }

            public void End()
            {
                edSvc = null;
            }

            public object Value { get; set; }
        }
    }
}
