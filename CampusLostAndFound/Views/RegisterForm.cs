using CampusLostAndFound.Controllers;

namespace CampusLostAndFound.Views
{
    public partial class RegisterForm : Form
    {
        private readonly AccountController _accountController;

        public RegisterForm(AccountController accountController)
        {
            _accountController = accountController;
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName  = txtFullName.Text.Trim();
            string email     = txtEmail.Text.Trim();
            string studentId = txtStudentId.Text.Trim();
            string password  = txtPassword.Text;
            string confirm   = txtConfirm.Text;

            if (password != confirm)
            {
                ShowError("Passwords do not match.");
                return;
            }

            var (success, error) = _accountController.Register(fullName, email, studentId, password);

            if (!success)
            {
                ShowError(error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowError(string msg)
        {
            lblError.Text    = msg;
            lblError.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
