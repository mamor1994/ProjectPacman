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
    public partial class Form1 : Form
    {
        private string name;
        private string selectedDifficulty;

        public Form1()
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
            this.Close();
            Game game = new Game(name, selectedDifficulty);
            game.Show();
        }
    }
}
