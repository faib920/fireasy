using Fireasy.Common;
using Fireasy.Windows.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Fireasy.Windows.FormsTests
{
    public partial class TreeListForm : Form
    {
        public TreeListForm()
        {
            InitializeComponent();

            //treeList2.Renderer = new MyTreeListRenderer();
            LoadData();
        }

        private void LoadData()
        {
            var random = new Random();
            treeList4.BeginUpdate();
            for (var i = 0; i < 20; i++)
            {
                var item = new TreeListItem();
                treeList4.Items.Add(item);
                item.Cells[0].Value = "祖国要举行建国" + (i + 1) + "周年纪念活动";
                item.Cells[1].Value = DateTime.Today;
                item.Cells[2].Value = random.Next(100, 100000);
                item.Cells[3].Value = (i + 4);
                item.ImageIndex = 0;

                for (var j = 0; j < 20; j++)
                {
                    var subitem = new TreeListItem();
                    item.Items.Add(subitem);
                    subitem.Cells[0].Value = "子节点显示" + (i + j);
                    subitem.Cells[1].Value = DateTime.Today;
                    subitem.Cells[2].Value = random.Next(100, 100000);
                    subitem.Cells[3].Value = (i + 4);
                    subitem.ImageIndex = 1;
                }

                item.Expended = true;
            }

            treeList4.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new TreeListItem();
            treeList1.Items.Add(item);
            item.Cells[0].Value = "祖国要举行建国" + treeList1.Items.Count + "周年纪念活动";
            item.Cells[1].Value = DateTime.Today;
            item.Cells[2].Value = treeList1.Items.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var item = new TreeListItem();
            treeList1.Items.Insert(0, item);
            item.Cells[0].Value = "祖国要举行建国" + treeList1.Items.Count + "周年纪念活动";
            item.Cells[1].Value = DateTime.Today;
            item.Cells[2].Value = treeList1.Items.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeList1.Items.Count > 0)
            {
                treeList1.Items.RemoveAt(0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeList1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var time = TimeWatcher.Watch(() =>
                {
                    treeList1.Items.Clear();
                    for (var i = 0; i < 5000; i++)
                    {
                        var item = new TreeListItem();
                        treeList1.Items.Add(item);
                        item.Cells[0].Value = "祖国要举行建国" + (i + 1) + "周年纪念活动";
                        item.Cells[1].Value = DateTime.Today;
                        item.Cells[2].Value = (i + 1);
                    }
                });

            MessageBox.Show("5000条数据需要" + time.TotalMilliseconds.ToString() + "毫秒");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var time = TimeWatcher.Watch(() =>
                {
                    treeList1.BeginUpdate();
                    treeList1.Items.Clear();
                    for (var i = 0; i < 5000; i++)
                    {
                        treeList1.Items.AddCells(new object[] { "祖国要举行建国" + (i + 1) + "周年纪念活动", DateTime.Today, (i + 1) });
                    }

                    treeList1.EndUpdate();
                });

            MessageBox.Show("5000条数据需要" + time.TotalMilliseconds.ToString() + "毫秒");

            treeList1.Items[treeList1.Items.Count - 1].Selected = true;
            treeList1.Items[treeList1.Items.Count - 1].EnsureVisible();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (treeList1.Items.Count > 0)
            {
                treeList1.Items[0].Selected = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (treeList1.Items.Count > 0)
            {
                treeList1.SelectedItems.Add(treeList1.Items[0]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            treeList1.SelectedItems.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var ran = new Random();
            treeList2.BeginUpdate();
            treeList2.Items.Clear();
            for (var i = 0; i < 5000; i++)
            {
                var item = new TreeListItem();
                item.Enabled = false;
                treeList2.Items.Add(item);
                item.Cells[0].Value = "文本数据文本数据" + (i + 1) + "文本数据文本数据文本数据";
                item.Cells[1].Value = DateTime.Today;
                item.Cells[2].Value = ran.Next(100);
                item.Cells[3].Value = ran.Next(100) % 2 == 0;

                item.ShowExpanded = true;
            }

            treeList2.EndUpdate();
        }

        private void treeList2_DemandLoad(object sender, TreeListItemEventArgs e)
        {
            var ran = new Random();
            for (var i = 0; i < 5; i++)
            {
                var item = new TreeListItem();
                e.Item.Items.Add(item);
                item.Cells[0].Value = "文本数据文本数据" + (i + 1) + "文本数据文本数据文本数据";
                item.Cells[1].Value = DateTime.Today;
                item.Cells[2].Value = ran.Next(100);
                item.Cells[3].Value = ran.Next(100) % 2 == 0;

                item.ShowExpanded = true;
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            treeList4.Columns[0].Width = new Random().Next(100, 300);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeList4.Columns[0].ForeColor = Color.FromArgb(random.Next(0, 200), random.Next(0, 200), random.Next(0, 200));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var fonts = new[] { "宋体", "仿宋", "幼圆", "微软雅黑" };
            var random = new Random();
            treeList4.Columns[0].Font = new Font(fonts[random.Next(0, fonts.Length)], (float)random.Next(9, 16));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeList4.Columns[1].TextAlign = (HorizontalAlignment)random.Next(0, 2);
            treeList4.Columns[2].TextAlign = (HorizontalAlignment)random.Next(0, 2);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var formats = new[] { "yyyy-MM-dd", "yyyy-M-d", "yyyy年MM月dd日", "yyyy/M/d" };
            var formats2 = new[] { "#,##0", "0.00", "#,##0.00", "￥0.00" };
            var random = new Random();
            treeList4.Columns[1].DataFormat = formats[random.Next(0, formats.Length)];
            treeList4.Columns[2].DataFormat = formats2[random.Next(0, formats2.Length)];
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeList4.Items[0].ForeColor = Color.FromArgb(random.Next(0, 200), random.Next(0, 200), random.Next(0, 200));
            treeList4.Items[0].BackgroundColor = Color.FromArgb(random.Next(200, 255), random.Next(200, 255), random.Next(200, 255));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var fonts = new[] { "宋体", "仿宋", "幼圆", "微软雅黑" };
            var random = new Random();
            treeList4.Items[0].Font = new Font(fonts[random.Next(0, fonts.Length)], (float)random.Next(9, 16));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            treeList4.ShowHeader = !treeList4.ShowHeader;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            treeList4.ShowFooter = !treeList4.ShowFooter;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            treeList4.ShowGridLines = !treeList4.ShowGridLines;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            treeList4.ShowPlusMinus = !treeList4.ShowPlusMinus;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            treeList4.ShowPlusMinusLines = !treeList4.ShowPlusMinusLines;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            treeList4.ShowCheckBoxes = !treeList4.ShowCheckBoxes;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeList4.AlternateBackColor = Color.FromArgb(random.Next(200, 255), random.Next(200, 255), random.Next(200, 255));
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (treeList4.ImageList == null)
            {
                treeList4.ImageList = imageList1;
            }
            else
            {
                treeList4.ImageList = null;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            treeList4.Columns[0].ImageIndex = 2;
            treeList4.Columns[1].ImageKey = "purview.png";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeList4.Columns[0].ImageAlign = (HorizontalAlignment)random.Next(0, 2);
            treeList4.Columns[1].ImageAlign = (HorizontalAlignment)random.Next(0, 2);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            treeList4.Items[0].Items[0].ImageIndex = 0;
            treeList4.Items[0].Items[1].ImageKey = "purview.png";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            treeList1.MultiSelect = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            treeList4.MultiSelect = checkBox2.Checked;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeList4.Items[0].Items[random.Next(10)].Selected = true;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var random = new Random();
            treeList4.SelectedItems.Add(treeList4.Items[0].Items[random.Next(10)]);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            treeList1.HotTracking = checkBox3.Checked;
        }

        private void TreeListForm_Load(object sender, EventArgs e)
        {
            var c = new TreeListComboBoxEditor();
            //c.Inner.DropDownStyle = ComboBoxStyle.DropDownList;
            c.Inner.Items.Add("fireasy");
            c.Inner.Items.Add("kunming");
            treeList2.Columns[4].SetEditor(c);

            var n = new TreeListNumericUpDownEditor();
            treeList2.Columns[2].SetEditor(n);

            treeListComboBox1.TreeList.ShowPlusMinus = true;
            treeListComboBox1.TreeList.ShowCheckBoxes = true;
            var node = treeListComboBox1.TreeList.Items.Add("dfasdfdsaf");
            node.KeyValue = 1;
            var sub = node.Items.Add("dfasdfsaf");
            sub.KeyValue = 2;
            node.Expended = true;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            var ran = new Random();
            treeList1.BeginUpdate();
            treeList1.Groups.Clear();
            treeList1.Items.Clear();
            for (var i = 0; i < 10; i++)
            {
                var group = new TreeListGroup("TreeList组" + i);
                treeList1.Groups.Add(group);

                for (var j = 0; j < 10; j++ )
                {
                    var item = new TreeListItem();
                    item.Enabled = false;
                    group.Items.Add(item);
                    item.Cells[0].Value = "祖国要举行建国" + (j + 1) + "周年纪念活动";
                    item.Cells[1].Value = DateTime.Today;
                    item.Cells[2].Value = (j + 1);
                }
            }

            treeList1.EndUpdate();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            foreach (var item in treeList1.Items)
            {
                item.Selected = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            treeList1.ShowGridLines = checkBox4.Checked;
        }
    }

    public class MyTreeListRenderer : TreeListRenderer
    {
        protected override void DrawColumnHeaderBackground(Graphics graphics, Rectangle rect, DrawState state)
        {
            using (var l = new System.Drawing.Drawing2D.LinearGradientBrush(rect, Color.White, Color.LightGray, 90))
            {
                graphics.FillRectangle(l, rect);
            }

            using (var l = new System.Drawing.Drawing2D.LinearGradientBrush(rect, Color.LightGray, Color.Gray, 90))
            {
                var r = new Rectangle(rect.Right - 2, rect.Top + 4, 1, rect.Height - 8);
                graphics.FillRectangle(l, r);
            }
        }

        protected override void DrawItemBackground(TreeListItemRenderEventArgs e)
        {
            if (e.DrawState == DrawState.Selected)
            {
                var rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1);
                using (var l = new System.Drawing.Drawing2D.LinearGradientBrush(rect, Color.FromArgb(60, 144, 218, 144), Color.FromArgb(60, 0, 100, 0), 90))
                {
                    e.Graphics.FillPath(l, CreateRoundedRectanglePath(rect, 4));
                }

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.DrawPath(Pens.Green, CreateRoundedRectanglePath(rect, 4));

                return;
            }

            base.DrawItemBackground(e);
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }
}
