namespace ManagementCompany
{
    partial class ManagementCompanyMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagementCompanyMain));
            this.panelBack = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewHouse = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewApart = new System.Windows.Forms.DataGridView();
            this.Column2_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewStreet = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDelApart = new System.Windows.Forms.Button();
            this.buttonNewInfo = new System.Windows.Forms.Button();
            this.buttonSaveInfo = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBack.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStreet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.Transparent;
            this.panelBack.Controls.Add(this.panel2);
            this.panelBack.Controls.Add(this.panel1);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(1129, 669);
            this.panelBack.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewHouse);
            this.panel2.Controls.Add(this.dataGridViewStreet);
            this.panel2.Controls.Add(this.dataGridViewApart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 634);
            this.panel2.TabIndex = 5;
            // 
            // dataGridViewHouse
            // 
            this.dataGridViewHouse.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(218)))), ((int)(((byte)(247)))));
            this.dataGridViewHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHouse.Location = new System.Drawing.Point(260, 0);
            this.dataGridViewHouse.Name = "dataGridViewHouse";
            this.dataGridViewHouse.RowHeadersWidth = 51;
            this.dataGridViewHouse.RowTemplate.Height = 24;
            this.dataGridViewHouse.Size = new System.Drawing.Size(531, 634);
            this.dataGridViewHouse.TabIndex = 2;
            this.dataGridViewHouse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHouse_CellClick);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Дом";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Всего квартир";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Квартир в списке";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // dataGridViewApart
            // 
            this.dataGridViewApart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(218)))), ((int)(((byte)(247)))));
            this.dataGridViewApart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2_,
            this.Column3_});
            this.dataGridViewApart.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewApart.Location = new System.Drawing.Point(791, 0);
            this.dataGridViewApart.Name = "dataGridViewApart";
            this.dataGridViewApart.RowHeadersWidth = 51;
            this.dataGridViewApart.RowTemplate.Height = 24;
            this.dataGridViewApart.Size = new System.Drawing.Size(338, 634);
            this.dataGridViewApart.TabIndex = 1;
            // 
            // Column2_
            // 
            this.Column2_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2_.HeaderText = "Номер квартиры";
            this.Column2_.MinimumWidth = 6;
            this.Column2_.Name = "Column2_";
            // 
            // Column3_
            // 
            this.Column3_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3_.HeaderText = "Плата за услуги за месяц";
            this.Column3_.MinimumWidth = 6;
            this.Column3_.Name = "Column3_";
            // 
            // dataGridViewStreet
            // 
            this.dataGridViewStreet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(218)))), ((int)(((byte)(247)))));
            this.dataGridViewStreet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStreet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewStreet.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewStreet.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStreet.Name = "dataGridViewStreet";
            this.dataGridViewStreet.RowHeadersWidth = 51;
            this.dataGridViewStreet.RowTemplate.Height = 24;
            this.dataGridViewStreet.Size = new System.Drawing.Size(260, 634);
            this.dataGridViewStreet.TabIndex = 0;
            this.dataGridViewStreet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStreet_CellClick_1);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Улица";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::ManagementCompany.Properties.Resources.back1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.buttonInfo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonDelApart);
            this.panel1.Controls.Add(this.buttonNewInfo);
            this.panel1.Controls.Add(this.buttonSaveInfo);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 35);
            this.panel1.TabIndex = 4;
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInfo.BackgroundImage")));
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInfo.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Image = global::ManagementCompany.Properties.Resources.icons8_info_20;
            this.buttonInfo.Location = new System.Drawing.Point(1078, 3);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(48, 30);
            this.buttonInfo.TabIndex = 7;
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(547, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить квартиру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelete.BackgroundImage")));
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(738, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(164, 30);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить дом";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDelApart
            // 
            this.buttonDelApart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelApart.BackgroundImage")));
            this.buttonDelApart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelApart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelApart.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonDelApart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelApart.Location = new System.Drawing.Point(908, 3);
            this.buttonDelApart.Name = "buttonDelApart";
            this.buttonDelApart.Size = new System.Drawing.Size(164, 30);
            this.buttonDelApart.TabIndex = 5;
            this.buttonDelApart.Text = "Удалить квартиру";
            this.buttonDelApart.UseVisualStyleBackColor = true;
            this.buttonDelApart.Click += new System.EventHandler(this.buttonDelApart_Click);
            // 
            // buttonNewInfo
            // 
            this.buttonNewInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNewInfo.BackgroundImage")));
            this.buttonNewInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNewInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewInfo.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonNewInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewInfo.Location = new System.Drawing.Point(377, 3);
            this.buttonNewInfo.Name = "buttonNewInfo";
            this.buttonNewInfo.Size = new System.Drawing.Size(164, 30);
            this.buttonNewInfo.TabIndex = 4;
            this.buttonNewInfo.Text = "Добавить дом";
            this.buttonNewInfo.UseVisualStyleBackColor = true;
            this.buttonNewInfo.Click += new System.EventHandler(this.buttonNewInfo_Click);
            // 
            // buttonSaveInfo
            // 
            this.buttonSaveInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSaveInfo.BackgroundImage")));
            this.buttonSaveInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaveInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveInfo.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonSaveInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveInfo.Location = new System.Drawing.Point(3, 3);
            this.buttonSaveInfo.Name = "buttonSaveInfo";
            this.buttonSaveInfo.Size = new System.Drawing.Size(119, 30);
            this.buttonSaveInfo.TabIndex = 2;
            this.buttonSaveInfo.Text = "Сохранить";
            this.buttonSaveInfo.UseVisualStyleBackColor = true;
            this.buttonSaveInfo.Click += new System.EventHandler(this.buttonSaveInfo_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClear.BackgroundImage")));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(252, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(119, 30);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLoad.BackgroundImage")));
            this.buttonLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoad.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Location = new System.Drawing.Point(128, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(119, 30);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Открыть";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Сумма выплат";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // ManagementCompanyMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 669);
            this.Controls.Add(this.panelBack);
            this.Name = "ManagementCompanyMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.panelBack.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStreet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.DataGridView dataGridViewStreet;
        private System.Windows.Forms.DataGridView dataGridViewApart;
        private System.Windows.Forms.Button buttonSaveInfo;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNewInfo;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonDelApart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3_;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

