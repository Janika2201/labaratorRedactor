using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redactor_valjataga
{
    
    public partial class Form1 : Form
    {
        Image imgOriginal;
        bool drawing;
        int historyCounter = 0; //счетчик истории

        GraphicsPath currentPath;
        Point oldLocation;
        public static Pen currentPen;
        public static Color historyColor = Color.Black;//сохранение текущего цвета перед использованием ластика
        Timer cyclee;
        List<Image> History;//список для истории
        int X = 0;//задаем переменые 
        int Y = 0;
        int XO = 0;
        int YO = 0;
        int figuri = 0;
        public Form1()
        {
            InitializeComponent();
            drawing = false; //переменная, отвественная за рисование
            currentPen = new Pen(Color.Black);// Инициализация пера с чёрным цветом
            currentPen.Width = trackBar1.Value;//Инциализация толщины пера
            picDrawingSurface.MouseDown += PicDrawingSurface_MouseDown1;
            picDrawingSurface.MouseUp += PicDrawingSurface_MouseUp;
            picDrawingSurface.MouseMove += PicDrawingSurface_MouseMove;
            History = new List<Image>();//инциализация списка для истории
            History.Add(new Bitmap(697, 462));
            cyclee = new Timer();
            cyclee.Start();

            trackBar2.Minimum = 0;
            trackBar2.Maximum = 10;
        }

        private void PicDrawingSurface_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "x= " + e.X.ToString() + ", y= " + e.Y.ToString();//отвечает за кардинаты х и у которые обозначаны в левом углу 
            if (drawing)
            {
                if (figuri == 0)
                {
                    Graphics g = Graphics.FromImage(picDrawingSurface.Image);

                    currentPath.AddLine(oldLocation, e.Location);
                    g.DrawPath(currentPen, currentPath);
                    oldLocation = e.Location;
                    g.Dispose();
                    picDrawingSurface.Invalidate();

                }
                else
                {
                    X = oldLocation.X;//кардиныты
                    Y = oldLocation.Y;
                    XO = e.Location.X - oldLocation.X;
                    YO = e.Location.Y - oldLocation.Y;
                }


            }

        }

        private void PicDrawingSurface_MouseUp(object sender, MouseEventArgs e)
        {
            if (figuri == 1) //Drawing square
            {
                Graphics g = Graphics.FromImage(picDrawingSurface.Image);
                Rectangle rect = new Rectangle(X, Y, XO, YO);
                currentPath.AddRectangle(rect);
                g.DrawPath(currentPen, currentPath);
                oldLocation = e.Location;
                g.Dispose();
                picDrawingSurface.Invalidate();
            }



            if (figuri == 2) //drawing circle
            {
                Graphics g = Graphics.FromImage(picDrawingSurface.Image);
                Rectangle circ = new Rectangle(X, Y, XO, YO);
                currentPath.AddEllipse(circ);
                g.DrawPath(currentPen, currentPath);
                g.Dispose();
                picDrawingSurface.Invalidate();
            }
            if (figuri == 0)
            {
                currentPath = new GraphicsPath();
                currentPath.Dispose();
            }




            //Removing unnecessary history
            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(picDrawingSurface.Image));
            if (historyCounter + 1 < 10) historyCounter++;
            if (History.Count - 1 == 10) History.RemoveAt(0);
            drawing = false;

            try
            {
                currentPath = new GraphicsPath();
                currentPath.Dispose();
            }
            catch { };

            currentPen.Color = historyColor;
            imgOriginal = picDrawingSurface.Image;
        }



        private void PicDrawingSurface_MouseDown1(object sender, MouseEventArgs e)
        {
            if (picDrawingSurface.Image == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                drawing = true;
                oldLocation = e.Location;
                currentPath = new GraphicsPath();
                currentPen.Color = historyColor;
            }
            if (e.Button == MouseButtons.Right)
            {
                drawing = true;
                oldLocation = e.Location;
                currentPath = new GraphicsPath();
                currentPen.DashStyle = DashStyle.Solid;
                currentPen.Color = Color.White;
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trackBar1.Value;
        }
        

        private Image Zoom(Image img, int size)
        {
            Bitmap pic = new Bitmap(img, img.Width + (img.Width * size / 10), img.Height + (img.Height * size / 10));
            Graphics g = Graphics.FromImage(pic);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return pic;
        }


        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4;


            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDlg.OpenFile();

                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Png);
                        break;
                }

                fs.Close();
            }
            Graphics g = Graphics.FromImage(picDrawingSurface.Image);
            g.Clear(Color.White);
            g.DrawImage(picDrawingSurface.Image, 0, 0, 750, 500);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)//создается новый файл 
        {
            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Передупреждение", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: SaveToolStripMenuItem_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
                Bitmap pic = new Bitmap(697, 462);
                picDrawingSurface.Image = pic;

            }
            else
            {
                Bitmap pic = new Bitmap(697, 462);
                picDrawingSurface.Image = pic;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)//открывается папка в которой можно открыть любого формата картинку 
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;

            if (OP.ShowDialog() != DialogResult.Cancel)
                picDrawingSurface.Load(OP.FileName);


            picDrawingSurface.AutoSize = true;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)//отвечает за создание нового листа и если что-то нарисованно, то предлагает сохранить 
        {
           

            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Передупреждение", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: SaveToolStripMenuItem_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
                Bitmap pic = new Bitmap(697, 462);
                picDrawingSurface.Image = pic;

            }
            else
            {
                Bitmap pic = new Bitmap(697, 462);
                picDrawingSurface.Image = pic;
            }
        }

       

        private void toolStripButton4_Click(object sender, EventArgs e)//отвечает за открытие  фото
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;

            if (OP.ShowDialog() != DialogResult.Cancel)
                picDrawingSurface.Load(OP.FileName);

            picDrawingSurface.AutoSize = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//отвечает за открытие второй формы
        {
            Form2 f = new Form2();
            f.Owner = this;
            f.ShowDialog();
        }
        
     

        

        private void trackBar2_Scroll_1(object sender, EventArgs e)//отвечает за приближения (лупа)
        {
            picDrawingSurface.Image = Zoom(imgOriginal, trackBar2.Value);
        }
       
        

        private void trackBar1_Scroll_1(object sender, EventArgs e)//размер кисти 
        {
            currentPen.Width = trackBar1.Value;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.Count != 0 && historyCounter != 0)
            {
                picDrawingSurface.Image = new Bitmap(History[--historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void renoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyCounter < History.Count - 1)
            {
                picDrawingSurface.Image = new Bitmap(History[++historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void colorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this;
            f.ShowDialog();
        }
        
        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Solid;

            solidToolStripMenuItem.Checked = true;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = false;
        }

        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Dot;

            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = true;
            dashDotDotToolStripMenuItem.Checked = false;
        }

        private void dashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.DashDotDot;

            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)// отвечает за выход из рисовалки
        {
            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед выходом?", "Передупреждение", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.No: Application.Exit(); break;
                    case DialogResult.Yes: SaveToolStripMenuItem_Click(sender, e); Application.Exit(); break;
                    case DialogResult.Cancel: return;

                }

            }
            else
            {
                Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paint Janika Valjataga, Rostislav Konovalov");
        }

        private void picDrawingSurface_MouseDoubleClick(object sender, MouseEventArgs e)//отвечает за возвращение рисунка с помощью ctrl+z
        {
            Graphics g = Graphics.FromImage(picDrawingSurface.Image);
      
            if (e.Button == MouseButtons.Left)
            {
                g.Clear(historyColor);
                History.Add(new Bitmap(picDrawingSurface.Image));
            }
            if (e.Button == MouseButtons.Right)
            {
                g.Clear(Color.White);
                History.Add(new Bitmap(picDrawingSurface.Image));
            }

        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4;


            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDlg.OpenFile();

                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Png);
                        break;
                }

                fs.Close();
            }
            Graphics g = Graphics.FromImage(picDrawingSurface.Image);
            g.Clear(Color.White);
            g.DrawImage(picDrawingSurface.Image, 0, 0, 750, 500);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (randColors.Checked == true)
            {
                cyclee.Interval = (int)Convert.ToDecimal(randFreq.Value);
                cyclee.Enabled = true;
                cyclee.Tick += Cyclee_Tick;


            }
            if (randColors.Checked == false)
            {
                cyclee.Enabled = false;

            }
        }

        private void Cyclee_Tick(object sender, EventArgs e)
        {
            Random rainboow = new Random();
            currentPen.Color = Color.FromArgb(rainboow.Next(255), rainboow.Next(255), rainboow.Next(255));
            historyColor = currentPen.Color;
            currentPath = new GraphicsPath();
        }

        private void squareToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            figuri = 1;
        }

        private void straightToolStripMenuItem_Click_1(object sender, EventArgs e)
        {            
            figuri = 2;
        }

        private void penToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            figuri = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click_1(sender, e);
        }

        private void picDrawingSurface_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
