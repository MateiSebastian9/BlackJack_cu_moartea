using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class winscreen : Form
    {
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        int livesleftc=0;
        async void render()
        {
            string stringwin = "MAI AVEAI : " + livesleftc + " sanse";
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            label1.Text = "FELICITARI!";
            label2.Text = "AI AJUNS IN RAI";
            label1.Top = screenHeight/2-label1.Size.Height;
            label2.Top = screenHeight / 2 - label2.Size.Height + label1.Size.Height;
            label1.Left = screenWidth / 2 - label1.Size.Width / 2;
            label2.Left = screenWidth /2 - label2.Size.Width / 2;
            await Task.Delay(5000);
            Application.Exit();
        }
        public winscreen(int livesleft)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            int livesleftc = livesleft;
            render();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
