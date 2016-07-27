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
        SaveFileDialog sfd = new SaveFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            /*val = Convert.ToInt32(textBox1.Text);
            timer1.Enabled = true;*/
        }
        Image[] img = new Image[450];
        Image aux;
        int t = 0;
        int k = 0;
        float val = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opid = new OpenFileDialog();
            opid.Multiselect = true;
            /*(if (DialogResult.OK == opid.ShowDialog())
            {
                img[t] = Image.FromFile(opid.FileName);
                t++;
            }*/
            opid.ShowDialog();
            foreach (String file in opid.FileNames)
            {
                img[t] = Image.FromFile(file);
                t++;
            }
        }
        int tmp;
        private void button3_Click(object sender, EventArgs e)
        {
            /* create Gif */
            //you should replace filepath
            /*String[] imageFilePaths = new String[] { @"C:\Users\Administrator\Desktop\imagini\resurse\1.jpg", @"C:\Users\Administrator\Desktop\imagini\resurse\2.jpg", @"C:\Users\Administrator\Desktop\imagini\resurse\3.jpg", @"C:\Users\Administrator\Desktop\imagini\resurse\4.jpg", @"C:\Users\Administrator\Desktop\imagini\resurse\5.jpg" };*/
            /*String outputFilePath = @"C:\Users\Administrator\Desktop\imagini\resurse\test.gif";*/
            sfd.ShowDialog();
            tmp = Convert.ToInt32(textBox1.Text);
            String outputFilePath = sfd.FileName;
            AnimatedGifEncoder s = new AnimatedGifEncoder();
            s.Start(outputFilePath);
            tmp = tmp;
            s.SetDelay(tmp);
            //-1:no repeat,0:always repeat
            s.SetRepeat(0);
            /*for (int i = 0, count = imageFilePaths.Length; i < count; i++)
            {
                s.AddFrame(Image.FromFile(imageFilePaths[i]));
            }*/
            for (int i = 0, count = img.Length; i < count; i++)
            {
                s.AddFrame(img[i]);
            }
            /* extract Gif */
            s.Finish();
            MessageBox.Show("GIF-ul a fost creat cu succes! Apasati pe butonul 'OK' ca sa inchideti aplicatia!");
            //Application.Exit();
        }
        int tek = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tek == val && k < t)
            {
                pictureBox1.Image = img[k];
                k++;
                tek = 0;
            }
            if (k == t)
                k = 0;
            tek++;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
        int x, y;

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                val = Convert.ToInt32(textBox1.Text)/100;
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Pentru a simula GIF-ul e nevoie sa introduceti o valoare de tranzitie!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fg = new Form1();
            fg.ShowDialog();
        }
        Image originalImg;
        int lim;
        string den;
        private void button7_Click(object sender, EventArgs e)
        {
            //Image originalImg = Image.FromFile(@"C:\Users\Administrator\Desktop\gifulet\stark.gif");
            /*OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            Image originalImg = Image.FromFile(op.FileName);*/
            int numberOfFrames = originalImg.GetFrameCount(FrameDimension.Time);
            Image[] frames = new Image[numberOfFrames];
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            sd.ShowDialog();
            string[] vec = sd.FileName.Split('.');
            for (int i = 0; i < vec.Length-1; i++)
            {
                if (i != vec.Length - 2)
                    den += vec[i] + ".";
                else
                    den += vec[i];
            }
            lim = vec.Length-1;
            for (int i = 0; i < numberOfFrames; i++)
            {
                originalImg.SelectActiveFrame(FrameDimension.Time, i);
                frames[i] = ((Image)originalImg.Clone());
                //frames[i].Save(@"C:\Users\Administrator\Desktop\gifulet\" + i + ".png", ImageFormat.Png);
                frames[i].Save(den + " " + i + "." + vec[lim], ImageFormat.Png);
            }
        }
        int var1;
        private void button8_Click(object sender, EventArgs e)
        {
            // create instance of video reader
            VideoFileReader reader = new VideoFileReader();
            // open video file
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            reader.Open(open.FileName);
            SaveFileDialog sed = new SaveFileDialog();
            sed.ShowDialog();
            // read 100 video frames out of it
            for (int i = 0; i < 100; i++)
            {
                Bitmap videoFrame = reader.ReadVideoFrame();

                videoFrame.Save(sed.FileName + i + ".bmp");
            
            // dispose the frame when it is no longer required
                videoFrame.Dispose();
            }
            reader.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            originalImg = Image.FromFile(op.FileName);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            /*sfd.ShowDialog();
            tmp = 100;
            String outputFilePath = sfd.FileName;
            AnimatedGifEncoder s = new AnimatedGifEncoder();
            s.Start(outputFilePath);
            tmp = tmp;
            s.SetDelay(tmp);
            //-1:no repeat,0:always repeat
            s.SetRepeat(0);
            for (int i = 0, count = vbm.Length; i < count; i=i+3)
            {
                s.AddFrame(vbm[i]);
            }
            s.Finish();*/
            /*sfd.ShowDialog();
            tmp = Convert.ToInt32(textBox1.Text);
            String outputFilePath = sfd.FileName;
            AnimatedGifEncoder s = new AnimatedGifEncoder();
            s.Start(outputFilePath);
            tmp = tmp;
            s.SetDelay(tmp);
            s.SetRepeat(0);
            for (int i = 0; i < reader.FrameCount; i++)
            {
                s.AddFrame(vbm[i]);
            }
            s.Finish();*/
            reader.Open(path);
            /*tmp = Convert.ToInt32(textBox1.Text);
            dur = Convert.ToInt32(textBox3.Text);
            sec = reader.FrameCount / dur;
            frm = Convert.ToInt32(textBox2.Text);
            st = frm * Convert.ToInt32(sec);
            stop = Convert.ToInt32(sec) * Convert.ToInt32(textBox4.Text);*/
            sfd.ShowDialog();
            AnimatedGifEncoder s = new AnimatedGifEncoder();
            s.Start(sfd.FileName);
            s.SetDelay(tmp);
            s.SetRepeat(0);
            for (int i = 0; i < vbm.Length; i++)
            {
                s.AddFrame(vbm[i]);
            }
            s.Finish();
            MessageBox.Show("GIF-ul a fost creat cu succes! Apasati pe butonul 'OK' ca sa inchideti aplicatia!");
            //Application.Exit();
        }
        Bitmap[] vbm = new Bitmap[500];
        int dur, frm, st;
        long sec, sec1, stop;
        string path;
        int t3 = 0, sum = 0;
        int t4 = 0;
        VideoFileReader reader;
        string sir1, sir2, sir3;
        string[] vecu1;
        private void button11_Click(object sender, EventArgs e)
        {
            // create instance of video reader
             reader = new VideoFileReader();
            // open video file
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            path = open.FileName;
            reader.Open(open.FileName);
            sum = 0;
            sir3 = textBox3.Text;
            sir1 = textBox2.Text;
            sir2 = textBox4.Text;
            tmp = Convert.ToInt32(textBox1.Text);
            vecu1 = sir3.Split(':');
            dur = dur + Convert.ToInt32(vecu1[0]) * 60;
            dur = dur + Convert.ToInt32(vecu1[1]);
            sec = reader.FrameCount / dur;
            sec1 = sec;
            vecu1 = sir1.Split(':');
            sum = sum + Convert.ToInt32(vecu1[0]) * 60;
            sum = sum + Convert.ToInt32(vecu1[1]);
            st = sum * Convert.ToInt32(sec);
            vecu1 = sir2.Split(':');
            sum=0;
            sum = sum + Convert.ToInt32(vecu1[0]) * 60;
            sum = sum + Convert.ToInt32(vecu1[1]);
            stop = sec1 * sum;
            // read 100 video frames out of it
            for (int i = 0; i < reader.FrameCount; i++)
            {
                if (i > stop)
                    break;
                if (i >= st && i <= stop)
                {
                    t3++;
                    vbm[t3] = reader.ReadVideoFrame();
                }
                else
                    reader.ReadVideoFrame();
            }
            reader.Close();
        }
        int con = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
