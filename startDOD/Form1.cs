using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.Data.Common;
//using System.Data.SQLite;

namespace startDOD
{
    public partial class Form1 : Form
    {
        string workFolder = AppDomain.CurrentDomain.BaseDirectory;
        string updateFolder ;
        const string RunMOD = "День Победы";
        const string revLoader = "revLoader.exe";
        char[] separatingChars = { ' ', '\t' };
    public Form1()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Tune form control
            panel_Console.Width = this.Width - panel_Console.Left - panel_Console.Margin.All;
            panel_Console.Height = this.Height - panel_Console.Top - panel_Console.Margin.All - panel_Console.Margin.All;
            label_Console_cmd.Left = panel_Console.Padding.All;
            button_cmd.Left = panel_Console.Width - panel_Console.Margin.All - button_cmd.Width;
            label_Console_cmd.Width = button_cmd.Left - panel_Console.Margin.All - label_Console_cmd.Left;
            label_Console_cmd.Top = panel_Console.Height - panel_Console.Padding.All - label_Console_cmd.Height;
            button_cmd.Top = label_Console_cmd.Top;
            textBox_Console.Height = label_Console_cmd.Top - textBox_Console.Top - panel_Console.Padding.All;
            panel_Console.BackColor = Color.FromArgb(200, 128, 128, 128);
            label_Console_cmd.BackColor = Color.FromArgb(100, 48, 48, 48);
            panel_Console.Visible = true;

            textBox_Console.AppendText("Рабочая папка " + workFolder+Environment.NewLine);
            string iniFile = RunMOD + ".ini";
            
            if (!File.Exists(workFolder + iniFile)) textBox_Console.AppendText("Файла конфигурации " + iniFile + " не найден. Обновление невозможно." + Environment.NewLine);
            else
            {
                iniFile = workFolder + iniFile;
                textBox_Console.AppendText("Чтение файла конфигурации " + iniFile  + Environment.NewLine);
                using (StreamReader sINI = new StreamReader(iniFile))
                {
                    string INIline;
                    while ((INIline = sINI.ReadLine()) != null)
                    {
                        INIline=INIline.Trim();
                        if (INIline.Length==0) continue;
                        if (INIline.StartsWith("#")) continue;
                        updateFolder = INIline.TrimEnd();
                        break;                                                
                    }
                    if (updateFolder == null) textBox_Console.AppendText("Файла конфигурации не содержить ссылку на папку обновлений"+Environment.NewLine);
                    else if (!Directory.Exists(updateFolder)) textBox_Console.AppendText("Указанная папка обновлений не найдена " + updateFolder + Environment.NewLine);
                    else
                    {
                        if (!updateFolder.EndsWith("\\")) updateFolder += "\\";
                        string updateFile = updateFolder + "update.txt";
                        string lastupdate = null;
                        // TODO: read file from end
                        while ((INIline = sINI.ReadLine()) != null) //goto last update
                        {
                            INIline = INIline.TrimStart();
                            if (INIline.StartsWith("#")) continue;
                            if (INIline.Length==0) continue;
                            lastupdate = INIline.Trim();
                        }
                        sINI.Close();

                        if (!File.Exists(updateFile)) textBox_Console.AppendText("Файл обновлений не найден " + updateFile + Environment.NewLine);
                        else
                        {
                            textBox_Console.AppendText("Чтение файла обновлений " + updateFile + Environment.NewLine);
                            using (StreamReader sUPDATE = new StreamReader(updateFile))
                            {
                                string UPDATEline;
                                string[] UpdateLineWords;
                                // Find last update
                                while ((UPDATEline = sUPDATE.ReadLine()) != null)
                                {
                                    UPDATEline = UPDATEline.TrimStart();
                                    if (UPDATEline.StartsWith("#")) continue; // skip comment
                                    if (UPDATEline.Length==0) continue; // skip empty line
                                    {
                                        UpdateLineWords = UPDATEline.Split(separatingChars);
                                        if (lastupdate == null) break;
                                        if (UpdateLineWords[0] == lastupdate) break;                                        
                                    }
                                }
                                //do update
                                StreamWriter swINI = File.AppendText(iniFile);
                                swINI.WriteLine();
                                
                                 while ((UPDATEline = sUPDATE.ReadLine()) != null)
                                    {
                                    UPDATEline = UPDATEline.TrimStart();
                                    if (UPDATEline.StartsWith("#")) continue;// skip comment
                                    if (UPDATEline.Length == 0) continue; // skip empty line
                                    {                                    
                                        UpdateLineWords = UPDATEline.Split(separatingChars);
                                        textBox_Console.AppendText("Установка обновления "+UpdateLineWords[0] + Environment.NewLine);
                                        swINI.WriteLine(UpdateLineWords[0]);
                                    }                                    
                                }
                                swINI.Close();
                            }
                        }
                    }

                }
            }
        }
    }
}
