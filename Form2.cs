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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        Image bm1, bm2;
        Bitmap bim, bim2;
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            ImgGl = Image.FromFile(op.FileName);
            ImGl2 = Image.FromFile(op.FileName);
            pictureBox2.Image = Image.FromFile(op.FileName);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            imi2 = pictureBox2.Image;
            ImUndo = imi2;
            /*Graphics graf = pictureBox2.CreateGraphics();
            graf.DrawString(textBox1.Text, new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text)), new SolidBrush(c), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));*/
            imeg = pictureBox2.Image;
            ImUndo = pictureBox2.Image;
            Graphics graf = Graphics.FromImage(imeg);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "Selectati Fontul")
            {
                graf.DrawString(textBox1.Text, new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text)), new SolidBrush(c), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                pictureBox2.Image = imeg;
            }
            else
                MessageBox.Show("Aveti grija sa setati toate valorile textului!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox3.Text = "Selecteaza marimea de scalare";
            comboBox2.Text = comboBox2.Items[0].ToString();
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
            bm1 = pictureBox2.Image;
            numericUpDown1.Maximum = 5;
        }
        int x, y;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Faceti Click_1 pe imagine , pentru a stabili coordonatele de unde doriti sa inceapa textul adaugat!");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bm2 = pictureBox2.Image;
            bm2.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox2.Image = bm2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bm2 = pictureBox2.Image;
            bm2.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox2.Image = bm2;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            bim = (Bitmap)pictureBox2.Image;
            pictureBox2.Image = (Image)MakeGrayscale3(bim);
        }

        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        private void button5_Click_1(object sender, EventArgs e)
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
            Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
            using (Graphics g = Graphics.FromImage(sepiaEffect))
            {
                g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
            }
            pictureBox2.Image = sepiaEffect;
        }
        Image ImgGl;
        Image imeg;
        private void button8_Click_1(object sender, EventArgs e)
        {
            imeg = pictureBox2.Image;
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            if (DialogResult.OK == sdf.ShowDialog())
            {
                imeg.Save(sdf.FileName, ImageFormat.Bmp);
            }
        }
        Image imi1, imi2, imi3, imi4, imi5;
        private void button6_Click_1(object sender, EventArgs e)
        {
            ImUndo = pictureBox2.Image;
            if (comboBox2.SelectedIndex == 0)
            {
                bim = (Bitmap)pictureBox2.Image;
                pictureBox2.Image = (Image)MakeGrayscale3(bim);
            }
            else
                if (comboBox2.SelectedIndex == 1)
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
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                    if (comboBox2.SelectedIndex == 2)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.259f, .210f, .334f, 0, 0},
            new float[]{.149f, .451f, .731f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                        if (comboBox2.SelectedIndex == 3)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.259f, .210f, .334f, 0, 0},
            new float[]{.149f, .451f, .731f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                            if (comboBox2.SelectedIndex == 4)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.859f, .510f, .334f, 0, 0},
            new float[]{.349f, .851f, .431f, 0, 0},
            new float[]{1, 0, 0, 0, 0},
            new float[]{0, 1, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                if (comboBox2.SelectedIndex == 5)
            {
                float[][] sepiaValues ={
                                      new float[]{.293f, .549f, .172f, 0, 0},
            new float[]{.319f, .246f, .134f, 0, 0},
            new float[]{.489f, .568f, .431f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                    if (comboBox2.SelectedIndex == 6)
            {
                float[][] sepiaValues ={
                                      new float[]{.1093f, .949f, .872f, 0, 0},
            new float[]{.109f, .186f, .134f, 0, 0},
            new float[]{.249f, .668f, .731f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                        if (comboBox2.SelectedIndex == 7)
            {
                float[][] sepiaValues ={
                                      new float[]{.13f, .19f, .22f, 0, 0},
            new float[]{.939f, .146f, .594f, 0, 0},
            new float[]{.249f, .598f, .51f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                            if (comboBox2.SelectedIndex == 8)
            {
                float[][] sepiaValues ={
                                      new float[]{.213f, .419f, .22f, 0, 0},
            new float[]{.439f, .946f, .594f, 0, 0},
            new float[]{.49f, .998f, .51f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                                if (comboBox2.SelectedIndex == 9)
            {
                float[][] sepiaValues ={
                                      new float[]{.893f, .759f, .773f, 0, 0},
            new float[]{.169f, .186f, .134f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                                    if (comboBox2.SelectedIndex == 10)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .859f, .273f, 0, 0},
            new float[]{.469f, .186f, .434f, 0, 0},
            new float[]{.589f, .568f, .431f, 0, 0},
            new float[]{1, 0, 0, 2, 0},
            new float[]{0, 0, 0, 0, 4}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                                        if (comboBox2.SelectedIndex == 11)
            {
                Image imeji = pictureBox2.Image;
                pictureBox2.Image = InvertImageColorMatrix(imeji);
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

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = ImGl2;
            /*if (t > 0)
            {
                pictureBox2.Width = d1;
                pictureBox2.Height = d2;
                t = 0;
            }*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.859f, .510f, .334f, 0, 0},
            new float[]{.349f, .851f, .431f, 0, 0},
            new float[]{1, 0, 0, 0, 0},
            new float[]{0, 1, 0, 0, 1}};
            System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
            System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
            Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
            IA.SetColorMatrix(sepiaMatrix);
            for (int i = 0; i < 7; i++)
            {
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
            }
            pictureBox2.Image = sepiaEffect;
        }
        Image res;
        int t = 0;
        int d1, d2;
        string p1;
        private void btn_Click_1(object sender, EventArgs e)
        {

        }
        Bitmap newb;
        private void button7_Click_1_2(object sender, EventArgs e)
        {
            ImUndo = pictureBox2.Image;
            /*newb = (Bitmap)pictureBox2.Image.Clone();
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
            pictureBox2.Image = newb;*/
            ImageList img = new ImageList();
            img.ImageSize = new Size(80, 80);
            img.Images.Add(pictureBox2.Image);
            pictureBox2.Image = img.Images[0];
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        int xel, yel;
        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_MouseClick_1(object sender, MouseEventArgs e)
        {

        }
        Color c;
        private void button9_Click_1(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            c = cd.Color;
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            imi1 = pictureBox2.Image;
            ImUndo = imi1;
            Bitmap originalImage = (Bitmap)pictureBox2.Image;
            Bitmap adjustedImage = (Bitmap)pictureBox2.Image;
            float brightness = 1.0f; // no change in brightness
            float contrast = Convert.ToSingle(numericUpDown1.Value); // twice the contrast
            float gamma = 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
        new float[] {contrast, 0, 0, 0, 0}, // scale red
        new float[] {0, contrast, 0, 0, 0}, // scale green
        new float[] {0, 0, contrast, 0, 0}, // scale blue
        new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
        new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};
            System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(adjustedImage);
            g.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                , 0, 0, originalImage.Width, originalImage.Height,
                GraphicsUnit.Pixel, imageAttributes);
            pictureBox2.Image = adjustedImage;
        }
        double zoomFactor = 1.0;
        Image imeg2;
        private void button11_Click_1(object sender, EventArgs e)
        {
            ImUndo = pictureBox2.Image;
            imeg = pictureBox2.Image;
            if (comboBox3.SelectedIndex == 0)
            {
                zoomFactor = 0.5;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                if (comboBox3.SelectedIndex == 1)
            {
                zoomFactor = 1.0;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                    if (comboBox3.SelectedIndex == 2)
            {
                zoomFactor = 1.5;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                        if (comboBox3.SelectedIndex == 3)
            {
                zoomFactor = 2.0;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                            if (comboBox3.SelectedIndex == 4)
            {
                zoomFactor = 2.5;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f = new Form8();
            f.Show();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f = new Form4();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button13_Click_1(object sender, EventArgs e)
        {
            ImUndo = pictureBox2.Image;
            Bitmap btm1 = (Bitmap)pictureBox2.Image;
            Rectangle section = new Rectangle(new Point(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text)), new Size(Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text)));
            pictureBox2.Image = CropImage(btm1, section);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        static Image ImUndo;

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = ImUndo;
            ImUndo = null;
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Form1 fg = new Form1();
            fg.ShowDialog();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        Image sticki;
        private void button7_Click_1_3(object sender, EventArgs e)
        {
            ImgGl = pictureBox2.Image;
            using (Graphics grd = Graphics.FromImage(ImgGl))
            {
                grd.DrawImage(sticki, new Rectangle(Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text)));
            }
            pictureBox2.Image = ImgGl;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ope = new OpenFileDialog();
            ope.ShowDialog();
            sticki = Image.FromFile(ope.FileName);
        }

        /*public Bitmap GrayScale(Bitmap Bmp)
         {
             int rgb;
             Color c;
             for(int x=0;x<Bmp.Height;x++)
                 for (int y = 0; y < Bmp.Width; y++)
                 {
                     c = Bmp.GetPixel(x,y);
                     rgb = (int)((c.R + c.G + c.B) / 3);
                     Bmp.SetPixel(x,y, Color.FromArgb(rgb, rgb, rgb));
                 }
             return Bmp;
         }*/
    }
}