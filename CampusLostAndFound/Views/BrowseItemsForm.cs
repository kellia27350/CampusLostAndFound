using CampusLostAndFound.Controllers;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Views
{
    public partial class BrowseItemsForm : Form
    {
        private readonly AccountController _accountController;
        private readonly ItemController    _itemController;
        private readonly ClaimController   _claimController;

        public BrowseItemsForm(AccountController accountController,
                               ItemController    itemController,
                               ClaimController   claimController)
        {
            _accountController = accountController;
            _itemController    = itemController;
            _claimController   = claimController;
            InitializeComponent();
        }

        private void BrowseItemsForm_Load(object sender, EventArgs e)
        {
            // Category filter
            var cats = _itemController.GetCategories();
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add(new Category { CategoryId = 0, CategoryName = "All Categories" });
            foreach (var c in cats) cmbCategory.Items.Add(c);
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember   = "CategoryId";
            cmbCategory.SelectedIndex = 0;

            LoadItems();
        }

        private void LoadItems()
        {
            string keyword    = txtSearch.Text.Trim();
            string typeFilter = cmbType.SelectedItem?.ToString() ?? "All";
            int    catFilter  = (cmbCategory.SelectedItem as Category)?.CategoryId ?? 0;

            var items = string.IsNullOrWhiteSpace(keyword) && typeFilter == "All" && catFilter == 0
                ? _itemController.GetActiveItems()
                : _itemController.Search(keyword, typeFilter == "All" ? "" : typeFilter, catFilter);

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

            lblCount.Text = $"{items.Count} report(s) found";
        }

        private void btnSearch_Click(object sender, EventArgs e) => LoadItems();

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbType.SelectedIndex     = 0;
            cmbCategory.SelectedIndex = 0;
            LoadItems();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int itemId = (int)dgvItems.Rows[e.RowIndex].Cells["colId"].Value;
            var item   = _itemController.GetById(itemId);
            if (item == null) return;

            using var details = new ItemDetailsForm(item, _accountController, _itemController, _claimController);
            details.ShowDialog();
            LoadItems(); // refresh after possible status change
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadItems();
        }
    }
}
