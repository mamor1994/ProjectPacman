using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPacman
{
    public partial class GameOverForm : Form
    {

        private string name;
        private string selectedDifficulty;
        private readonly MenuForm menuForm;


        //SoundPlayer player = new SoundPlayer("mysound.wav");

        public GameOverForm(string name, string selectedDifficulty)
        {
            InitializeComponent();
            this.name = name; 
            this.selectedDifficulty = selectedDifficulty;   

        }
        public GameOverForm(MenuForm menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // player.Stop();
            //HideMenuForm();

            //this.Hide();
            //CloseGameAndGameOverForms();
            Close();
            MenuForm menu = Application.OpenForms.OfType<MenuForm>().FirstOrDefault();
            //menu.Name();
            menu.Show();
            //Close();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            // player.Stop();
            if (selectedDifficulty == "Easy")
            {
                //EasyGameForm gameForm = Application.OpenForms.OfType<EasyGameForm>().FirstOrDefault();
                //GameOverForm gameOverForm = Application.OpenForms.OfType<GameOverForm>().FirstOrDefault();

                //gameForm?.Close();
                //gameOverForm?.Close();

                HideMenuForm();


                //this.Hide();
                //CloseGameAndGameOverForms();
                Close();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
                //Close();

            }
            else if (selectedDifficulty == "Hard")
            {
                HideMenuForm();

                //this.Hide();
                //CloseGameAndGameOverForms();
                Close();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
               // Close();

                //HardGameForm hardGame = new HardGameForm(name);
                //hardGame.ShowDialog();
            }
        }
        private void CloseGameAndGameOverForms()
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
