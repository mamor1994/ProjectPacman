using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing.Imaging;


namespace ProjectPacman
{
    public partial class WinForm : Form
    {

        //string gifFilePath = "save.gif";

        private string name;
        private string selectedDifficulty;
        private int score;

        //SoundPlayer player = new SoundPlayer("mysound.wav");


        public WinForm(string name, string selectedDifficulty, int score)
        {
            InitializeComponent();
            this.name = name;
            this.selectedDifficulty = selectedDifficulty;
            this.score = score;

            //Image gifImage = Image.FromFile(@"images\animated.gif");
            //pictureBox1.Image = gifImage;

            //Timer timer = new Timer();
            //timer.Interval = 100; // Adjust the interval as needed
            //timer.Tick += Timer_Tick;
            //timer.Start();

            //this.name = name;
            //this.selectedDifficulty = selectedDifficulty;

            //this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    // Force the PictureBox to redraw
        //    pictureBox1.Refresh();
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    // Call the base OnPaint method
        //    base.OnPaint(e);

        //    // Draw the current frame of the animated GIF on the PictureBox
        //    ImageAnimator.UpdateFrames();
        //    e.Graphics.DrawImage(pictureBox1.Image, pictureBox1.Location);
        //}



        private void Save_Load(object sender, EventArgs e)
        {
            // player.Play();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // player.Stop();

            CloseGameAndWinForms();
            MenuForm menu = new MenuForm();
            menu.ShowDialog();
              
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            // player.Stop();
            if (selectedDifficulty == "Easy")
            {
                this.Close();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.Show();

              
            }
            else if (selectedDifficulty == "Hard")
            {
                //this.Close();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.Show();

                //HardGameForm hardGame = new HardGameForm(name);
                //hardGame.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // player.Stop();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save Form As";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    //sw.Write(this.Text);

                    sw.WriteLine("Name: " + name);
                    sw.WriteLine("Difficulty: " + selectedDifficulty);
                    sw.WriteLine("Score: " + score);
                }
                MessageBox.Show("Game data saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void CloseGameAndWinForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is EasyGameForm)
                {
                    form.Hide();
                    break;
                }
            }
            this.Hide();
        }
    }
}
