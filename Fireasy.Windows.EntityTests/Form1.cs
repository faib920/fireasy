using Fireasy.Data.Entity.Test.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fireasy.Windows.EntityTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            using (var context = new MyDbContext())
            {
                var list = context.Products;

                treeList1.DataBind(list);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (new ProductEdit().ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (treeList1.SelectedItems.Count == 0)
            {
                return;
            }

            var id = treeList1.SelectedItems[0].KeyValue.ToString();
            if (new ProductEdit() { InfoId = id }.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (treeList1.SelectedItems.Count == 0)
            {
                return;
            }

            var id = treeList1.SelectedItems[0].KeyValue.ToString();
            new ProductEdit() { InfoId = id, ViewMode = true }.ShowDialog();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (treeList1.SelectedItems.Count == 0)
            {
                return;
            }

            var id = treeList1.SelectedItems[0].KeyValue.ToString();
            using (var context = new MyDbContext())
            {
                context.Products.Delete(new[] { id });
                LoadData();
            }
        }
    }
}
