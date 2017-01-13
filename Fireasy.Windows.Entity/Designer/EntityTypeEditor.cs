// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Fireasy.Windows.Designer
{
    public class EntityTypeEditor : UITypeEditor
    {
        EntityTypeListBox modelUI;

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

                modelUI = new EntityTypeListBox(support);
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

        private class EntityTypeListBox : ListView
        {
            private ITypeEditSupport support;
            private IWindowsFormsEditorService edSvc;

            public EntityTypeListBox(ITypeEditSupport support)
            {
                View = System.Windows.Forms.View.Details;
                Columns.Add(new ColumnHeader { Text = "", Width = 160 });
                HeaderStyle = ColumnHeaderStyle.None;
                FullRowSelect = true;
                HideSelection = false;
                Height = 400;

                Click += EntityTypeListBox_Click;
                this.support = support;
                LoadTypes();
            }

            void EntityTypeListBox_Click(object sender, EventArgs e)
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

                EntityAssemblyHelper.CheckAssembly(support, assembly =>
                    {
                        foreach (var type in EntityAssemblyHelper.GetEntityTypes(assembly))
                        {
                            var item = new ListViewItem(type.Name);
                            item.Tag = type;
                            Items.Add(item);
                        }
                    });
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
