using DataGridView.Models.Constants;
using DataGridView.Models.Models;
using DataGridView.Services.Contracts;

namespace DataGriaView.Forms
{
    public partial class Form1 : Form
    {
        private readonly IProductService productService;

        public Form1(IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            Text = AppConstants.FormTitle;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = productService.GetAll();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var newProduct = new Product();
            var form = new ProductEditForm(newProduct, true);

            if (form.ShowDialog() == DialogResult.OK)
            {
                productService.Add(newProduct);
            }
        }

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
                MessageBox.Show("Выберите товар для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].DataBoundItem is Product product)
            {
                var result = MessageBox.Show(
                    $"Удалить товар \"{product.ProductName}\"?",
                    "Удаление товара",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    productService.Delete(product);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const int cellOffset = 2;

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                dataGridView1.Columns[e.ColumnIndex].Name == "QuantityColumn")
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Product product)
                {
                    e.Handled = true;
                    e.PaintBackground(e.ClipBounds, false);

                    e.Graphics.DrawRectangle(Pens.SteelBlue, new Rectangle(
                        e.CellBounds.X + cellOffset,
                        e.CellBounds.Y + cellOffset,
                        e.CellBounds.Width - cellOffset * 2 - 1,
                        e.CellBounds.Height - cellOffset * 2 - 1));

                    int fillWidth = (int)(product.Quantity *
                        (e.CellBounds.Width - cellOffset * 2 - 1) / AppConstants.QuantityMax);

                    e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(
                        e.CellBounds.X + cellOffset,
                        e.CellBounds.Y + cellOffset,
                        fillWidth,
                        e.CellBounds.Height - cellOffset * 2 - 1));

                    string text = product.Quantity.ToString();
                    Font font = e.CellStyle.Font ?? dataGridView1.Font;
                    TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                                           TextFormatFlags.VerticalCenter;

                    TextRenderer.DrawText(e.Graphics, text, font, e.CellBounds, Color.Black, flags);
                }
            }
        }
    }
}
