namespace Fireasy.Windows.EntityTests
{
    partial class ProductEdit
    {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.entityPropertyExtend1 = new Fireasy.Windows.Entity.EntityPropertyExtend(this.components);
            this.numericTextBox1 = new Fireasy.Windows.Forms.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.entityPropertyExtend1.SetFormat(this.textBox1, "");
            this.textBox1.Location = new System.Drawing.Point(107, 39);
            this.textBox1.Name = "textBox1";
            this.entityPropertyExtend1.SetPropertyName(this.textBox1, "Productname");
            this.textBox1.Size = new System.Drawing.Size(249, 21);
            this.textBox1.TabIndex = 21;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.AllowNegative = true;
            this.numericTextBox1.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTextBox1.DefaultValue = 0D;
            this.numericTextBox1.DigitsInGroup = 0;
            this.numericTextBox1.Flags = 0;
            this.entityPropertyExtend1.SetFormat(this.numericTextBox1, "#,##0.00");
            this.numericTextBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericTextBox1.Location = new System.Drawing.Point(107, 122);
            this.numericTextBox1.MaxDecimalPlaces = 4;
            this.numericTextBox1.MaxWholeDigits = 9;
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Prefix = "";
            this.entityPropertyExtend1.SetPropertyName(this.numericTextBox1, "Unitprice");
            this.numericTextBox1.RangeMax = 1.7976931348623157E+308D;
            this.numericTextBox1.RangeMin = -1.7976931348623157E+308D;
            this.numericTextBox1.Size = new System.Drawing.Size(175, 21);
            this.numericTextBox1.TabIndex = 26;
            this.numericTextBox1.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "折扣";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.entityPropertyExtend1.SetFormat(this.checkBox1, "");
            this.checkBox1.Location = new System.Drawing.Point(107, 79);
            this.checkBox1.Name = "checkBox1";
            this.entityPropertyExtend1.SetPropertyName(this.checkBox1, "Discontinued");
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "打折";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "折扣";
            // 
            // ProductEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 431);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.EntityPropertyExtend = this.entityPropertyExtend1;
            this.EntityType = typeof(Fireasy.Data.Entity.Test.Model.Products);
            this.Name = "ProductEdit";
            this.Text = "ProductEdit";
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.numericTextBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private Entity.EntityPropertyExtend entityPropertyExtend1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private Forms.NumericTextBox numericTextBox1;
    }
}