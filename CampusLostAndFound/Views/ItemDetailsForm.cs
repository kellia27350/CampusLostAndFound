using CampusLostAndFound.Controllers;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Views
{
    public partial class ItemDetailsForm : Form
    {
        private readonly Item              _item;
        private readonly AccountController _accountController;
        private readonly ItemController    _itemController;
        private readonly ClaimController   _claimController;

        public ItemDetailsForm(Item item,
                               AccountController accountController,
                               ItemController    itemController,
                               ClaimController   claimController)
        {
            _item              = item;
            _accountController = accountController;
            _itemController    = itemController;
            _claimController   = claimController;
            InitializeComponent();
        }

        private void ItemDetailsForm_Load(object sender, EventArgs e)
        {
            lblTypeBadge.Text      = _item.ReportTypeLabel.ToUpper();
            lblTypeBadge.BackColor = _item.ReportType == ReportType.Lost
                ? Color.FromArgb(220, 53, 69)
                : Color.FromArgb(0, 153, 76);

            lblStatusBadge.Text      = _item.StatusLabel.ToUpper();
            lblStatusBadge.BackColor = _item.Status == ItemStatus.Active
                ? Color.FromArgb(0, 102, 204)
                : Color.Gray;

            lblItemName.Text    = _item.ItemName;
            lblCategory.Text    = $"Category: {_item.CategoryName}";
            lblLocation.Text    = $"📍  {_item.Location}";
            lblDate.Text        = $"🗓  {_item.ReportDate:dd MMM yyyy}";
            lblReporter.Text    = $"👤  Reported by: {_item.ReporterName}  ({_item.ReporterEmail})";
            txtDescription.Text = _item.Description;

            // Show image if available
            if (!string.IsNullOrEmpty(_item.ImagePath) && File.Exists(_item.ImagePath))
            {
                try
                {
                    picImage.Image   = Image.FromFile(_item.ImagePath);
                    picImage.Visible = true;
                }
                catch { picImage.Visible = false; }
            }

            var currentUser = _accountController.CurrentUser!;
            bool isOwner    = _item.UserId == currentUser.UserId;
            bool isAdmin    = currentUser.IsAdmin;

            // "Mark Returned" button: owner or admin, item still active
            btnMarkReturned.Visible = (isOwner || isAdmin) && _item.Status == ItemStatus.Active;

            // "Claim Item" button: Found items, not own report, still active, logged-in student
            btnClaim.Visible = _item.ReportType == ReportType.Found
                && !isOwner
                && _item.Status == ItemStatus.Active
                && !isAdmin;

            // "View Claims" button: owner of a Found item, or admin
            btnViewClaims.Visible = (_item.ReportType == ReportType.Found && isOwner) || isAdmin;
        }

        private void btnMarkReturned_Click(object sender, EventArgs e)
        {
            var user           = _accountController.CurrentUser!;
            var (success, err) = _itemController.MarkReturned(_item.ItemId, user.UserId, user.IsAdmin);
            if (!success)
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Item marked as Returned.", "Updated",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            // Inline input dialog – no VisualBasic dependency needed
            string explanation = string.Empty;
            using var dlg = new Form
            {
                Text            = "Submit Claim",
                Size            = new Size(420, 200),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false
            };
            var lbl = new Label { Text = "Explain why you believe this item belongs to you:",
                Location = new Point(15, 15), Size = new Size(380, 36),
                Font = new Font("Segoe UI", 9) };
            var txt = new TextBox { Location = new Point(15, 55), Size = new Size(380, 60),
                Multiline = true, Font = new Font("Segoe UI", 10) };
            var btnOk = new Button { Text = "Submit", Location = new Point(15, 125),
                Size = new Size(100, 30), DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(0,102,204), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat };
            btnOk.FlatAppearance.BorderSize = 0;
            var btnNo = new Button { Text = "Cancel", Location = new Point(125, 125),
                Size = new Size(100, 30), DialogResult = DialogResult.Cancel,
                FlatStyle = FlatStyle.Flat };
            dlg.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnNo });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnNo;

            if (dlg.ShowDialog() != DialogResult.OK) return;
            explanation = txt.Text.Trim();
            if (string.IsNullOrWhiteSpace(explanation)) return;

            var user           = _accountController.CurrentUser!;
            var (success, err) = _claimController.SubmitClaim(user.UserId, _item.ItemId, explanation);
            if (!success)
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Your claim has been submitted successfully!",
                "Claim Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnClaim.Enabled = false;
        }

        private void btnViewClaims_Click(object sender, EventArgs e)
        {
            var claims = _claimController.GetClaimsForItem(_item.ItemId);
            if (claims.Count == 0)
            {
                MessageBox.Show("No claims have been submitted for this item yet.",
                    "Claims", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var form = new ClaimsForm(_accountController, _claimController, _itemController,
                itemId: _item.ItemId);
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
