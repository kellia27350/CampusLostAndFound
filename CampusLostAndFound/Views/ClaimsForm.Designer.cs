namespace CampusLostAndFound.Views
{
    partial class ClaimsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop  = new Panel();
            this.lblTitle  = new Label();
            this.lblCount  = new Label();
            this.dgvClaims = new DataGridView();
            this.btnClose  = new Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvClaims).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text            = "Claims";
            this.Size            = new Size(850, 520);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.BackColor       = Color.FromArgb(240, 244, 248);
            this.Load           += new EventHandler(this.ClaimsForm_Load);

            // panelTop
            this.panelTop.Dock      = DockStyle.Top;
            this.panelTop.Height    = 55;
            this.panelTop.BackColor = Color.FromArgb(255, 140, 0);

            this.lblTitle.Text      = "Claims";
            this.lblTitle.Font      = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location  = new Point(20, 12);
            this.lblTitle.Size      = new Size(600, 30);
            this.panelTop.Controls.Add(this.lblTitle);

            // lblCount
            this.lblCount.Text      = "";
            this.lblCount.Font      = new Font("Segoe UI", 8.5f, FontStyle.Italic);
            this.lblCount.Location  = new Point(14, 62);
            this.lblCount.Size      = new Size(200, 18);

            // dgvClaims
            this.dgvClaims.Location            = new Point(10, 85);
            this.dgvClaims.Size                = new Size(810, 360);
            this.dgvClaims.ReadOnly            = true;
            this.dgvClaims.AllowUserToAddRows  = false;
            this.dgvClaims.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClaims.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClaims.BackgroundColor     = Color.White;
            this.dgvClaims.BorderStyle         = BorderStyle.None;
            this.dgvClaims.RowHeadersVisible   = false;
            this.dgvClaims.Font                = new Font("Segoe UI", 9);
            this.dgvClaims.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            this.dgvClaims.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
            this.dgvClaims.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvClaims.EnableHeadersVisualStyles               = false;

            var colClaimId   = new DataGridViewTextBoxColumn { Name = "colClaimId",   HeaderText = "ID",        FillWeight = 5,  Visible = false };
            var colItem      = new DataGridViewTextBoxColumn { Name = "colItem",      HeaderText = "Item",      FillWeight = 20 };
            var colName      = new DataGridViewTextBoxColumn { Name = "colName",      HeaderText = "Claimant",  FillWeight = 15 };
            var colEmail     = new DataGridViewTextBoxColumn { Name = "colEmail",     HeaderText = "Email",     FillWeight = 18 };
            var colExplain   = new DataGridViewTextBoxColumn { Name = "colExplain",   HeaderText = "Explanation",FillWeight = 27 };
            var colDate      = new DataGridViewTextBoxColumn { Name = "colDate",      HeaderText = "Date",      FillWeight = 12 };
            var colStatus    = new DataGridViewTextBoxColumn { Name = "colStatus",    HeaderText = "Status",    FillWeight = 10 };
            this.dgvClaims.Columns.AddRange(colClaimId, colItem, colName, colEmail, colExplain, colDate, colStatus);

            // btnClose
            this.btnClose.Text      = "Close";
            this.btnClose.Location  = new Point(720, 455);
            this.btnClose.Size      = new Size(100, 30);
            this.btnClose.Font      = new Font("Segoe UI", 9);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Cursor    = Cursors.Hand;
            this.btnClose.Click    += new EventHandler(this.btnClose_Click);

            this.Controls.AddRange(new Control[] { panelTop, lblCount, dgvClaims, btnClose });
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvClaims).EndInit();
            this.ResumeLayout(false);
        }

        private Panel        panelTop;
        private Label        lblTitle;
        private Label        lblCount;
        private DataGridView dgvClaims;
        private Button       btnClose;
    }
}
