using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.FFMPEG;

namespace editor
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
        VideoFileReader readero = new VideoFileReader();
        string path;
        string vec1;
        string[] vec2;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
                path = op.FileName;
        }
        Image[] vbm = new Image[15000];
        private void button2_Click(object sender, EventArgs e)
        {
            readero.Open(path);
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        int con;
        private void timer1_Tick(object sender, EventArgs e)
        {
            con++;
            if (con == readero.FrameCount)
            {
                timer1.Stop();
                readero.Close();
            }
            else
            {
                pictureBox1.Image = readero.ReadVideoFrame();
                pictureBox1.Refresh();
            }
        }
    }
}
