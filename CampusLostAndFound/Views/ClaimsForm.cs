using CampusLostAndFound.Controllers;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Views
{
    /// <summary>
    /// Shows claims for a specific item (when itemId > 0) or all claims by the current user.
    /// </summary>
    public partial class ClaimsForm : Form
    {
        private readonly AccountController _accountController;
        private readonly ClaimController   _claimController;
        private readonly ItemController    _itemController;
        private readonly int               _itemId; // 0 = "my claims" mode

        public ClaimsForm(AccountController accountController,
                          ClaimController   claimController,
                          ItemController    itemController,
                          int itemId = 0)
        {
            _accountController = accountController;
            _claimController   = claimController;
            _itemController    = itemController;
            _itemId            = itemId;
            InitializeComponent();
        }

        private void ClaimsForm_Load(object sender, EventArgs e)
        {
            if (_itemId > 0)
            {
                var item    = _itemController.GetById(_itemId);
                lblTitle.Text = $"Claims for: {item?.ItemName ?? "Item"}";
            }
            else
            {
                lblTitle.Text = "My Submitted Claims";
            }
            LoadClaims();
        }

        private void LoadClaims()
        {
            var claims = _itemId > 0
                ? _claimController.GetClaimsForItem(_itemId)
                : _claimController.GetClaimsByUser(_accountController.CurrentUser!.UserId);

            dgvClaims.Rows.Clear();
            foreach (var c in claims)
            {
                dgvClaims.Rows.Add(
                    c.ClaimId,
                    c.ItemName,
                    c.ClaimantName,
                    c.ClaimantEmail,
                    c.Explanation.Length > 80 ? c.Explanation[..80] + "…" : c.Explanation,
                    c.ClaimDate.ToString("dd MMM yyyy HH:mm"),
                    c.ClaimStatus.ToString()
                );
            }
            lblCount.Text = $"{claims.Count} claim(s)";
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
