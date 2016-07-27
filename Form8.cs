using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace editor
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
        Image bm1, bm2;
        Bitmap bim, bim2;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            ImgGl = Image.FromFile(op.FileName);
            ImGl2 = Image.FromFile(op.FileName);
            pictureBox1.Image = Image.FromFile(op.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Graphics graf = pictureBox1.CreateGraphics();
            graf.DrawString(textBox1.Text, new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text)), new SolidBrush(c), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));*/
            imeg = pictureBox1.Image;
            Graphics graf = Graphics.FromImage(imeg);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "Selectati Fontul")
            {
                graf.DrawString(textBox1.Text, new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text)), new SolidBrush(c), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                pictureBox1.Image = imeg;
            }
            else
                MessageBox.Show("Aveti grija sa setati toate valorile textului");
        }

        int x, y;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Faceti click pe imagine , pentru a stabili coordonatele de unde doriti sa inceapa textul adaugat!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bm2 = pictureBox1.Image;
            bm2.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = bm2;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bm2 = pictureBox1.Image;
            bm2.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Image = bm2;
        }



        private void button5_Click(object sender, EventArgs e)
        {
            float[][] sepiaValues ={
                                      new float[]{.393f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
            System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
            System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
            IA.SetColorMatrix(sepiaMatrix);
            Bitmap sepiaEffect = (Bitmap)pictureBox1.Image.Clone();
            using (Graphics g = Graphics.FromImage(sepiaEffect))
            {
                g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
            }
            pictureBox1.Image = sepiaEffect;
        }
        Image ImgGl;
        Image imeg;
        private void button8_Click(object sender, EventArgs e)
        {
            imeg = pictureBox1.Image;
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            if (DialogResult.OK == sdf.ShowDialog())
            {
                imeg.Save(sdf.FileName, ImageFormat.Bmp);
            }
        }


        Image ImGl2;

        private static Image InvertImageColorMatrix(Image originalImg)
        {
            Bitmap invertedBmp = new Bitmap(originalImg.Width, originalImg.Height);

            //Setup color matrix
            ColorMatrix clrMatrix = new ColorMatrix(new float[][]
                                                    {
                                                    new float[] {-1, 0, 0, 0, 0},
                                                    new float[] {0, -1, 0, 0, 0},
                                                    new float[] {0, 0, -1, 0, 0},
                                                    new float[] {0, 0, 0, 1, 0},
                                                    new float[] {1, 1, 1, 0, 1}
                                                    });

            using (ImageAttributes attr = new ImageAttributes())
            {
                //Attach matrix to image attributes
                attr.SetColorMatrix(clrMatrix);

                using (Graphics g = Graphics.FromImage(invertedBmp))
                {
                    g.DrawImage(originalImg, new Rectangle(0, 0, originalImg.Width, originalImg.Height),
                                0, 0, originalImg.Width, originalImg.Height, GraphicsUnit.Pixel, attr);
                }
            }

            return invertedBmp;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = ImGl2;
            if (t > 0)
            {
                pictureBox1.Width = d1;
                pictureBox1.Height = d2;
                t = 0;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.859f, .510f, .334f, 0, 0},
            new float[]{.349f, .851f, .431f, 0, 0},
            new float[]{1, 0, 0, 0, 0},
            new float[]{0, 1, 0, 0, 1}};
            System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
            System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
            Bitmap sepiaEffect = (Bitmap)pictureBox1.Image.Clone();
            IA.SetColorMatrix(sepiaMatrix);
            for (int i = 0; i < 7; i++)
            {
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
            }
            pictureBox1.Image = sepiaEffect;
        }
        Image res;
        int t = 0;
        int d1, d2;
        string p1;
        private void btn_Click(object sender, EventArgs e)
        {

        }
        Bitmap newb;
        private void button7_Click_2(object sender, EventArgs e)
        {
            /*newb = (Bitmap)pictureBox1.Image.Clone();
            for (int x = 1; x < newb.Width; x++)
            {
                for (y = 1; y < newb.Height; y++)
                {
                    try
                    {
                        Color prevX = newb.GetPixel(x - 1, y);
                        Color nextX = newb.GetPixel(x + 1, y);
                        Color prevY = newb.GetPixel(x, y - 1);
                        Color nextY = newb.GetPixel(x, y + 1);
                        int avgR = (int)((prevX.R + nextX.R + prevY.R + nextY.R) / 4);
                        int avgG = (int)((prevX.G + nextX.G + prevY.G + nextY.G) / 4);
                        int avgB = (int)((prevX.B + nextX.B + prevX.B + nextY.B) / 4);

                        newb.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            pictureBox1.Image = newb;*/
            ImageList img = new ImageList();
            img.ImageSize = new Size(80, 80);
            img.Images.Add(pictureBox1.Image);
            pictureBox1.Image = img.Images[0];
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = e.Location.X.ToString();
            textBox4.Text = e.Location.Y.ToString();
        }
        int xel, yel;
        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        Color c;
        private void button9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            c = cd.Color;
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        double zoomFactor = 1.0;
        Image imeg2;


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
