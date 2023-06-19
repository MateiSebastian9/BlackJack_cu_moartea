using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BlackJack
{
    
    public partial class JocPrincipal : Form
    {       
        int[] usedCards = new int[56];
        public string VariableName { get; set; }
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int playerAces=0, dealerAces=0;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        PictureBox[] activeCards = new PictureBox[30];
        int[] playerVals = new int[56];
        int[] dealerVals = new int[56];
        Image[] images = new Image[4];
        Image heartfull = Image.FromFile("../../../res/carti/HEARTFULL.png");
        Image heartempty = Image.FromFile("../../../res/carti/EMPTYHEART.png");
        PictureBox[] pictureBox = new PictureBox[4];
        int showDealer = 0; int livesleft = 0; int playerCards = 2; int dealerCards = 2; int dealerSum=0; int playerSum=0;
        void clearArrs()
        {
            playerSum = dealerSum = 0;
            for(int i=1;i<=55;i++)
                playerVals[i] = dealerVals[i] = 0;
        }
        async void win()
        {
            button1.Enabled = button2.Enabled = false;
            await Task.Delay(5000);
            winscreen win = new winscreen(livesleft);
            win.Show();
            this.Hide();
        }
        async void newRound()
        {
            button1.Enabled = button2.Enabled = false;
            await Task.Delay(5000);
            JocPrincipal JocPrincipal = new JocPrincipal(livesleft);
            JocPrincipal.Show();
            this.Hide();
        }
        async void lose()
        {
            button1.Enabled = button2.Enabled = false;
            await Task.Delay(5000);
            lost lost = new lost();
            lost.Show();
            this.Hide();
        }
        async void checkEnd()
        {

            int sw4 = 1;
            if (showDealer >= 1)
            {

                while (dealerSum <= 16 && sw4 == 1 && dealerAces!=0 && dealerSum+10<=21)
                {
                    dealerSum += 10;
                    dealerAces--;
                }
                if(dealerSum <= 16 && sw4 == 1)
                {

                    await Task.Delay(5000);
                    dealerCards++;
                    rendercards();
                    sw4 = 0;
                }
                if (dealerSum > 21 && sw4 == 1)
                {
                    win();
                    sw4 = 0;
                }
                if (dealerSum == playerSum && sw4 == 1)
                {
                    sw4 = 0;
                    newRound();
                }
                if (dealerSum > 16)
                {
                    while(playerSum + 10 <= 21 && playerAces!=0)
                    {
                        playerSum += 10;
                    }
                    while (dealerSum + 10 <= 21 && dealerAces != 0)
                    {
                        dealerSum += 10;
                    }
                    if (dealerSum >= playerSum && sw4 == 1)
                    {
                        livesleft -= 1;
                        newRound();
                    }
                    else if (sw4 == 1) win();
                    sw4 = 0;
                }
            }
            if (playerSum == 21 && sw4 == 1)
            {
                win();
                sw4 = 0;
            }
            while (playerAces != 0 && playerSum + 10 <= 21)
            {
                playerSum += 10;
            if (playerSum == 21 && sw4 == 1)
            {
                win();
                sw4 = 0;
            }
        }
            if (playerSum > 21 && sw4 == 1)
            {
                if (livesleft > 0 && sw4 == 1)
                {
                    livesleft -= 1;
                    clearArrs();
                    playerCards = dealerCards = 2;
                    for (int i = 1; i <= 3; i++)
                    {
                        if (livesleft < i)
                        {
                            pictureBox[i].Image = heartempty;
                        }
                        else
                        {
                            pictureBox[i].Image = heartfull;
                        }
                    }
                    newRound();
                      sw4 = 0;
                    }
                else
                {
                    lose();
                    sw4 = 0;
                 }
            }
        
       }
        void render()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            button2.Enabled = button1.Enabled = false;
            button2.Top = button1.Top = screenHeight - screenHeight / 5;
            button1.Width = button2.Width = screenWidth / 10;
            button1.Height = button2.Height = screenWidth / 30;
            button2.Left = screenWidth / 3; button1.Left = button2.Left + screenWidth / 5; 
            for (int i = 1; i <= 3; i++)
            {
     
                pictureBox[i] = new PictureBox();
                if(livesleft < i)
                {
                    pictureBox[i].Image = heartempty;
                }
                else
                {
                    pictureBox[i].Image = heartfull;
                }
                pictureBox[i].Height = pictureBox[i].Width = screenHeight / 10;        
                pictureBox[i].Top = screenHeight / 4  + (screenHeight/10)*i;
                pictureBox[i].Left = screenWidth - screenWidth / 10; ;
                pictureBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Controls.Add(pictureBox[i]);
            }
        }
        void rendercards()
        {
            int cardWidth = screenHeight / 6;
            int cardHeight = screenHeight / 4;
            int cardGap = cardWidth / 4;
            int totalCardWidth = dealerCards * (cardWidth + cardGap) - cardGap;
            int startDealerPosition = (screenWidth - totalCardWidth) / 2;
            Controls.Remove(activeCards[1]);
            Image hiddenCard = Image.FromFile("../../../res/carti/BACK.png");
            activeCards[1] = new PictureBox();
            if (showDealer == 0)
            {
                activeCards[1].Image = hiddenCard;
            }
            else if (showDealer >= 1)
            {
                if (dealerVals[1] == 0)
                {
                    int summonedcardDealer = generatenum();
                    dealerVals[1] = summonedcardDealer;

                    if (summonedcardDealer <= 10 || summonedcardDealer % 10 == 0 || summonedcardDealer == 51 || summonedcardDealer == 52)
                        dealerSum += 10;
                    else
                        dealerSum += summonedcardDealer % 10;
                }
                string cardpartialname = (dealerVals[1]) + ".png";
                string currentpath = Path.Combine("../../../res/carti/", cardpartialname);
                activeCards[1].Image = Image.FromFile(currentpath);
            }

            for (int i = 1; i <= dealerCards; i++)
            {
                if (i != 1 && dealerVals[i] == 0)
                {
                    int summonedcardDealer = generatenum();
                    dealerVals[i] = summonedcardDealer;
                    if(summonedcardDealer % 10 == 1)dealerAces++;
                    if (summonedcardDealer <= 10 || summonedcardDealer % 10 == 0 || summonedcardDealer == 51 || summonedcardDealer == 52) dealerSum += 10;
                    else dealerSum += summonedcardDealer % 10;
                    activeCards[i] = new PictureBox();
                    string cardpartialname = (summonedcardDealer) + ".png";
                    string currentpath = Path.Combine("../../../res/carti/", cardpartialname);
                    activeCards[i].Image = Image.FromFile(currentpath);
                }
                activeCards[i].Height = activeCards[i].Width = screenHeight / 10;
                activeCards[i].SizeMode = PictureBoxSizeMode.StretchImage;
                activeCards[i].Top = screenHeight / 8;
                activeCards[i].Left = startDealerPosition + (i - 1) * (cardWidth + cardGap);
                Controls.Add(activeCards[i]);
                activeCards[i].Height = screenHeight / 4;
                activeCards[i].Width = screenHeight / 6;

            }
            totalCardWidth = playerCards * (cardWidth + cardGap) - cardGap;
            int startPlayerPosition = (screenWidth - totalCardWidth) / 2;
            int playerCardIndex = 1;
            for (int i = dealerCards + 1; i <= dealerCards + playerCards; i++, playerCardIndex++)
            {
                if (playerVals[i + 2 - dealerCards] == 0)
                {
                    int summonedcardPlayer = generatenum();
                    playerVals[i + 2 - dealerCards] = summonedcardPlayer;
                    if (summonedcardPlayer % 10 == 1) playerAces++;
                    if (summonedcardPlayer <= 10 || summonedcardPlayer % 10 == 0 || summonedcardPlayer == 51 || summonedcardPlayer == 52) playerSum += 10;
                    else playerSum += summonedcardPlayer % 10;
                    activeCards[i] = new PictureBox();
                    string cardpartialname = (summonedcardPlayer) + ".png";
                    string currentpath = Path.Combine("../../../res/carti/", cardpartialname);
                    activeCards[i].Image = Image.FromFile(currentpath);
                }
                    activeCards[i].Height = activeCards[i].Width = screenHeight / 10;
                    activeCards[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    activeCards[i].Top = screenHeight / 2;
                    activeCards[i].Left = startPlayerPosition + (playerCardIndex - 1) * (cardWidth + cardGap);
                    Controls.Add(activeCards[i]);
                    activeCards[i].Height = screenHeight / 4;
                    activeCards[i].Width = screenHeight / 6;
                
            }
            checkEnd();

        }
        void startgame()
        {
            for (int i = 1; i <= 55; i++)
        {
            usedCards[i] = 0;
        }
            rendercards();
            button1.Enabled = button2.Enabled = true;
        }

        int generatenum()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 52);
           while (usedCards[randomNumber] == 1)
            {
                usedCards[randomNumber]++;
                randomNumber = random.Next(1, 52);

            }
            return randomNumber;
        }
        public struct PlayingCards
        {
            bool used;
            int val;
        }
        public JocPrincipal(int livesleftc)
        {
            InitializeComponent();
            livesleft = livesleftc;
            render();
            startgame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerCards++;
            rendercards();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            showDealer += 1;
            button1.Enabled = button2.Enabled = false;
            Controls.Remove(activeCards[1]);
            rendercards();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void JocPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
