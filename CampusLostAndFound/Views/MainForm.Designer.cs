namespace CampusLostAndFound.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop     = new Panel();
            this.lblTitle     = new Label();
            this.lblWelcome   = new Label();
            this.btnLogout    = new Button();
            this.panelCenter  = new Panel();
            this.btnReport    = new Button();
            this.btnBrowse    = new Button();
            this.btnMyClaims  = new Button();
            this.btnAdmin     = new Button();
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text            = "Campus Lost & Found";
            this.Size            = new Size(600, 480);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = Color.FromArgb(240, 244, 248);
            this.Load           += new EventHandler(this.MainForm_Load);

            // panelTop
            this.panelTop.Dock      = DockStyle.Top;
            this.panelTop.Height    = 80;
            this.panelTop.BackColor = Color.FromArgb(0, 102, 204);
            this.panelTop.Padding   = new Padding(20, 10, 20, 10);

            // lblTitle
            this.lblTitle.Text      = "🎓  Campus Lost & Found";
            this.lblTitle.Font      = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location  = new Point(20, 10);
            this.lblTitle.Size      = new Size(360, 32);

            // lblWelcome
            this.lblWelcome.Text      = "";
            this.lblWelcome.Font      = new Font("Segoe UI", 9);
            this.lblWelcome.ForeColor = Color.FromArgb(200, 230, 255);
            this.lblWelcome.Location  = new Point(20, 48);
            this.lblWelcome.Size      = new Size(400, 20);

            // btnLogout
            this.btnLogout.Text      = "Log Out";
            this.btnLogout.Location  = new Point(470, 24);
            this.btnLogout.Size      = new Size(90, 30);
            this.btnLogout.Font      = new Font("Segoe UI", 9);
            this.btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Cursor    = Cursors.Hand;
            this.btnLogout.Click    += new EventHandler(this.btnLogout_Click);

            this.panelTop.Controls.AddRange(new Control[] { lblTitle, lblWelcome, btnLogout });

            // panelCenter
            this.panelCenter.Location  = new Point(50, 110);
            this.panelCenter.Size      = new Size(490, 300);

            // Helper to build a large nav tile button
            Button MakeTile(string text, string sub, Color color, int x, int y)
            {
                var btn = new Button
                {
                    Text      = text + "\n" + sub,
                    Location  = new Point(x, y),
                    Size      = new Size(220, 110),
                    Font      = new Font("Segoe UI", 11, FontStyle.Bold),
                    BackColor = color,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor    = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                btn.FlatAppearance.BorderSize = 0;
                return btn;
            }

            this.btnReport = MakeTile("📋  Report Item",
                "Submit Lost or Found", Color.FromArgb(0, 153, 76), 0, 0);
            this.btnReport.Click += new EventHandler(this.btnReport_Click);

            this.btnBrowse = MakeTile("🔍  Browse Items",
                "Search reports", Color.FromArgb(0, 102, 204), 250, 0);
            this.btnBrowse.Click += new EventHandler(this.btnBrowse_Click);

            this.btnMyClaims = MakeTile("📂  My Claims",
                "View submitted claims", Color.FromArgb(255, 140, 0), 0, 130);
            this.btnMyClaims.Click += new EventHandler(this.btnMyClaims_Click);

            this.btnAdmin = MakeTile("⚙️  Admin Panel",
                "Manage reports & users", Color.FromArgb(108, 117, 125), 250, 130);
            this.btnAdmin.Visible = false;
            this.btnAdmin.Click  += new EventHandler(this.btnAdmin_Click);

            this.panelCenter.Controls.AddRange(new Control[] {
                btnReport, btnBrowse, btnMyClaims, btnAdmin
            });

            this.Controls.AddRange(new Control[] { panelTop, panelCenter });
            this.panelTop.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel  panelTop;
        private Panel  panelCenter;
        private Label  lblTitle;
        private Label  lblWelcome;
        private Button btnLogout;
        private Button btnReport;
        private Button btnBrowse;
        private Button btnMyClaims;
        private Button btnAdmin;
    }
}
