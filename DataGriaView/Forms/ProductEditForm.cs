using System.ComponentModel.DataAnnotations;

namespace DataGridView
{
    public partial class ProductEditForm : Form
    {
        private readonly Product product;
        private readonly bool isNew;

        public ProductEditForm(Product productToEdit, bool isNew)
        {
            InitializeComponent();
            product = productToEdit;
            isNew = isNew;
            Text = isNew ? AppConstants.FormAddTitle : AppConstants.FormEditTitle;
            InitializeControls();
            LoadProductData();
        }

        private void InitializeControls()
        {
            comboBoxSize.DataSource = new[]
            {
                ProductSize.M6, ProductSize.M8, ProductSize.M10,
                ProductSize.M12, ProductSize.Size10Mm, ProductSize.Size20Mm
            };

            comboBoxMaterial.DataSource = new[]
            {
                Material.Copper, Material.Steel, Material.Iron, Material.Chrome
            };

            numericUpDownQuantity.Minimum = 0;
            numericUpDownQuantity.Maximum = AppConstants.QuantityMax;

            numericUpDownMinQuantity.Minimum = AppConstants.MinQuantityMin;
            numericUpDownMinQuantity.Maximum = AppConstants.MinQuantityMax;

            numericUpDownPrice.Minimum = 0;
            numericUpDownPrice.Maximum = AppConstants.PriceMax;
            numericUpDownPrice.DecimalPlaces = 2;
        }

        private void LoadProductData()
        {
            textBoxName.Text = product.ProductName;
            comboBoxSize.SelectedItem = product.ProductSize;
            comboBoxMaterial.SelectedItem = product.Material;
            numericUpDownQuantity.Value = product.Quantity;
            numericUpDownMinQuantity.Value = product.MinQuantity;
            numericUpDownPrice.Value = product.Price;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            product.ProductName = textBoxName.Text.Trim();
            product.ProductSize = (ProductSize)comboBoxSize.SelectedItem;
            product.Material = (Material)comboBoxMaterial.SelectedItem;
            product.Quantity = (int)numericUpDownQuantity.Value;
            product.MinQuantity = (int)numericUpDownMinQuantity.Value;
            product.Price = numericUpDownPrice.Value;

            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(product, context, results, validateAllProperties: true))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                string errorMessage = "Исправьте ошибки:\n\n" + string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(errorMessage, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
