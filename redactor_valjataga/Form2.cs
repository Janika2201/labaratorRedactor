using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redactor_valjataga
{
    public partial class Form2 : Form
    {
        public Color colorResult;
        Color color;
        public Form2()
        {
            InitializeComponent();

            hscrollBar_red.Tag = numericUpDown_red;
            hscrollBar_green.Tag = numericUpDown_green;
            hscrollBar_blue.Tag = numericUpDown_blue;


            numericUpDown_red.Tag = hscrollBar_red;
            numericUpDown_green.Tag = hscrollBar_green;
            numericUpDown_blue.Tag = hscrollBar_blue;


            numericUpDown_red.Value = color.R;
            numericUpDown_green.Value = color.G;
            numericUpDown_blue.Value = color.B;
        }

        private void hscrollBar_red_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void UpdateColor()
        {
            colorResult = Color.FromArgb(hscrollBar_red.Value, hscrollBar_green.Value, hscrollBar_blue.Value);
            pictureBox1.BackColor = colorResult;
        }

        private void numericUpDown_red_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
            UpdateColor();
        }

        private void hscrollBar_green_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void numericUpDown_green_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
            UpdateColor();
        }

        private void hscrollBar_blue_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void numericUpDown_blue_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
            UpdateColor();
        }

        private void buttonOther_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                hscrollBar_red.Value = colorDialog.Color.R;//rgb цвета
                hscrollBar_green.Value = colorDialog.Color.G;
                hscrollBar_blue.Value = colorDialog.Color.B;

                colorResult = colorDialog.Color;

                UpdateColor();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.currentPen.Color = colorResult;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
