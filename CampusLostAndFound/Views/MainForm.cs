using CampusLostAndFound.Controllers;

namespace CampusLostAndFound.Views
{
    public partial class MainForm : Form
    {
        private readonly AccountController _accountController;
        private readonly ItemController    _itemController;
        private readonly ClaimController   _claimController;

        public MainForm(AccountController accountController,
                        ItemController    itemController,
                        ClaimController   claimController)
        {
            _accountController = accountController;
            _itemController    = itemController;
            _claimController   = claimController;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var user = _accountController.CurrentUser!;
            lblWelcome.Text = $"Welcome, {user.FullName}  ({user.Role})";

            // Show admin button only for admins
            btnAdmin.Visible = user.IsAdmin;
        }

        // ── Navigation ─────────────────────────────────────────────────────
        private void btnReport_Click(object sender, EventArgs e)
        {
            using var form = new ReportItemForm(_accountController, _itemController);
            form.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var form = new BrowseItemsForm(_accountController, _itemController, _claimController);
            form.ShowDialog();
        }

        private void btnMyClaims_Click(object sender, EventArgs e)
        {
            using var form = new ClaimsForm(_accountController, _claimController, _itemController);
            form.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            using var form = new AdminDashboardForm(_accountController, _itemController, _claimController);
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Log Out",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _accountController.Logout();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
