using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BlackJack
{
    public partial class Form1 : Form
    {
        SoundPlayer player = new SoundPlayer("../../../res/music/jazz/jazz1h.wav");
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        public Form1()
        {
            InitializeComponent();
            preLoad();
        }

        void preLoad()
        {
            player.Play();
            WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.None;
            label1.Left = ( ( screenWidth / 2) - label1.Size.Width / 2 );
            label1.Top = screenHeight / 3;
            button1.Top = label1.Location.Y + label1.Size.Height + screenHeight / 15;
            button1.Left = label1.Location.X + label1.Size.Width / 2 - button1.Size.Width / 2;
            label2.Top = label1.Location.Y + label1.Size.Height;
            label2.Left = label1.Location.X + label1.Width /20;
            label3.Top = label1.Location.Y + label1.Size.Height;
            label3.Left = label1.Location.X + label1.Width * 2/3;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JocPrincipal JocPrincipal = new JocPrincipal(3);
            JocPrincipal.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            lost lost = new lost();
            lost.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}