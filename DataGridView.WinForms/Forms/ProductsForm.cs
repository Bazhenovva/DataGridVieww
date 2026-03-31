using DataGridView.Models;
using DataGridView.Models.Constants;
using DataGridView.Services.Contracts;

namespace DataGridView.WinForms.Forms
{
    /// <summary>
    /// Главная форма приложения со списком товаров
    /// </summary>
    public partial class ProductsForm : Form
    {
        private readonly IProductService productService;

        /// <summary>
        /// Инициализирует новую главную форму
        /// </summary>
        public ProductsForm(IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            Text = UiConstants.FormTitle;
            InitializeDataGridView();
        }

        /// <summary>
        /// Инициализирует DataGridView с данными о товарах
        /// </summary>
        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = productService.GetAll();
        }

        /// <summary>
        /// Обработчик кнопки добавления нового товара
        /// </summary>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var newProduct = new Product();
            var form = new ProductEditForm(newProduct, true);

            if (form.ShowDialog() == DialogResult.OK)
            {
                productService.Add(newProduct);
            }
        }

        /// <summary>
        /// Обработчик кнопки редактирования выбранного товара
        /// </summary>
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].DataBoundItem is Product product)
            {
                var form = new ProductEditForm(product, false);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    productService.Update(product);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования", UiConstants.MessageBoxWarningTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик кнопки удаления выбранного товара
        /// </summary>
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].DataBoundItem is Product product)
            {
                var result = MessageBox.Show(
                    $"Удалить товар \"{product.ProductName}\"?",
                    UiConstants.MessageBoxDeleteTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    productService.Delete(product);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления", UiConstants.MessageBoxWarningTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Отрисовка столбца, индикатор заполнения
        /// </summary>
        private void dataGridView1_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            const int cellOffset = UiConstants.CellOffset;

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                dataGridView1.Columns[e.ColumnIndex].Name == UiConstants.QuantityColumnName)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Product product)
                {
                    e.Handled = true;
                    e.PaintBackground(e.ClipBounds, false);

                    using var borderPen = new Pen(UiConstants.QuantityProgressBarBorderColor);
                    using var fillBrush = new SolidBrush(UiConstants.QuantityProgressBarFillColor);

                    e.Graphics?.DrawRectangle(borderPen, new Rectangle(
                        e.CellBounds.X + cellOffset,
                        e.CellBounds.Y + cellOffset,
                        e.CellBounds.Width - cellOffset * 2 - 1,
                        e.CellBounds.Height - cellOffset * 2 - 1));

                    var fillWidth = (product.Quantity *
                        (e.CellBounds.Width - cellOffset * 2 - 1) / ValidationConstants.QuantityMax);

                    e.Graphics?.FillRectangle(fillBrush, new Rectangle(
                        e.CellBounds.X + cellOffset,
                        e.CellBounds.Y + cellOffset,
                        fillWidth,
                        e.CellBounds.Height - cellOffset * 2 - 1));

                    if (e.Graphics != null)
                    {
                        TextRenderer.DrawText(e.Graphics, product.Quantity.ToString(),
                            e.CellStyle?.Font ?? dataGridView1.Font, e.CellBounds,
                            UiConstants.QuantityProgressTextColor,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
            }
        }
    }
}
