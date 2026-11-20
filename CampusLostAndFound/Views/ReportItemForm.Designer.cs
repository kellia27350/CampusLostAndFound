namespace CampusLostAndFound.Views
{
    partial class ReportItemForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle       = new Label();
            this.lblType        = new Label();
            this.rdoLost        = new RadioButton();
            this.rdoFound       = new RadioButton();
            this.lblItemName    = new Label();
            this.txtItemName    = new TextBox();
            this.lblCategory    = new Label();
            this.cmbCategory    = new ComboBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblLocation    = new Label();
            this.txtLocation    = new TextBox();
            this.lblDate        = new Label();
            this.dtpDate        = new DateTimePicker();
            this.lblImage       = new Label();
            this.txtImagePath   = new TextBox();
            this.btnBrowseImage = new Button();
            this.lblError       = new Label();
            this.btnSubmit      = new Button();
            this.btnCancel      = new Button();
            this.panelMain      = new Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text            = "Report a Lost / Found Item";
            this.Size            = new Size(500, 620);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.ReportItemForm_Load);

            // panelMain
            this.panelMain.BackColor = Color.White;
            this.panelMain.Location  = new Point(20, 15);
            this.panelMain.Size      = new Size(445, 565);

            // lblTitle
            this.lblTitle.Text      = "📋  Submit Item Report";
            this.lblTitle.Font      = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            this.lblTitle.Location  = new Point(15, 12);
            this.lblTitle.Size      = new Size(400, 28);

            int y = 55;

            // Report type row
            this.lblType.Text     = "Report Type";
            this.lblType.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblType.Location = new Point(15, y);
            this.lblType.Size     = new Size(120, 18);
            y += 20;

            this.rdoLost.Text     = "🔴  Lost Item";
            this.rdoLost.Checked  = true;
            this.rdoLost.Font     = new Font("Segoe UI", 10);
            this.rdoLost.Location = new Point(15, y);
            this.rdoLost.Size     = new Size(130, 24);

            this.rdoFound.Text     = "🟢  Found Item";
            this.rdoFound.Font     = new Font("Segoe UI", 10);
            this.rdoFound.Location = new Point(155, y);
            this.rdoFound.Size     = new Size(140, 24);
            y += 36;

            void AddField(Label lbl, string text, Control ctrl, ref int yPos, int height = 26)
            {
                lbl.Text     = text;
                lbl.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
                lbl.Location = new Point(15, yPos);
                lbl.Size     = new Size(410, 18);
                yPos += 20;
                ctrl.Location = new Point(15, yPos);
                ctrl.Size     = new Size(410, height);
                if (ctrl is TextBox tb) tb.Font = new Font("Segoe UI", 10);
                yPos += height + 10;
            }

            AddField(lblItemName, "Item Name *", txtItemName, ref y);
            txtItemName.PlaceholderText = "e.g. Blue backpack";

            AddField(lblCategory, "Category *", cmbCategory, ref y);
            cmbCategory.Font        = new Font("Segoe UI", 10);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            AddField(lblDescription, "Description *", txtDescription, ref y, 60);
            txtDescription.Multiline    = true;
            txtDescription.ScrollBars  = ScrollBars.Vertical;
            txtDescription.PlaceholderText = "Describe the item in detail...";

            AddField(lblLocation, "Location *", txtLocation, ref y);
            txtLocation.PlaceholderText = "Where was it lost/found?";

            // Date
            this.lblDate.Text     = "Date *";
            this.lblDate.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblDate.Location = new Point(15, y);
            this.lblDate.Size     = new Size(410, 18);
            y += 20;
            this.dtpDate.Location = new Point(15, y);
            this.dtpDate.Size     = new Size(200, 26);
            this.dtpDate.Font     = new Font("Segoe UI", 10);
            this.dtpDate.Format   = DateTimePickerFormat.Short;
            y += 36;

            // Image
            this.lblImage.Text     = "Photo (optional)";
            this.lblImage.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblImage.Location = new Point(15, y);
            this.lblImage.Size     = new Size(410, 18);
            y += 20;
            this.txtImagePath.Location       = new Point(15, y);
            this.txtImagePath.Size           = new Size(300, 26);
            this.txtImagePath.Font           = new Font("Segoe UI", 10);
            this.txtImagePath.ReadOnly       = true;
            this.txtImagePath.PlaceholderText = "No image selected";

            this.btnBrowseImage.Text      = "Browse…";
            this.btnBrowseImage.Location  = new Point(325, y);
            this.btnBrowseImage.Size      = new Size(100, 26);
            this.btnBrowseImage.Font      = new Font("Segoe UI", 9);
            this.btnBrowseImage.FlatStyle = FlatStyle.Flat;
            this.btnBrowseImage.Cursor    = Cursors.Hand;
            this.btnBrowseImage.Click    += new EventHandler(this.btnBrowseImage_Click);
            y += 36;

            // lblError
            this.lblError.ForeColor = Color.Red;
            this.lblError.Font      = new Font("Segoe UI", 8.5f);
            this.lblError.Location  = new Point(15, y);
            this.lblError.Size      = new Size(410, 18);
            this.lblError.Visible   = false;
            y += 24;

            // Buttons
            this.btnSubmit.Text      = "Submit Report";
            this.btnSubmit.Location  = new Point(15, y);
            this.btnSubmit.Size      = new Size(190, 34);
            this.btnSubmit.Font      = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnSubmit.BackColor = Color.FromArgb(0, 153, 76);
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Cursor    = Cursors.Hand;
            this.btnSubmit.Click    += new EventHandler(this.btnSubmit_Click);

            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Location  = new Point(220, y);
            this.btnCancel.Size      = new Size(205, 34);
            this.btnCancel.Font      = new Font("Segoe UI", 10);
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Cursor    = Cursors.Hand;
            this.btnCancel.Click    += new EventHandler(this.btnCancel_Click);

            this.panelMain.Controls.AddRange(new Control[] {
                lblTitle,
                lblType, rdoLost, rdoFound,
                lblItemName, txtItemName,
                lblCategory, cmbCategory,
                lblDescription, txtDescription,
                lblLocation, txtLocation,
                lblDate, dtpDate,
                lblImage, txtImagePath, btnBrowseImage,
                lblError, btnSubmit, btnCancel
            });

            this.Controls.Add(this.panelMain);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Label           lblTitle;
        private Label           lblType;
        private RadioButton     rdoLost;
        private RadioButton     rdoFound;
        private Label           lblItemName;
        private TextBox         txtItemName;
        private Label           lblCategory;
        private ComboBox        cmbCategory;
        private Label           lblDescription;
        private TextBox         txtDescription;
        private Label           lblLocation;
        private TextBox         txtLocation;
        private Label           lblDate;
        private DateTimePicker  dtpDate;
        private Label           lblImage;
        private TextBox         txtImagePath;
        private Button          btnBrowseImage;
        private Label           lblError;
        private Button          btnSubmit;
        private Button          btnCancel;
        private Panel           panelMain;
    }
}
