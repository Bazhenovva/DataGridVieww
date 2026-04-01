using DataGridView.Models;
using DataGridView.Models.Constants;
using DataGridView.WinForms.Extensions;
using DataGridView.WinForms.UI;

namespace DataGridView.WinForms.Forms
{
    public partial class ProductEditForm : Form
    {
        private readonly Product product;

        public ProductEditForm(Product productToEdit, bool isNew)
        {
            InitializeComponent();
            product = productToEdit;
            Text = isNew ? UiConstants.FormAddTitle : UiConstants.FormEditTitle;

            textBoxName.AddBinding("Text", product, p => p.ProductName, errorProvider1);
            numericUpDownQuantity.AddBinding("Value", product, p => p.Quantity, errorProvider1);
            numericUpDownMinQuantity.AddBinding("Value", product, p => p.MinQuantity, errorProvider1);
            numericUpDownPrice.AddBinding("Value", product, p => p.Price, errorProvider1);

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

            numericUpDownQuantity.Minimum = ValidationConstants.QuantityMin;
            numericUpDownQuantity.Maximum = ValidationConstants.QuantityMax;
            numericUpDownMinQuantity.Minimum = ValidationConstants.MinQuantityMin;
            numericUpDownMinQuantity.Maximum = ValidationConstants.MinQuantityMax;
            numericUpDownPrice.Minimum = ValidationConstants.PriceMin;
            numericUpDownPrice.Maximum = ValidationConstants.PriceMax;
            numericUpDownPrice.DecimalPlaces = ValidationConstants.PriceDecimalPlaces;
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
            if (!ValidateChildren())
            {
                MessageBox.Show("Исправьте ошибки в полях перед сохранением.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedSize = (ProductSize)comboBoxSize.SelectedItem;
            var selectedMaterial = (Material)comboBoxMaterial.SelectedItem;

            product.ProductName = textBoxName.Text.Trim();
            product.ProductSize = selectedSize;
            product.Material = selectedMaterial;
            product.Quantity = (int)numericUpDownQuantity.Value;
            product.MinQuantity = (int)numericUpDownMinQuantity.Value;
            product.Price = numericUpDownPrice.Value;

            DialogResult = DialogResult.OK;
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
