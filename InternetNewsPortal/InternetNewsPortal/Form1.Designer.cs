namespace InternetNewsPortal
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
            this.dataGridViewNews = new System.Windows.Forms.DataGridView();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBackground = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonAddNews = new System.Windows.Forms.Button();
            this.buttonAddSection = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewsName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaxNews = new System.Windows.Forms.TextBox();
            this.textBoxSection = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewSection = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Load = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSection = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteNews = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNews)).BeginInit();
            this.panelBackground.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSection)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewNews
            // 
            this.dataGridViewNews.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2});
            this.dataGridViewNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewNews.Location = new System.Drawing.Point(572, 28);
            this.dataGridViewNews.Name = "dataGridViewNews";
            this.dataGridViewNews.ReadOnly = true;
            this.dataGridViewNews.RowHeadersWidth = 51;
            this.dataGridViewNews.RowTemplate.Height = 24;
            this.dataGridViewNews.Size = new System.Drawing.Size(563, 427);
            this.dataGridViewNews.TabIndex = 4;
            // 
            // c1
            // 
            this.c1.HeaderText = "заголовок новости";
            this.c1.MinimumWidth = 6;
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            this.c1.Width = 125;
            // 
            // c2
            // 
            this.c2.HeaderText = "дата публикации";
            this.c2.MinimumWidth = 6;
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.Width = 125;
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = System.Drawing.Color.Silver;
            this.panelBackground.Controls.Add(this.dateTimePicker1);
            this.panelBackground.Controls.Add(this.buttonAddNews);
            this.panelBackground.Controls.Add(this.buttonAddSection);
            this.panelBackground.Controls.Add(this.label3);
            this.panelBackground.Controls.Add(this.label2);
            this.panelBackground.Controls.Add(this.textBoxNewsName);
            this.panelBackground.Controls.Add(this.label4);
            this.panelBackground.Controls.Add(this.label1);
            this.panelBackground.Controls.Add(this.textBoxMaxNews);
            this.panelBackground.Controls.Add(this.textBoxSection);
            this.panelBackground.Controls.Add(this.panel1);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(1135, 574);
            this.panelBackground.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(790, 532);
            this.dateTimePicker1.MaxDate = new System.DateTime(2023, 6, 30, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2010, 3, 25, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(189, 22);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2023, 5, 28, 0, 0, 0, 0);
            // 
            // buttonAddNews
            // 
            this.buttonAddNews.Location = new System.Drawing.Point(991, 531);
            this.buttonAddNews.Name = "buttonAddNews";
            this.buttonAddNews.Size = new System.Drawing.Size(141, 24);
            this.buttonAddNews.TabIndex = 6;
            this.buttonAddNews.Text = "Добавить";
            this.buttonAddNews.UseVisualStyleBackColor = true;
            this.buttonAddNews.Click += new System.EventHandler(this.buttonAddNews_Click);
            // 
            // buttonAddSection
            // 
            this.buttonAddSection.Location = new System.Drawing.Point(431, 531);
            this.buttonAddSection.Name = "buttonAddSection";
            this.buttonAddSection.Size = new System.Drawing.Size(141, 24);
            this.buttonAddSection.TabIndex = 3;
            this.buttonAddSection.Text = "Добавить";
            this.buttonAddSection.UseVisualStyleBackColor = true;
            this.buttonAddSection.Click += new System.EventHandler(this.buttonAddSection_Click_1);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(790, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Дата публикации";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(586, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Заголовок новости";
            // 
            // textBoxNewsName
            // 
            this.textBoxNewsName.Location = new System.Drawing.Point(586, 532);
            this.textBoxNewsName.Name = "textBoxNewsName";
            this.textBoxNewsName.Size = new System.Drawing.Size(189, 22);
            this.textBoxNewsName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(219, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 40);
            this.label4.TabIndex = 8;
            this.label4.Text = "Максимальное количество новостей";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название раздела";
            // 
            // textBoxMaxNews
            // 
            this.textBoxMaxNews.Location = new System.Drawing.Point(219, 533);
            this.textBoxMaxNews.Name = "textBoxMaxNews";
            this.textBoxMaxNews.Size = new System.Drawing.Size(189, 22);
            this.textBoxMaxNews.TabIndex = 2;
            // 
            // textBoxSection
            // 
            this.textBoxSection.Location = new System.Drawing.Point(12, 533);
            this.textBoxSection.Name = "textBoxSection";
            this.textBoxSection.Size = new System.Drawing.Size(189, 22);
            this.textBoxSection.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dataGridViewNews);
            this.panel1.Controls.Add(this.dataGridViewSection);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 455);
            this.panel1.TabIndex = 6;
            // 
            // dataGridViewSection
            // 
            this.dataGridViewSection.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewSection.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewSection.Name = "dataGridViewSection";
            this.dataGridViewSection.ReadOnly = true;
            this.dataGridViewSection.RowHeadersWidth = 51;
            this.dataGridViewSection.RowTemplate.Height = 24;
            this.dataGridViewSection.Size = new System.Drawing.Size(572, 427);
            this.dataGridViewSection.TabIndex = 5;
            this.dataGridViewSection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSection_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "раздел";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Максимально возможное количество новостей";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "количество новостей";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.DeleteSection,
            this.DeleteNews,
            this.clearAll});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1135, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Load});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(59, 24);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(166, 26);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(166, 26);
            this.Load.Text = "Загрузить";
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // DeleteSection
            // 
            this.DeleteSection.Name = "DeleteSection";
            this.DeleteSection.Size = new System.Drawing.Size(129, 24);
            this.DeleteSection.Text = "удалить раздел";
            this.DeleteSection.Click += new System.EventHandler(this.DeleteSection_Click);
            // 
            // DeleteNews
            // 
            this.DeleteNews.Name = "DeleteNews";
            this.DeleteNews.Size = new System.Drawing.Size(137, 24);
            this.DeleteNews.Text = "удалить новость";
            this.DeleteNews.Click += new System.EventHandler(this.DeleteNews_Click);
            // 
            // clearAll
            // 
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(112, 24);
            this.clearAll.Text = "очистить всё";
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(884, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "общее число новостей: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 574);
            this.Controls.Add(this.panelBackground);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новостной портал";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNews)).EndInit();
            this.panelBackground.ResumeLayout(false);
            this.panelBackground.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSection)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewNews;
        private System.Windows.Forms.Panel panelBackground;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridView dataGridViewSection;
        private System.Windows.Forms.Button buttonAddNews;
        private System.Windows.Forms.Button buttonAddSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewsName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaxNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Load;
        private System.Windows.Forms.ToolStripMenuItem DeleteSection;
        private System.Windows.Forms.ToolStripMenuItem DeleteNews;
        private System.Windows.Forms.ToolStripMenuItem clearAll;
        private System.Windows.Forms.Label label5;
    }
}

