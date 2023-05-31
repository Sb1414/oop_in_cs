namespace cargo_transportation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelBack = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.load = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxLicensePlate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVolume = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddShipment = new System.Windows.Forms.Button();
            this.editCount = new System.Windows.Forms.ToolStripButton();
            this.removeVehicle = new System.Windows.Forms.Button();
            this.removeShipment = new System.Windows.Forms.Button();
            this.toolStripLabelMaxSize = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelAllVol = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.panelBack.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.Controls.Add(this.removeShipment);
            this.panelBack.Controls.Add(this.removeVehicle);
            this.panelBack.Controls.Add(this.buttonAddShipment);
            this.panelBack.Controls.Add(this.buttonAddVehicle);
            this.panelBack.Controls.Add(this.label6);
            this.panelBack.Controls.Add(this.label3);
            this.panelBack.Controls.Add(this.label5);
            this.panelBack.Controls.Add(this.label2);
            this.panelBack.Controls.Add(this.textBoxVolume);
            this.panelBack.Controls.Add(this.textBoxSurname);
            this.panelBack.Controls.Add(this.label4);
            this.panelBack.Controls.Add(this.textBoxTime);
            this.panelBack.Controls.Add(this.label1);
            this.panelBack.Controls.Add(this.textBoxLicensePlate);
            this.panelBack.Controls.Add(this.panel1);
            this.panelBack.Controls.Add(this.toolStrip1);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(1171, 641);
            this.panelBack.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load,
            this.save,
            this.clear,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.toolStripLabelMaxSize,
            this.editCount,
            this.toolStripSeparator3,
            this.toolStripLabelAllVol});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1171, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Панель";
            // 
            // load
            // 
            this.load.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.load.Image = ((System.Drawing.Image)(resources.GetObject("load.Image")));
            this.load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(80, 28);
            this.load.Text = "загрузить";
            this.load.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(85, 28);
            this.save.Text = "сохранить";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 610);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(501, 610);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(501, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(384, 610);
            this.dataGridView2.TabIndex = 21;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Время начала рейса";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Объем груза";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Госномер";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "ФИО водителя";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Общий объем груза";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // textBoxLicensePlate
            // 
            this.textBoxLicensePlate.Location = new System.Drawing.Point(912, 137);
            this.textBoxLicensePlate.Name = "textBoxLicensePlate";
            this.textBoxLicensePlate.Size = new System.Drawing.Size(230, 22);
            this.textBoxLicensePlate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(909, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Добавить водителя";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(909, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Госномер (пример: \"ABC123\")";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(912, 198);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(230, 22);
            this.textBoxSurname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(909, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "ФИО водителя";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(970, 239);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(127, 23);
            this.buttonAddVehicle.TabIndex = 3;
            this.buttonAddVehicle.Text = "добавить";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.buttonAddVehicle_Click);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(912, 389);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(230, 22);
            this.textBoxTime.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(909, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Добавить рейс";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxVolume
            // 
            this.textBoxVolume.Location = new System.Drawing.Point(912, 450);
            this.textBoxVolume.Name = "textBoxVolume";
            this.textBoxVolume.Size = new System.Drawing.Size(230, 22);
            this.textBoxVolume.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(909, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Время начала (пример: \"12:00\")";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(909, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Объем груза (кг)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddShipment
            // 
            this.buttonAddShipment.Location = new System.Drawing.Point(970, 491);
            this.buttonAddShipment.Name = "buttonAddShipment";
            this.buttonAddShipment.Size = new System.Drawing.Size(127, 23);
            this.buttonAddShipment.TabIndex = 7;
            this.buttonAddShipment.Text = "добавить";
            this.buttonAddShipment.UseVisualStyleBackColor = true;
            this.buttonAddShipment.Click += new System.EventHandler(this.buttonAddShipment_Click);
            // 
            // editCount
            // 
            this.editCount.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.editCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editCount.Image = ((System.Drawing.Image)(resources.GetObject("editCount.Image")));
            this.editCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editCount.Name = "editCount";
            this.editCount.Size = new System.Drawing.Size(72, 28);
            this.editCount.Text = "выбрать";
            this.editCount.Click += new System.EventHandler(this.editCount_Click);
            // 
            // removeVehicle
            // 
            this.removeVehicle.Location = new System.Drawing.Point(970, 268);
            this.removeVehicle.Name = "removeVehicle";
            this.removeVehicle.Size = new System.Drawing.Size(127, 23);
            this.removeVehicle.TabIndex = 4;
            this.removeVehicle.Text = "удалить";
            this.removeVehicle.UseVisualStyleBackColor = true;
            this.removeVehicle.Click += new System.EventHandler(this.removeVehicle_Click);
            // 
            // removeShipment
            // 
            this.removeShipment.Location = new System.Drawing.Point(970, 520);
            this.removeShipment.Name = "removeShipment";
            this.removeShipment.Size = new System.Drawing.Size(127, 23);
            this.removeShipment.TabIndex = 8;
            this.removeShipment.Text = "удалить";
            this.removeShipment.UseVisualStyleBackColor = true;
            this.removeShipment.Click += new System.EventHandler(this.removeShipment_Click);
            // 
            // toolStripLabelMaxSize
            // 
            this.toolStripLabelMaxSize.Name = "toolStripLabelMaxSize";
            this.toolStripLabelMaxSize.Size = new System.Drawing.Size(94, 28);
            this.toolStripLabelMaxSize.Text = "Max Size = 0";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabelAllVol
            // 
            this.toolStripLabelAllVol.Name = "toolStripLabelAllVol";
            this.toolStripLabelAllVol.Size = new System.Drawing.Size(157, 28);
            this.toolStripLabelAllVol.Text = "Общий объем груза: ";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(350, 28);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clear.Image = ((System.Drawing.Image)(resources.GetObject("clear.Image")));
            this.clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 28);
            this.clear.Text = "очистить";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 641);
            this.Controls.Add(this.panelBack);
            this.MaximumSize = new System.Drawing.Size(1189, 688);
            this.MinimumSize = new System.Drawing.Size(1189, 688);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelBack.ResumeLayout(false);
            this.panelBack.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton load;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLicensePlate;
        private System.Windows.Forms.Button buttonAddShipment;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxVolume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.ToolStripButton editCount;
        private System.Windows.Forms.Button removeVehicle;
        private System.Windows.Forms.Button removeShipment;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMaxSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabelAllVol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton clear;
    }
}

