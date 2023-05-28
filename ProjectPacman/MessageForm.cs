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
using System.Media;


namespace ProjectPacman
{
    public partial class MessageForm : Form
    {
        private string name;
        private string selectedDifficulty;
        private GameForm easyGame;
        private GameForm hardGame;
        private SoundPlayer player;

        public MessageForm(string name, SoundPlayer player)
        {
            InitializeComponent();
            this.name = name;
            this.player = player;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if (radioButtonEasy.Checked)
            {
                player.Stop();
                selectedDifficulty = "Easy";
                HideMenuAndMessageForms();
                easyGame = new GameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
            }
            else if (radioButtonHard.Checked)
            {
                player.Stop();
                selectedDifficulty = "Hard";
                HideMenuAndMessageForms();
                hardGame = new GameForm(name, selectedDifficulty);
                hardGame.ShowDialog();
            }
        }

        private void HideMenuAndMessageForms()
        {
            MenuForm menu = Application.OpenForms.OfType<MenuForm>().FirstOrDefault();
            menu?.Hide();  
            this.Hide();
        }

    }
}
