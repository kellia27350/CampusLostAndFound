namespace CampusLostAndFound.Views
{
    partial class ItemDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader    = new Panel();
            this.lblTypeBadge   = new Label();
            this.lblStatusBadge = new Label();
            this.lblItemName    = new Label();
            this.lblCategory    = new Label();
            this.lblLocation    = new Label();
            this.lblDate        = new Label();
            this.lblReporter    = new Label();
            this.lblDescTitle   = new Label();
            this.txtDescription = new TextBox();
            this.picImage       = new PictureBox();
            this.panelButtons   = new Panel();
            this.btnMarkReturned= new Button();
            this.btnClaim       = new Button();
            this.btnViewClaims  = new Button();
            this.btnClose       = new Button();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picImage).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text            = "Item Details";
            this.Size            = new Size(560, 580);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.ItemDetailsForm_Load);

            // panelHeader  (white card)
            this.panelHeader.BackColor = Color.White;
            this.panelHeader.Location  = new Point(15, 10);
            this.panelHeader.Size      = new Size(510, 420);

            // badges
            this.lblTypeBadge.Font      = new Font("Segoe UI", 8, FontStyle.Bold);
            this.lblTypeBadge.ForeColor = Color.White;
            this.lblTypeBadge.Location  = new Point(15, 15);
            this.lblTypeBadge.Size      = new Size(55, 22);
            this.lblTypeBadge.TextAlign = ContentAlignment.MiddleCenter;

            this.lblStatusBadge.Font      = new Font("Segoe UI", 8, FontStyle.Bold);
            this.lblStatusBadge.ForeColor = Color.White;
            this.lblStatusBadge.Location  = new Point(78, 15);
            this.lblStatusBadge.Size      = new Size(70, 22);
            this.lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;

            // item name
            this.lblItemName.Font      = new Font("Segoe UI", 15, FontStyle.Bold);
            this.lblItemName.ForeColor = Color.FromArgb(30, 30, 30);
            this.lblItemName.Location  = new Point(15, 46);
            this.lblItemName.Size      = new Size(480, 32);

            // meta labels
            int y = 88;
            void MetaLabel(Label lbl, int yy)
            {
                lbl.Font      = new Font("Segoe UI", 9.5f);
                lbl.ForeColor = Color.FromArgb(80, 80, 80);
                lbl.Location  = new Point(15, yy);
                lbl.Size      = new Size(480, 20);
            }

            MetaLabel(lblCategory, y);  y += 24;
            MetaLabel(lblLocation,  y);  y += 24;
            MetaLabel(lblDate,      y);  y += 24;
            MetaLabel(lblReporter,  y);  y += 32;

            // description
            this.lblDescTitle.Text      = "Description";
            this.lblDescTitle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblDescTitle.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblDescTitle.Location  = new Point(15, y);
            this.lblDescTitle.Size      = new Size(200, 18);
            y += 20;

            this.txtDescription.Location   = new Point(15, y);
            this.txtDescription.Size       = new Size(300, 80);
            this.txtDescription.Font       = new Font("Segoe UI", 9.5f);
            this.txtDescription.Multiline  = true;
            this.txtDescription.ReadOnly   = true;
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            this.txtDescription.BackColor  = Color.FromArgb(248, 249, 250);
            this.txtDescription.BorderStyle= BorderStyle.FixedSingle;

            // image
            this.picImage.Location   = new Point(325, y);
            this.picImage.Size       = new Size(170, 100);
            this.picImage.SizeMode   = PictureBoxSizeMode.Zoom;
            this.picImage.BorderStyle= BorderStyle.FixedSingle;
            this.picImage.Visible    = false;

            this.panelHeader.Controls.AddRange(new Control[] {
                lblTypeBadge, lblStatusBadge, lblItemName,
                lblCategory, lblLocation, lblDate, lblReporter,
                lblDescTitle, txtDescription, picImage
            });

            // panelButtons
            this.panelButtons.BackColor = Color.White;
            this.panelButtons.Location  = new Point(15, 440);
            this.panelButtons.Size      = new Size(510, 60);

            Button StyleBtn(Button b, string text, Color bg, int x)
            {
                b.Text      = text;
                b.Location  = new Point(x, 12);
                b.Size      = new Size(155, 34);
                b.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
                b.BackColor = bg;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Cursor    = Cursors.Hand;
                return b;
            }

            StyleBtn(btnMarkReturned, "✔ Mark Returned", Color.FromArgb(0, 153, 76),    0);
            StyleBtn(btnClaim,        "📩 Claim Item",   Color.FromArgb(255, 140, 0),  165);
            StyleBtn(btnViewClaims,   "📋 View Claims",  Color.FromArgb(0, 102, 204),  330);

            this.btnMarkReturned.Click += new EventHandler(this.btnMarkReturned_Click);
            this.btnClaim.Click        += new EventHandler(this.btnClaim_Click);
            this.btnViewClaims.Click   += new EventHandler(this.btnViewClaims_Click);

            // btnClose
            this.btnClose.Text      = "Close";
            this.btnClose.Location  = new Point(420, 510);
            this.btnClose.Size      = new Size(105, 30);
            this.btnClose.Font      = new Font("Segoe UI", 9);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Cursor    = Cursors.Hand;
            this.btnClose.Click    += new EventHandler(this.btnClose_Click);

            this.panelButtons.Controls.AddRange(new Control[] {
                btnMarkReturned, btnClaim, btnViewClaims
            });

            this.Controls.AddRange(new Control[] { panelHeader, panelButtons, btnClose });
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.picImage).EndInit();
            this.ResumeLayout(false);
        }

        private Panel       panelHeader;
        private Panel       panelButtons;
        private Label       lblTypeBadge;
        private Label       lblStatusBadge;
        private Label       lblItemName;
        private Label       lblCategory;
        private Label       lblLocation;
        private Label       lblDate;
        private Label       lblReporter;
        private Label       lblDescTitle;
        private TextBox     txtDescription;
        private PictureBox  picImage;
        private Button      btnMarkReturned;
        private Button      btnClaim;
        private Button      btnViewClaims;
        private Button      btnClose;
    }
}
