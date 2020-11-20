using System;
using System.Drawing;
using System.Windows.Forms;

namespace redactor_valjataga
{
    public partial class Form2 : Form
    {
        Color colorResult;
        Color color;
        public Form2()
        {
            InitializeComponent();
            Scroll_Red.Tag = numeric_Red;
            Scroll_Green.Tag = numeric_Green;
            Scroll_Blue.Tag = numeric_Blue;

            numeric_Red.Tag = Scroll_Red;
            numeric_Green.Tag = Scroll_Green;
            numeric_Blue.Tag = Scroll_Blue;

            numeric_Red.Value = color.R;
            numeric_Green.Value = color.G;
            numeric_Blue.Value = color.B;

        }

        private void Scroll_Red_ValueChanged(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void Scroll_Green_ValueChanged(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void Numeric_Red_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }

        private void Numeric_Green_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }

        private void Scroll_Blue_ValueChanged(object sender, ScrollEventArgs e)
        {
            ScrollBar scrollBar = (ScrollBar)sender;
            NumericUpDown numericUpDown = (NumericUpDown)scrollBar.Tag;
            numericUpDown.Value = scrollBar.Value;
            UpdateColor();
        }

        private void Numeric_Blue_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            ScrollBar scrollBar = (ScrollBar)numericUpDown.Tag;
            scrollBar.Value = (int)numericUpDown.Value;
        }
        private void UpdateColor()
        {
            colorResult = Color.FromArgb(Scroll_Red.Value, Scroll_Green.Value, Scroll_Blue.Value);
            pictureBox1.BackColor = colorResult;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1.currentPen.Color = colorResult;
            Form1.historyColor = colorResult;
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Scroll_Red.Value = colorDialog.Color.R;
                Scroll_Green.Value = colorDialog.Color.G;
                Scroll_Blue.Value = colorDialog.Color.B;

                colorResult = colorDialog.Color;

                UpdateColor();
            }
            Form1 Main = Owner as Form1;
        }
    }

}
