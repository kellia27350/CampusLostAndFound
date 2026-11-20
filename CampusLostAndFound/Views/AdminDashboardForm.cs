using CampusLostAndFound.Controllers;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Views
{
    public partial class AdminDashboardForm : Form
    {
        private readonly AccountController _accountController;
        private readonly ItemController    _itemController;
        private readonly ClaimController   _claimController;
        private readonly AdminController   _adminController = new();

        public AdminDashboardForm(AccountController accountController,
                                  ItemController    itemController,
                                  ClaimController   claimController)
        {
            _accountController = accountController;
            _itemController    = itemController;
            _claimController   = claimController;
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadStats();
            LoadItems();
        }

        // ── Stats ───────────────────────────────────────────────────────────
        private void LoadStats()
        {
            var (total, active, returned, users, claims) =
                _adminController.GetStats(_accountController.IsAdmin);

            lblStatItems.Text    = $"Total Reports:  {total}";
            lblStatActive.Text   = $"Active:         {active}";
            lblStatReturned.Text = $"Returned:       {returned}";
            lblStatUsers.Text    = $"Registered Users: {users}";
            lblStatClaims.Text   = $"Total Claims:   {claims}";
        }

        // ── Items tab ───────────────────────────────────────────────────────
        private void LoadItems()
        {
            var items = _adminController.GetAllItems(_accountController.IsAdmin);
            dgvItems.Rows.Clear();
            foreach (var item in items)
            {
                dgvItems.Rows.Add(
                    item.ItemId,
                    item.ReportTypeLabel,
                    item.ItemName,
                    item.CategoryName,
                    item.Location,
                    item.ReportDate.ToShortDateString(),
                    item.StatusLabel,
                    item.ReporterName
                );
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow == null) return;
            int itemId = (int)dgvItems.CurrentRow.Cells["colAdmId"].Value;

            if (MessageBox.Show("Remove this report permanently?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            var (ok, err) = _adminController.RemoveItem(itemId, _accountController.IsAdmin);
            if (!ok) { MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            LoadItems();
            LoadStats();
        }

        private void btnMarkReturnedItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow == null) return;
            int itemId     = (int)dgvItems.CurrentRow.Cells["colAdmId"].Value;
            var (ok, err)  = _adminController.MarkItemReturned(itemId, _accountController.IsAdmin);
            if (!ok) { MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Item marked as Returned.", "Updated",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadItems();
            LoadStats();
        }

        // ── Users tab ───────────────────────────────────────────────────────
        private void tabAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabAdmin.SelectedTab == tabPageUsers) LoadUsers();
            if (tabAdmin.SelectedTab == tabPageClaims) LoadAdminClaims();
        }

        private void LoadUsers()
        {
            var users = _adminController.GetAllUsers(_accountController.IsAdmin);
            dgvUsers.Rows.Clear();
            foreach (var u in users)
            {
                dgvUsers.Rows.Add(u.UserId, u.FullName, u.Email,
                    u.StudentId, u.Role.ToString(), u.CreatedAt.ToShortDateString());
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = (int)dgvUsers.CurrentRow.Cells["colUsrId"].Value;

            if (MessageBox.Show("Remove this user account?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            var (ok, err) = _adminController.RemoveUser(
                userId, _accountController.CurrentUser!.UserId, _accountController.IsAdmin);
            if (!ok) { MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            LoadUsers();
            LoadStats();
        }

        // ── Claims tab ──────────────────────────────────────────────────────
        private void LoadAdminClaims()
        {
            var claims = _adminController.GetAllClaims(_accountController.IsAdmin);
            dgvAdminClaims.Rows.Clear();
            foreach (var c in claims)
            {
                dgvAdminClaims.Rows.Add(
                    c.ClaimId, c.ItemName, c.ClaimantName,
                    c.ClaimantEmail,
                    c.Explanation.Length > 60 ? c.Explanation[..60] + "…" : c.Explanation,
                    c.ClaimDate.ToString("dd MMM yyyy"),
                    c.ClaimStatus.ToString()
                );
            }
        }

        private void btnUpdateClaimStatus_Click(object sender, EventArgs e)
        {
            if (dgvAdminClaims.CurrentRow == null) return;
            int claimId = (int)dgvAdminClaims.CurrentRow.Cells["colAClaimId"].Value;

            using var dlg = new Form
            {
                Text = "Update Claim Status", Size = new Size(300, 160),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false
            };
            var cmb = new ComboBox { Location = new Point(20, 20), Size = new Size(240, 26),
                DropDownStyle = ComboBoxStyle.DropDownList };
            cmb.Items.AddRange(Enum.GetNames(typeof(ClaimStatus)));
            cmb.SelectedIndex = 0;
            var btnOk = new Button { Text = "Update", Location = new Point(20, 60),
                Size = new Size(100, 30), DialogResult = DialogResult.OK };
            dlg.Controls.AddRange(new Control[] { cmb, btnOk });
            dlg.AcceptButton = btnOk;

            if (dlg.ShowDialog() != DialogResult.OK) return;
            var newStatus = Enum.Parse<ClaimStatus>(cmb.SelectedItem!.ToString()!);
            _adminController.UpdateClaimStatus(claimId, newStatus, _accountController.IsAdmin);
            LoadAdminClaims();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
