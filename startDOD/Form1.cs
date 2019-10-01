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
        string updateFolder;
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

            textBox_Console.AppendText("Рабочая папка " + workFolder + Environment.NewLine);
            string iniFile = RunMOD + ".ini";

            if (!File.Exists(workFolder + iniFile)) textBox_Console.AppendText("Файла конфигурации " + iniFile + " не найден. Обновление невозможно." + Environment.NewLine);
            else
            {
                iniFile = workFolder + iniFile;
                textBox_Console.AppendText("Чтение файла конфигурации " + iniFile + Environment.NewLine);
                using (StreamReader sINI = new StreamReader(iniFile))
                {
                    string INIline;
                    int StartLogLine=0;
                    while ((INIline = sINI.ReadLine()) != null)
                    {
                        StartLogLine++;
                        INIline = INIline.Trim();
                        if (INIline.Length == 0) continue;
                        if (INIline.StartsWith("#")) continue;
                        updateFolder = INIline.TrimEnd();                        
                        break;
                    }
                    if (updateFolder == null) textBox_Console.AppendText("Файла конфигурации не содержить ссылку на папку обновлений" + Environment.NewLine);
                    else
                    {
                        if (!updateFolder.EndsWith("\\")) updateFolder += "\\";
                        updateFolder += "update\\";
                        if (!Directory.Exists(updateFolder)) textBox_Console.AppendText("Указанная папка обновлений не найдена " + updateFolder + Environment.NewLine);
                        else
                        {                            
                            string updateFile = updateFolder + "update.txt";                           
                            
                            if (!File.Exists(updateFile)) textBox_Console.AppendText("Файл обновлений не найден " + updateFile + Environment.NewLine);
                            else
                            {
                                textBox_Console.AppendText("Чтение файла обновлений " + updateFile + Environment.NewLine);
                                using (StreamReader sUPDATE = new StreamReader(updateFile))
                                {
                                    string UPDATEline;
                                    string[] UpdateLineWords;
                                    string[] INILineWords;
                                    //StreamWriter swINI = File.AppendText(iniFile);
                                    //swINI.WriteLine();
                                    //System.Environment.SetEnvironmentVariable("FolderInstall", workFolder, EnvironmentVariableTarget.User);
                                    while ((UPDATEline = sUPDATE.ReadLine()) != null)
                                    {
                                        UPDATEline = UPDATEline.TrimStart();
                                        if (UPDATEline.StartsWith("#")) continue;// skip comment
                                        if (UPDATEline.Length == 0) continue; // skip empty line
                                        {
                                            UpdateLineWords = UPDATEline.Split(separatingChars);
                                            textBox_Console.AppendText(UpdateLineWords[0]);
                                            if (UpdateLineWords.Length <= 3)
                                            {
                                                textBox_Console.AppendText(" invalid line"  + Environment.NewLine);
                                                continue; // skip invalid line
                                            }
                                            textBox_Console.AppendText(" " + UpdateLineWords[1]);
                                            //check this update in client INI file
                                            int LogLineCounter = 0;
                                            bool needUpdate = true;
                                            while ((INIline = sINI.ReadLine()) != null)
                                            {
                                                LogLineCounter++;
                                                if (LogLineCounter < StartLogLine) continue;                                                
                                                INIline = INIline.Trim();
                                                if (INIline.Length == 0) continue;
                                                if (INIline.StartsWith("#")) continue;
                                                INIline = INIline.TrimEnd();
                                                INILineWords = INIline.Split(separatingChars);
                                                if (INILineWords[0] == UpdateLineWords[0])
                                                {
                                                    if (INILineWords.Length>=2)
                                                    {                                                        
                                                        if (INILineWords[1] == UpdateLineWords[1])
                                                            needUpdate = false;
                                                     }
                                                        
                                                }       
                                            }
                                            if (needUpdate)
                                            {
                                                textBox_Console.AppendText(" updating..." + Environment.NewLine);
                                            }
                                            //string updateFilecmd = updateFolder + UpdateLineWords[0] + ".cmd";
                                            //if (!File.Exists(updateFilecmd)) textBox_Console.AppendText("Файл обновления не найден " + updateFilecmd + Environment.NewLine);
                                            //else
                                            //{
                                            //textBox_Console.AppendText(updateFilecmd + Environment.NewLine);
                                            //textBox_Console.AppendText("Установка обновления " + UpdateLineWords[0] + Environment.NewLine);
                                            //RUN_cmd(updateFilecmd);
                                            //swINI.WriteLine(UpdateLineWords[0]);
                                            //}
                                        }
                                    }
                                    sINI.Close();
                                }
                            }
                        }
                    }
                }
                textBox_Console.AppendText("Запуск " + RunMOD + Environment.NewLine);
                #if !DEBUG
                LoadRevEmu();
                System.Threading.Thread.Sleep(5000);
                this.Close();
                #endif


            }
        }
        private void LoadRevEmu()
            {
            }
        private void CFG(string cmdFile, string Param, string Value)
            {
            textBox_Console.AppendText("Конфигурация" + cmdFile+" "+Param+" "+Value+Environment.NewLine);
        }
        private void UNZIP(string cmdFile)
        {
            textBox_Console.AppendText("Распаковка" + cmdFile + Environment.NewLine);
        }
        private void REGimport(string cmdFile)
        {
            textBox_Console.AppendText("Правка реестра" + cmdFile + Environment.NewLine);
        }
        private void SYNC(string cmdFolder)
        {
            textBox_Console.AppendText("Синхронизация" + cmdFolder + Environment.NewLine);
        }
    }
}
