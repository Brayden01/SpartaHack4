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
        bool moodScreen;
        int mood;
        int Face1Size, Face2Size, Face3Size, Face4Size, Face5Size;
        Rectangle rFace1, rFace2, rFace3, rFace4, rFace5;

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
            rCloud1 = new Rectangle(0,0, 1024, 380);
            rCloud2 = new Rectangle(1024, 0, 1024, 380);
            rStartBackground = new Rectangle(0, 0, 1024, 576);

            #endregion
            #region MoodScreen
                //Creates Face Rectangles
            rFace1 = new Rectangle(242, 300, 100, 100);
            rFace2 = new Rectangle(352, 300, 100, 100);
            rFace3 = new Rectangle(462, 300, 100, 100);
            rFace4 = new Rectangle(572, 300, 100, 100);
            rFace5 = new Rectangle(682, 300, 100, 100);
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        #region Start timer
            if ((play == false) || (moodScreen == true))
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
            #region Mood Faces Movement
            //ONE Face Enlarge on Hover
            if (Face1Size == 1)
            {
                rFace1.Y -= 5;
                if (rFace1.Y <= 275)
                    Face1Size = 2;
            }
            if (Face1Size == 2)
            {
                if (rFace1.Y != 300)
                rFace1.Y += 5;
                if (rFace1.Y >= 300)
                    Face1Size = 0;
            }

            //TWO Face Enlarge on Hover
            if (Face2Size == 1)
            {
                rFace2.Y -= 5;
                if (rFace2.Y <= 275)
                    Face2Size = 2;
            }
            if (Face2Size == 2)
            {
                if (rFace2.Y != 300)
                rFace2.Y += 5;
                if (rFace2.Y >= 300)
                    Face2Size = 0;
            }

            //THREE Face Enlarge on Hover
            if (Face3Size == 1)
            {
                rFace3.Y -= 5;
                if (rFace3.Y <= 275)
                    Face3Size = 2;
            }
            if (Face3Size == 2)
            {
                if (rFace3.Y != 300)
                rFace3.Y += 5;
                if (rFace3.Y >= 300)
                    Face3Size = 0;
            }

            //FOUR Face Enlarge on Hover
            if (Face4Size == 1)
            {
                rFace4.Y -= 5;
                if (rFace4.Y <= 275)
                    Face4Size = 2;
            }
            if (Face4Size == 2)
            {
                if (rFace4.Y != 300)
                rFace4.Y += 5;
                if (rFace4.Y >= 300)
                    Face4Size = 0;
            }

            //FIVE Face Enlarge on Hover
            if (Face5Size == 1)
            {
                rFace5.Y -= 5;
                if (rFace5.Y <= 275)
                    Face5Size = 2;
            }
            if (Face5Size == 2)
            {
                if (rFace5.Y != 300)
                rFace5.Y += 5;
                if (rFace5.Y >= 300)
                    Face5Size = 0;
            }



            #endregion

            this.Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region Start Screen Paint
            if ((moodScreen == true) || (play == false))
            {
                //Clouds/Background
                e.Graphics.DrawImage(Properties.Resources.Background, rStartBackground);
                e.Graphics.DrawImage(Properties.Resources.Clouds, rCloud1);
                e.Graphics.DrawImage(Properties.Resources.Clouds, rCloud2);
            }
                if (play == false)
                {
                    //Draws Start/Chatbot buttons
                    e.Graphics.DrawImage(Properties.Resources.PlayButton, rStartButton);
                    e.Graphics.DrawImage(Properties.Resources.ChatButton, rChatbot);
                }
            
            #endregion
            #region Mood Screen Paint
            if (moodScreen == true)
            {
                e.Graphics.DrawString("How are you feeling today?".ToString(), new System.Drawing.Font("Impact", 39), Brushes.Black, 220, 200);
                e.Graphics.DrawImage(Properties.Resources.Face1, rFace1);
                e.Graphics.DrawImage(Properties.Resources.Face2, rFace2);
                e.Graphics.DrawImage(Properties.Resources.Face3, rFace3);
                e.Graphics.DrawImage(Properties.Resources.Face4, rFace4);
                e.Graphics.DrawImage(Properties.Resources.Face5, rFace5);

            }


            #endregion

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
                    moodScreen = true;
                }

                if (rChatbot.Contains(e.Location))
                {
                    chatbot = true;
                }
            }
            #endregion
            #region Mood Screen

            if (rFace1.Contains(e.Location))
            {
                mood = 1;
            }
            if (rFace2.Contains(e.Location))
            {
                mood = 2;
            }
            if (rFace3.Contains(e.Location))
            {
                mood = 3;
            }
            if (rFace4.Contains(e.Location))
            {
                mood = 4;
            }
            if (rFace5.Contains(e.Location))
            {
                mood = 5;
            }

            #endregion

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (moodScreen == true)
            {
                if (rFace1.Contains(e.Location))
                    Face1Size = 1;


                if (rFace2.Contains(e.Location))
                    Face2Size = 1;

                if (rFace3.Contains(e.Location))
                    Face3Size = 1;

                if (rFace4.Contains(e.Location))
                    Face4Size = 1;

                if (rFace5.Contains(e.Location))
                    Face5Size = 1;



            }
        }

      

      

      

       
    }
}
