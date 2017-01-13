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
using System.Drawing;
using System.Windows.Forms;

namespace Fireasy.Windows.Entity
{
    /// <summary>
    /// 提供控件与实体属性之间的数据交换方法。
    /// </summary>
    public interface IControlEntityMapper
    {
        /// <summary>
        /// 从控件中获取值。
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        object GetValue(Control control);

        /// <summary>
        /// 将指定的值填充到控件中。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        void SetValue(Control control, object value);

        /// <summary>
        /// 清除控件的值。
        /// </summary>
        /// <param name="control"></param>
        void Clear(Control control);

        Control SetViewControl(Control control);
    }

    public interface IControlEntityMapper<T>
    {
        object GetValue(T control);

        void SetValue(T control, object value);

        Control SetViewControl(T control);
    }

    public abstract class ControlEntityMapperBase<T> : IControlEntityMapper, IControlEntityMapper<T> where T : Control
    {
        object IControlEntityMapper.GetValue(Control control)
        {
            return GetValue((T)control);
        }

        void IControlEntityMapper.SetValue(Control control, object value)
        {
            SetValue((T)control, value);
        }


        void IControlEntityMapper.Clear(Control control)
        {
            Clear((T)control);
        }

        Control IControlEntityMapper.SetViewControl(Control control)
        {
            return SetViewControl((T)control);
        }

        public abstract object GetValue(T control);

        public abstract void SetValue(T control, object value);

        public abstract void Clear(T control);

        public virtual Control SetViewControl(T control)
        {
            var textBox = new TextBox();
            textBox.Location = control.Location;
            textBox.Size = control.Size;
            textBox.Text = control.Text;
            textBox.ReadOnly = true;
            textBox.BackColor = Color.LightYellow;
            control.Visible = false;

            control.Parent.Controls.Add(textBox);
            return textBox;
        }
    }

    public class TextBoxMapper : ControlEntityMapperBase<TextBox>
    {
        public override object GetValue(TextBox control)
        {
            return control.Text;
        }

        public override void SetValue(TextBox control, object value)
        {
            control.Text = value.ToString();
        }

        public override void Clear(TextBox control)
        {
            control.Text = "";
        }

        public override Control SetViewControl(TextBox control)
        {
            control.ReadOnly = true;
            control.BackColor = Color.LightYellow;
            return control;
        }
    }

    public class DateTimePickerMapper : ControlEntityMapperBase<DateTimePicker>
    {
        public override object GetValue(DateTimePicker control)
        {
            if (control.ShowCheckBox && !control.Checked)
            {
                return null;
            }

            return control.Value;
        }

        public override void SetValue(DateTimePicker control, object value)
        {
            if (value == null && control.ShowCheckBox)
            {
                control.Checked = false;
            }

            control.Value = value.To<DateTime>();
        }

        public override void Clear(DateTimePicker control)
        {
            control.Value = DateTime.Now;
        }
    }

    public class ComboBoxMapper : ControlEntityMapperBase<ComboBox>
    {

        public override object GetValue(ComboBox control)
        {
            return control.SelectedValue;
        }

        public override void SetValue(ComboBox control, object value)
        {
            control.SelectedValue = value;
        }

        public override void Clear(ComboBox control)
        {
            control.SelectedIndex = -1;
        }
    }

    //public class ComplexComboBoxMapper : ControlEntityMapperBase<ComplexComboBox>
    //{

    //    public override object GetValue(ComplexComboBox control)
    //    {
    //        return control.SelectedValue;
    //    }

    //    public override void SetValue(ComplexComboBox control, object value)
    //    {
    //        control.SelectedValue = value;
    //    }

    //    public override void Clear(ComplexComboBox control)
    //    {
    //        control.SelectedValue = null;
    //    }
    //}

    public class CheckBoxMapper : ControlEntityMapperBase<CheckBox>
    {
        public override object GetValue(CheckBox control)
        {
            return control.Checked ? 1 : 0;
        }

        public override void SetValue(CheckBox control, object value)
        {
            control.Checked = value.To<bool>();
        }

        public override void Clear(CheckBox control)
        {
            control.Checked = false;
        }

        public override Control SetViewControl(CheckBox control)
        {
            var label = new Label();
            label.Text = control.Checked ? "是" : "否";
            label.Location = control.Location;
            control.Visible = false;
            control.Parent.Controls.Add(label);
            return label;
        }
    }
}
