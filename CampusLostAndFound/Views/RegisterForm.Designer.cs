namespace CampusLostAndFound.Views
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle     = new Label();
            this.lblFullName  = new Label();
            this.txtFullName  = new TextBox();
            this.lblEmail     = new Label();
            this.txtEmail     = new TextBox();
            this.lblStudentId = new Label();
            this.txtStudentId = new TextBox();
            this.lblPassword  = new Label();
            this.txtPassword  = new TextBox();
            this.lblConfirm   = new Label();
            this.txtConfirm   = new TextBox();
            this.lblError     = new Label();
            this.btnRegister  = new Button();
            this.btnCancel    = new Button();
            this.panelMain    = new Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text            = "Campus Lost & Found – Register";
            this.Size            = new Size(430, 500);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;

            // panelMain
            this.panelMain.BackColor = Color.White;
            this.panelMain.Location  = new Point(25, 15);
            this.panelMain.Size      = new Size(365, 440);

            // lblTitle
            this.lblTitle.Text      = "Create an Account";
            this.lblTitle.Font      = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            this.lblTitle.Location  = new Point(20, 15);
            this.lblTitle.Size      = new Size(300, 30);

            int y = 55;
            int gap = 48;

            // FullName
            this.lblFullName.Text     = "Full Name";
            this.lblFullName.Font     = new Font("Segoe UI", 9);
            this.lblFullName.Location = new Point(20, y);
            this.lblFullName.Size     = new Size(320, 18);
            y += 20;
            this.txtFullName.Location       = new Point(20, y);
            this.txtFullName.Size           = new Size(320, 26);
            this.txtFullName.Font           = new Font("Segoe UI", 10);
            this.txtFullName.PlaceholderText = "Your full name";
            y += gap;

            // Email
            this.lblEmail.Text     = "Email Address";
            this.lblEmail.Font     = new Font("Segoe UI", 9);
            this.lblEmail.Location = new Point(20, y);
            this.lblEmail.Size     = new Size(320, 18);
            y += 20;
            this.txtEmail.Location       = new Point(20, y);
            this.txtEmail.Size           = new Size(320, 26);
            this.txtEmail.Font           = new Font("Segoe UI", 10);
            this.txtEmail.PlaceholderText = "you@example.com";
            y += gap;

            // StudentId
            this.lblStudentId.Text     = "Student ID";
            this.lblStudentId.Font     = new Font("Segoe UI", 9);
            this.lblStudentId.Location = new Point(20, y);
            this.lblStudentId.Size     = new Size(320, 18);
            y += 20;
            this.txtStudentId.Location       = new Point(20, y);
            this.txtStudentId.Size           = new Size(320, 26);
            this.txtStudentId.Font           = new Font("Segoe UI", 10);
            this.txtStudentId.PlaceholderText = "e.g. 27350";
            y += gap;

            // Password
            this.lblPassword.Text     = "Password";
            this.lblPassword.Font     = new Font("Segoe UI", 9);
            this.lblPassword.Location = new Point(20, y);
            this.lblPassword.Size     = new Size(320, 18);
            y += 20;
            this.txtPassword.Location     = new Point(20, y);
            this.txtPassword.Size         = new Size(320, 26);
            this.txtPassword.Font         = new Font("Segoe UI", 10);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Min. 6 characters";
            y += gap;

            // Confirm
            this.lblConfirm.Text     = "Confirm Password";
            this.lblConfirm.Font     = new Font("Segoe UI", 9);
            this.lblConfirm.Location = new Point(20, y);
            this.lblConfirm.Size     = new Size(320, 18);
            y += 20;
            this.txtConfirm.Location     = new Point(20, y);
            this.txtConfirm.Size         = new Size(320, 26);
            this.txtConfirm.Font         = new Font("Segoe UI", 10);
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.PlaceholderText = "Re-enter password";
            y += 30;

            // lblError
            this.lblError.ForeColor = Color.Red;
            this.lblError.Font      = new Font("Segoe UI", 8.5f);
            this.lblError.Location  = new Point(20, y);
            this.lblError.Size      = new Size(320, 18);
            this.lblError.Visible   = false;
            y += 24;

            // btnRegister
            this.btnRegister.Text      = "Register";
            this.btnRegister.Location  = new Point(20, y);
            this.btnRegister.Size      = new Size(150, 34);
            this.btnRegister.Font      = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnRegister.BackColor = Color.FromArgb(0, 102, 204);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Cursor    = Cursors.Hand;
            this.btnRegister.Click    += new EventHandler(this.btnRegister_Click);

            // btnCancel
            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Location  = new Point(185, y);
            this.btnCancel.Size      = new Size(155, 34);
            this.btnCancel.Font      = new Font("Segoe UI", 10);
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Cursor    = Cursors.Hand;
            this.btnCancel.Click    += new EventHandler(this.btnCancel_Click);

            this.panelMain.Controls.AddRange(new Control[] {
                lblTitle, lblFullName, txtFullName, lblEmail, txtEmail,
                lblStudentId, txtStudentId, lblPassword, txtPassword,
                lblConfirm, txtConfirm, lblError, btnRegister, btnCancel
            });

            this.Controls.Add(this.panelMain);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Label   lblTitle;
        private Label   lblFullName;
        private TextBox txtFullName;
        private Label   lblEmail;
        private TextBox txtEmail;
        private Label   lblStudentId;
        private TextBox txtStudentId;
        private Label   lblPassword;
        private TextBox txtPassword;
        private Label   lblConfirm;
        private TextBox txtConfirm;
        private Label   lblError;
        private Button  btnRegister;
        private Button  btnCancel;
        private Panel   panelMain;
    }
}
