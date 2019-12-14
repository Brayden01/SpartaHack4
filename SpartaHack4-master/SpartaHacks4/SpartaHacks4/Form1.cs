using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpartaHacks4
{
    public partial class Form1 : Form
    {
        #region Start Screen

        //Start Screen Buttons
        bool play;
        Rectangle rStartButton;
        bool chatbot;
        Rectangle rChatbot;
        //Start Screen Clouds/Background
        int cloudVel = 4;
        Rectangle rCloud1;
        Rectangle rCloud2;
        Rectangle rStartBackground;

        #endregion
        #region Happy Scale

        #endregion
        #region Meditation

        bool meditation;
        bool medFit;
        int MedWidth = 0;
        int MedHeight = 0;
        Rectangle rMedCircle;
        Rectangle rMedOutline;
        #endregion
        #region 6ix9ine

        Image img = Properties.Resources._69;

        int count;
        int row;
        int col;

        int sheetHeight;
        int sheetWidth;
        int spriteWidth;
        int spriteHeight;
        int totalRows;
        int totalCols;

        Rectangle r69 = new Rectangle();
        #endregion


        public Form1()
        {
            InitializeComponent();
            #region Start Screen Initialize
            //Start Screen Initialization _____________
            //Buttons
            rStartButton = new Rectangle(362, 188, 300, 100);
            rChatbot = new Rectangle(362, 318, 300, 100);
            //Clouds/Background
            rCloud1 = new Rectangle(0, 0, 1024, 380);
            rCloud2 = new Rectangle(1024, 0, 1024, 380);
            rStartBackground = new Rectangle(0, 0, 1024, 576);

            #endregion
            #region MedLevelInitials
            meditation = false;
            rMedCircle = new Rectangle(this.Width / 2 - MedWidth / 2, this.Height / 2 - MedHeight / 2, MedWidth, MedHeight);
            rMedOutline = new Rectangle(this.Width / 2 - 205, this.Height / 2 - 220, 400, 400);
            #endregion
            #region 6ix9ine
            img = Properties.Resources._69;
            sheetWidth = img.Width;
            sheetHeight = img.Height;
            totalRows = 1;
            totalCols = 4;
            spriteWidth = sheetWidth / totalCols;
            spriteHeight = sheetHeight / totalRows;

            r69 = new Rectangle(-50, 375, spriteWidth * 2, spriteHeight * 2);
            #endregion

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Start timer
            if (play == false)
            {
                //Cloud Movement
                rCloud1.X -= cloudVel;
                rCloud2.X -= cloudVel;

                if (rCloud1.X <= -1024)
                    rCloud1.X = 1024;

                if (rCloud2.X <= -1024)
                    rCloud2.X = 1024;
            }
            #endregion
            #region MedTimer
            if (meditation == true)
            {
                if (rMedCircle.Width >= 400)
                    medFit = true;
                else if (rMedCircle.Width < 2)
                    medFit = false;

                if (medFit == false)
                {
                    MedWidth += 2;
                    MedHeight += 2;
                    rMedCircle = new Rectangle(this.Width / 2 - MedWidth / 2 - 5, this.Height / 2 - MedHeight / 2 - 20, MedWidth, MedHeight);
                }
                else if (medFit == true)
                {
                    MedWidth -= 2;
                    MedHeight -= 2;
                    rMedCircle = new Rectangle(this.Width / 2 - MedWidth / 2 - 5, this.Height / 2 - MedHeight / 2 - 20, MedWidth, MedHeight);
                }
            }
            #endregion

            this.Refresh();
        }
        private void Sprite_Tick(object sender, EventArgs e)
        {
            if (count >= (totalRows * totalCols))
            {
                count = 0;
            }
            row = 0;
            col = count % totalCols;  //returns the remainder only (no integer)

            // increment the counter
            count += 1;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region Start Screen Paint
            if (play == false)
            {
                //Clouds/Background

                e.Graphics.DrawImage(Properties.Resources.Background, rStartBackground);
                e.Graphics.DrawImage(Properties.Resources.Clouds, rCloud1);
                e.Graphics.DrawImage(Properties.Resources.Clouds, rCloud2);
                //Draws Start/Chatbot buttons
                e.Graphics.DrawImage(Properties.Resources.PlayButton, rStartButton);
                e.Graphics.DrawImage(Properties.Resources.ChatButton, rChatbot);

            }
            #endregion
            #region Meditation Level
            if (meditation == true)
            {

                e.Graphics.DrawImage(Properties.Resources.medBackground, 0, 0, 1024, 576);
                e.Graphics.FillEllipse(Brushes.White, rMedCircle);
                e.Graphics.DrawEllipse(Pens.White, rMedOutline);
            }
            #endregion
            e.Graphics.DrawImage(img, r69, new RectangleF(col * spriteWidth, row * spriteHeight, spriteWidth, spriteHeight), GraphicsUnit.Pixel);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            #region Start Screen
            if (play == false)
            {
                //Start Screen Button Click
                if (rStartButton.Contains(e.Location))
                {
                    play = true;
                    meditation = true;
                }

                if (rChatbot.Contains(e.Location))
                {
                    chatbot = true;
                }
            }
            #endregion

        }

 



    }
}
