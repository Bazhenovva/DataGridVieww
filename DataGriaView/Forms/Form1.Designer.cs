namespace DataGridView
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();

            dataGridView1 = new System.Windows.Forms.DataGridView();
            ProductNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            MaterialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            MinQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TotalAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();

            // toolStrip1
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonDelete });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1332, 35);
            toolStrip1.TabIndex = 1;

            // toolStripButtonAdd
            toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new System.Drawing.Size(64, 32);
            toolStripButtonAdd.Text = "Добавить";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;

            // toolStripButtonEdit
            toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new System.Drawing.Size(82, 32);
            toolStripButtonEdit.Text = "Редактировать";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;

            // toolStripButtonDelete
            toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new System.Drawing.Size(58, 32);
            toolStripButtonDelete.Text = "Удалить";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;

            // dataGridView1
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ProductNameColumn, SizeColumn, MaterialColumn, QuantityColumn, MinQuantityColumn, PriceColumn, TotalAmountColumn });
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 35);
            dataGridView1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 2);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new System.Drawing.Size(1332, 756);
            dataGridView1.TabIndex = 2;

            // ProductNameColumn
            ProductNameColumn.DataPropertyName = "ProductName";
            ProductNameColumn.HeaderText = "Наименование товара";
            ProductNameColumn.MinimumWidth = 8;
            ProductNameColumn.Name = "ProductNameColumn";
            ProductNameColumn.ReadOnly = true;
            ProductNameColumn.Width = 150;

            // SizeColumn
            SizeColumn.DataPropertyName = "ProductSize";
            SizeColumn.HeaderText = "Размер";
            SizeColumn.MinimumWidth = 8;
            SizeColumn.Name = "SizeColumn";
            SizeColumn.ReadOnly = true;
            SizeColumn.Width = 150;

            // MaterialColumn
            MaterialColumn.DataPropertyName = "Material";
            MaterialColumn.HeaderText = "Материал";
            MaterialColumn.MinimumWidth = 8;
            MaterialColumn.Name = "MaterialColumn";
            MaterialColumn.ReadOnly = true;
            MaterialColumn.Width = 150;

            // QuantityColumn
            QuantityColumn.DataPropertyName = "Quantity";
            QuantityColumn.HeaderText = "Количество на складе";
            QuantityColumn.MinimumWidth = 8;
            QuantityColumn.Name = "QuantityColumn";
            QuantityColumn.ReadOnly = true;
            QuantityColumn.Width = 150;

            // MinQuantityColumn
            MinQuantityColumn.DataPropertyName = "MinQuantity";
            MinQuantityColumn.HeaderText = "Минимальный предел количества";
            MinQuantityColumn.MinimumWidth = 8;
            MinQuantityColumn.Name = "MinQuantityColumn";
            MinQuantityColumn.ReadOnly = true;
            MinQuantityColumn.Width = 150;

            // PriceColumn
            PriceColumn.HeaderText = "Цена товара без НДС";
            PriceColumn.MinimumWidth = 8;
            PriceColumn.Name = "PriceColumn";
            PriceColumn.DataPropertyName = "Price";
            PriceColumn.ReadOnly = true;
            PriceColumn.Width = 150;

            // TotalAmountColumn
            TotalAmountColumn.DataPropertyName = "TotalAmount";
            TotalAmountColumn.HeaderText = "Общая сумма товара";
            TotalAmountColumn.MinimumWidth = 8;
            TotalAmountColumn.Name = "TotalAmountColumn";
            TotalAmountColumn.ReadOnly = true;
            TotalAmountColumn.Width = 150;

            // Form1
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1332, 791);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Реестр товаров";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinQuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmountColumn;
    }
}
