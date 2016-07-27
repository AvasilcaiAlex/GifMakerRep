using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace editor
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        Color c;
        Image bm1, bm2;
        Bitmap bim, bim2;
        Image ImgGl, ImGl2;
        Image imeg, sticki;
        Image imi1, imi2, imi3, imi4, imi5;
        static Image ImUndo;

        private void Form9_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ImgGl = pictureBox2.Image;
            using (Graphics grd = Graphics.FromImage(ImgGl))
            {
                grd.DrawImage(sticki, new Rectangle(Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text)));
            }
            pictureBox2.Image = ImgGl;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            OpenFileDialog ope = new OpenFileDialog();
            ope.ShowDialog();
            sticki = Image.FromFile(ope.FileName);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            ImgGl = Image.FromFile(op.FileName);
            ImGl2 = Image.FromFile(op.FileName);
            pictureBox2.Image = Image.FromFile(op.FileName);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            c = cd.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imi2 = pictureBox2.Image;
            ImUndo = imi2;
            /*Graphics graf = pictureBox2.CreateGraphics();
            graf.DrawString(textBox1.Text, new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text)), new SolidBrush(c), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));*/
            ///imeg.PixelFormat=ImageIndexConverter.StandardValuesCollection.
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
    }
}
