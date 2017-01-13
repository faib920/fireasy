using Fireasy.Data.Entity;
using Fireasy.Data.Entity.Dynamic;
using Fireasy.Windows.Designer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Fireasy.Windows.Entity
{
    public class EditFormBase : Form, ITypeEditSupport, IEntityEditableForm
    {
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveAndNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnPrint;

        protected bool isChanged;
        private bool createContinuous = true;
        private bool showPrintButton = false;
        private bool showHelpButton = true;
        private bool viewMode;
        private EntityFormHelper formHelper; 

        public EditFormBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFormBase));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveAndNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnHelp);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSaveAndNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 88);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(107, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(77, 27);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(24, 38);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(77, 27);
            this.btnHelp.TabIndex = 24;
            this.btnHelp.Text = "帮助(&H)";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Location = new System.Drawing.Point(499, 38);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 27);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveAndNew.Location = new System.Drawing.Point(396, 38);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(97, 27);
            this.btnSaveAndNew.TabIndex = 22;
            this.btnSaveAndNew.Text = "保存并新增(&A)";
            this.btnSaveAndNew.UseVisualStyleBackColor = true;
            this.btnSaveAndNew.Click += new System.EventHandler(this.btnSaveAndNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(313, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 27);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            //this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 431);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// 获取或设置实体类型。
        /// </summary>
        [Editor(typeof(EntityTypeEditor), typeof(UITypeEditor))]
        [Description("获取或设置实体类型。")]
        public Type EntityType { get; set; }

        Type ITypeEditSupport.EditType
        {
            get
            {
                return EntityType;
            }
            set
            {
                EntityType = value;
            }
        }

        /// <summary>
        /// 获取或设置参数的实体对象，用于在新增时填充在窗体上。
        /// </summary>
        [Browsable(false)]
        public IEntity Refer { get; set; }

        [DefaultValue(false)]
        public bool ShowPrintButton
        {
            get { return showPrintButton; }
            set {
                if (showPrintButton != value)
                {
                    showPrintButton = value;
                    btnPrint.Visible = showPrintButton;
                }
            }
        }

        [DefaultValue(true)]
        public bool ShowHelpButton
        {
            get { return showHelpButton; }
            set
            {
                if (showHelpButton != value)
                {
                    showHelpButton = value;
                    btnHelp.Visible = showHelpButton;
                }
            }
        }

        /// <summary>
        /// 返回新添加的实体对象。
        /// </summary>
        [Browsable(false)]
        public IEntity EntityAdded { get; private set; }

        /// <summary>
        /// 获取或设置实体属性扩展控件。
        /// </summary>
        public EntityPropertyExtend EntityPropertyExtend { get; set; }

        /// <summary>
        /// 获取或设置信息ID，根据此ID查询实体并填充在窗体上。
        /// </summary>
        public string InfoId { get; set; }

        /// <summary>
        /// 获取或设置是否连续添加实体。
        /// </summary>
        public bool CreateContinuous
        {
            get { return createContinuous; }
            set
            {
                if (createContinuous != value)
                {
                    createContinuous = value;
                    ShowCreateContinuousButtons(value);
                }
            }
        }

        /// <summary>
        /// 获取或设置保存完成后是否关闭窗体。
        /// </summary>
        public bool CloseWhenSaved { get; set; }

        public bool ViewMode
        {
            get { return viewMode; }
            set
            {
                if (viewMode != value)
                {
                    viewMode = value;
                    SetViewMode(value);
                }
            }
        }

        public string CaptionWhenNew { get; set; }

        public string CaptionWhenModify { get; set; }

        public string CaptionWhenView { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode)
            {
                DrawDesignGrid(e.Graphics);
            }

            base.OnPaint(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            formHelper = new EntityFormHelper(this, errorProvider1);

            if (!DesignMode)
            {
                if (!string.IsNullOrEmpty(InfoId))
                {
                    CloseWhenSaved = true;
                    CreateContinuous = false;
                }

                LoadInfo();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((EntityAdded = SaveData()) != null && CloseWhenSaved)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            if ((EntityAdded = SaveData()) == null)
            {
                return;

            }

            if (CreateContinuous)
            {
                InfoId = string.Empty;
                formHelper.ClearForm();
                BeginNew();
            }
            else if (CloseWhenSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //ShowHelper();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOrder();
        }

        protected virtual void BeginNew()
        {
        }

        /// <summary>
        /// 读取实体信息，显示在窗体上。
        /// </summary>
        protected virtual void LoadInfo()
        {
            formHelper.Load();
        }

        /// <summary>
        /// 保存表单数据到数据库。
        /// </summary>
        /// <param name="createNew">保存后是否新建信息。</param>
        /// <returns></returns>
        protected virtual IEntity SaveData(bool createNew = false)
        {
            return formHelper.Save(PreSaveData, AfterSaveData, DoSaveData);
        }

        protected virtual void DoSaveData(EntityPersister persister, IEntity entity)
        {
            persister.Save(entity);
        }

        protected virtual void PreSaveData(IEntity entity)
        {
        }

        protected virtual void AfterSaveData(IEntity entity)
        {
            MessageBox.Show("数据保存成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected virtual void PrintOrder()
        {
        }

        private void DrawDesignGrid(Graphics g)
        {
            using (var pen = new Pen(Color.Gray, 1))
            {
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 2, 2 }; 

                for (var i = 30; i < Height; i += 35)
                {
                    g.DrawLine(pen, new Point(0, i), new Point(Width, i));
                }

                g.DrawLine(pen, new Point(110, 20), new Point(110, Height));
                g.DrawLine(pen, new Point(380, 20), new Point(380, Height));
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, new Point(20, 20), new Point(Width - 35, 20));
            e.Graphics.DrawLine(Pens.White, new Point(20, 21), new Point(Width - 35, 21));
        }

        private void ShowCreateContinuousButtons(bool show)
        {
            if (!show)
            {
                btnSave.Visible = false;
                btnSaveAndNew.Text = "保存(&S)";
                btnSaveAndNew.Width = btnSave.Width;
                btnSaveAndNew.Left += 20;
            }
        }

        private void SetViewMode(bool view)
        {
            if (view)
            {
                btnSave.Visible = btnSaveAndNew.Visible = false;
            }
        }
    }
}
