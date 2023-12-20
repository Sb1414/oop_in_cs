namespace educational_institution
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
			this.clearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.Load = new System.Windows.Forms.ToolStripMenuItem();
			this.Save = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.labelTotalCountDepart = new System.Windows.Forms.Label();
			this.dataGridViewTeacher = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.panelBackground = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGridViewDepartment = new System.Windows.Forms.DataGridView();
			this.действияСКафедройToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addDepartment = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteDepartment = new System.Windows.Forms.ToolStripMenuItem();
			this.действияСПреподавателямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addTeacher = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteTeacher = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacher)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panelBackground.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartment)).BeginInit();
			this.SuspendLayout();
			// 
			// clearAll
			// 
			this.clearAll.Name = "clearAll";
			this.clearAll.Size = new System.Drawing.Size(104, 24);
			this.clearAll.Text = "удалить всё";
			this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
			// 
			// Load
			// 
			this.Load.Name = "Load";
			this.Load.Size = new System.Drawing.Size(224, 26);
			this.Load.Text = "загрузить";
			this.Load.Click += new System.EventHandler(this.Load_Click);
			// 
			// Save
			// 
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(224, 26);
			this.Save.Text = "сохранить";
			this.Save.Click += new System.EventHandler(this.Save_Click);
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
			// labelTotalCountDepart
			// 
			this.labelTotalCountDepart.BackColor = System.Drawing.Color.LightGray;
			this.labelTotalCountDepart.Location = new System.Drawing.Point(742, 2);
			this.labelTotalCountDepart.Name = "labelTotalCountDepart";
			this.labelTotalCountDepart.Size = new System.Drawing.Size(248, 23);
			this.labelTotalCountDepart.TabIndex = 13;
			this.labelTotalCountDepart.Text = "общее число кафедр:";
			// 
			// dataGridViewTeacher
			// 
			this.dataGridViewTeacher.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dataGridViewTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTeacher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2,
            this.Column1});
			this.dataGridViewTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewTeacher.Location = new System.Drawing.Point(528, 28);
			this.dataGridViewTeacher.Name = "dataGridViewTeacher";
			this.dataGridViewTeacher.ReadOnly = true;
			this.dataGridViewTeacher.RowHeadersWidth = 51;
			this.dataGridViewTeacher.RowTemplate.Height = 24;
			this.dataGridViewTeacher.Size = new System.Drawing.Size(436, 523);
			this.dataGridViewTeacher.TabIndex = 4;
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.clearAll,
            this.действияСКафедройToolStripMenuItem,
            this.действияСПреподавателямиToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(964, 28);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// panelBackground
			// 
			this.panelBackground.BackColor = System.Drawing.Color.Silver;
			this.panelBackground.Controls.Add(this.panel1);
			this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBackground.Location = new System.Drawing.Point(0, 0);
			this.panelBackground.Name = "panelBackground";
			this.panelBackground.Size = new System.Drawing.Size(964, 551);
			this.panelBackground.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelTotalCountDepart);
			this.panel1.Controls.Add(this.dataGridViewTeacher);
			this.panel1.Controls.Add(this.dataGridViewDepartment);
			this.panel1.Controls.Add(this.menuStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(964, 551);
			this.panel1.TabIndex = 6;
			// 
			// dataGridViewDepartment
			// 
			this.dataGridViewDepartment.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dataGridViewDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDepartment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.dataGridViewTextBoxColumn2});
			this.dataGridViewDepartment.Dock = System.Windows.Forms.DockStyle.Left;
			this.dataGridViewDepartment.Location = new System.Drawing.Point(0, 28);
			this.dataGridViewDepartment.Name = "dataGridViewDepartment";
			this.dataGridViewDepartment.ReadOnly = true;
			this.dataGridViewDepartment.RowHeadersWidth = 51;
			this.dataGridViewDepartment.RowTemplate.Height = 24;
			this.dataGridViewDepartment.Size = new System.Drawing.Size(528, 523);
			this.dataGridViewDepartment.TabIndex = 5;
			this.dataGridViewDepartment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDepartment_CellClick);
			// 
			// действияСКафедройToolStripMenuItem
			// 
			this.действияСКафедройToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDepartment,
            this.deleteDepartment});
			this.действияСКафедройToolStripMenuItem.Name = "действияСКафедройToolStripMenuItem";
			this.действияСКафедройToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
			this.действияСКафедройToolStripMenuItem.Text = "действия с кафедрой";
			// 
			// addDepartment
			// 
			this.addDepartment.Name = "addDepartment";
			this.addDepartment.Size = new System.Drawing.Size(224, 26);
			this.addDepartment.Text = "добавить";
			this.addDepartment.Click += new System.EventHandler(this.addDepartment_Click);
			// 
			// deleteDepartment
			// 
			this.deleteDepartment.Name = "deleteDepartment";
			this.deleteDepartment.Size = new System.Drawing.Size(224, 26);
			this.deleteDepartment.Text = "удалить";
			this.deleteDepartment.Click += new System.EventHandler(this.deleteDepartment_Click);
			// 
			// действияСПреподавателямиToolStripMenuItem
			// 
			this.действияСПреподавателямиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTeacher,
            this.deleteTeacher});
			this.действияСПреподавателямиToolStripMenuItem.Name = "действияСПреподавателямиToolStripMenuItem";
			this.действияСПреподавателямиToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
			this.действияСПреподавателямиToolStripMenuItem.Text = "действия с преподавателями";
			// 
			// addTeacher
			// 
			this.addTeacher.Name = "addTeacher";
			this.addTeacher.Size = new System.Drawing.Size(224, 26);
			this.addTeacher.Text = "добавить";
			this.addTeacher.Click += new System.EventHandler(this.addTeacher_Click);
			// 
			// deleteTeacher
			// 
			this.deleteTeacher.Name = "deleteTeacher";
			this.deleteTeacher.Size = new System.Drawing.Size(224, 26);
			this.deleteTeacher.Text = "удалить";
			this.deleteTeacher.Click += new System.EventHandler(this.deleteTeacher_Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn1.HeaderText = "Название кафедры";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column2.HeaderText = "Количество преподавателей";
			this.Column2.MinimumWidth = 6;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn2.HeaderText = "Общая учебная нагрузка";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// c1
			// 
			this.c1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.c1.HeaderText = "Фамилия преподавателя";
			this.c1.MinimumWidth = 6;
			this.c1.Name = "c1";
			this.c1.ReadOnly = true;
			// 
			// c2
			// 
			this.c2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.c2.HeaderText = "Должность";
			this.c2.MinimumWidth = 6;
			this.c2.Name = "c2";
			this.c2.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1.HeaderText = "Учебная нагрузка (ч.)";
			this.Column1.MinimumWidth = 6;
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(964, 551);
			this.Controls.Add(this.panelBackground);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Учебная нагрузка преподавателей";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacher)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelBackground.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartment)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripMenuItem clearAll;
		private System.Windows.Forms.ToolStripMenuItem Load;
		private System.Windows.Forms.ToolStripMenuItem Save;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Label labelTotalCountDepart;
		private System.Windows.Forms.DataGridView dataGridViewTeacher;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Panel panelBackground;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dataGridViewDepartment;
		private System.Windows.Forms.ToolStripMenuItem действияСКафедройToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addDepartment;
		private System.Windows.Forms.ToolStripMenuItem deleteDepartment;
		private System.Windows.Forms.ToolStripMenuItem действияСПреподавателямиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addTeacher;
		private System.Windows.Forms.ToolStripMenuItem deleteTeacher;
		private System.Windows.Forms.DataGridViewTextBoxColumn c1;
		private System.Windows.Forms.DataGridViewTextBoxColumn c2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
	}
}

