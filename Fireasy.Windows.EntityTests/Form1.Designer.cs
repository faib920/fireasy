namespace Fireasy.Windows.EntityTests
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.treeList1 = new Fireasy.Windows.Forms.TreeList();
            this.treeListColumn1 = new Fireasy.Windows.Forms.TreeListColumn();
            this.treeListColumn2 = new Fireasy.Windows.Forms.TreeListColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeList1
            // 
            this.treeList1.AlternateBackColor = System.Drawing.Color.Empty;
            this.treeList1.Columns.AddRange(new Fireasy.Windows.Forms.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1.Footer = null;
            this.treeList1.KeyField = "Productid";
            this.treeList1.Location = new System.Drawing.Point(12, 41);
            this.treeList1.Name = "treeList1";
            this.treeList1.NoneItemText = "没有可显示的数据";
            this.treeList1.Size = new System.Drawing.Size(808, 320);
            this.treeList1.TabIndex = 1;
            this.treeList1.Text = "treeList1";
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.DataKey = "Productname";
            this.treeListColumn1.ForeColor = System.Drawing.Color.Empty;
            this.treeListColumn1.Image = null;
            this.treeListColumn1.Text = "名称";
            this.treeListColumn1.Width = 200;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.DataFormat = "￥#,##0.00";
            this.treeListColumn2.DataKey = "Unitprice";
            this.treeListColumn2.ForeColor = System.Drawing.Color.Empty;
            this.treeListColumn2.Image = null;
            this.treeListColumn2.Text = "单价";
            this.treeListColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "查看";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(255, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 373);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Forms.TreeList treeList1;
        private Forms.TreeListColumn treeListColumn1;
        private Forms.TreeListColumn treeListColumn2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

