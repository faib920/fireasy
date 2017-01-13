// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Data.Entity;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Fireasy.Windows.Designer
{
    /// <summary>
    /// 实体属性选择编辑器。
    /// </summary>
    public class EntityPropertyEditor : UITypeEditor
    {
        private EntityPropertyListBox modelUI;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                var control = (Control)context.Instance;
                var form = control.FindForm() as ITypeEditSupport;
                if (edSvc == null || form == null || form.EditType == null)
                {
                    return value;
                }

                if (form.EditType == null)
                {
                    return value;
                }

                modelUI = new EntityPropertyListBox(form.EditType);
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

        private class EntityPropertyListBox : ListView
        {
            private IWindowsFormsEditorService edSvc;
            private Type entityType;

            public EntityPropertyListBox(Type entityType)
            {
                View = System.Windows.Forms.View.Details;
                Columns.Add(new ColumnHeader { Text = "", Width = 160 });
                HeaderStyle = ColumnHeaderStyle.None;
                FullRowSelect = true;
                HideSelection = false;
                Height = 400;

                Click += EntityTypeListBox_Click;
                this.entityType = entityType;
                LoadProperties();
            }

            void EntityTypeListBox_Click(object sender, EventArgs e)
            {
                Value = base.SelectedItems[0].Text;
                edSvc.CloseDropDown();
            }

            /// <summary>
            /// 加载实体类型中的所有属性。
            /// </summary>
            private void LoadProperties()
            {
                foreach (var property in PropertyUnity.GetPersistentProperties(entityType))
                {
                    var item = new ListViewItem(property.Name);
                    Items.Add(item);
                }
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

                foreach (ListViewItem item in base.Items)
                {
                    if (item.Text.Equals(value))
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
