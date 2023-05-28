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
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace ProjectPacman
{
    public partial class MenuForm : Form, INotifyPropertyChanged
    {

        private readonly Form _parent;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;


        SoundPlayer player = new SoundPlayer("mysound.wav");


        public MenuForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public string PlayerName
        {
            get 
            {
                return name; 
            }
            set 
            { 
                name = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Menu_Load(object sender, EventArgs e)
        {
             player.Play();
        }

        private void playgame_Click(object sender, EventArgs e)
        {
            name = userNameTextBox.Text.Trim();
            
            if (string.IsNullOrEmpty(name))
            {
                string message = "Please input your name.";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageForm message = new MessageForm(name, player);
                message.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Show();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string name = "Name: Maria Amorgianou";
            string email = "Email: mariaamorgianou.1994@gmail.com";
            string am = "AM: MPPL2205";

            string message = $"{name}\n{email}\n{am}";
            MessageBox.Show(message, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearNameTextBox()
        {
            userNameTextBox.Clear();
        }
    }
}
