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
				
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox textBox_Console;
		private System.Windows.Forms.Label label_CE;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel_Console;
		private System.Windows.Forms.Label label_Console_Title;
		private System.Windows.Forms.Button button_cmd;
		private System.Windows.Forms.Label label_Console_cmd;
		
		
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.textBox_Console = new System.Windows.Forms.TextBox();
			this.label_CE = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel_Console = new System.Windows.Forms.Panel();
			this.label_Console_cmd = new System.Windows.Forms.Label();
			this.button_cmd = new System.Windows.Forms.Button();
			this.label_Console_Title = new System.Windows.Forms.Label();
			this.panel_Console.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			// 
			// textBox_Console
			// 
			this.textBox_Console.BackColor = System.Drawing.Color.DimGray;
			this.textBox_Console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox_Console.ForeColor = System.Drawing.Color.White;
			this.textBox_Console.Location = new System.Drawing.Point(10, 33);
			this.textBox_Console.Margin = new System.Windows.Forms.Padding(10);
			this.textBox_Console.Multiline = true;
			this.textBox_Console.Name = "textBox_Console";
			this.textBox_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_Console.Size = new System.Drawing.Size(603, 331);
			this.textBox_Console.TabIndex = 8;
			// 
			// label_CE
			// 
			this.label_CE.AutoSize = true;
			this.label_CE.BackColor = System.Drawing.Color.Transparent;
			this.label_CE.Dock = System.Windows.Forms.DockStyle.Right;
			this.label_CE.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label_CE.ForeColor = System.Drawing.Color.Silver;
			this.label_CE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label_CE.Location = new System.Drawing.Point(665, 0);
			this.label_CE.Name = "label_CE";
			this.label_CE.Size = new System.Drawing.Size(190, 18);
			this.label_CE.TabIndex = 12;
			this.label_CE.Text = "          Корпоративная версия";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(80, 602);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 18);
			this.label8.TabIndex = 14;
			this.label8.Text = "ВЫХОД";
			this.label8.Click += new System.EventHandler(this.Label8Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Silver;
			this.label7.Location = new System.Drawing.Point(80, 575);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 18);
			this.label7.TabIndex = 15;
			this.label7.Text = "НАСТРОЙКИ";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.Color.Silver;
			this.label6.Location = new System.Drawing.Point(80, 548);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 18);
			this.label6.TabIndex = 16;
			this.label6.Text = "ДОСТИЖЕНИЯ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Silver;
			this.label5.Location = new System.Drawing.Point(80, 522);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(162, 18);
			this.label5.TabIndex = 17;
			this.label5.Text = "СООБЩИТЕ ОБ ОШИБКЕ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Silver;
			this.label4.Location = new System.Drawing.Point(80, 496);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(115, 18);
			this.label4.TabIndex = 18;
			this.label4.Text = "СОЗДАТЬ СЕРВЕР";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Silver;
			this.label3.Location = new System.Drawing.Point(80, 469);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 18);
			this.label3.TabIndex = 13;
			this.label3.Text = "НАЙТИ СЕРВЕРЫ";
			// 
			// panel_Console
			// 
			this.panel_Console.AutoSize = true;
			this.panel_Console.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel_Console.Controls.Add(this.label_Console_cmd);
			this.panel_Console.Controls.Add(this.button_cmd);
			this.panel_Console.Controls.Add(this.label_Console_Title);
			this.panel_Console.Controls.Add(this.textBox_Console);
			this.panel_Console.Location = new System.Drawing.Point(216, 38);
			this.panel_Console.Margin = new System.Windows.Forms.Padding(20);
			this.panel_Console.Name = "panel_Console";
			this.panel_Console.Padding = new System.Windows.Forms.Padding(10);
			this.panel_Console.Size = new System.Drawing.Size(633, 423);
			this.panel_Console.TabIndex = 19;
			// 
			// label_Console_cmd
			// 
			this.label_Console_cmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_Console_cmd.BackColor = System.Drawing.Color.DimGray;
			this.label_Console_cmd.Location = new System.Drawing.Point(10, 382);
			this.label_Console_cmd.Name = "label_Console_cmd";
			this.label_Console_cmd.Size = new System.Drawing.Size(494, 23);
			this.label_Console_cmd.TabIndex = 22;
			// 
			// button_cmd
			// 
			this.button_cmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_cmd.AutoSize = true;
			this.button_cmd.BackColor = System.Drawing.Color.Transparent;
			this.button_cmd.Enabled = false;
			this.button_cmd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.button_cmd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button_cmd.Location = new System.Drawing.Point(519, 380);
			this.button_cmd.Name = "button_cmd";
			this.button_cmd.Size = new System.Drawing.Size(94, 30);
			this.button_cmd.TabIndex = 21;
			this.button_cmd.Text = "Выполнить";
			this.button_cmd.UseVisualStyleBackColor = false;
			// 
			// label_Console_Title
			// 
			this.label_Console_Title.BackColor = System.Drawing.Color.Transparent;
			this.label_Console_Title.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Console_Title.Location = new System.Drawing.Point(10, 10);
			this.label_Console_Title.Margin = new System.Windows.Forms.Padding(50);
			this.label_Console_Title.Name = "label_Console_Title";
			this.label_Console_Title.Size = new System.Drawing.Size(613, 23);
			this.label_Console_Title.TabIndex = 0;
			this.label_Console_Title.Text = "Консоль";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gray;
			this.BackgroundImage = global::startDOD.Resource1.bg;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(855, 669);
			this.Controls.Add(this.panel_Console);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label_CE);
			this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = global::startDOD.Resource1.game;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "День победы";
			this.TransparencyKey = System.Drawing.Color.Magenta;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panel_Console.ResumeLayout(false);
			this.panel_Console.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}		
	}
}
