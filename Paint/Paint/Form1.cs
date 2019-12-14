using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap DrawBitmap;
        Graphics g;

        bool drawOn;

        bool drawL;
        bool eraser;

        SolidBrush brushColor;
        Pen penColor;

        Color colorPick;
        Color eraserColor;

        int toolSize = 25;
        int toolThickness = 1;

        Point mPOS, mPOS2;

        public Form1()
        {
            InitializeComponent();
            brushColor = new SolidBrush(Color.Black);
            penColor = new Pen(Color.Black);
            colorPick = Color.Black;
            DrawBitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            g = Graphics.FromImage(DrawBitmap);
        }

        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            mPOS.X = e.X;
            mPOS.Y = e.Y;

            if (drawOn == true)
            {
                if
                    (drawL = true)
                {
                    penColor = new Pen(colorPick, toolSize);
                    g.DrawLine(penColor, mPOS, mPOS2);
                    g.FillEllipse(brushColor, (e.X - toolSize / 2), (e.Y - toolSize / 2), toolSize, toolSize);
                }
            }
             mPOS2 = mPOS;
            pbCanvas.Image = DrawBitmap;
        }

        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            drawOn = true;
        }

        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            drawOn = false;
        }

       
    }
}
