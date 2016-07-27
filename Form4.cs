using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Gif.Components;
using AForge.Video.FFMPEG;
using System.Windows.Forms;

namespace editor
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        Image originalImg, originalImg2;
        VideoFileReader reader;
        Bitmap[] vbm = new Bitmap[150000];
        Bitmap vbm2;
        int k = 0,val, j=0,i=1;
        string path;
        string den;
        int lim;
        int numberOfFrames;
        Image frames2;
        Image[] frames = new Image[150000];

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        int limita;
        private void button8_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            originalImg = Image.FromFile(op.FileName);

            numberOfFrames = originalImg.GetFrameCount(FrameDimension.Time);
            limita = numberOfFrames;
            //Image[] frames = new Image[numberOfFrames];
            for (int i = 0; i < numberOfFrames; i++)
            {
                originalImg.SelectActiveFrame(FrameDimension.Time, i);
                frames[i] = ((Image)originalImg.Clone());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pictureBox4.Image = originalImg;
            val = Convert.ToInt32(textBox2.Text);
            timer2.Interval = val;
            timer2.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Image[] frames = new Image[numberOfFrames];
            SaveFileDialog sd = new SaveFileDialog();
            sd.ShowDialog();
            for (int i = 0; i < limita; i++)
            {
                //frames[i].Save(den + " " + i + "." + vec[lim], ImageFormat.Png);
                //frames[i].Save(sd.FileName + i, ImageFormat.Png);
                frames[i].Save(sd.FileName + i + ".bmp");
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (i < frames.Length)
            {
                
                pictureBox4.Image = frames[i];
                pictureBox4.Refresh();
                i++;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < vbm.Length ; i++)
            {
                pictureBox4.Image = vbm[i];
                pictureBox4.Refresh();
            }*/
            val = Convert.ToInt32(textBox1.Text);
            timer1.Interval = val;
            timer1.Enabled = true;
            reader.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reader.Open(path);
            SaveFileDialog sed = new SaveFileDialog();
            sed.ShowDialog();
            // read 100 video frames out of it
            for (int i = 0; i < reader.FrameCount ; i++)
            {
                Bitmap videoFrame = reader.ReadVideoFrame();

                videoFrame.Save(sed.FileName + i + ".bmp");

                // dispose the frame when it is no longer required
                videoFrame.Dispose();
            }
            reader.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if(k==0)
            {
                reader.Open(path);
            }
            k++;
            if (i < reader.FrameCount)
            {
                pictureBox4.Image = reader.ReadVideoFrame();
                pictureBox4.Refresh();
                i++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // create instance of video reader
            reader = new VideoFileReader();
            // open video file
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            path = open.FileName;
        }
    }
}
