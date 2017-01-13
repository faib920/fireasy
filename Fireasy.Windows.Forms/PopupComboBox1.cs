using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fireasy.Windows.Forms
{
    public class PopupComboBox1 : ComboBox
    {
        private const int WM_USER = 0x0400,
                                  WM_REFLECT = WM_USER + 0x1C00,
                                  WM_COMMAND = 0x0111,
                                  CBN_DROPDOWN = 7;

        internal Popup1 pop;
        private Size m_maxsize = new Size(600, 600);
        private bool first = true;

        public PopupComboBox1()
            : base ()
        {
            IntegralHeight = false;
        }

        public void SetControl(Control ctl)
        {
            pop = new Popup1(ctl);
            pop.MinimumSize = new Size(50, 50);
            pop.MaximumSize = m_maxsize;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        internal new System.Windows.Forms.ComboBox.ObjectCollection Items
        {
            get { return base.Items; }
        }

        public virtual void SetText(string text)
        {
            if (DropDownStyle != ComboBoxStyle.DropDownList)
            {
                Text = text;
            }
            else
            {
                if (Items.Count == 0)
                {
                    Items.Add(text);
                }
                else
                {
                    Items[0] = text;
                }
                Text = text;
            }
        }

        public void ShowDropDown()
        {
            if (pop != null)
            {
                if (first)
                {
                    pop.Width = DropDownWidth;
                    pop.Height = DropDownHeight;
                    first = false;
                }
                pop.Show(this);
            }
        }

        public void HideDropDown()
        {
            pop.Hide();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD(m.WParam) == CBN_DROPDOWN)
                {
                    BeginInvoke(new MethodInvoker(ShowDropDown));
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        private int HIWORD(IntPtr n)
        {
            return HIWORD(unchecked((int)(long)n));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                ShowDropDown();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (pop != null)
                {
                    pop.Dispose();
                    pop = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
