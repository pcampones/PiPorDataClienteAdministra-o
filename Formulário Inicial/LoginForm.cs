using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Formulário_Inicial.ServiceReference1;

namespace Formulário_Inicial
{
    public partial class LoginForm : Form
    {
        private Service1Client cliente;
        private string password;
        private string token;
        private string username;

        public LoginForm()
        {
      
            InitializeComponent();
            this.cliente = new Service1Client();
        }
        
        public String Token
        {
            get
            {
                return token;
            }
        }
      


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                username = userTextBox.Text;
                password = passTextBox.Text;

                token = cliente.LogIn(username,password);

                this.DialogResult = DialogResult.OK;
                this.Hide();
                Form1 form = new Form1();
                form.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
