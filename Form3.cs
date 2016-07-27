using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace editor
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Bitmap b;
        private void button1_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            b = new Bitmap(op.FileName);
            btm = new Bitmap(b.Width, b.Height);
            image = Graphics.FromImage(btm);
            image.DrawImage(b, new Rectangle(0, 0, panel1.Width, panel1.Height));
            g.DrawImage(btm, Point.Empty);
            panel1.BackgroundImage = btm;
        }
        Graphics g;
        Graphics image;
        Bitmap btm;
        Color c;
        bool drawing = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }
        Image mainimg;
        private void Form3_Load(object sender, EventArgs e)
        {
            /*g = panel1.CreateGraphics();
            btm = new Bitmap(panel1.Width, panel1.Height);
            image = Graphics.FromImage(btm);
            image.Clear(Color.White);*/
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            c = cd.Color;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Rectangle mouseRect = new Rectangle(e.X - (trackBar1.Value / 2), e.Y - (trackBar1.Value / 2), (trackBar1.Value), (trackBar1.Value));
                image.FillRectangle(new SolidBrush(c), mouseRect);
                g.DrawImage(btm, Point.Empty);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            int w = panel1.Width;
            int h = panel1.Height;
            /*
           Bitmap bm = new Bitmap(w, h);
           panel1.DrawToBitmap(bm, new Rectangle(0, 0, w, h));*/
            Bitmap imen = new Bitmap(w, h);
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            using (Bitmap bmp = new Bitmap(w, h))
            {
                panel1.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
                if(DialogResult.OK==sdf.ShowDialog())
                bmp.Save(sdf.FileName, ImageFormat.Jpeg);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 fg = new Form1();
            fg.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
