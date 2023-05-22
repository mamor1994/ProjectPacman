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
        SoundPlayer player = new SoundPlayer();

        public Menu()
        {
            InitializeComponent();
            player.SoundLocation = @"C:\Users\User\Documents\ProjectPacman\ProjectPacman\ProjectPacman\music\mysound.wav";
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            player.Play();
        }


        private void playgame_Click(object sender, EventArgs e)
        {
            player.Stop();
            //check user name null value
            if(userNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please input your name.", "Message");
                return; 
            }


            // Start the game form 
             Form2 form2 = new Form2(userNameTextBox.Text);
             form2.Show();
             this.Hide();
        }
 
    }
}
