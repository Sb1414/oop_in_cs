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
            this.panelBack = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSaveInfo = new System.Windows.Forms.Button();
            this.dataGridViewApart = new System.Windows.Forms.DataGridView();
            this.Column1_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewHouse = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonNewInfo = new System.Windows.Forms.Button();
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.PapayaWhip;
            this.panelBack.Controls.Add(this.panel2);
            this.panelBack.Controls.Add(this.panel1);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(1139, 669);
            this.panelBack.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(271, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(214, 20);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Разрешить редактирование";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(128, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(119, 30);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Открыть";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSaveInfo
            // 
            this.buttonSaveInfo.Location = new System.Drawing.Point(3, 3);
            this.buttonSaveInfo.Name = "buttonSaveInfo";
            this.buttonSaveInfo.Size = new System.Drawing.Size(119, 30);
            this.buttonSaveInfo.TabIndex = 2;
            this.buttonSaveInfo.Text = "Сохранить";
            this.buttonSaveInfo.UseVisualStyleBackColor = true;
            this.buttonSaveInfo.Click += new System.EventHandler(this.buttonSaveInfo_Click);
            // 
            // dataGridViewApart
            // 
            this.dataGridViewApart.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridViewApart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1_,
            this.Column2_,
            this.Column3_});
            this.dataGridViewApart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewApart.Location = new System.Drawing.Point(680, 0);
            this.dataGridViewApart.Name = "dataGridViewApart";
            this.dataGridViewApart.RowHeadersWidth = 51;
            this.dataGridViewApart.RowTemplate.Height = 24;
            this.dataGridViewApart.Size = new System.Drawing.Size(459, 634);
            this.dataGridViewApart.TabIndex = 1;
            this.dataGridViewApart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridViewApart.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewApart_CellValidating);
            // 
            // Column1_
            // 
            this.Column1_.HeaderText = "Номер дома";
            this.Column1_.MinimumWidth = 6;
            this.Column1_.Name = "Column1_";
            this.Column1_.Width = 125;
            // 
            // Column2_
            // 
            this.Column2_.HeaderText = "Номер квартиры";
            this.Column2_.MinimumWidth = 6;
            this.Column2_.Name = "Column2_";
            this.Column2_.Width = 125;
            // 
            // Column3_
            // 
            this.Column3_.HeaderText = "Плата за услуги за месяц";
            this.Column3_.MinimumWidth = 6;
            this.Column3_.Name = "Column3_";
            this.Column3_.Width = 125;
            // 
            // dataGridViewHouse
            // 
            this.dataGridViewHouse.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridViewHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewHouse.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewHouse.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHouse.Name = "dataGridViewHouse";
            this.dataGridViewHouse.RowHeadersWidth = 51;
            this.dataGridViewHouse.RowTemplate.Height = 24;
            this.dataGridViewHouse.Size = new System.Drawing.Size(680, 634);
            this.dataGridViewHouse.TabIndex = 0;
            this.dataGridViewHouse.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridViewHouse.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewHouse_CellValidating);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Улица";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дом";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Всего квартир";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(518, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(119, 30);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.buttonNewInfo);
            this.panel1.Controls.Add(this.buttonSaveInfo);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 35);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewApart);
            this.panel2.Controls.Add(this.dataGridViewHouse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1139, 634);
            this.panel2.TabIndex = 5;
            // 
            // buttonNewInfo
            // 
            this.buttonNewInfo.Location = new System.Drawing.Point(643, 3);
            this.buttonNewInfo.Name = "buttonNewInfo";
            this.buttonNewInfo.Size = new System.Drawing.Size(119, 30);
            this.buttonNewInfo.TabIndex = 4;
            this.buttonNewInfo.Text = "Добавить";
            this.buttonNewInfo.UseVisualStyleBackColor = true;
            this.buttonNewInfo.Click += new System.EventHandler(this.buttonNewInfo_Click);
            // 
            // ManagementCompanyMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 669);
            this.Controls.Add(this.panelBack);
            this.Name = "ManagementCompanyMain";
            this.Text = "Form1";
            this.panelBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.DataGridView dataGridViewHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView dataGridViewApart;
        private System.Windows.Forms.Button buttonSaveInfo;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3_;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNewInfo;
    }
}

