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
		private System.Windows.Forms.TextBox textBox_Console;		
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button_install2;
		
		
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
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_Console = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button_install2 = new System.Windows.Forms.Button();
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
			// textBox_Console
			// 
			this.textBox_Console.BackColor = System.Drawing.SystemColors.ControlDark;
			this.textBox_Console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox_Console.Location = new System.Drawing.Point(143, 29);
			this.textBox_Console.Multiline = true;
			this.textBox_Console.Name = "textBox_Console";
			this.textBox_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_Console.Size = new System.Drawing.Size(650, 395);
			this.textBox_Console.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(42, 232);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gray;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(805, 467);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox_Console);
			this.Controls.Add(this.button_install2);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "День победы";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		
	}
}
