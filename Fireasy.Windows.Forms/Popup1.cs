using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Fireasy.Windows.Forms
{
    internal class Popup1 : ToolStripDropDown
    {
        #region API
        private const int WM_NCHITTEST = 0x0084,
                           WM_NCACTIVATE = 0x0086,
                           WS_EX_NOACTIVATE = 0x08000000,
                           HTTRANSPARENT = -1,
                           HTLEFT = 10,
                           HTRIGHT = 11,
                           HTTOP = 12,
                           HTTOPLEFT = 13,
                           HTTOPRIGHT = 14,
                           HTBOTTOM = 15,
                           HTBOTTOMLEFT = 16,
                           HTBOTTOMRIGHT = 17,
                           WM_USER = 0x0400,
                           WM_REFLECT = WM_USER + 0x1C00,
                           WM_COMMAND = 0x0111,
                           CBN_DROPDOWN = 7,
                           WM_GETMINMAXINFO = 0x0024;

        [StructLayout(LayoutKind.Sequential)]
        private struct MINMAXINFO
        {
            public Point reserved;
            public Size maxSize;
            public Point maxPosition;
            public Size minTrackSize;
            public Size maxTrackSize;
        }
        #endregion

        #region " Fields & Properties "

        private Control content;
        /// <summary>
        /// Gets the content of the pop-up.
        /// 將彈出的控件
        /// </summary>
        public Control Content
        {
            get { return content; }
        }

        private bool fade;
        /// <summary>
        /// Gets a value indicating whether the <see cref="PopupControl.Popup"/> uses the fade effect.
        /// 是否使用漸顯效果
        /// </summary>
        /// <value><c>true</c> if pop-up uses the fade effect; otherwise, <c>false</c>.</value>
        /// <remarks>To use the fade effect, the FocusOnOpen property also has to be set to <c>true</c>.</remarks>
        public bool UseFadeEffect
        {
            get { return fade; }
            set
            {
                if (fade == value) return;
                fade = value;
            }
        }

        private bool focusOnOpen = true;
        /// <summary>
        /// Gets or sets a value indicating whether to focus the content after the pop-up has been opened.
        /// 彈窗後是否將焦點放在彈出控件上
        /// </summary>
        /// <value><c>true</c> if the content should be focused after the pop-up has been opened; otherwise, <c>false</c>.</value>
        /// <remarks>If the FocusOnOpen property is set to <c>false</c>, then pop-up cannot use the fade effect.</remarks>
        public bool FocusOnOpen
        {
            get { return focusOnOpen; }
            set { focusOnOpen = value; }
        }

        private bool acceptAlt = true;
        /// <summary>
        /// Gets or sets a value indicating whether presing the alt key should close the pop-up.
        /// 按下Alt鍵時是否仍顯示彈窗
        /// </summary>
        /// <value><c>true</c> if presing the alt key does not close the pop-up; otherwise, <c>false</c>.</value>
        public bool AcceptAlt
        {
            get { return acceptAlt; }
            set { acceptAlt = value; }
        }


        private bool resizable;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PopupControl.Popup" /> is resizable.
        /// 彈出控件是否可以調整尺寸
        /// </summary>
        /// <value><c>true</c> if resizable; otherwise, <c>false</c>.</value>
        public bool Resizable
        {
            get { return resizable; }
            set { resizable = value; }
        }

        private Size minSize;
        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// 最小尺寸 
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public new Size MinimumSize
        {
            get { return minSize; }
            set { minSize = value; }
        }

        private Size maxSize;
        /// <summary>
        /// Gets or sets the size that is the upper limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        ///最大尺寸 
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public new Size MaximumSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        #endregion

        #region " Constructors "

        private ToolStripControlHost host;

        /// <summary>
        /// Initializes a new instance of the <see cref="PopupControl.Popup"/> class.
        /// </summary>
        /// <param name="content">The content of the pop-up.</param>
        /// <remarks>
        /// Pop-up will be disposed immediately after disposion of the content control.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="content" /> is <code>null</code>.</exception>
        public Popup1(Control content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            this.content = content;
            this.fade = true;
            AutoSize = false;
            Resizable = true;
            //DropShadowEnabled = false;
            host = new ToolStripControlHost(content);
            MinimumSize = content.MinimumSize;
            content.MinimumSize = content.Size;
            MaximumSize = content.MaximumSize;
            content.MaximumSize = content.Size;
            Size = content.Size;
            Items.Add(host);
            content.Disposed += delegate(object sender, EventArgs e)
            {
                content = null;
                Dispose(true);
            };
            content.RegionChanged += delegate(object sender, EventArgs e)
            {
                UpdateRegion();
            };
            content.Paint += delegate(object sender, PaintEventArgs e)
            {
                PaintSizeGrip(e);
            };
            UpdateRegion();
        }

        #endregion

        #region " Methods "

        /// <summary>
        /// Processes a dialog box key.
        /// 處理對話框按鍵
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the key was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (acceptAlt && ((keyData & Keys.Alt) == Keys.Alt)) return false;
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// Updates the pop-up region.
        /// </summary>
        protected void UpdateRegion()
        {
            if (this.Region != null)
            {
                this.Region.Dispose();
                this.Region = null;
            }
            if (content.Region != null)
            {
                this.Region = content.Region.Clone();
            }
        }

        /// <summary>
        /// Shows pop-up window below the specified control.
        /// 在控件control下方(或上方)彈出本控件
        /// </summary>
        /// <param name="control">The control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below the specified control, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            Show(control, control.ClientRectangle);
        }

        private bool resizableTop;
        private bool resizableRight;

        /// <summary>
        /// Shows pop-up window below the specified area of specified control.
        /// 在指定控件右下方的指定區域顯示
        /// </summary>
        /// <param name="control">The control used to compute screen location of specified area.</param>
        /// <param name="area">The area of control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below specified area, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            resizableTop = resizableRight = false;
            //將彈窗定位到控件左下角坐標
            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            //取得表單的顯示區域
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            //如果右邊出界,則左移出界的寬度
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                resizableRight = true;
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            //如果下邊出界,則顯示在控件右上方
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                resizableTop = true;
                location.Y -= Size.Height + area.Height;
            }
            //將彈窗重新定位.
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        private const int frames = 5;//幀數
        private const int totalduration = 800;//完整顯示所需時間
        private const int frameduration = totalduration / frames;//間隔時間
        /// <summary>
        /// Adjusts the size of the owner <see cref="T:System.Windows.Forms.ToolStrip" /> to accommodate the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> if the owner <see cref="T:System.Windows.Forms.ToolStrip" /> is currently displayed, or clears and resets active <see cref="T:System.Windows.Forms.ToolStripDropDown" /> child controls of the <see cref="T:System.Windows.Forms.ToolStrip" /> if the <see cref="T:System.Windows.Forms.ToolStrip" /> is not currently displayed.
        /// 調整透明度
        /// </summary>
        /// <param name="visible">true if the owner <see cref="T:System.Windows.Forms.ToolStrip" /> is currently displayed; otherwise, false.</param>
        protected override void SetVisibleCore(bool visible)
        {
            double opacity = Opacity;
            if (visible && fade && focusOnOpen) Opacity = 0;
            base.SetVisibleCore(visible);
            if (!visible || !fade || !focusOnOpen) return;
            for (int i = 1; i <= frames; i++)
            {
                if (i > 1)
                {
                    System.Threading.Thread.Sleep(frameduration);//漸顯
                }
                Opacity = opacity * (double)i / (double)frames;
            }
            Opacity = opacity;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// 尺寸更改事件
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            Size size = new Size(Size.Width - 2, Size.Height - 4);
            content.MinimumSize = size;
            content.MaximumSize = size;
            content.Size = size;
            base.OnSizeChanged(e);
        }

        #endregion

        #region " Resizing Support "調整大小

        /// <summary>
        /// Processes Windows messages.
        /// 處理Windows消息
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            //以彈窗為顯示區域...
            if (InternalProcessResizing(ref m, false))
            {
                return;
            }
            base.WndProc(ref m);
        }

        protected override void OnOpened(EventArgs e)
        {
            if (focusOnOpen)
            {
                content.Focus();
            }
            base.OnOpened(e);
        }

        /// <summary>
        /// Processes the resizing messages.
        /// 處理調整大小消息
        /// </summary>
        /// <param name="m">The message.</param>
        /// <returns>true, if the WndProc method from the base class shouldn't be invoked.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool ProcessResizing(ref Message m)
        {
            //以控件為顯示區域...
            return InternalProcessResizing(ref m, true);
        }

        //控件內部調整大小
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool InternalProcessResizing(ref Message m, bool contentControl)
        {
            if (!Resizable)
            {
                return false;
            }
            if (m.Msg == WM_NCHITTEST)
            {
                return OnNcHitTest(ref m, contentControl);
            }
            else if (m.Msg == WM_GETMINMAXINFO)
            {
                return OnGetMinMaxInfo(ref m);
            }
            return false;
        }

        //取得窗口的最大及最小尺寸
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool OnGetMinMaxInfo(ref Message m)
        {
            MINMAXINFO minmax = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
            minmax.maxTrackSize = this.MaximumSize;
            minmax.minTrackSize = this.MinimumSize;
            Marshal.StructureToPtr(minmax, m.LParam, false);
            return true;
        }

        //測試窗體,並取得窗體顯示方位
        private bool OnNcHitTest(ref Message m, bool contentControl)
        {
            int x = LOWORD(m.LParam);
            int y = HIWORD(m.LParam);
            Point clientLocation = PointToClient(new Point(x, y));

            GripBounds gripBouns = new GripBounds(contentControl ? content.ClientRectangle : ClientRectangle);
            IntPtr transparent = new IntPtr(HTTRANSPARENT);

            if (resizableTop)
            {
                if (resizableRight && gripBouns.TopLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)HTTOPLEFT;
                    return true;
                }
                if (!resizableRight && gripBouns.TopRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)HTTOPRIGHT;
                    return true;
                }
                if (gripBouns.Top.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)HTTOP;
                    return true;
                }
            }
            else
            {
                if (resizableRight && gripBouns.BottomLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)HTBOTTOMLEFT;
                    return true;
                }
                if (!resizableRight && gripBouns.BottomRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)HTBOTTOMRIGHT;
                    return true;
                }
                if (gripBouns.Bottom.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)HTBOTTOM;
                    return true;
                }
            }
            if (resizableRight && gripBouns.Left.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)HTLEFT;
                return true;
            }
            if (!resizableRight && gripBouns.Right.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)HTRIGHT;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Paints the size grip.
        /// 繪製調整框
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        public void PaintSizeGrip(PaintEventArgs e)
        {
            if (e == null || e.Graphics == null || !resizable)
            {
                return;
            }
            Size clientSize = content.ClientSize;
            if (Application.RenderWithVisualStyles)
            {
                //if (this.sizeGripRenderer == null)
                //{
                //this.sizeGripRenderer = new VS.VisualStyleRenderer(VS.VisualStyleElement.Status.Gripper.Normal);
                //}
                //this.sizeGripRenderer.DrawBackground(e.Graphics, new Rectangle(clientSize.Width - 0x10, clientSize.Height - 0x10, 0x10, 0x10));
            }
            else
            {
                ControlPaint.DrawSizeGrip(e.Graphics, content.BackColor, clientSize.Width - 0x10, clientSize.Height - 0x10, 0x10, 0x10);
            }
        }


        private int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        private int HIWORD(IntPtr n)
        {
            return HIWORD(unchecked((int)(long)n));
        }

        private int LOWORD(int n)
        {
            return n & 0xffff;
        }

        private int LOWORD(IntPtr n)
        {
            return LOWORD(unchecked((int)(long)n));
        }
        #endregion
    }
}
