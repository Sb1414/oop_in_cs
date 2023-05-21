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
            this.dataGridViewHouse = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewApart = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveInfo = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApart)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.Controls.Add(this.buttonLoad);
            this.panelBack.Controls.Add(this.buttonSaveInfo);
            this.panelBack.Controls.Add(this.dataGridViewApart);
            this.panelBack.Controls.Add(this.dataGridViewHouse);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(1106, 660);
            this.panelBack.TabIndex = 0;
            // 
            // dataGridViewHouse
            // 
            this.dataGridViewHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewHouse.Location = new System.Drawing.Point(12, 127);
            this.dataGridViewHouse.Name = "dataGridViewHouse";
            this.dataGridViewHouse.RowHeadersWidth = 51;
            this.dataGridViewHouse.RowTemplate.Height = 24;
            this.dataGridViewHouse.Size = new System.Drawing.Size(688, 530);
            this.dataGridViewHouse.TabIndex = 0;
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
            // dataGridViewApart
            // 
            this.dataGridViewApart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5});
            this.dataGridViewApart.Location = new System.Drawing.Point(706, 127);
            this.dataGridViewApart.Name = "dataGridViewApart";
            this.dataGridViewApart.RowHeadersWidth = 51;
            this.dataGridViewApart.RowTemplate.Height = 24;
            this.dataGridViewApart.Size = new System.Drawing.Size(397, 530);
            this.dataGridViewApart.TabIndex = 1;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Номер квартиры";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Плата за услуги за месяц";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // buttonSaveInfo
            // 
            this.buttonSaveInfo.Location = new System.Drawing.Point(13, 12);
            this.buttonSaveInfo.Name = "buttonSaveInfo";
            this.buttonSaveInfo.Size = new System.Drawing.Size(119, 30);
            this.buttonSaveInfo.TabIndex = 2;
            this.buttonSaveInfo.Text = "Сохранить";
            this.buttonSaveInfo.UseVisualStyleBackColor = true;
            this.buttonSaveInfo.Click += new System.EventHandler(this.buttonSaveInfo_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(147, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(119, 30);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Открыть";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // ManagementCompanyMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 660);
            this.Controls.Add(this.panelBack);
            this.Name = "ManagementCompanyMain";
            this.Text = "Form1";
            this.panelBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.DataGridView dataGridViewHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView dataGridViewApart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button buttonSaveInfo;
        private System.Windows.Forms.Button buttonLoad;
    }
}

