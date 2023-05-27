using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectPacman
{
    public partial class MessageForm : Form
    {
        private string name;
        private string selectedDifficulty;

        //SoundPlayer player = new SoundPlayer("mysound.wav");

        private void Message_Load(object sender, EventArgs e)
        {
            // player.Play();
        }

        public MessageForm(string name)
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // player.Stop();

            this.Close();
            MenuForm menu = new MenuForm();
            menu.Show();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if (radioButtonEasy.Checked)
            {
                // player.Stop();
                selectedDifficulty = "Easy";
                CloseMenuAndMessageForms();
                //this.Hide();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
            }
            else //if (radioButtonHard.Checked)
            {
                // player.Stop();
                selectedDifficulty = "Hard";
                CloseMenuAndMessageForms();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
                //HardGameForm hardGame = new HardGameForm(name, selectedDifficulty);
                //hardGame.ShowDialog();
            }
        }

        //private void CloseMenuAndMessageForms()
        //{
        //    foreach (Form form in Application.OpenForms)
        //    {
        //        if (form is MenuForm)
        //        {
        //            form.Close();
        //            break;
        //        }
        //    }

        //    EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
        //    easyGame.ShowDialog();
        //    this.Close();
        //}

        private void CloseMenuAndMessageForms()
        {
            // Close the "GameOver" form if it is open
            MenuForm menu = Application.OpenForms.OfType<MenuForm>().FirstOrDefault();
            menu?.Hide();

            // Close the "Game" form
            this.Hide();
        }

    }
}
