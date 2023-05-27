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
                this.Close();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
            }
            else //if (radioButtonHard.Checked)
            {
                // player.Stop();
                selectedDifficulty = "Hard";
                this.Close();
                EasyGameForm easyGame = new EasyGameForm(name, selectedDifficulty);
                easyGame.ShowDialog();
                //HardGameForm hardGame = new HardGameForm(name, selectedDifficulty);
                //hardGame.ShowDialog();
            }

        }
    }
}
