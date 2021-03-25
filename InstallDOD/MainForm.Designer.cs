/*
 * Created by SharpDevelop.
 * User: Andrew
 * Date: 07.01.2019
 * Time: 13:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace InstallDOD
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel_Folder;
		private System.Windows.Forms.ListBox listBox_Folders;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button_folder_Cancel;
		private System.Windows.Forms.Button button_folder_OK;
		private System.Windows.Forms.TextBox textBox_TargetFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label_CE;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboBox_Disks;
		private System.Windows.Forms.Button button_FolderUp;
		private System.Windows.Forms.Button button_newFolder;
		private System.Windows.Forms.Label label9;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel_Folder = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.button_newFolder = new System.Windows.Forms.Button();
            this.button_FolderUp = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_Disks = new System.Windows.Forms.ComboBox();
            this.listBox_Folders = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_folder_Cancel = new System.Windows.Forms.Button();
            this.button_folder_OK = new System.Windows.Forms.Button();
            this.textBox_TargetFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_CE = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_Folder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Folder
            // 
            this.panel_Folder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Folder.BackColor = System.Drawing.Color.DarkGray;
            this.panel_Folder.Controls.Add(this.label9);
            this.panel_Folder.Controls.Add(this.button_newFolder);
            this.panel_Folder.Controls.Add(this.button_FolderUp);
            this.panel_Folder.Controls.Add(this.label10);
            this.panel_Folder.Controls.Add(this.comboBox_Disks);
            this.panel_Folder.Controls.Add(this.listBox_Folders);
            this.panel_Folder.Controls.Add(this.label2);
            this.panel_Folder.Controls.Add(this.button_folder_Cancel);
            this.panel_Folder.Controls.Add(this.button_folder_OK);
            this.panel_Folder.Controls.Add(this.textBox_TargetFolder);
            this.panel_Folder.Controls.Add(this.label1);
            this.panel_Folder.Location = new System.Drawing.Point(124, 75);
            this.panel_Folder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_Folder.Name = "panel_Folder";
            this.panel_Folder.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel_Folder.Size = new System.Drawing.Size(597, 464);
            this.panel_Folder.TabIndex = 8;
            this.panel_Folder.Visible = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(20, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 23);
            this.label9.TabIndex = 28;
            this.label9.Text = "Папки";
            // 
            // button_newFolder
            // 
            this.button_newFolder.AutoSize = true;
            this.button_newFolder.BackColor = System.Drawing.Color.Transparent;
            this.button_newFolder.BackgroundImage = global::InstallDOD.Resource1.icon_newfolder;
            this.button_newFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_newFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_newFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_newFolder.Location = new System.Drawing.Point(503, 29);
            this.button_newFolder.Name = "button_newFolder";
            this.button_newFolder.Size = new System.Drawing.Size(24, 24);
            this.button_newFolder.TabIndex = 26;
            this.toolTip1.SetToolTip(this.button_newFolder, "Создать новую папку");
            this.button_newFolder.UseVisualStyleBackColor = false;
            this.button_newFolder.Click += new System.EventHandler(this.Button_newFolderClick);
            // 
            // button_FolderUp
            // 
            this.button_FolderUp.AutoSize = true;
            this.button_FolderUp.BackColor = System.Drawing.Color.Transparent;
            this.button_FolderUp.BackgroundImage = global::InstallDOD.Resource1.icon_folderup;
            this.button_FolderUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_FolderUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_FolderUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_FolderUp.Location = new System.Drawing.Point(476, 29);
            this.button_FolderUp.Name = "button_FolderUp";
            this.button_FolderUp.Size = new System.Drawing.Size(24, 24);
            this.button_FolderUp.TabIndex = 25;
            this.toolTip1.SetToolTip(this.button_FolderUp, "Вверх");
            this.button_FolderUp.UseVisualStyleBackColor = false;
            this.button_FolderUp.Click += new System.EventHandler(this.Button_FolderUpClick);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(20, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "Диск";
            // 
            // comboBox_Disks
            // 
            this.comboBox_Disks.BackColor = System.Drawing.Color.Gray;
            this.comboBox_Disks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Disks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Disks.ForeColor = System.Drawing.Color.White;
            this.comboBox_Disks.Location = new System.Drawing.Point(94, 28);
            this.comboBox_Disks.Name = "comboBox_Disks";
            this.comboBox_Disks.Size = new System.Drawing.Size(376, 31);
            this.comboBox_Disks.TabIndex = 23;
            this.comboBox_Disks.SelectedIndexChanged += new System.EventHandler(this.ComboBox_DisksSelectedIndexChanged);
            // 
            // listBox_Folders
            // 
            this.listBox_Folders.BackColor = System.Drawing.Color.Gray;
            this.listBox_Folders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Folders.ForeColor = System.Drawing.Color.White;
            this.listBox_Folders.FormattingEnabled = true;
            this.listBox_Folders.ItemHeight = 23;
            this.listBox_Folders.Location = new System.Drawing.Point(10, 90);
            this.listBox_Folders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox_Folders.Name = "listBox_Folders";
            this.listBox_Folders.ScrollAlwaysVisible = true;
            this.listBox_Folders.Size = new System.Drawing.Size(577, 232);
            this.listBox_Folders.Sorted = true;
            this.listBox_Folders.TabIndex = 2;
            this.listBox_Folders.SelectedIndexChanged += new System.EventHandler(this.ListBox_FoldersSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(38, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "DOD будет установлен в эту папку";
            // 
            // button_folder_Cancel
            // 
            this.button_folder_Cancel.AutoSize = true;
            this.button_folder_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_folder_Cancel.FlatAppearance.BorderSize = 0;
            this.button_folder_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_folder_Cancel.Location = new System.Drawing.Point(498, 412);
            this.button_folder_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_folder_Cancel.Name = "button_folder_Cancel";
            this.button_folder_Cancel.Size = new System.Drawing.Size(83, 33);
            this.button_folder_Cancel.TabIndex = 13;
            this.button_folder_Cancel.Text = "Отмена";
            this.button_folder_Cancel.UseVisualStyleBackColor = true;
            this.button_folder_Cancel.Click += new System.EventHandler(this.Button1Click);
            // 
            // button_folder_OK
            // 
            this.button_folder_OK.AutoSize = true;
            this.button_folder_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_folder_OK.FlatAppearance.BorderSize = 0;
            this.button_folder_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_folder_OK.Location = new System.Drawing.Point(38, 412);
            this.button_folder_OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_folder_OK.Name = "button_folder_OK";
            this.button_folder_OK.Size = new System.Drawing.Size(60, 33);
            this.button_folder_OK.TabIndex = 14;
            this.button_folder_OK.Text = "OK";
            this.button_folder_OK.UseVisualStyleBackColor = true;
            this.button_folder_OK.Click += new System.EventHandler(this.Button_folder_OKClick);
            // 
            // textBox_TargetFolder
            // 
            this.textBox_TargetFolder.BackColor = System.Drawing.Color.Gray;
            this.textBox_TargetFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TargetFolder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_TargetFolder.ForeColor = System.Drawing.Color.White;
            this.textBox_TargetFolder.Location = new System.Drawing.Point(28, 362);
            this.textBox_TargetFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_TargetFolder.Name = "textBox_TargetFolder";
            this.textBox_TargetFolder.ReadOnly = true;
            this.textBox_TargetFolder.Size = new System.Drawing.Size(536, 30);
            this.textBox_TargetFolder.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "    Выберите  папку  для  установки DOD или создайте новую папку";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(98, 562);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "НАЙТИ СЕРВЕРЫ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(98, 589);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "СОЗДАТЬ СЕРВЕР";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(98, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "СООБЩИТЕ ОБ ОШИБКЕ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(98, 641);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "ДОСТИЖЕНИЯ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(98, 668);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "НАСТРОЙКИ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(98, 695);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "ВЫХОД";
            this.label8.Click += new System.EventHandler(this.Button1Click);
            this.label8.MouseEnter += new System.EventHandler(this.Label8MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.Label8MouseLeave);
            // 
            // label_CE
            // 
            this.label_CE.AutoSize = true;
            this.label_CE.BackColor = System.Drawing.Color.Transparent;
            this.label_CE.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_CE.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CE.ForeColor = System.Drawing.Color.Silver;
            this.label_CE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_CE.Location = new System.Drawing.Point(629, 0);
            this.label_CE.Name = "label_CE";
            this.label_CE.Size = new System.Drawing.Size(243, 23);
            this.label_CE.TabIndex = 11;
            this.label_CE.Text = "          Корпоративная версия";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(872, 752);
            this.Controls.Add(this.label_CE);
            this.Controls.Add(this.panel_Folder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::InstallDOD.Resource1.game;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstallDOD";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.panel_Folder.ResumeLayout(false);
            this.panel_Folder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.ToolTip toolTip1;
    }
}