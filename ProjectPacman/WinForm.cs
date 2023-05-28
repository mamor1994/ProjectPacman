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
using System.Media;


namespace ProjectPacman
{
    public partial class WinForm : Form
    {
        private string name;
        private string selectedDifficulty;
        private int score;

        SoundPlayer player = new SoundPlayer(@"..\..\musicPacman\mysound.wav");

        public WinForm(string name, string selectedDifficulty, int score)
        {
            InitializeComponent();
            this.name = name;
            this.selectedDifficulty = selectedDifficulty;
            this.score = score;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save Form As";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Name: " + name);
                    sw.WriteLine("Difficulty: " + selectedDifficulty);
                    sw.WriteLine("Score: " + score);
                }
                MessageBox.Show("Game data saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
