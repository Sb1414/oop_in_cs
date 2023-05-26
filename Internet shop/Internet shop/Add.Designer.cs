namespace Internet_shop
{
    partial class Add
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNameHum = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(68, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Дата";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Имя заказчика";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNameHum
            // 
            this.textBoxNameHum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNameHum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameHum.Location = new System.Drawing.Point(273, 62);
            this.textBoxNameHum.Name = "textBoxNameHum";
            this.textBoxNameHum.Size = new System.Drawing.Size(217, 24);
            this.textBoxNameHum.TabIndex = 8;
            this.textBoxNameHum.TextChanged += new System.EventHandler(this.textBoxNameHum_TextChanged);
            // 
            // ok
            // 
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.Location = new System.Drawing.Point(206, 194);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(163, 42);
            this.ok.TabIndex = 18;
            this.ok.Text = "Добавить";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDate.Location = new System.Drawing.Point(273, 115);
            this.dateTimePickerDate.MaxDate = new System.DateTime(2023, 5, 27, 0, 0, 0, 0);
            this.dateTimePickerDate.MinDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(217, 22);
            this.dateTimePickerDate.TabIndex = 19;
            this.dateTimePickerDate.Value = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 298);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNameHum);
            this.Controls.Add(this.ok);
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNameHum;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
    }
}