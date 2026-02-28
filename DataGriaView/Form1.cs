using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridView
{
    /// <summary>
    /// Главная форма приложения
    /// Отображает реестр товаров в DataGridView с кастомной отрисовкой
    /// количества на складе и автоматической привязкой данных
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly BindingSource source = new();

        /// <summary>
        /// Инициализирует форму, настраивает DataGridView
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            InitializeDataGridView();
        }

        /// <summary>
        /// Инициализирует список товаров и привязывает его к DataGridView
        /// </summary>
        private void InitializeDataGridView()
        {
            var products = new List<Product>
            {
                new Product("Гвоздь", ProductSize.Size10Mm, Material.Steel, 100, 20, 3.5m),
                new Product("Гайка", ProductSize.M8, Material.Copper, 50, 10, 7.2m),
                new Product("Болт", ProductSize.M10, Material.Iron, 15, 15, 9.0m),
                new Product("Шайба", ProductSize.M6, Material.Chrome, 3, 30, 2.1m)
            };

            dataGridView1.AutoGenerateColumns = false;
            source.DataSource = products;
            dataGridView1.DataSource = source;
        }

        /// <summary>
        /// отрисовка ячейки "Количество на складе"
        /// Отображает голубую полосу-индикатор заполнения (максимум 100)
        /// </summary>
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const int cellOffset = 2;
            const float maxQuantity = 100;

            if (e is { ColumnIndex: >= 0, RowIndex: >= 0 } &&
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
                        (e.CellBounds.Width - cellOffset * 2 - 1) / maxQuantity);

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
