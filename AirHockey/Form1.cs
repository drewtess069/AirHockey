using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace AirHockey
{
    public partial class Form1 : Form
    {
        //Air Hockey Game -- Drew Tessmer, May 3
        //This is a virtual representation of an Air Hockey Game


        SoundPlayer puckPlayer = new SoundPlayer(Properties.Resources.puckBounce);

        Rectangle border = new Rectangle(5, 5, 390, 490);
        Rectangle player1 = new Rectangle(180, 20, 40, 10);
        Rectangle player2 = new Rectangle(176, 470, 40, 10);
        Rectangle ball = new Rectangle(192, 248, 10, 10);
        Rectangle net1 = new Rectangle(140, 0, 120, 10);
        Rectangle net2 = new Rectangle(136, 490, 120, 10);

        Pen blackPen = new Pen(Color.Black, 10);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        int player1Score;
        int player2Score;

        int playerSpeed = 3;
        float ballXSpeed = 4;
        float ballYSpeed = 4;

        int maxXSpeed = 8;
        int maxYSpeed = 8;

        int minXSpeed = -8;
        int minYSpeed = -8;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(blackPen, border);
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(blackBrush, ball);
            e.Graphics.FillRectangle(whiteBrush, net1);
            e.Graphics.FillRectangle(whiteBrush, net2);

            /* e.Graphics.FillRectangle(blueBrush, p1Sec1);
             e.Graphics.FillRectangle(blueBrush, p1Sec2);
             e.Graphics.FillRectangle(blueBrush, p1Sec3);
             e.Graphics.FillRectangle(blueBrush, p1Sec4);
            */
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move ball 
            ball.X += (int)ballXSpeed;
            ball.Y += (int)ballYSpeed;

            //move player 1 
            //if ((wDown == true) && (player1.Y > blackPen.Width) && (p1Sec1.Y > blackPen.Width) && (p1Sec2.Y > blackPen.Width) && (p1Sec3.Y > blackPen.Width) && (p1Sec4.Y > blackPen.Width))
            if ((wDown == true) && (player1.Y > blackPen.Width))
            {
                player1.Y -= playerSpeed;

            }

            //if ((aDown == true) && (player1.X > 0 + blackPen.Width) && (p1Sec1.X > 0 + blackPen.Width) && (p1Sec2.X > 0 + blackPen.Width) && (p1Sec3.X > 0 + blackPen.Width) && (p1Sec4.X > 0 + blackPen.Width))
            if ((aDown == true) && (player1.X > 0 + blackPen.Width))
            {
                player1.X -= playerSpeed;
            }

            //if ((sDown == true) && (player1.Y < this.Height / 2 - player1.Height) && (p1Sec1.Y < this.Height / 2 - player1.Height) && (p1Sec2.Y < this.Height / 2 - player1.Height) && (p1Sec3.Y < this.Height / 2 - player1.Height) && (p1Sec4.Y < this.Height / 2 - player1.Height))
            if ((sDown == true) && (player1.Y < this.Height / 2 - player1.Height))
            {
                player1.Y += playerSpeed;
            }

            //if ((dDown == true) && (player1.X < this.Width - blackPen.Width - player1.Width) && (p1Sec1.X < this.Width - blackPen.Width - player1.Width) && (p1Sec2.X < this.Width - blackPen.Width - player1.Width) && (p1Sec3.X < this.Width - blackPen.Width - player1.Width) && (p1Sec4.X < this.Width - blackPen.Width - player1.Width))
            if ((dDown == true) && (player1.X < this.Width - blackPen.Width - player1.Width))

            {
                player1.X += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > this.Height / 2)
            {
                player2.Y -= playerSpeed;
            }
            if (leftArrowDown == true && player2.X > 0 + blackPen.Width)
            {
                player2.X -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - blackPen.Width - player2.Height)
            {
                player2.Y += playerSpeed;
            }
            if (rightArrowDown == true && player2.X < this.Width - blackPen.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //check if ball goes in either net
            //Adjust score accordingly
            if (net1.IntersectsWith(ball))
            {
                player1Score++;
                p1ScoreLabel.Text = Convert.ToString(player1Score);

                Goal();
            }
            if (net2.IntersectsWith(ball))
            {
                player2Score++;
                p2ScoreLabel.Text = Convert.ToString(player2Score);

                Goal();
            }

            //Set boundaries for ball
            if (ball.Y < blackPen.Width || ball.Y > this.Height - blackPen.Width - ball.Height)
            {
                puckPlayer.Play();
                ballYSpeed *= -1;
            }
            if (ball.X > this.Width - blackPen.Width - ball.Width)
            {
                puckPlayer.Play();
                ballXSpeed *= -1;
            }
            if (ball.X < blackPen.Width)
            {
                puckPlayer.Play();
                ballXSpeed *= -1;
            }

            //check if ball hits either player. If it does change the direction 
            //and place the ball in front of the player hit 

            if (player1.IntersectsWith(ball) && (ballYSpeed > 0) && (ballYSpeed > minYSpeed) && (ballXSpeed > minXSpeed) && (ballYSpeed < maxYSpeed) && (ballXSpeed < maxXSpeed))
            {
                ballYSpeed *= -1;

                Rectangle p1Sec1 = new Rectangle(player1.X, player1.Y - 1, 8, 12);
                Rectangle p1Sec2 = new Rectangle(player1.X + 8, player1.Y - 1, 8, 12);
                Rectangle p1Sec3 = new Rectangle(player1.X + 24, player1.Y - 1, 8, 12);
                Rectangle p1Sec4 = new Rectangle(player1.X + 32, player1.Y - 1, 8, 12);
                Rectangle p1Sec5 = new Rectangle(player1.X + 16, player1.Y - 1, 8, 12);

                puckPlayer.Play();
                if (p1Sec1.IntersectsWith(ball))
                {

                    if (ballXSpeed < 5)
                    {
                        ballXSpeed = -5f;

                        ball.Y = player1.Y - ball.Height - 3;
                    }
                    else
                    {
                        ballXSpeed = -2f;
                        ball.Y = player1.Y - ball.Height - 3;
                    }
                }
                else if (p1Sec2.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player1.Y - ball.Height - 3;
                }
                else if (p1Sec3.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player1.Y - ball.Height - 3;
                }
                if (p1Sec4.IntersectsWith(ball))
                {
                    if (ballXSpeed < 5)
                    {
                        ballXSpeed = 4f;

                        ball.Y = player1.Y - ball.Height - 3;
                    }
                    else
                    {
                        ballXSpeed = 2f;

                        ball.Y = player1.Y - ball.Height - 3;
                    }
                }
                else if (p1Sec5.IntersectsWith(ball))
                {

                    ball.Y = player1.Y - ball.Height - 3;
                }
            }
            if ((ballYSpeed > maxYSpeed) || (ballYSpeed < minYSpeed))
            {
                ballYSpeed -= 1f;
            }
            if ((ballXSpeed > maxXSpeed) || (ballXSpeed < minXSpeed))
            {
                ballXSpeed *= 0.9f;
            }


            if (player1.IntersectsWith(ball) && ballYSpeed < 0)
            {
                Rectangle p1Sec1 = new Rectangle(player1.X, player1.Y - 1, 8, 12);
                Rectangle p1Sec2 = new Rectangle(player1.X + 8, player1.Y - 1, 8, 12);
                Rectangle p1Sec3 = new Rectangle(player1.X + 24, player1.Y - 1, 8, 12);
                Rectangle p1Sec4 = new Rectangle(player1.X + 32, player1.Y - 1, 8, 12);
                Rectangle p1Sec5 = new Rectangle(player1.X + 16, player1.Y - 1, 8, 12);

                ballYSpeed *= -1;
                puckPlayer.Play();

                if (p1Sec1.IntersectsWith(ball))
                {

                    if (ballXSpeed < 5)
                    {

                        ballXSpeed = -5f;

                        ball.Y = player1.Y + ball.Height + 3;
                    }
                    else
                    {
                        ballXSpeed = -2f;

                        ball.Y = player1.Y + ball.Height + 3;
                    }
                }
                else if (p1Sec2.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player1.Y + ball.Height + 3;
                }
                else if (p1Sec3.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player1.Y + ball.Height + 3;
                }
                if (p1Sec4.IntersectsWith(ball))
                {
                    if (ballYSpeed < -5)
                    {

                        ballXSpeed = 5f;

                        ball.Y = player1.Y + ball.Height + 3;
                    }
                    else
                    {
                        ballXSpeed = 2f;

                        ball.Y = player1.Y + ball.Height + 3;
                    }
                }
                else if (p1Sec5.IntersectsWith(ball))
                {
                    ballYSpeed *= -1;

                    ball.Y = player1.Y + ball.Height + 3;
                }
            }

            // Set up player 2 intersections
            if (player2.IntersectsWith(ball) && (ballYSpeed > 0) && (ballYSpeed > minYSpeed) && (ballXSpeed > minXSpeed) && (ballYSpeed < maxYSpeed) && (ballXSpeed < maxXSpeed))
            {
                ballYSpeed *= -1;

                Rectangle p2Sec1 = new Rectangle(player2.X, player1.Y - 1, 8, 12);
                Rectangle p2Sec2 = new Rectangle(player2.X + 8, player2.Y - 1, 8, 12);
                Rectangle p2Sec3 = new Rectangle(player2.X + 24, player2.Y - 1, 8, 12);
                Rectangle p2Sec4 = new Rectangle(player2.X + 32, player2.Y - 1, 8, 12);
                Rectangle p2Sec5 = new Rectangle(player2.X + 16, player2.Y - 1, 8, 12);

                if (p2Sec1.IntersectsWith(ball))
                {
                    if (ballXSpeed < 5)
                    {
                        ballXSpeed = -5f;

                        ball.Y = player2.Y - ball.Height - 3;
                    }
                    else
                    {
                        ballXSpeed = -2f;
                        ball.Y = player2.Y - ball.Height - 3;
                    }
                }
                else if (p2Sec2.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player2.Y - ball.Height - 3;
                }
                else if (p2Sec3.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player2.Y - ball.Height - 3;
                }
                if (p2Sec4.IntersectsWith(ball))
                {
                    if (ballXSpeed < 5)
                    {
                        ballXSpeed = 4f;

                        ball.Y = player2.Y - ball.Height - 3;
                    }
                    else
                    {
                        ballXSpeed = 2f;

                        ball.Y = player2.Y - ball.Height - 3;
                    }
                }
                else if (p2Sec5.IntersectsWith(ball))
                {
                    ball.Y = player2.Y - ball.Height - 3;
                }
            }
            if ((ballYSpeed > maxYSpeed) || (ballYSpeed < minYSpeed))
            {
                ballYSpeed -= 1f;
            }
            if ((ballXSpeed > maxXSpeed) || (ballXSpeed < minXSpeed))
            {
                ballXSpeed *= 0.9f;
            }
            if (player2.IntersectsWith(ball) && ballYSpeed < 0)
            {
                Rectangle p2Sec1 = new Rectangle(player2.X, player1.Y - 1, 8, 12);
                Rectangle p2Sec2 = new Rectangle(player2.X + 8, player2.Y - 1, 8, 12);
                Rectangle p2Sec3 = new Rectangle(player2.X + 24, player2.Y - 1, 8, 12);
                Rectangle p2Sec4 = new Rectangle(player2.X + 32, player2.Y - 1, 8, 12);
                Rectangle p2Sec5 = new Rectangle(player2.X + 16, player2.Y - 1, 8, 12);

                ballYSpeed *= -1;

                if (p2Sec1.IntersectsWith(ball))
                {

                    if (ballXSpeed < 5)
                    {

                        ballXSpeed = -5f;

                        ball.Y = player2.Y + ball.Height + 3;
                    }
                    else
                    {
                        ballXSpeed = -2f;

                        ball.Y = player2.Y + ball.Height + 3;
                    }
                }
                else if (p2Sec2.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player2.Y + ball.Height + 3;
                }
                else if (p2Sec3.IntersectsWith(ball))
                {
                    ballXSpeed *= 1.5f;

                    ball.Y = player2.Y + ball.Height + 3;
                }
                if (p2Sec4.IntersectsWith(ball))
                {
                    if (ballYSpeed < -5)
                    {

                        ballXSpeed = 5f;

                        ball.Y = player2.Y + ball.Height + 3;
                    }
                    else
                    {
                        ballXSpeed = 2f;

                        ball.Y = player2.Y + ball.Height + 3;
                    }
                }
                else if (p2Sec5.IntersectsWith(ball))
                {
                    ballYSpeed *= -1;

                    ball.Y = player1.Y + ball.Height + 3;
                }
            }

            if (player1Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "PLAYER 1 WINS!";
            }
            else if (player2Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "PLAYER 2 WINS!";
            }
            Refresh();
        }

        private void Goal()
        {
            SoundPlayer goalPlayer = new SoundPlayer(Properties.Resources.goal);
            goalPlayer.Play();

            ball.X = 192;
            ball.Y = 248;

            player1.X = 180;
            player1.Y = 20;

            player2.X = 176;
            player2.Y = 470;


            ballXSpeed = 3;
            ballYSpeed = 4;

            Refresh();
            Thread.Sleep(1000);

            ballYSpeed *= -1;
        }
    }
}
