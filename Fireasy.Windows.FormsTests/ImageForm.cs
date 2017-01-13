using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fireasy.Common.Extensions;
using System.IO;
using Fireasy.Common.Drawing;
using System.Net;

namespace Fireasy.Windows.FormsTests
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "所有文件|*.jpg;*.png;*.gif";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                panel1.BackgroundImage = Image.FromFile(open.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = panel1.BackgroundImage.Thumb(200, 200);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = panel1.BackgroundImage.Thumb(200, 200, Common.Drawing.ThumbnailStyle.Center);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = panel1.BackgroundImage.Thumb(200, 200, Common.Drawing.ThumbnailStyle.Zoom);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Invert(panel1.BackgroundImage);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Gray(panel1.BackgroundImage);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Brightness(panel1.BackgroundImage, 80);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Noise(panel1.BackgroundImage, 100, 2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Mosaic(panel1.BackgroundImage, 10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Binaryzation(panel1.BackgroundImage);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Sharpen(panel1.BackgroundImage, 5);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = panel1.BackgroundImage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Contrast(panel1.BackgroundImage, 10);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = ImageDigitization.Relief(panel1.BackgroundImage);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = panel1.BackgroundImage.Zoom(700, 400);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = panel1.BackgroundImage.Compress(8);
        }
    }
}
