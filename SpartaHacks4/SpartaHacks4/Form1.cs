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

            this.Refresh();

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
