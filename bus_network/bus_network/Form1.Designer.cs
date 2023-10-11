namespace bus_network
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Load = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteBus = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddBus = new System.Windows.Forms.Button();
            this.buttonAddRoute = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLicensePlate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumberRoute = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewRoutes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewBus = new System.Windows.Forms.DataGridView();
            this.panelBackground = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBus)).BeginInit();
            this.panelBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.DeleteRoute,
            this.DeleteBus,
            this.clearAll});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 28);
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
            this.Save.Size = new System.Drawing.Size(224, 26);
            this.Save.Text = "Сохранить";
            // 
            // Load
            // 
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(224, 26);
            this.Load.Text = "Загрузить";
            // 
            // DeleteRoute
            // 
            this.DeleteRoute.Name = "DeleteRoute";
            this.DeleteRoute.Size = new System.Drawing.Size(143, 24);
            this.DeleteRoute.Text = "удалить маршрут";
            // 
            // DeleteBus
            // 
            this.DeleteBus.Name = "DeleteBus";
            this.DeleteBus.Size = new System.Drawing.Size(135, 24);
            this.DeleteBus.Text = "удалить автобус";
            // 
            // clearAll
            // 
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(112, 24);
            this.clearAll.Text = "очистить всё";
            // 
            // buttonAddBus
            // 
            this.buttonAddBus.Location = new System.Drawing.Point(814, 533);
            this.buttonAddBus.Name = "buttonAddBus";
            this.buttonAddBus.Size = new System.Drawing.Size(141, 24);
            this.buttonAddBus.TabIndex = 6;
            this.buttonAddBus.Text = "Добавить";
            this.buttonAddBus.UseVisualStyleBackColor = true;
            this.buttonAddBus.Click += new System.EventHandler(this.buttonAddBus_Click);
            // 
            // buttonAddRoute
            // 
            this.buttonAddRoute.Location = new System.Drawing.Point(222, 532);
            this.buttonAddRoute.Name = "buttonAddRoute";
            this.buttonAddRoute.Size = new System.Drawing.Size(141, 24);
            this.buttonAddRoute.TabIndex = 3;
            this.buttonAddRoute.Text = "Добавить";
            this.buttonAddRoute.UseVisualStyleBackColor = true;
            this.buttonAddRoute.Click += new System.EventHandler(this.buttonAddRoute_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(409, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "госномер";
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
            this.label1.Text = "номер маршрута";
            // 
            // textBoxNumberRoute
            // 
            this.textBoxNumberRoute.Location = new System.Drawing.Point(12, 533);
            this.textBoxNumberRoute.Name = "textBoxNumberRoute";
            this.textBoxNumberRoute.Size = new System.Drawing.Size(189, 22);
            this.textBoxNumberRoute.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(764, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "общее число автобусов: ";
            // 
            // dataGridViewRoutes
            // 
            this.dataGridViewRoutes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoutes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewRoutes.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewRoutes.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewRoutes.Name = "dataGridViewRoutes";
            this.dataGridViewRoutes.ReadOnly = true;
            this.dataGridViewRoutes.RowHeadersWidth = 51;
            this.dataGridViewRoutes.RowTemplate.Height = 24;
            this.dataGridViewRoutes.Size = new System.Drawing.Size(572, 427);
            this.dataGridViewRoutes.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dataGridViewBus);
            this.panel1.Controls.Add(this.dataGridViewRoutes);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 455);
            this.panel1.TabIndex = 6;
            // 
            // dataGridViewBus
            // 
            this.dataGridViewBus.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewBus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2});
            this.dataGridViewBus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBus.Location = new System.Drawing.Point(572, 28);
            this.dataGridViewBus.Name = "dataGridViewBus";
            this.dataGridViewBus.ReadOnly = true;
            this.dataGridViewBus.RowHeadersWidth = 51;
            this.dataGridViewBus.RowTemplate.Height = 24;
            this.dataGridViewBus.Size = new System.Drawing.Size(443, 427);
            this.dataGridViewBus.TabIndex = 4;
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = System.Drawing.Color.Silver;
            this.panelBackground.Controls.Add(this.label3);
            this.panelBackground.Controls.Add(this.textBoxSurname);
            this.panelBackground.Controls.Add(this.buttonAddBus);
            this.panelBackground.Controls.Add(this.buttonAddRoute);
            this.panelBackground.Controls.Add(this.label2);
            this.panelBackground.Controls.Add(this.textBoxLicensePlate);
            this.panelBackground.Controls.Add(this.label1);
            this.panelBackground.Controls.Add(this.textBoxNumberRoute);
            this.panelBackground.Controls.Add(this.panel1);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(1015, 582);
            this.panelBackground.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "маршрут";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "количество автобусов";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // c1
            // 
            this.c1.HeaderText = "госномер";
            this.c1.MinimumWidth = 6;
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            this.c1.Width = 125;
            // 
            // c2
            // 
            this.c2.HeaderText = "фамилия водителя";
            this.c2.MinimumWidth = 6;
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.Width = 125;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(619, 534);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(189, 22);
            this.textBoxSurname.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(619, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "фамилия";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 582);
            this.Controls.Add(this.panelBackground);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автобусная сеть";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBus)).EndInit();
            this.panelBackground.ResumeLayout(false);
            this.panelBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Load;
        private System.Windows.Forms.ToolStripMenuItem DeleteRoute;
        private System.Windows.Forms.ToolStripMenuItem DeleteBus;
        private System.Windows.Forms.ToolStripMenuItem clearAll;
        private System.Windows.Forms.Button buttonAddBus;
        private System.Windows.Forms.Button buttonAddRoute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLicensePlate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumberRoute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewRoutes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewBus;
        private System.Windows.Forms.Panel panelBackground;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSurname;
    }
}

