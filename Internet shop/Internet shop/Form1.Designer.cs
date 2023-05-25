namespace Internet_shop
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBackground = new System.Windows.Forms.Panel();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonAddInfo = new System.Windows.Forms.ToolStripButton();
            this.AddOrder = new System.Windows.Forms.ToolStripButton();
            this.LoadFromFileInfo = new System.Windows.Forms.ToolStripButton();
            this.SaveToFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonsearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AllPrice = new System.Windows.Forms.ToolStripButton();
            this.panelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackground
            // 
            this.panelBackground.Controls.Add(this.dataGridViewProduct);
            this.panelBackground.Controls.Add(this.dataGridViewOrder);
            this.panelBackground.Controls.Add(this.toolStrip1);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(1157, 579);
            this.panelBackground.TabIndex = 0;
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.BackgroundColor = System.Drawing.Color.Thistle;
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewOrder.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.RowHeadersWidth = 51;
            this.dataGridViewOrder.RowTemplate.Height = 24;
            this.dataGridViewOrder.Size = new System.Drawing.Size(584, 546);
            this.dataGridViewOrder.TabIndex = 3;
            this.dataGridViewOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrder_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Имя заказчика";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дата заказа";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Общая сумма";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.BackgroundColor = System.Drawing.Color.Thistle;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2,
            this.C3});
            this.dataGridViewProduct.Location = new System.Drawing.Point(583, 28);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.RowHeadersWidth = 51;
            this.dataGridViewProduct.RowTemplate.Height = 24;
            this.dataGridViewProduct.Size = new System.Drawing.Size(571, 546);
            this.dataGridViewProduct.TabIndex = 4;
            // 
            // c1
            // 
            this.c1.HeaderText = "№ заказа";
            this.c1.MinimumWidth = 6;
            this.c1.Name = "c1";
            this.c1.Width = 125;
            // 
            // c2
            // 
            this.c2.HeaderText = "Наименование товара";
            this.c2.MinimumWidth = 6;
            this.c2.Name = "c2";
            this.c2.Width = 125;
            // 
            // C3
            // 
            this.C3.HeaderText = "Цена";
            this.C3.MinimumWidth = 6;
            this.C3.Name = "C3";
            this.C3.Width = 125;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::Internet_shop.Properties.Resources.фон;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonAddInfo,
            this.AddOrder,
            this.LoadFromFileInfo,
            this.SaveToFile,
            this.toolStripDropDownButton1,
            this.toolStripTextBox1,
            this.toolStripButtonsearch,
            this.toolStripSeparator1,
            this.AllPrice});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(1157, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "меню";
            // 
            // ButtonAddInfo
            // 
            this.ButtonAddInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ButtonAddInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonAddInfo.Image = global::Internet_shop.Properties.Resources.add;
            this.ButtonAddInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonAddInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAddInfo.Name = "ButtonAddInfo";
            this.ButtonAddInfo.Size = new System.Drawing.Size(29, 28);
            this.ButtonAddInfo.Text = "Добавить заказчика";
            this.ButtonAddInfo.ToolTipText = "ButtonAddInfo";
            this.ButtonAddInfo.Click += new System.EventHandler(this.ButtonAddInfo_Click);
            // 
            // AddOrder
            // 
            this.AddOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddOrder.Image = global::Internet_shop.Properties.Resources.add2;
            this.AddOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddOrder.Name = "AddOrder";
            this.AddOrder.Size = new System.Drawing.Size(29, 28);
            this.AddOrder.Text = "Добавить товары в заказ";
            this.AddOrder.Click += new System.EventHandler(this.AddOrder_Click);
            // 
            // LoadFromFileInfo
            // 
            this.LoadFromFileInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadFromFileInfo.Image = global::Internet_shop.Properties.Resources.load;
            this.LoadFromFileInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadFromFileInfo.Name = "LoadFromFileInfo";
            this.LoadFromFileInfo.Size = new System.Drawing.Size(29, 28);
            this.LoadFromFileInfo.Text = "Загрузить из файла";
            this.LoadFromFileInfo.Click += new System.EventHandler(this.LoadFromFileInfo_Click);
            // 
            // SaveToFile
            // 
            this.SaveToFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToFile.Image = global::Internet_shop.Properties.Resources.save;
            this.SaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(29, 28);
            this.SaveToFile.Text = "Сохранить в файл";
            this.SaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteProduct,
            this.deleteOrder});
            this.toolStripDropDownButton1.Image = global::Internet_shop.Properties.Resources.empty_trash;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 28);
            this.toolStripDropDownButton1.Text = "Удаление";
            // 
            // deleteProduct
            // 
            this.deleteProduct.Name = "deleteProduct";
            this.deleteProduct.Size = new System.Drawing.Size(272, 26);
            this.deleteProduct.Text = "Удалить товар";
            this.deleteProduct.Click += new System.EventHandler(this.deleteProduct_Click);
            // 
            // deleteOrder
            // 
            this.deleteOrder.Name = "deleteOrder";
            this.deleteOrder.Size = new System.Drawing.Size(272, 26);
            this.deleteOrder.Text = "Удалить заказчика (заказ)";
            this.deleteOrder.Click += new System.EventHandler(this.deleteOrder_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.Plum;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 31);
            // 
            // toolStripButtonsearch
            // 
            this.toolStripButtonsearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonsearch.Image = global::Internet_shop.Properties.Resources.icons8_search_20;
            this.toolStripButtonsearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonsearch.Name = "toolStripButtonsearch";
            this.toolStripButtonsearch.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonsearch.Text = "поиск заказа";
            this.toolStripButtonsearch.Click += new System.EventHandler(this.toolStripButtonsearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // AllPrice
            // 
            this.AllPrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AllPrice.Image = global::Internet_shop.Properties.Resources.icons8_info_20;
            this.AllPrice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AllPrice.Name = "AllPrice";
            this.AllPrice.Size = new System.Drawing.Size(29, 28);
            this.AllPrice.Text = "информация";
            this.AllPrice.Click += new System.EventHandler(this.AllPrice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 579);
            this.Controls.Add(this.panelBackground);
            this.Name = "Form1";
            this.Text = "Shop";
            this.panelBackground.ResumeLayout(false);
            this.panelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBackground;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonAddInfo;
        private System.Windows.Forms.ToolStripButton LoadFromFileInfo;
        private System.Windows.Forms.ToolStripButton SaveToFile;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem deleteProduct;
        private System.Windows.Forms.ToolStripMenuItem deleteOrder;
        private System.Windows.Forms.ToolStripButton AddOrder;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButtonsearch;
        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewTextBoxColumn C3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AllPrice;
    }
}

