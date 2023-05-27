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
using System.Drawing.Imaging;



namespace ProjectPacman
{
    public partial class MenuForm : Form
    {

        private readonly Form _parent;
        private string name;


        //SoundPlayer player = new SoundPlayer("mysound.wav");


        public MenuForm()
        {
            InitializeComponent();
            //player.SoundLocation = @"C:\Users\User\Documents\ProjectPacman\ProjectPacman\ProjectPacman\music\mysound.wav";
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // player.Play();
        }


        private void playgame_Click(object sender, EventArgs e)
        {
            // player.Stop();
            
            name = userNameTextBox.Text.Trim();
            

            if (string.IsNullOrEmpty(name))
            {
                //MessageBox.Show("Please input your name.", "Message");
                string message = "Please input your name.";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageForm message = new MessageForm(name);
                message.ShowDialog();

            }

            //string selectedDifficulty = ShowDifficultyDialog();
            //LaunchGame(selectedDifficulty);
            //this.Close();
            //Form1 form = new Form1();
            //form.Show();

        }


        //private string ShowDifficultyDialog()
        //{
        //    using (var dialog = new Form())
        //    {
        //        dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
        //        dialog.StartPosition = FormStartPosition.CenterParent;
        //        dialog.ControlBox = false;
        //        dialog.Size = new Size(200, 190);
        //        dialog.BackColor = Color.Orange;


        //        var headerLabel = new Label()
        //        {
        //            Text = "Select Difficulty",
        //            Location = new Point(50, 10),
        //            Size = new Size(dialog.Width - 100, 20),
        //            Font = new Font(dialog.Font, FontStyle.Bold),
        //            TextAlign = ContentAlignment.MiddleCenter
        //        };


        //        var easyRadioButton = new RadioButton()
        //        {
        //            Text = "Easy",
        //            Location = new Point(50, 30),
        //            Checked = true
        //        };

        //        var hardRadioButton = new RadioButton()
        //        {
        //            Text = "Hard",
        //            Location = new Point(50, 60)
        //        };

        //        var confirmButton = new Button()
        //        {
        //            Text = "Confirm",
        //            Location = new Point(65, 90),
        //            DialogResult = DialogResult.OK,
        //            BackColor = Color.Green,
        //            ForeColor = Color.White
        //        };

        //        var cancelButton = new Button()
        //        {
        //            Text = "Cancel",
        //            Location = new Point(65, confirmButton.Bottom + 10),
        //            DialogResult = DialogResult.Cancel,
        //            BackColor = Color.Red,
        //            ForeColor = Color.White
        //        };

        //        dialog.Controls.AddRange(new Control[]
        //        {
        //            headerLabel,
        //            easyRadioButton,
        //            hardRadioButton,
        //            confirmButton,
        //            cancelButton
        //        });

        //        cancelButton.Click += (sender, e) => dialog.Close();

        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            return easyRadioButton.Checked ? "Easy" : "Hard";
        //        }
        //    }
        //    return null;
        //}

        //private void LaunchGame(string selectedDifficulty)
        //{
        //    this.Show();
        //    Game game = new Game(name, selectedDifficulty);
        //    game.ShowDialog();
        //}


        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Show();
        }


        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string name = "Name: Maria Amorgianou";
            string email = "Email: mariaamorgianou.1994@gmail.com";
            string am = "AM: MPPL2205";

            string message = $"{name}\n{email}\n{am}";
            MessageBox.Show(message, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
