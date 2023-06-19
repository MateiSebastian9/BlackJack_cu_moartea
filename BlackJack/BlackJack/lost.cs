using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class lost : Form
    {
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        void render()
        {
            label1.Text = "TI-AI PIERDUT SUFLETUL";
            label1.Left= screenWidth/2 - label1.Size.Width/2;
            label1.Top= screenHeight / 2 - label1.Size.Height / 2;

            label1.ForeColor = Color.Red;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }
        public lost()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            render();
        }

        private void lost_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
