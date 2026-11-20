using CampusLostAndFound.Controllers;
using CampusLostAndFound.Models;

namespace CampusLostAndFound.Views
{
    public partial class ReportItemForm : Form
    {
        private readonly AccountController _accountController;
        private readonly ItemController    _itemController;

        public ReportItemForm(AccountController accountController, ItemController itemController)
        {
            _accountController = accountController;
            _itemController    = itemController;
            InitializeComponent();
        }

        private void ReportItemForm_Load(object sender, EventArgs e)
        {
            // Populate categories
            var categories = _itemController.GetCategories();
            cmbCategory.DataSource    = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember   = "CategoryId";

            // Default date = today
            dtpDate.Value = DateTime.Today;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title  = "Select Item Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                txtImagePath.Text = dlg.FileName;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var reportType = rdoLost.Checked ? ReportType.Lost : ReportType.Found;
            var category   = cmbCategory.SelectedItem as Category;
            int categoryId = category?.CategoryId ?? 0;
            string? image  = string.IsNullOrWhiteSpace(txtImagePath.Text) ? null : txtImagePath.Text.Trim();

            var (itemId, error) = _itemController.SubmitReport(
                userId:     _accountController.CurrentUser!.UserId,
                itemName:   txtItemName.Text,
                description:txtDescription.Text,
                location:   txtLocation.Text,
                reportDate: dtpDate.Value,
                reportType: reportType,
                categoryId: categoryId,
                imagePath:  image);

            if (itemId == 0)
            {
                lblError.Text    = error;
                lblError.Visible = true;
                return;
            }

            MessageBox.Show("Your report has been submitted successfully!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
