namespace CampusLostAndFound.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle    = new Label();
            this.lblEmail    = new Label();
            this.txtEmail    = new TextBox();
            this.lblPwd      = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin    = new Button();
            this.lblError    = new Label();
            this.lnkRegister = new LinkLabel();
            this.panelMain   = new Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text            = "Campus Lost & Found – Login";
            this.Size            = new Size(420, 380);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;

            // panelMain
            this.panelMain.BackColor = Color.White;
            this.panelMain.Location  = new Point(30, 20);
            this.panelMain.Size      = new Size(340, 300);
            this.panelMain.Padding   = new Padding(20);

            // lblTitle
            this.lblTitle.Text      = "🎓  Campus Lost & Found";
            this.lblTitle.Font      = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            this.lblTitle.Location  = new Point(20, 20);
            this.lblTitle.Size      = new Size(300, 30);

            // lblEmail
            this.lblEmail.Text     = "Email Address";
            this.lblEmail.Font     = new Font("Segoe UI", 9);
            this.lblEmail.Location = new Point(20, 70);
            this.lblEmail.Size     = new Size(300, 20);

            // txtEmail
            this.txtEmail.Location  = new Point(20, 92);
            this.txtEmail.Size      = new Size(300, 26);
            this.txtEmail.Font      = new Font("Segoe UI", 10);
            this.txtEmail.PlaceholderText = "Enter your email";

            // lblPwd
            this.lblPwd.Text     = "Password";
            this.lblPwd.Font     = new Font("Segoe UI", 9);
            this.lblPwd.Location = new Point(20, 130);
            this.lblPwd.Size     = new Size(300, 20);

            // txtPassword
            this.txtPassword.Location       = new Point(20, 152);
            this.txtPassword.Size           = new Size(300, 26);
            this.txtPassword.Font           = new Font("Segoe UI", 10);
            this.txtPassword.PasswordChar   = '●';
            this.txtPassword.PlaceholderText = "Enter your password";
            this.txtPassword.KeyDown        += new KeyEventHandler(this.txtPassword_KeyDown);

            // lblError
            this.lblError.ForeColor = Color.Red;
            this.lblError.Font      = new Font("Segoe UI", 8.5f);
            this.lblError.Location  = new Point(20, 185);
            this.lblError.Size      = new Size(300, 20);
            this.lblError.Visible   = false;

            // btnLogin
            this.btnLogin.Text      = "Log In";
            this.btnLogin.Location  = new Point(20, 210);
            this.btnLogin.Size      = new Size(300, 36);
            this.btnLogin.Font      = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnLogin.BackColor = Color.FromArgb(0, 102, 204);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor    = Cursors.Hand;
            this.btnLogin.Click    += new EventHandler(this.btnLogin_Click);

            // lnkRegister
            this.lnkRegister.Text      = "Don't have an account? Register here";
            this.lnkRegister.Font      = new Font("Segoe UI", 8.5f);
            this.lnkRegister.Location  = new Point(20, 258);
            this.lnkRegister.Size      = new Size(300, 20);
            this.lnkRegister.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);

            this.panelMain.Controls.AddRange(new Control[] {
                lblTitle, lblEmail, txtEmail, lblPwd, txtPassword,
                lblError, btnLogin, lnkRegister
            });

            this.Controls.Add(this.panelMain);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Label     lblTitle;
        private Label     lblEmail;
        private TextBox   txtEmail;
        private Label     lblPwd;
        private TextBox   txtPassword;
        private Button    btnLogin;
        private Label     lblError;
        private LinkLabel lnkRegister;
        private Panel     panelMain;
    }
}
