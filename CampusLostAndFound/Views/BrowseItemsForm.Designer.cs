namespace CampusLostAndFound.Views
{
    partial class BrowseItemsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop    = new Panel();
            this.lblTitle    = new Label();
            this.panelFilter = new Panel();
            this.lblSearch   = new Label();
            this.txtSearch   = new TextBox();
            this.lblType     = new Label();
            this.cmbType     = new ComboBox();
            this.lblCat      = new Label();
            this.cmbCategory = new ComboBox();
            this.btnSearch   = new Button();
            this.btnClear    = new Button();
            this.lblCount    = new Label();
            this.dgvItems    = new DataGridView();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvItems).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text            = "Browse Lost & Found Items";
            this.Size            = new Size(900, 620);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.BackColor       = Color.FromArgb(240, 244, 248);
            this.Load           += new EventHandler(this.BrowseItemsForm_Load);

            // panelTop
            this.panelTop.Dock      = DockStyle.Top;
            this.panelTop.Height    = 55;
            this.panelTop.BackColor = Color.FromArgb(0, 102, 204);

            this.lblTitle.Text      = "🔍  Browse Items";
            this.lblTitle.Font      = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location  = new Point(20, 12);
            this.lblTitle.Size      = new Size(300, 30);
            this.panelTop.Controls.Add(this.lblTitle);

            // panelFilter
            this.panelFilter.BackColor = Color.White;
            this.panelFilter.Location  = new Point(10, 65);
            this.panelFilter.Size      = new Size(860, 65);

            this.lblSearch.Text     = "Keyword:";
            this.lblSearch.Font     = new Font("Segoe UI", 9);
            this.lblSearch.Location = new Point(10, 10);
            this.lblSearch.Size     = new Size(60, 18);

            this.txtSearch.Location       = new Point(72, 7);
            this.txtSearch.Size           = new Size(200, 26);
            this.txtSearch.Font           = new Font("Segoe UI", 10);
            this.txtSearch.PlaceholderText = "Search items…";
            this.txtSearch.KeyDown        += new KeyEventHandler(this.txtSearch_KeyDown);

            this.lblType.Text     = "Type:";
            this.lblType.Font     = new Font("Segoe UI", 9);
            this.lblType.Location = new Point(285, 10);
            this.lblType.Size     = new Size(40, 18);

            this.cmbType.Location      = new Point(328, 7);
            this.cmbType.Size          = new Size(100, 26);
            this.cmbType.Font          = new Font("Segoe UI", 10);
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbType.Items.AddRange(new object[] { "All", "Lost", "Found" });
            this.cmbType.SelectedIndex = 0;

            this.lblCat.Text     = "Category:";
            this.lblCat.Font     = new Font("Segoe UI", 9);
            this.lblCat.Location = new Point(442, 10);
            this.lblCat.Size     = new Size(65, 18);

            this.cmbCategory.Location      = new Point(510, 7);
            this.cmbCategory.Size          = new Size(150, 26);
            this.cmbCategory.Font          = new Font("Segoe UI", 10);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnSearch.Text      = "Search";
            this.btnSearch.Location  = new Point(675, 6);
            this.btnSearch.Size      = new Size(80, 28);
            this.btnSearch.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnSearch.BackColor = Color.FromArgb(0, 102, 204);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Cursor    = Cursors.Hand;
            this.btnSearch.Click    += new EventHandler(this.btnSearch_Click);

            this.btnClear.Text      = "Clear";
            this.btnClear.Location  = new Point(762, 6);
            this.btnClear.Size      = new Size(80, 28);
            this.btnClear.Font      = new Font("Segoe UI", 9);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Cursor    = Cursors.Hand;
            this.btnClear.Click    += new EventHandler(this.btnClear_Click);

            this.panelFilter.Controls.AddRange(new Control[] {
                lblSearch, txtSearch, lblType, cmbType, lblCat, cmbCategory, btnSearch, btnClear
            });

            // lblCount
            this.lblCount.Text     = "";
            this.lblCount.Font     = new Font("Segoe UI", 8.5f, FontStyle.Italic);
            this.lblCount.Location = new Point(14, 136);
            this.lblCount.Size     = new Size(300, 18);

            // DataGridView
            this.dgvItems.Location            = new Point(10, 158);
            this.dgvItems.Size                = new Size(860, 420);
            this.dgvItems.ReadOnly            = true;
            this.dgvItems.AllowUserToAddRows  = false;
            this.dgvItems.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor     = Color.White;
            this.dgvItems.BorderStyle         = BorderStyle.None;
            this.dgvItems.RowHeadersVisible   = false;
            this.dgvItems.Font                = new Font("Segoe UI", 9);
            this.dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            this.dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.CellDoubleClick          += new DataGridViewCellEventHandler(this.dgvItems_CellDoubleClick);

            // Columns
            var colId       = new DataGridViewTextBoxColumn { Name = "colId",       HeaderText = "ID",       FillWeight = 5,  Visible = false };
            var colType     = new DataGridViewTextBoxColumn { Name = "colType",     HeaderText = "Type",     FillWeight = 8  };
            var colName     = new DataGridViewTextBoxColumn { Name = "colName",     HeaderText = "Item Name",FillWeight = 22 };
            var colCat      = new DataGridViewTextBoxColumn { Name = "colCat",      HeaderText = "Category", FillWeight = 12 };
            var colLoc      = new DataGridViewTextBoxColumn { Name = "colLoc",      HeaderText = "Location", FillWeight = 20 };
            var colDate     = new DataGridViewTextBoxColumn { Name = "colDate",     HeaderText = "Date",     FillWeight = 10 };
            var colStatus   = new DataGridViewTextBoxColumn { Name = "colStatus",   HeaderText = "Status",   FillWeight = 10 };
            var colReporter = new DataGridViewTextBoxColumn { Name = "colReporter", HeaderText = "Reported By", FillWeight = 13 };
            this.dgvItems.Columns.AddRange(colId, colType, colName, colCat, colLoc, colDate, colStatus, colReporter);

            var tip = new Label
            {
                Text      = "Double-click a row to view full details",
                Font      = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location  = new Point(14, 580),
                Size      = new Size(300, 18)
            };

            this.Controls.AddRange(new Control[] {
                panelTop, panelFilter, lblCount, dgvItems, tip
            });

            this.panelTop.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvItems).EndInit();
            this.ResumeLayout(false);
        }

        private Panel           panelTop;
        private Panel           panelFilter;
        private Label           lblTitle;
        private Label           lblSearch;
        private TextBox         txtSearch;
        private Label           lblType;
        private ComboBox        cmbType;
        private Label           lblCat;
        private ComboBox        cmbCategory;
        private Button          btnSearch;
        private Button          btnClear;
        private Label           lblCount;
        private DataGridView    dgvItems;
    }
}
