namespace redactor_valjataga
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hscrollBar_red = new System.Windows.Forms.HScrollBar();
            this.hscrollBar_green = new System.Windows.Forms.HScrollBar();
            this.hscrollBar_blue = new System.Windows.Forms.HScrollBar();
            this.numericUpDown_red = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_green = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_blue = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonOther = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue";
            // 
            // hscrollBar_red
            // 
            this.hscrollBar_red.Location = new System.Drawing.Point(124, 32);
            this.hscrollBar_red.Name = "hscrollBar_red";
            this.hscrollBar_red.Size = new System.Drawing.Size(172, 25);
            this.hscrollBar_red.TabIndex = 3;
            this.hscrollBar_red.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrollBar_red_Scroll);
            // 
            // hscrollBar_green
            // 
            this.hscrollBar_green.Location = new System.Drawing.Point(124, 106);
            this.hscrollBar_green.Name = "hscrollBar_green";
            this.hscrollBar_green.Size = new System.Drawing.Size(172, 25);
            this.hscrollBar_green.TabIndex = 4;
            this.hscrollBar_green.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrollBar_green_Scroll);
            // 
            // hscrollBar_blue
            // 
            this.hscrollBar_blue.Location = new System.Drawing.Point(124, 173);
            this.hscrollBar_blue.Name = "hscrollBar_blue";
            this.hscrollBar_blue.Size = new System.Drawing.Size(172, 25);
            this.hscrollBar_blue.TabIndex = 5;
            this.hscrollBar_blue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrollBar_blue_Scroll);
            // 
            // numericUpDown_red
            // 
            this.numericUpDown_red.Location = new System.Drawing.Point(364, 44);
            this.numericUpDown_red.Name = "numericUpDown_red";
            this.numericUpDown_red.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_red.TabIndex = 6;
            this.numericUpDown_red.ValueChanged += new System.EventHandler(this.numericUpDown_red_ValueChanged);
            // 
            // numericUpDown_green
            // 
            this.numericUpDown_green.Location = new System.Drawing.Point(364, 118);
            this.numericUpDown_green.Name = "numericUpDown_green";
            this.numericUpDown_green.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_green.TabIndex = 7;
            this.numericUpDown_green.ValueChanged += new System.EventHandler(this.numericUpDown_green_ValueChanged);
            // 
            // numericUpDown_blue
            // 
            this.numericUpDown_blue.Location = new System.Drawing.Point(364, 178);
            this.numericUpDown_blue.Name = "numericUpDown_blue";
            this.numericUpDown_blue.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_blue.TabIndex = 8;
            this.numericUpDown_blue.ValueChanged += new System.EventHandler(this.numericUpDown_blue_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(565, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 186);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // buttonOther
            // 
            this.buttonOther.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonOther.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonOther.Location = new System.Drawing.Point(614, 212);
            this.buttonOther.Name = "buttonOther";
            this.buttonOther.Size = new System.Drawing.Size(97, 51);
            this.buttonOther.TabIndex = 10;
            this.buttonOther.Text = "другой цвет";
            this.buttonOther.UseVisualStyleBackColor = false;
            this.buttonOther.Click += new System.EventHandler(this.buttonOther_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Olive;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button1.Location = new System.Drawing.Point(46, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Olive;
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button2.Location = new System.Drawing.Point(360, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 33);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::redactor_valjataga.Properties.Resources.PL71482_12;
            this.ClientSize = new System.Drawing.Size(800, 275);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOther);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDown_blue);
            this.Controls.Add(this.numericUpDown_green);
            this.Controls.Add(this.numericUpDown_red);
            this.Controls.Add(this.hscrollBar_blue);
            this.Controls.Add(this.hscrollBar_green);
            this.Controls.Add(this.hscrollBar_red);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Colors";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar hscrollBar_red;
        private System.Windows.Forms.HScrollBar hscrollBar_green;
        private System.Windows.Forms.HScrollBar hscrollBar_blue;
        private System.Windows.Forms.NumericUpDown numericUpDown_red;
        private System.Windows.Forms.NumericUpDown numericUpDown_green;
        private System.Windows.Forms.NumericUpDown numericUpDown_blue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonOther;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}