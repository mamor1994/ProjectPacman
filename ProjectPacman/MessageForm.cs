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
        private EasyGameForm easyGame;
        private EasyGameForm hardGame;

        //SoundPlayer player = new SoundPlayer("mysound.wav");

        private void Message_Load(object sender, EventArgs e)
        {
            // player.Play();
        }

        public MessageForm(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // player.Stop();

            this.Close();
            //MenuForm menu = new MenuForm();
            //menu.Show();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if (radioButtonEasy.Checked)
            {
                // player.Stop();
                selectedDifficulty = "Easy";
                HideMenuAndMessageForms();
                //this.Hide();
                easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
            }
            else //if (radioButtonHard.Checked)
            {
                // player.Stop();
                selectedDifficulty = "Hard";
                HideMenuAndMessageForms();
                hardGame = new EasyGameForm(name, selectedDifficulty);
                hardGame.ShowDialog();
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

        private void HideMenuAndMessageForms()
        {
            MenuForm menu = Application.OpenForms.OfType<MenuForm>().FirstOrDefault();
            menu?.Hide();

            
            this.Hide();
        }

    }
}
