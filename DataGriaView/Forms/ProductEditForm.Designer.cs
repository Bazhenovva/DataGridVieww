namespace DataGriaView.Forms
{
    partial class ProductEditForm
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
            components = new System.ComponentModel.Container();
            labelName = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            labelSize = new System.Windows.Forms.Label();
            comboBoxSize = new System.Windows.Forms.ComboBox();
            labelMaterial = new System.Windows.Forms.Label();
            comboBoxMaterial = new System.Windows.Forms.ComboBox();
            labelQuantity = new System.Windows.Forms.Label();
            numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            labelMinQuantity = new System.Windows.Forms.Label();
            numericUpDownMinQuantity = new System.Windows.Forms.NumericUpDown();
            labelPrice = new System.Windows.Forms.Label();
            numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            // labelName
            labelName.AutoSize = true;
            labelName.Location = new System.Drawing.Point(20, 20);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(140, 25);
            labelName.Text = "Название товара:";

            // textBoxName
            textBoxName.Location = new System.Drawing.Point(20, 50);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(300, 31);

            // labelSize
            labelSize.AutoSize = true;
            labelSize.Location = new System.Drawing.Point(20, 90);
            labelSize.Name = "labelSize";
            labelSize.Size = new System.Drawing.Size(60, 25);
            labelSize.Text = "Размер:";

            // comboBoxSize
            comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxSize.Location = new System.Drawing.Point(20, 120);
            comboBoxSize.Name = "comboBoxSize";
            comboBoxSize.Size = new System.Drawing.Size(140, 33);

            // labelMaterial
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new System.Drawing.Point(180, 90);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new System.Drawing.Size(80, 25);
            labelMaterial.Text = "Материал:";

            // comboBoxMaterial
            comboBoxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxMaterial.Location = new System.Drawing.Point(180, 120);
            comboBoxMaterial.Name = "comboBoxMaterial";
            comboBoxMaterial.Size = new System.Drawing.Size(140, 33);

            // labelQuantity
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new System.Drawing.Point(20, 165);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new System.Drawing.Size(100, 25);
            labelQuantity.Text = "Количество:";

            // numericUpDownQuantity
            numericUpDownQuantity.Location = new System.Drawing.Point(20, 195);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new System.Drawing.Size(140, 31);

            // labelMinQuantity
            labelMinQuantity.AutoSize = true;
            labelMinQuantity.Location = new System.Drawing.Point(180, 165);
            labelMinQuantity.Name = "labelMinQuantity";
            labelMinQuantity.Size = new System.Drawing.Size(90, 25);
            labelMinQuantity.Text = "Мин. запас:";

            // numericUpDownMinQuantity
            numericUpDownMinQuantity.Location = new System.Drawing.Point(180, 195);
            numericUpDownMinQuantity.Name = "numericUpDownMinQuantity";
            numericUpDownMinQuantity.Size = new System.Drawing.Size(140, 31);

            // labelPrice
            labelPrice.AutoSize = true;
            labelPrice.Location = new System.Drawing.Point(20, 240);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new System.Drawing.Size(50, 25);
            labelPrice.Text = "Цена:";

            // numericUpDownPrice
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new System.Drawing.Point(20, 270);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new System.Drawing.Size(140, 31);

            // btnSave
            btnSave.Location = new System.Drawing.Point(20, 320);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(140, 40);
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            // btnCancel
            btnCancel.Location = new System.Drawing.Point(180, 320);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(140, 40);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            // errorProvider1
            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

            // ProductEditForm
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(360, 380);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelSize);
            Controls.Add(comboBoxSize);
            Controls.Add(labelMaterial);
            Controls.Add(comboBoxMaterial);
            Controls.Add(labelQuantity);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(labelMinQuantity);
            Controls.Add(numericUpDownMinQuantity);
            Controls.Add(labelPrice);
            Controls.Add(numericUpDownPrice);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Редактирование товара";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label labelMinQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownMinQuantity;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
