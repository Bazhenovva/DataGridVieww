using DataGridView.Models.Constants;
using DataGridView.Models.Models;
using UI.Extensions;

namespace UI.Forms
{
    /// <summary>
    /// Форма добавления/редактирования товара
    /// </summary>
    public partial class ProductEditForm : Form
    {
        private readonly Product product;

        /// <summary>
        /// Инициализирует новую форму редактирования товара
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
        /// Инициализирует элементы управления формы
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

           numericUpDownPrice.Minimum = ValidationConstants.PriceUiMin;
           numericUpDownPrice.Maximum = ValidationConstants.PriceMax;
           numericUpDownPrice.DecimalPlaces = ValidationConstants.PriceDecimalPlaces;
       }

        /// <summary>
        /// Загружает данные товара в элементы управления
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
            try
            {
                var validatedProduct = new Product(
                    textBoxName.Text.Trim(),
                    (ProductSize)comboBoxSize.SelectedItem!,
                    (Material)comboBoxMaterial.SelectedItem!,
                    (int)numericUpDownQuantity.Value,
                    (int)numericUpDownMinQuantity.Value,
                    numericUpDownPrice.Value
                );

                validatedProduct.Id = product.Id;
                product.ProductName = validatedProduct.ProductName;
                product.ProductSize = validatedProduct.ProductSize;
                product.Material = validatedProduct.Material;
                product.Quantity = validatedProduct.Quantity;
                product.MinQuantity = validatedProduct.MinQuantity;
                product.Price = validatedProduct.Price;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
