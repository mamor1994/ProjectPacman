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
    public partial class GameOverForm : Form
    {

        private string name;
        private string selectedDifficulty;

        SoundPlayer player = new SoundPlayer("mysound.wav");

        public GameOverForm(string name, string selectedDifficulty)
        {
            InitializeComponent();
            this.name = name; 
            this.selectedDifficulty = selectedDifficulty;
            player.Play();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            MenuForm menu = Application.OpenForms.OfType<MenuForm>().FirstOrDefault();
            menu.ClearNameTextBox();
            menu.Show();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            player.Stop();
            if (selectedDifficulty == "Easy")
            {
                HideMenuForm();
                Close();
                GameForm easyGame = new GameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
            }
            else if (selectedDifficulty == "Hard")
            {
                HideMenuForm();
                Close();
                GameForm easyGame = new GameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
            }
        }

        private void HideMenuForm()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is MenuForm)
                {
                    form.Hide();
                    break;
                }
            }
        }
    }
}
