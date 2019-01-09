/*
 * Created by SharpDevelop.
 * User: skorik
 * Date: 09.01.2019
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace InstallDOD
{
	partial class newFolder
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.TextBox textBox_newFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button_OK = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.textBox_newFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button_OK
			// 
			this.button_OK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button_OK.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_OK.Location = new System.Drawing.Point(82, 93);
			this.button_OK.Margin = new System.Windows.Forms.Padding(4);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(77, 32);
			this.button_OK.TabIndex = 1;
			this.button_OK.Text = "ОК";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.Button_OKClick);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_Cancel.Location = new System.Drawing.Point(292, 93);
			this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(83, 32);
			this.button_Cancel.TabIndex = 2;
			this.button_Cancel.Text = "Отмена";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.Button_CancelClick);
			// 
			// textBox_newFolder
			// 
			this.textBox_newFolder.BackColor = System.Drawing.Color.DimGray;
			this.textBox_newFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox_newFolder.ForeColor = System.Drawing.Color.White;
			this.textBox_newFolder.Location = new System.Drawing.Point(13, 50);
			this.textBox_newFolder.Margin = new System.Windows.Forms.Padding(4);
			this.textBox_newFolder.Name = "textBox_newFolder";
			this.textBox_newFolder.Size = new System.Drawing.Size(425, 26);
			this.textBox_newFolder.TabIndex = 0;
			this.textBox_newFolder.Text = "DOD.2018";
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(459, 25);
			this.label1.TabIndex = 3;
			this.label1.Text = "Новая папка";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 25);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 21);
			this.label2.TabIndex = 4;
			this.label2.Text = "Имя:";
			// 
			// newFolder
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gray;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(459, 149);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_newFolder);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_OK);
			this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "newFolder";
			this.Opacity = 0.95D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.newFolder_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
