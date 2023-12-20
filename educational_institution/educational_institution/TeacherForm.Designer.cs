namespace educational_institution
{
	partial class TeacherForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPosition = new System.Windows.Forms.TextBox();
			this.numWorkload = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numWorkload)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(77, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Фамилия";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(80, 40);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(231, 22);
			this.textBoxLastName.TabIndex = 4;
			this.textBoxLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLastName_KeyPress);
			this.textBoxLastName.Leave += new System.EventHandler(this.textBoxLastName_Leave);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(128, 192);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(139, 34);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "добавить";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(77, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Должность";
			// 
			// textBoxPosition
			// 
			this.textBoxPosition.Location = new System.Drawing.Point(80, 95);
			this.textBoxPosition.Name = "textBoxPosition";
			this.textBoxPosition.Size = new System.Drawing.Size(231, 22);
			this.textBoxPosition.TabIndex = 6;
			this.textBoxPosition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLastName_KeyPress);
			// 
			// numWorkload
			// 
			this.numWorkload.Location = new System.Drawing.Point(80, 154);
			this.numWorkload.Name = "numWorkload";
			this.numWorkload.Size = new System.Drawing.Size(231, 22);
			this.numWorkload.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(77, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Учебная нагрузка (часов)";
			// 
			// TeacherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 238);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numWorkload);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxPosition);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.buttonSave);
			this.Name = "TeacherForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Преподаватель";
			((System.ComponentModel.ISupportInitialize)(this.numWorkload)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPosition;
		private System.Windows.Forms.NumericUpDown numWorkload;
		private System.Windows.Forms.Label label3;
	}
}