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
    public partial class Menu : Form
    {
        //SoundPlayer player = new SoundPlayer("mysound.wav");
        string selectedDifficulty;


        public Menu()
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

            if (userNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please input your name.", "Message");
                return;
            }

            string selectedDifficulty = ShowDifficultyDialog();
            Form2 form2 = new Form2(userNameTextBox.Text, selectedDifficulty);
            form2.Show();
            this.Hide();
        }


        private string ShowDifficultyDialog()
        {
            using (var dialog = new Form())
            {
                //dialog.Text = "Wait!";
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ControlBox = false;
                dialog.Size = new Size(200, 190);
                dialog.BackColor = Color.Orange;


                var headerLabel = new Label()
                {
                    Text = "Select Difficulty",
                    Location = new Point(50, 10),
                    Size = new Size(dialog.Width - 100, 20),
                    Font = new Font(dialog.Font, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };


                var easyRadioButton = new RadioButton()
                {
                    Text = "Easy",
                    Location = new Point(50, 30),
                    Checked = true
                };

                var hardRadioButton = new RadioButton()
                {
                    Text = "Hard",
                    Location = new Point(50, 60)
                };

                var confirmButton = new Button()
                {
                    Text = "Confirm",
                    Location = new Point(65, 90),
                    DialogResult = DialogResult.OK,
                    BackColor = Color.Green,
                    ForeColor = Color.White
                };

                var cancelButton = new Button()
                {
                    Text = "Cancel",
                    Location = new Point(65, confirmButton.Bottom + 10),
                    DialogResult = DialogResult.Cancel,
                    BackColor = Color.Red,
                    ForeColor = Color.White
                };

                dialog.Controls.Add(headerLabel);

                dialog.Controls.Add(easyRadioButton);
                dialog.Controls.Add(hardRadioButton);
                dialog.Controls.Add(confirmButton);
                dialog.Controls.Add(cancelButton);

               
                confirmButton.Click += (sender, e) => dialog.Close();

                dialog.ShowDialog();

                return dialog.Tag as string;
            }
        }


        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string name = "Name: Maria Amorgianou";
            string email = "Email: mariaamorgianou.1994@gmail.com";

            string message = name + "\n" + email;
            MessageBox.Show(message, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
