namespace management_company
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
			this.textBoxSurname = new System.Windows.Forms.TextBox();
			this.panelBackground = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonAddApart = new System.Windows.Forms.Button();
			this.buttonAddHouse = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxLicensePlate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxAdress = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelTotalCountApart = new System.Windows.Forms.Label();
			this.dataGridViewApartments = new System.Windows.Forms.DataGridView();
			this.dataGridViewHouses = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.Save = new System.Windows.Forms.ToolStripMenuItem();
			this.Load = new System.Windows.Forms.ToolStripMenuItem();
			this.DeleteHouse = new System.Windows.Forms.ToolStripMenuItem();
			this.DeleteApart = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelBackground.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouses)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxSurname
			// 
			this.textBoxSurname.Location = new System.Drawing.Point(619, 534);
			this.textBoxSurname.Name = "textBoxSurname";
			this.textBoxSurname.Size = new System.Drawing.Size(189, 22);
			this.textBoxSurname.TabIndex = 11;
			// 
			// panelBackground
			// 
			this.panelBackground.BackColor = System.Drawing.Color.Silver;
			this.panelBackground.Controls.Add(this.label3);
			this.panelBackground.Controls.Add(this.textBoxSurname);
			this.panelBackground.Controls.Add(this.buttonAddApart);
			this.panelBackground.Controls.Add(this.buttonAddHouse);
			this.panelBackground.Controls.Add(this.label2);
			this.panelBackground.Controls.Add(this.textBoxLicensePlate);
			this.panelBackground.Controls.Add(this.label1);
			this.panelBackground.Controls.Add(this.textBoxAdress);
			this.panelBackground.Controls.Add(this.panel1);
			this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBackground.Location = new System.Drawing.Point(0, 0);
			this.panelBackground.Name = "panelBackground";
			this.panelBackground.Size = new System.Drawing.Size(993, 626);
			this.panelBackground.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(619, 508);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(189, 23);
			this.label3.TabIndex = 12;
			this.label3.Text = "плата за услуги за месяц";
			// 
			// buttonAddApart
			// 
			this.buttonAddApart.Location = new System.Drawing.Point(814, 533);
			this.buttonAddApart.Name = "buttonAddApart";
			this.buttonAddApart.Size = new System.Drawing.Size(141, 24);
			this.buttonAddApart.TabIndex = 6;
			this.buttonAddApart.Text = "Добавить";
			this.buttonAddApart.UseVisualStyleBackColor = true;
			// 
			// buttonAddHouse
			// 
			this.buttonAddHouse.Location = new System.Drawing.Point(222, 532);
			this.buttonAddHouse.Name = "buttonAddHouse";
			this.buttonAddHouse.Size = new System.Drawing.Size(141, 24);
			this.buttonAddHouse.TabIndex = 3;
			this.buttonAddHouse.Text = "Добавить";
			this.buttonAddHouse.UseVisualStyleBackColor = true;
			this.buttonAddHouse.Click += new System.EventHandler(this.buttonAddHouse_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(409, 508);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(189, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "номер квартиры";
			// 
			// textBoxLicensePlate
			// 
			this.textBoxLicensePlate.Location = new System.Drawing.Point(409, 534);
			this.textBoxLicensePlate.Name = "textBoxLicensePlate";
			this.textBoxLicensePlate.Size = new System.Drawing.Size(189, 22);
			this.textBoxLicensePlate.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 507);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(189, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "адрес";
			// 
			// textBoxAdress
			// 
			this.textBoxAdress.Location = new System.Drawing.Point(12, 533);
			this.textBoxAdress.Name = "textBoxAdress";
			this.textBoxAdress.Size = new System.Drawing.Size(189, 22);
			this.textBoxAdress.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelTotalCountApart);
			this.panel1.Controls.Add(this.dataGridViewApartments);
			this.panel1.Controls.Add(this.dataGridViewHouses);
			this.panel1.Controls.Add(this.menuStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(993, 455);
			this.panel1.TabIndex = 6;
			// 
			// labelTotalCountApart
			// 
			this.labelTotalCountApart.BackColor = System.Drawing.Color.LightGray;
			this.labelTotalCountApart.Location = new System.Drawing.Point(742, 2);
			this.labelTotalCountApart.Name = "labelTotalCountApart";
			this.labelTotalCountApart.Size = new System.Drawing.Size(248, 23);
			this.labelTotalCountApart.TabIndex = 13;
			this.labelTotalCountApart.Text = "общее число квартир: ";
			// 
			// dataGridViewApartments
			// 
			this.dataGridViewApartments.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dataGridViewApartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewApartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2});
			this.dataGridViewApartments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewApartments.Location = new System.Drawing.Point(582, 28);
			this.dataGridViewApartments.Name = "dataGridViewApartments";
			this.dataGridViewApartments.ReadOnly = true;
			this.dataGridViewApartments.RowHeadersWidth = 51;
			this.dataGridViewApartments.RowTemplate.Height = 24;
			this.dataGridViewApartments.Size = new System.Drawing.Size(411, 427);
			this.dataGridViewApartments.TabIndex = 4;
			// 
			// dataGridViewHouses
			// 
			this.dataGridViewHouses.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dataGridViewHouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewHouses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1});
			this.dataGridViewHouses.Dock = System.Windows.Forms.DockStyle.Left;
			this.dataGridViewHouses.Location = new System.Drawing.Point(0, 28);
			this.dataGridViewHouses.Name = "dataGridViewHouses";
			this.dataGridViewHouses.ReadOnly = true;
			this.dataGridViewHouses.RowHeadersWidth = 51;
			this.dataGridViewHouses.RowTemplate.Height = 24;
			this.dataGridViewHouses.Size = new System.Drawing.Size(582, 427);
			this.dataGridViewHouses.TabIndex = 5;
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.DeleteHouse,
            this.DeleteApart,
            this.clearAll});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(993, 28);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Load});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(58, 24);
			this.toolStripMenuItem1.Text = "файл";
			// 
			// Save
			// 
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(224, 26);
			this.Save.Text = "сохранить";
			// 
			// Load
			// 
			this.Load.Name = "Load";
			this.Load.Size = new System.Drawing.Size(224, 26);
			this.Load.Text = "загрузить";
			// 
			// DeleteHouse
			// 
			this.DeleteHouse.Name = "DeleteHouse";
			this.DeleteHouse.Size = new System.Drawing.Size(109, 24);
			this.DeleteHouse.Text = "удалить дом";
			// 
			// DeleteApart
			// 
			this.DeleteApart.Name = "DeleteApart";
			this.DeleteApart.Size = new System.Drawing.Size(144, 24);
			this.DeleteApart.Text = "удалить квартиру";
			// 
			// clearAll
			// 
			this.clearAll.Name = "clearAll";
			this.clearAll.Size = new System.Drawing.Size(104, 24);
			this.clearAll.Text = "удалить всё";
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Адрес";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 125;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Количество квартир";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 125;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Сумма выплат";
			this.Column1.MinimumWidth = 6;
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 125;
			// 
			// c1
			// 
			this.c1.HeaderText = "Номер квартиры";
			this.c1.MinimumWidth = 6;
			this.c1.Name = "c1";
			this.c1.ReadOnly = true;
			this.c1.Width = 125;
			// 
			// c2
			// 
			this.c2.HeaderText = "Плата за услуги за месяц";
			this.c2.MinimumWidth = 6;
			this.c2.Name = "c2";
			this.c2.ReadOnly = true;
			this.c2.Width = 125;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(993, 626);
			this.Controls.Add(this.panelBackground);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Управляющая компания";
			this.panelBackground.ResumeLayout(false);
			this.panelBackground.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouses)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxSurname;
		private System.Windows.Forms.Panel panelBackground;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonAddApart;
		private System.Windows.Forms.Button buttonAddHouse;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxLicensePlate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxAdress;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelTotalCountApart;
		private System.Windows.Forms.DataGridView dataGridViewApartments;
		private System.Windows.Forms.DataGridView dataGridViewHouses;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem Save;
		private System.Windows.Forms.ToolStripMenuItem Load;
		private System.Windows.Forms.ToolStripMenuItem DeleteHouse;
		private System.Windows.Forms.ToolStripMenuItem DeleteApart;
		private System.Windows.Forms.ToolStripMenuItem clearAll;
		private System.Windows.Forms.DataGridViewTextBoxColumn c1;
		private System.Windows.Forms.DataGridViewTextBoxColumn c2;
	}
}

