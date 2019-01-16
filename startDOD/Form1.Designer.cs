namespace startDOD
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_CE = new System.Windows.Forms.Label();
            this.panel_Console = new System.Windows.Forms.Panel();
            this.label_Console_cmd = new System.Windows.Forms.Label();
            this.button_cmd = new System.Windows.Forms.Button();
            this.textBox_Console = new System.Windows.Forms.TextBox();
            this.label_panel_Console_Title = new System.Windows.Forms.Label();
            this.panel_Console.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(47, 646);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "ВЫХОД";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(47, 608);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "НАСТРОЙКИ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(47, 571);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "ДОСТИЖЕНИЯ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(47, 535);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "СООБЩИТЕ ОБ ОШИБКЕ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(47, 499);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "СОЗДАТЬ СЕРВЕР";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(47, 461);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "НАЙТИ СЕРВЕРЫ";
            // 
            // label_CE
            // 
            this.label_CE.AutoSize = true;
            this.label_CE.BackColor = System.Drawing.Color.Transparent;
            this.label_CE.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_CE.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CE.ForeColor = System.Drawing.Color.Silver;
            this.label_CE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_CE.Location = new System.Drawing.Point(872, 10);
            this.label_CE.Name = "label_CE";
            this.label_CE.Size = new System.Drawing.Size(190, 18);
            this.label_CE.TabIndex = 17;
            this.label_CE.Text = "          Корпоративная версия";
            // 
            // panel_Console
            // 
            this.panel_Console.Controls.Add(this.label_Console_cmd);
            this.panel_Console.Controls.Add(this.button_cmd);
            this.panel_Console.Controls.Add(this.textBox_Console);
            this.panel_Console.Controls.Add(this.label_panel_Console_Title);
            this.panel_Console.Location = new System.Drawing.Point(259, 37);
            this.panel_Console.Margin = new System.Windows.Forms.Padding(16);
            this.panel_Console.Name = "panel_Console";
            this.panel_Console.Padding = new System.Windows.Forms.Padding(16);
            this.panel_Console.Size = new System.Drawing.Size(770, 617);
            this.panel_Console.TabIndex = 18;
            this.panel_Console.Visible = false;
            // 
            // label_Console_cmd
            // 
            this.label_Console_cmd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_Console_cmd.Location = new System.Drawing.Point(16, 578);
            this.label_Console_cmd.Name = "label_Console_cmd";
            this.label_Console_cmd.Size = new System.Drawing.Size(645, 23);
            this.label_Console_cmd.TabIndex = 3;
            // 
            // button_cmd
            // 
            this.button_cmd.AutoSize = true;
            this.button_cmd.Enabled = false;
            this.button_cmd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_cmd.Location = new System.Drawing.Point(673, 582);
            this.button_cmd.Name = "button_cmd";
            this.button_cmd.Size = new System.Drawing.Size(90, 28);
            this.button_cmd.TabIndex = 2;
            this.button_cmd.Text = "Выполнить";
            this.button_cmd.UseVisualStyleBackColor = true;
            // 
            // textBox_Console
            // 
            this.textBox_Console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_Console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Console.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_Console.ForeColor = System.Drawing.Color.White;
            this.textBox_Console.Location = new System.Drawing.Point(16, 34);
            this.textBox_Console.Margin = new System.Windows.Forms.Padding(10);
            this.textBox_Console.Multiline = true;
            this.textBox_Console.Name = "textBox_Console";
            this.textBox_Console.Size = new System.Drawing.Size(738, 534);
            this.textBox_Console.TabIndex = 1;
            // 
            // label_panel_Console_Title
            // 
            this.label_panel_Console_Title.BackColor = System.Drawing.Color.Transparent;
            this.label_panel_Console_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_panel_Console_Title.Location = new System.Drawing.Point(16, 16);
            this.label_panel_Console_Title.Margin = new System.Windows.Forms.Padding(10);
            this.label_panel_Console_Title.Name = "label_panel_Console_Title";
            this.label_panel_Console_Title.Size = new System.Drawing.Size(738, 18);
            this.label_panel_Console_Title.TabIndex = 0;
            this.label_panel_Console_Title.Text = "Консоль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::startDOD.Resource1.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1072, 723);
            this.Controls.Add(this.panel_Console);
            this.Controls.Add(this.label_CE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запуск DOD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Console.ResumeLayout(false);
            this.panel_Console.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_CE;
        private System.Windows.Forms.Panel panel_Console;
        private System.Windows.Forms.Label label_Console_cmd;
        private System.Windows.Forms.Button button_cmd;
        private System.Windows.Forms.TextBox textBox_Console;
        private System.Windows.Forms.Label label_panel_Console_Title;
    }
}

