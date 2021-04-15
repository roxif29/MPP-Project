using ProiectC_Mpp.repository.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectC_Mpp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            UserTextBox.MaxLength = 20;
            PassTextBox.MaxLength = 20;
            PassTextBox.PasswordChar = '*';      
        }

    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = UserTextBox.Text;
            Console.WriteLine(username);
            string password = PassTextBox.Text; Console.WriteLine(password);

            AngajatDbRepository angajatDbRepository = new AngajatDbRepository();
            if (angajatDbRepository.findOne(username, password) != null)
            {
                MainForm mainForm = new MainForm();
                mainForm.Text = username;
                mainForm.Show();
            }
            else
                MessageBox.Show("Username sau parola incorecta!");
        }
    }
}
