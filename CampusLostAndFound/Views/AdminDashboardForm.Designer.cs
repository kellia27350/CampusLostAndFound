namespace CampusLostAndFound.Views
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop          = new Panel();
            this.lblTitle          = new Label();
            this.panelStats        = new Panel();
            this.lblStatItems      = new Label();
            this.lblStatActive     = new Label();
            this.lblStatReturned   = new Label();
            this.lblStatUsers      = new Label();
            this.lblStatClaims     = new Label();
            this.tabAdmin          = new TabControl();
            this.tabPageItems      = new TabPage();
            this.dgvItems          = new DataGridView();
            this.btnDeleteItem     = new Button();
            this.btnMarkReturnedItem = new Button();
            this.tabPageUsers      = new TabPage();
            this.dgvUsers          = new DataGridView();
            this.btnDeleteUser     = new Button();
            this.tabPageClaims     = new TabPage();
            this.dgvAdminClaims    = new DataGridView();
            this.btnUpdateClaimStatus = new Button();
            this.btnClose          = new Button();

            this.panelTop.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.tabPageClaims.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvAdminClaims).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text            = "Admin Dashboard";
            this.Size            = new Size(1000, 700);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.BackColor       = Color.FromArgb(240, 244, 248);
            this.Load           += new EventHandler(this.AdminDashboardForm_Load);

            // panelTop
            this.panelTop.Dock      = DockStyle.Top;
            this.panelTop.Height    = 55;
            this.panelTop.BackColor = Color.FromArgb(52, 58, 64);
            this.lblTitle.Text      = "⚙️  Administrator Dashboard";
            this.lblTitle.Font      = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location  = new Point(20, 12);
            this.lblTitle.Size      = new Size(500, 30);
            this.panelTop.Controls.Add(this.lblTitle);

            // panelStats (horizontal strip)
            this.panelStats.BackColor = Color.White;
            this.panelStats.Location  = new Point(10, 65);
            this.panelStats.Size      = new Size(960, 50);

            int sx = 10;
            void StatLbl(Label lbl, int x)
            {
                lbl.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(52, 58, 64);
                lbl.Location  = new Point(x, 15);
                lbl.Size      = new Size(185, 20);
            }
            StatLbl(lblStatItems,    sx); sx += 190;
            StatLbl(lblStatActive,   sx); sx += 190;
            StatLbl(lblStatReturned, sx); sx += 190;
            StatLbl(lblStatUsers,    sx); sx += 190;
            StatLbl(lblStatClaims,   sx);
            this.panelStats.Controls.AddRange(new Control[] {
                lblStatItems, lblStatActive, lblStatReturned, lblStatUsers, lblStatClaims
            });

            // tabAdmin
            this.tabAdmin.Location     = new Point(10, 125);
            this.tabAdmin.Size         = new Size(960, 500);
            this.tabAdmin.Font         = new Font("Segoe UI", 10);
            this.tabAdmin.SelectedIndexChanged += new EventHandler(this.tabAdmin_SelectedIndexChanged);

            // ── Tab: Reports ────────────────────────────────────────────────
            this.tabPageItems.Text    = "  Reports  ";
            this.tabPageItems.Padding = new Padding(5);

            DataGridView MakeGrid()
            {
                var g = new DataGridView
                {
                    Dock                  = DockStyle.None,
                    Location              = new Point(5, 5),
                    Size                  = new Size(930, 380),
                    ReadOnly              = true,
                    AllowUserToAddRows    = false,
                    SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
                    AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill,
                    BackgroundColor       = Color.White,
                    BorderStyle           = BorderStyle.None,
                    RowHeadersVisible     = false,
                    Font                  = new Font("Segoe UI", 9)
                };
                g.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
                g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
                g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                g.EnableHeadersVisualStyles               = false;
                return g;
            }

            this.dgvItems = MakeGrid();
            this.dgvItems.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "colAdmId",   HeaderText = "ID",         FillWeight = 5,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "colAdmType", HeaderText = "Type",        FillWeight = 8  },
                new DataGridViewTextBoxColumn { Name = "colAdmName", HeaderText = "Item Name",   FillWeight = 22 },
                new DataGridViewTextBoxColumn { Name = "colAdmCat",  HeaderText = "Category",    FillWeight = 12 },
                new DataGridViewTextBoxColumn { Name = "colAdmLoc",  HeaderText = "Location",    FillWeight = 20 },
                new DataGridViewTextBoxColumn { Name = "colAdmDate", HeaderText = "Date",        FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "colAdmStat", HeaderText = "Status",      FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "colAdmRep",  HeaderText = "Reporter",    FillWeight = 13 }
            );

            Button MakeBtn(string text, Color bg, int x, int y)
            {
                var b = new Button
                {
                    Text      = text,
                    Location  = new Point(x, y),
                    Size      = new Size(170, 30),
                    Font      = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = bg,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor    = Cursors.Hand
                };
                b.FlatAppearance.BorderSize = 0;
                return b;
            }

            this.btnDeleteItem = MakeBtn("🗑  Remove Report", Color.FromArgb(220, 53, 69), 5, 395);
            this.btnDeleteItem.Click += new EventHandler(this.btnDeleteItem_Click);

            this.btnMarkReturnedItem = MakeBtn("✔  Mark Returned", Color.FromArgb(0, 153, 76), 185, 395);
            this.btnMarkReturnedItem.Click += new EventHandler(this.btnMarkReturnedItem_Click);

            this.tabPageItems.Controls.AddRange(new Control[] {
                dgvItems, btnDeleteItem, btnMarkReturnedItem
            });

            // ── Tab: Users ──────────────────────────────────────────────────
            this.tabPageUsers.Text    = "  Users  ";
            this.tabPageUsers.Padding = new Padding(5);

            this.dgvUsers = MakeGrid();
            this.dgvUsers.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "colUsrId",   HeaderText = "ID",        FillWeight = 5,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "colUsrName", HeaderText = "Full Name",  FillWeight = 25 },
                new DataGridViewTextBoxColumn { Name = "colUsrEmail",HeaderText = "Email",      FillWeight = 25 },
                new DataGridViewTextBoxColumn { Name = "colUsrSid",  HeaderText = "Student ID", FillWeight = 15 },
                new DataGridViewTextBoxColumn { Name = "colUsrRole", HeaderText = "Role",       FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "colUsrDate", HeaderText = "Joined",     FillWeight = 12 }
            );

            this.btnDeleteUser = MakeBtn("🗑  Remove User", Color.FromArgb(220, 53, 69), 5, 395);
            this.btnDeleteUser.Click += new EventHandler(this.btnDeleteUser_Click);

            this.tabPageUsers.Controls.AddRange(new Control[] { dgvUsers, btnDeleteUser });

            // ── Tab: Claims ─────────────────────────────────────────────────
            this.tabPageClaims.Text    = "  Claims  ";
            this.tabPageClaims.Padding = new Padding(5);

            this.dgvAdminClaims = MakeGrid();
            this.dgvAdminClaims.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "colAClaimId",   HeaderText = "ID",          FillWeight = 5,  Visible = false },
                new DataGridViewTextBoxColumn { Name = "colAItem",      HeaderText = "Item",         FillWeight = 18 },
                new DataGridViewTextBoxColumn { Name = "colAName",      HeaderText = "Claimant",     FillWeight = 15 },
                new DataGridViewTextBoxColumn { Name = "colAEmail",     HeaderText = "Email",        FillWeight = 18 },
                new DataGridViewTextBoxColumn { Name = "colAExplain",   HeaderText = "Explanation",  FillWeight = 25 },
                new DataGridViewTextBoxColumn { Name = "colADate",      HeaderText = "Date",         FillWeight = 10 },
                new DataGridViewTextBoxColumn { Name = "colAStatus",    HeaderText = "Status",       FillWeight = 10 }
            );

            this.btnUpdateClaimStatus = MakeBtn("✏  Update Status", Color.FromArgb(0, 102, 204), 5, 395);
            this.btnUpdateClaimStatus.Click += new EventHandler(this.btnUpdateClaimStatus_Click);

            this.tabPageClaims.Controls.AddRange(new Control[] { dgvAdminClaims, btnUpdateClaimStatus });

            // Add tabs
            this.tabAdmin.TabPages.AddRange(new TabPage[] { tabPageItems, tabPageUsers, tabPageClaims });

            // btnClose
            this.btnClose.Text      = "Close";
            this.btnClose.Location  = new Point(880, 635);
            this.btnClose.Size      = new Size(90, 28);
            this.btnClose.Font      = new Font("Segoe UI", 9);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Cursor    = Cursors.Hand;
            this.btnClose.Click    += new EventHandler(this.btnClose_Click);

            this.Controls.AddRange(new Control[] { panelTop, panelStats, tabAdmin, btnClose });

            this.panelTop.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            this.tabPageItems.ResumeLayout(false);
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageClaims.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvAdminClaims).EndInit();
            this.ResumeLayout(false);
        }

        private Panel        panelTop;
        private Label        lblTitle;
        private Panel        panelStats;
        private Label        lblStatItems;
        private Label        lblStatActive;
        private Label        lblStatReturned;
        private Label        lblStatUsers;
        private Label        lblStatClaims;
        private TabControl   tabAdmin;
        private TabPage      tabPageItems;
        private DataGridView dgvItems;
        private Button       btnDeleteItem;
        private Button       btnMarkReturnedItem;
        private TabPage      tabPageUsers;
        private DataGridView dgvUsers;
        private Button       btnDeleteUser;
        private TabPage      tabPageClaims;
        private DataGridView dgvAdminClaims;
        private Button       btnUpdateClaimStatus;
        private Button       btnClose;
    }
}
