using System;
using System.Drawing;
using System.Windows.Forms;
using FitTrack_DDOCP.Services;
using FitTrack_DDOCP.Models;

namespace FitTrack_DDOCP.Forms
{
    public partial class Authentication : Form
    {
        private AuthService authService;
        public User LoggedInUser { get; private set; }

        public Authentication()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string message;
            User user = authService.Login(txtUsername.Text, txtPassword.Text, out message);

            lblMessage.Text = message;

            if (user != null)
            {
                lblMessage.ForeColor = Color.Green;
                LoggedInUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string message;
            bool success = authService.Register(
                txtUsername.Text,
                txtPassword.Text,
                out message);

            lblMessage.Text = message;

            if (success)
            {
                lblMessage.ForeColor = Color.Green;
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void Authentication_Load(object sender, EventArgs e)
        {

        }
    }
}
