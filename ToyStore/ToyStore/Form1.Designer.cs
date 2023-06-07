namespace ToyStore
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.open = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.labelNameStore = new System.Windows.Forms.ToolStripLabel();
            this.labelWorkingHours = new System.Windows.Forms.ToolStripLabel();
            this.paneltable = new System.Windows.Forms.Panel();
            this.dataGridViewToys = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.totalSum = new System.Windows.Forms.Label();
            this.buttonAddToy = new System.Windows.Forms.Button();
            this.buttonAddStore = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxToyQuantity = new System.Windows.Forms.TextBox();
            this.textBoxToyPrice = new System.Windows.Forms.TextBox();
            this.textBoxToyManufacturer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxToyArticle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxToyName = new System.Windows.Forms.TextBox();
            this.textBoxStHours = new System.Windows.Forms.TextBox();
            this.textBoxStName = new System.Windows.Forms.TextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.countToys = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.paneltable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToys)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.save,
            this.delete,
            this.toolStripSeparator1,
            this.labelNameStore,
            this.toolStripSeparator2,
            this.labelWorkingHours});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1091, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // open
            // 
            this.open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(80, 24);
            this.open.Text = "загрузить";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(85, 24);
            this.save.Text = "сохранить";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(128, 24);
            this.delete.Text = "удалить игрушку";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // labelNameStore
            // 
            this.labelNameStore.Name = "labelNameStore";
            this.labelNameStore.Size = new System.Drawing.Size(150, 24);
            this.labelNameStore.Text = "Название магазина:";
            this.labelNameStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWorkingHours
            // 
            this.labelWorkingHours.Name = "labelWorkingHours";
            this.labelWorkingHours.Size = new System.Drawing.Size(115, 24);
            this.labelWorkingHours.Text = "Режим работы:";
            this.labelWorkingHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // paneltable
            // 
            this.paneltable.Controls.Add(this.dataGridViewToys);
            this.paneltable.Dock = System.Windows.Forms.DockStyle.Left;
            this.paneltable.Location = new System.Drawing.Point(0, 27);
            this.paneltable.Name = "paneltable";
            this.paneltable.Size = new System.Drawing.Size(813, 651);
            this.paneltable.TabIndex = 1;
            // 
            // dataGridViewToys
            // 
            this.dataGridViewToys.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewToys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewToys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewToys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewToys.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewToys.Name = "dataGridViewToys";
            this.dataGridViewToys.RowHeadersWidth = 51;
            this.dataGridViewToys.RowTemplate.Height = 24;
            this.dataGridViewToys.Size = new System.Drawing.Size(813, 651);
            this.dataGridViewToys.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.paneltable);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 678);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.countToys);
            this.panel2.Controls.Add(this.totalSum);
            this.panel2.Controls.Add(this.buttonAddToy);
            this.panel2.Controls.Add(this.buttonAddStore);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxToyQuantity);
            this.panel2.Controls.Add(this.textBoxToyPrice);
            this.panel2.Controls.Add(this.textBoxToyManufacturer);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxToyArticle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxToyName);
            this.panel2.Controls.Add(this.textBoxStHours);
            this.panel2.Controls.Add(this.textBoxStName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(817, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 651);
            this.panel2.TabIndex = 2;
            // 
            // totalSum
            // 
            this.totalSum.Location = new System.Drawing.Point(5, 0);
            this.totalSum.Name = "totalSum";
            this.totalSum.Size = new System.Drawing.Size(266, 28);
            this.totalSum.TabIndex = 64;
            this.totalSum.Text = "Общая сумма: ";
            this.totalSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAddToy
            // 
            this.buttonAddToy.Location = new System.Drawing.Point(53, 602);
            this.buttonAddToy.Name = "buttonAddToy";
            this.buttonAddToy.Size = new System.Drawing.Size(176, 23);
            this.buttonAddToy.TabIndex = 54;
            this.buttonAddToy.Text = "добавить";
            this.buttonAddToy.UseVisualStyleBackColor = true;
            this.buttonAddToy.Click += new System.EventHandler(this.buttonAddToy_Click);
            // 
            // buttonAddStore
            // 
            this.buttonAddStore.Location = new System.Drawing.Point(52, 248);
            this.buttonAddStore.Name = "buttonAddStore";
            this.buttonAddStore.Size = new System.Drawing.Size(176, 23);
            this.buttonAddStore.TabIndex = 48;
            this.buttonAddStore.Text = "добавить";
            this.buttonAddStore.UseVisualStyleBackColor = true;
            this.buttonAddStore.Click += new System.EventHandler(this.buttonAddStore_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 531);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 23);
            this.label9.TabIndex = 61;
            this.label9.Text = "Количество";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 480);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 23);
            this.label8.TabIndex = 60;
            this.label8.Text = "Стоимость";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(269, 23);
            this.label7.TabIndex = 59;
            this.label7.Text = "Произоводитель";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 23);
            this.label6.TabIndex = 62;
            this.label6.Text = "Артикул";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "Часы работы";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 23);
            this.label5.TabIndex = 57;
            this.label5.Text = "Название игрушки";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 23);
            this.label2.TabIndex = 58;
            this.label2.Text = "Название магазина";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxToyQuantity
            // 
            this.textBoxToyQuantity.Location = new System.Drawing.Point(53, 557);
            this.textBoxToyQuantity.Name = "textBoxToyQuantity";
            this.textBoxToyQuantity.Size = new System.Drawing.Size(176, 22);
            this.textBoxToyQuantity.TabIndex = 53;
            // 
            // textBoxToyPrice
            // 
            this.textBoxToyPrice.Location = new System.Drawing.Point(53, 506);
            this.textBoxToyPrice.Name = "textBoxToyPrice";
            this.textBoxToyPrice.Size = new System.Drawing.Size(176, 22);
            this.textBoxToyPrice.TabIndex = 52;
            // 
            // textBoxToyManufacturer
            // 
            this.textBoxToyManufacturer.Location = new System.Drawing.Point(53, 455);
            this.textBoxToyManufacturer.Name = "textBoxToyManufacturer";
            this.textBoxToyManufacturer.Size = new System.Drawing.Size(176, 22);
            this.textBoxToyManufacturer.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 23);
            this.label4.TabIndex = 55;
            this.label4.Text = "Добавить игрушку";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxToyArticle
            // 
            this.textBoxToyArticle.Location = new System.Drawing.Point(53, 395);
            this.textBoxToyArticle.Name = "textBoxToyArticle";
            this.textBoxToyArticle.Size = new System.Drawing.Size(176, 22);
            this.textBoxToyArticle.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 23);
            this.label1.TabIndex = 56;
            this.label1.Text = "Добавить магазин";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxToyName
            // 
            this.textBoxToyName.Location = new System.Drawing.Point(53, 344);
            this.textBoxToyName.Name = "textBoxToyName";
            this.textBoxToyName.Size = new System.Drawing.Size(176, 22);
            this.textBoxToyName.TabIndex = 49;
            // 
            // textBoxStHours
            // 
            this.textBoxStHours.Location = new System.Drawing.Point(52, 201);
            this.textBoxStHours.Name = "textBoxStHours";
            this.textBoxStHours.Size = new System.Drawing.Size(176, 22);
            this.textBoxStHours.TabIndex = 47;
            // 
            // textBoxStName
            // 
            this.textBoxStName.Location = new System.Drawing.Point(52, 150);
            this.textBoxStName.Name = "textBoxStName";
            this.textBoxStName.Size = new System.Drawing.Size(176, 22);
            this.textBoxStName.TabIndex = 46;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // countToys
            // 
            this.countToys.Location = new System.Drawing.Point(5, 28);
            this.countToys.Name = "countToys";
            this.countToys.Size = new System.Drawing.Size(266, 28);
            this.countToys.TabIndex = 65;
            this.countToys.Text = "Общее количество: ";
            this.countToys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Название";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Артикул";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Производитель";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Стоимость";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Количество";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 678);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1109, 725);
            this.MinimumSize = new System.Drawing.Size(1109, 725);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Магазин игрушек";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.paneltable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToys)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripLabel labelNameStore;
        private System.Windows.Forms.ToolStripLabel labelWorkingHours;
        private System.Windows.Forms.Panel paneltable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewToys;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label totalSum;
        private System.Windows.Forms.Button buttonAddToy;
        private System.Windows.Forms.Button buttonAddStore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxToyQuantity;
        private System.Windows.Forms.TextBox textBoxToyPrice;
        private System.Windows.Forms.TextBox textBoxToyManufacturer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxToyArticle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxToyName;
        private System.Windows.Forms.TextBox textBoxStHours;
        private System.Windows.Forms.TextBox textBoxStName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label countToys;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

