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
    public partial class Message : Form
    {
        private string name;
        private string selectedDifficulty;

        public Message(string name)
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            
            if (radioButtonEasy.Checked)
            {
                
                this.Close();
                Game easyGame = new Game(name, selectedDifficulty);
                easyGame.ShowDialog();
            }
            else if (radioButtonHard.Checked)
            {
                //HardGameForm hardGame = new HardGameForm(name);
                //hardGame.ShowDialog();
            }
            //this.Close();
            //Game game = new Game(name, selectedDifficulty);
            //game.Show();
        }
    }
}
