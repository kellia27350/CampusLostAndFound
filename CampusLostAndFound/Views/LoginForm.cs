using CampusLostAndFound.Controllers;

namespace CampusLostAndFound.Views
{
    public partial class LoginForm : Form
    {
        private readonly AccountController _accountController;

        public LoginForm(AccountController accountController)
        {
            _accountController = accountController;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email    = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            var (success, error) = _accountController.Login(email, password);

            if (!success)
            {
                lblError.Text    = error;
                lblError.Visible = true;
                return;
            }

            lblError.Visible = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using var regForm = new RegisterForm(_accountController);
            if (regForm.ShowDialog() == DialogResult.OK)
                MessageBox.Show("Registration successful! You can now log in.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }
    }
}
