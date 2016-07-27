using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gif.Components;
using AForge.Video.FFMPEG;
using System.Drawing.Imaging;

namespace editor
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        Image[] img = new Image[450];
        Image aux;
        int t = 0;
        int k = 0;
        int val = 0;
        int tmp;
        SaveFileDialog sfd = new SaveFileDialog();

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                val = Convert.ToInt32(textBox1.Text);
                timer1.Interval = val;
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Pentru a simula GIF-ul e nevoie sa introduceti o valoare de tranzitie!");
            }
        }

        int tek =0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tek == val && k < t)
            {
                pictureBox2.Image = img[k];
                pictureBox2.Refresh();
                k++;
                tek = 0;
            }
            if (k == t)
                k = 0;
            tek++;
        }

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
        VideoFileReader reader;
        string path;
        string sir1, sir2, sir3;
        int t3, sum, dur, frm, frm2;
        long sec, sec1, stop,st;
        Image[] vbm = new Image[1500];
        string[] vecu1;
        Image originalIMG;
        long number;
        SaveFileDialog sed = new SaveFileDialog();
        VideoFileReader[] read = new VideoFileReader[3500];
        private void button11_Click(object sender, EventArgs e)
        {
            // create instance of video reader
            reader = new VideoFileReader();
            // open video file
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            path = open.FileName;
            reader.Open(path);
            sir1 = textBox5.Text;
            vecu1=sir1.Split(':');
            dur = dur + Convert.ToInt32(vecu1[0]) * 60;
            dur = dur + Convert.ToInt32(vecu1[1]);
            sec = reader.FrameCount / dur;
            sir2 = textBox2.Text;
            vecu1 = sir2.Split(':');
            frm = frm + Convert.ToInt32(vecu1[0]) * 60;
            frm = frm + Convert.ToInt32(vecu1[1]);
            sir3 = textBox4.Text;
            vecu1 = sir3.Split(':');
            frm2 = frm2 + Convert.ToInt32(vecu1[0]) * 60;
            frm2 = frm2 + Convert.ToInt32(vecu1[1]);
            st = frm * sec;
            stop = frm2 * sec;
            // read 100 video frames out of it
            Image cont;
            for(int i = 0; i < reader.FrameCount; i++)
            {
                if (i > stop)
                    break;
                if (i >= st && i <= stop)
                {
                    t3++;
                    vbm[t3] = reader.ReadVideoFrame();
                }
                if (i < st)
                {
                    cont = reader.ReadVideoFrame();
                    cont.Dispose();
                }
            }
            reader.Close();
        }
        int tmp1;
        private void button10_Click(object sender, EventArgs e)
        {
            reader.Open(path);
            sfd.ShowDialog();
            tmp1 = Convert.ToInt32(textBox3.Text);
            AnimatedGifEncoder s = new AnimatedGifEncoder();
            s.Start(sfd.FileName);
            s.SetDelay(tmp1);
            s.SetRepeat(0);
            for (int i = 0; i < vbm.Length; i++)
            {
                s.AddFrame(vbm[i]);
            }
            s.Finish();
            MessageBox.Show("GIF-ul a fost creat cu succes! Apasati pe butonul 'OK' ca sa inchideti aplicatia!");
        }
    }
}
