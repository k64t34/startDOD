/*
 * Created by SharpDevelop.
 * User: Andrew
 * Date: 05.01.2019
 * Time: 19:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace startDOD
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
				
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button_install2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button_folder_Cancel;
		private System.Windows.Forms.Button button_folder_OK;
		private System.Windows.Forms.TextBox textBox_TargetFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel_Folder;
		private System.Windows.Forms.TextBox textBox_Console;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton_Disk_C;
		private System.Windows.Forms.Panel panel_Disk;
		private System.Windows.Forms.ListBox listBox_Folders;
		
		
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
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button_install2 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel_Folder = new System.Windows.Forms.Panel();
			this.listBox_Folders = new System.Windows.Forms.ListBox();
			this.panel_Disk = new System.Windows.Forms.Panel();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton_Disk_C = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.button_folder_Cancel = new System.Windows.Forms.Button();
			this.button_folder_OK = new System.Windows.Forms.Button();
			this.textBox_TargetFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_Console = new System.Windows.Forms.TextBox();
			this.panel_Folder.SuspendLayout();
			this.panel_Disk.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(28, 393);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 31);
			this.button1.TabIndex = 0;
			this.button1.Text = "Выход";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(35, 364);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Refresh";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button_install2
			// 
			this.button_install2.AutoSize = true;
			this.button_install2.BackColor = System.Drawing.Color.Transparent;
			this.button_install2.FlatAppearance.BorderSize = 0;
			this.button_install2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_install2.Location = new System.Drawing.Point(28, 25);
			this.button_install2.Name = "button_install2";
			this.button_install2.Size = new System.Drawing.Size(82, 31);
			this.button_install2.TabIndex = 0;
			this.button_install2.Text = "Install";
			this.button_install2.UseVisualStyleBackColor = false;
			this.button_install2.Click += new System.EventHandler(this.button_installClick);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// panel_Folder
			// 
			this.panel_Folder.BackColor = System.Drawing.Color.Transparent;
			this.panel_Folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_Folder.Controls.Add(this.listBox_Folders);
			this.panel_Folder.Controls.Add(this.panel_Disk);
			this.panel_Folder.Controls.Add(this.label2);
			this.panel_Folder.Controls.Add(this.button_folder_Cancel);
			this.panel_Folder.Controls.Add(this.button_folder_OK);
			this.panel_Folder.Controls.Add(this.textBox_TargetFolder);
			this.panel_Folder.Controls.Add(this.label1);
			this.panel_Folder.Location = new System.Drawing.Point(336, 25);
			this.panel_Folder.Name = "panel_Folder";
			this.panel_Folder.Size = new System.Drawing.Size(747, 413);
			this.panel_Folder.TabIndex = 7;
			// 
			// listBox_Folders
			// 
			this.listBox_Folders.FormattingEnabled = true;
			this.listBox_Folders.ItemHeight = 19;
			this.listBox_Folders.Location = new System.Drawing.Point(24, 80);
			this.listBox_Folders.Name = "listBox_Folders";
			this.listBox_Folders.Size = new System.Drawing.Size(679, 213);
			this.listBox_Folders.TabIndex = 22;
			this.listBox_Folders.DoubleClick += new System.EventHandler(this.ListBox_FoldersDoubleClick);
			// 
			// panel_Disk
			// 
			this.panel_Disk.Controls.Add(this.radioButton3);
			this.panel_Disk.Controls.Add(this.radioButton2);
			this.panel_Disk.Controls.Add(this.radioButton_Disk_C);
			this.panel_Disk.Location = new System.Drawing.Point(24, 37);
			this.panel_Disk.Name = "panel_Disk";
			this.panel_Disk.Size = new System.Drawing.Size(689, 37);
			this.panel_Disk.TabIndex = 21;
			// 
			// radioButton3
			// 
			this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
			this.radioButton3.AutoSize = true;
			this.radioButton3.BackColor = System.Drawing.Color.Transparent;
			this.radioButton3.Dock = System.Windows.Forms.DockStyle.Left;
			this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.radioButton3.Location = new System.Drawing.Point(74, 0);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(37, 37);
			this.radioButton3.TabIndex = 5;
			this.radioButton3.Text = "E:";
			this.radioButton3.UseVisualStyleBackColor = false;
			// 
			// radioButton2
			// 
			this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
			this.radioButton2.AutoSize = true;
			this.radioButton2.Dock = System.Windows.Forms.DockStyle.Left;
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.radioButton2.Location = new System.Drawing.Point(37, 0);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(37, 37);
			this.radioButton2.TabIndex = 4;
			this.radioButton2.Text = "D:";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton_Disk_C
			// 
			this.radioButton_Disk_C.Appearance = System.Windows.Forms.Appearance.Button;
			this.radioButton_Disk_C.AutoSize = true;
			this.radioButton_Disk_C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.radioButton_Disk_C.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButton_Disk_C.Checked = true;
			this.radioButton_Disk_C.Dock = System.Windows.Forms.DockStyle.Left;
			this.radioButton_Disk_C.FlatAppearance.BorderSize = 0;
			this.radioButton_Disk_C.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.radioButton_Disk_C.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.radioButton_Disk_C.Location = new System.Drawing.Point(0, 0);
			this.radioButton_Disk_C.Name = "radioButton_Disk_C";
			this.radioButton_Disk_C.Size = new System.Drawing.Size(37, 37);
			this.radioButton_Disk_C.TabIndex = 3;
			this.radioButton_Disk_C.TabStop = true;
			this.radioButton_Disk_C.Text = "C:";
			this.radioButton_Disk_C.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 300);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(297, 19);
			this.label2.TabIndex = 15;
			this.label2.Text = "DOD будет установлен в эту папку";
			// 
			// button_folder_Cancel
			// 
			this.button_folder_Cancel.AutoSize = true;
			this.button_folder_Cancel.FlatAppearance.BorderSize = 0;
			this.button_folder_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_folder_Cancel.Location = new System.Drawing.Point(610, 366);
			this.button_folder_Cancel.Name = "button_folder_Cancel";
			this.button_folder_Cancel.Size = new System.Drawing.Size(75, 29);
			this.button_folder_Cancel.TabIndex = 13;
			this.button_folder_Cancel.Text = "Отмена";
			this.button_folder_Cancel.UseVisualStyleBackColor = true;
			// 
			// button_folder_OK
			// 
			this.button_folder_OK.AutoSize = true;
			this.button_folder_OK.FlatAppearance.BorderSize = 0;
			this.button_folder_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_folder_OK.Location = new System.Drawing.Point(35, 366);
			this.button_folder_OK.Name = "button_folder_OK";
			this.button_folder_OK.Size = new System.Drawing.Size(75, 29);
			this.button_folder_OK.TabIndex = 14;
			this.button_folder_OK.Text = "OK";
			this.button_folder_OK.UseVisualStyleBackColor = true;
			// 
			// textBox_TargetFolder
			// 
			this.textBox_TargetFolder.Location = new System.Drawing.Point(35, 322);
			this.textBox_TargetFolder.Name = "textBox_TargetFolder";
			this.textBox_TargetFolder.Size = new System.Drawing.Size(668, 26);
			this.textBox_TargetFolder.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(745, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Укажите место для установки";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox_Console
			// 
			this.textBox_Console.Location = new System.Drawing.Point(24, 63);
			this.textBox_Console.Multiline = true;
			this.textBox_Console.Name = "textBox_Console";
			this.textBox_Console.Size = new System.Drawing.Size(78, 85);
			this.textBox_Console.TabIndex = 8;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gray;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(1288, 467);
			this.Controls.Add(this.textBox_Console);
			this.Controls.Add(this.panel_Folder);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button_install2);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "День победы";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panel_Folder.ResumeLayout(false);
			this.panel_Folder.PerformLayout();
			this.panel_Disk.ResumeLayout(false);
			this.panel_Disk.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		
	}
}
