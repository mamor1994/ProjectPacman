using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;



namespace ProjectPacman
{
    public partial class EasyGameForm : Form
    {

        bool goup, godown, goleft, goright, isGameOver;

        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;

        int remainingTime; 

        //private SoundPlayer coinSoundPlayer;

        private string name;

        private string selectedDifficulty;



        public EasyGameForm(string name, string selectedDifficulty)
        {
            InitializeComponent();

            resetGame(selectedDifficulty);
            StartCountdownTimer(selectedDifficulty);

            //coinSoundPlayer = new SoundPlayer("pacManEating.wav");

            //coinSoundPlayer = new SoundPlayer();
            //coinSoundPlayer.SoundLocation = @"C:\Users\User\Documents\ProjectPacman\ProjectPacman\ProjectPacman\music\mysound.wav";

            this.name = name;
            this.selectedDifficulty = selectedDifficulty;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }



        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right) 
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame(selectedDifficulty);

            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;
            }
            if (goright == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;
            }
            if (godown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;
            }
            if (goup == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }

            if (pacman.Left < -10)
            {
                pacman.Left = 680;
            }
            if (pacman.Left > 680)
            {
                pacman.Left = -10;
            }

            if (pacman.Top < -10)
            {
                pacman.Top = 550;
            }
            if (pacman.Top > 550)
            {
                pacman.Top = 0;
            }


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            x.Visible = false;
                            score++;
                            txtScore.Text = "Score: " + score;
                           // coinSoundPlayer.Play(); 

                        }
                    }

                    if ((string)x.Tag == "wall")
                    {

                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            
                            if (goleft)
                                pacman.Left += playerSpeed;
                            if (goright)
                                pacman.Left -= playerSpeed;
                            if (godown)
                                pacman.Top -= playerSpeed;
                            if (goup)
                                pacman.Top += playerSpeed;
                        }

                        if (pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }

                    }

                    if ((string)x.Tag == "ghost")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            TerminateGame();
                            gameOver("You Lose!");
                        }
                    }
                }

            }


            //moving ghost

            //red

            redGhost.Left += redGhostSpeed;

            if (redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            //yellow

            yellowGhost.Left -= yellowGhostSpeed;

            if (yellowGhost.Bounds.IntersectsWith(pictureBox20.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            // pink

            pinkGhost.Left += pinkGhostX;
           

            if (pinkGhost.Left < 0 || pinkGhost.Left > ClientSize.Width - pinkGhost.Width)
            {
                pinkGhostX = -pinkGhostX;
            }



            if (score >= 46)
            {
                TerminateGame();
                //gameOver("You Win!");
            }
            
        }
        

        private void resetGame(string selectedDifficulty)
        {
            txtScore.Text = "Score: 0";
            score = 0;

            if (selectedDifficulty == "Easy")
            {
                remainingTime = 60;
                redGhostSpeed = 5;
                yellowGhostSpeed = 5;
                pinkGhostX = 5;
                pinkGhostY = 5;
                playerSpeed = 8;
            }
            else
            {
                remainingTime = 30;
                redGhostSpeed = 10;
                yellowGhostSpeed = 10;
                pinkGhostX = 10;
                pinkGhostY = 10;
                playerSpeed = 8;
            }

            isGameOver = false;

            pacman.Left = 31;
            pacman.Top = 46;

            redGhost.Left = 208;
            redGhost.Top = 55;

            yellowGhost.Left = 448;
            yellowGhost.Top = 445;

            pinkGhost.Left = 525;
            pinkGhost.Top = 235;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }
            
            gameTimer.Start();

        }

       

        //private void gameOver(string message)
        //{
        //    isGameOver = true;
        //    gameTimer.Stop();
        //    countdownTimer.Stop();

        //    txtScore.Text = "Score: " + score + Environment.NewLine + message;
        //    MessageBox.Show("You lose!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    DialogResult result = MessageBox.Show("Do you want to play again?", "Restart Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes)
        //    {
        //        resetGame(selectedDifficulty);
        //    }
        //    else
        //    {
        //        this.Hide();
        //        MenuForm menu = new MenuForm();
        //        menu.Show();
        //    }
        //}
        

        private void StartCountdownTimer(string selectedDifficulty)
        {
            if (selectedDifficulty == "Easy")
            {
                remainingTime = 60;
                Countdown1.Text = "Time: " + remainingTime.ToString();
                countdownTimer.Interval = 1000;
                countdownTimer.Tick += CountdownTimer_Tick;
                countdownTimer.Start();
            }
            else
            {
                remainingTime = 30;
                Countdown1.Text = "Time: " + remainingTime.ToString();
                countdownTimer.Interval = 1000;
                countdownTimer.Tick += CountdownTimer_Tick;
                countdownTimer.Start();
            }

           
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            if (remainingTime >= 0)
            {
                
                Countdown1.Text = "Time: " + remainingTime.ToString();
            }
            else
            {
                TerminateGame();
                GameOverForm gameover = new GameOverForm();
                gameover.Show();
            }
        }

        private void TerminateGame()
        {
            isGameOver = true;
            gameTimer.Stop();
            countdownTimer.Stop();

        }
    }
    
}
