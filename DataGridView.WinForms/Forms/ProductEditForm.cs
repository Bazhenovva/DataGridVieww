using System.ComponentModel.DataAnnotations;
using DataGridView.Models;
using DataGridView.Models.Constants;
using DataGridView.WinForms.Extensions;
using DataGridView.WinForms.UI;

namespace DataGridView.WinForms.Forms
{
    /// <summary>
    /// Форма редактирования товара
    /// </summary>
    public partial class ProductEditForm : Form
    {
        private readonly Product product;

        /// <summary>
        /// Инициализирует форму редактирования товара
        /// </summary>
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

        /// <summary>
        /// Инициализирует контролы формы
        /// </summary>
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
            numericUpDownPrice.Minimum = UiConstants.PriceUiMin;
            numericUpDownPrice.Maximum = ValidationConstants.PriceMax;
            numericUpDownPrice.DecimalPlaces = ValidationConstants.PriceDecimalPlaces;
        }

        /// <summary>
        /// Загружает данные товара в форму
        /// </summary>
        private void LoadProductData()
        {
            textBoxName.Text = product.ProductName;
            comboBoxSize.SelectedItem = product.ProductSize;
            comboBoxMaterial.SelectedItem = product.Material;
            numericUpDownQuantity.Value = product.Quantity;
            numericUpDownMinQuantity.Value = product.MinQuantity;
            numericUpDownPrice.Value = product.Price;
        }

        /// <summary>
        /// Обработчик кнопки сохранения товара
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (comboBoxSize.SelectedItem is not ProductSize selectedSize)
            {
                errorProvider1.SetError(comboBoxSize, "Выберите размер");
                MessageBox.Show("Выберите размер товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxMaterial.SelectedItem is not Material selectedMaterial)
            {
                errorProvider1.SetError(comboBoxMaterial, "Выберите материал");
                MessageBox.Show("Выберите материал товара", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            product.ProductName = textBoxName.Text.Trim();
            product.ProductSize = selectedSize;
            product.Material = selectedMaterial;
            product.Quantity = (int)numericUpDownQuantity.Value;
            product.MinQuantity = (int)numericUpDownMinQuantity.Value;
            product.Price = numericUpDownPrice.Value;

            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(product, context, results, validateAllProperties: true))
            {
                foreach (var error in results)
                {
                    foreach (var memberName in error.MemberNames)
                    {
                        switch (memberName)
                        {
                            case nameof(Product.ProductName):
                                errorProvider1.SetError(textBoxName, error.ErrorMessage);
                                break;
                            case nameof(Product.Price):
                                errorProvider1.SetError(numericUpDownPrice, error.ErrorMessage);
                                break;
                            case nameof(Product.Quantity):
                                errorProvider1.SetError(numericUpDownQuantity, error.ErrorMessage);
                                break;
                            case nameof(Product.MinQuantity):
                                errorProvider1.SetError(numericUpDownMinQuantity, error.ErrorMessage);
                                break;
                        }
                    }
                }

                MessageBox.Show("Исправьте ошибки в полях перед сохранением.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обработчик кнопки отмены
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
