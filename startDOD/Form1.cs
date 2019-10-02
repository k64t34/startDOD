﻿using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
//using System.Data.Common;
//using System.Data.SQLite;
using System.Threading;

namespace startDOD
{
    public partial class Form1 : Form
    {
        string workFolder = AppDomain.CurrentDomain.BaseDirectory;
        string updateFolder;
        const string RunMOD = "День Победы";
        const string revLoader = "revLoader.exe";
        char[] separatingChars = { ' ', '\t' };
        SynchronizationContext _syncContext;       
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
            _syncContext = SynchronizationContext.Current;
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
                                            UpdateLineWords = UPDATEline.Split(separatingChars,StringSplitOptions.RemoveEmptyEntries);
                                            textBox_Console.AppendText(UpdateLineWords[0]);
                                            if (UpdateLineWords.Length < 3)
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
                                                INILineWords = INIline.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries);
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
                                                UpdateLineWords[2] = UpdateLineWords[2].ToUpper();
                                                textBox_Console.AppendText(" updating... " + UpdateLineWords[2] +" " );
                                                if (String.Equals(UpdateLineWords[2], "UNZIP"))
                                                {
                                                    if (UpdateLineWords.Length < 4)
                                                        textBox_Console.AppendText(" Файл архива не указан" + Environment.NewLine);
                                                    else
                                                    if (UNZIP(UpdateLineWords[3]))
                                                    {
                                                        textBox_Console.AppendText(" OK" + Environment.NewLine);
                                                        //TODO: Записать в MOD.ini успех обновления
                                                        //https://docs.microsoft.com/ru-ru/dotnet/api/system.io.filestream?view=netframework-4.8
                                                        //sINI.Close();
                                                        //StreamWriter swINI = File.AppendText(iniFile);
                                                        //swINI.WriteLine(UpdateLineWords[0]+" "+ UpdateLineWords[1]);
                                                        //swINI.Close();
                                                        //sINI.open(iniFile);
                                                    }
                                                    else { textBox_Console.AppendText(" Ошибка" + Environment.NewLine); }
                                                }
                                                else if (String.Equals(UpdateLineWords[2], "REG"))
                                                {
                                                    if (UpdateLineWords.Length < 4)
                                                        textBox_Console.AppendText(" Файл реестра не указан" + Environment.NewLine);
                                                    else
                                                    if (REGimport(UpdateLineWords[3]))
                                                    {
                                                        textBox_Console.AppendText(" OK" + Environment.NewLine);
                                                        //TODO: Записать в MOD.ini успех обновления
                                                    }
                                                }
                                                else
                                                    textBox_Console.AppendText(" Invalid command." + Environment.NewLine);
                                            }                                           
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
        private bool UNZIP(string cmdFile)
        {
            bool UNZIP_return = true;
            textBox_Console.AppendText("Распаковка " + cmdFile);
            cmdFile = updateFolder + cmdFile;
            if (!File.Exists(cmdFile)) { textBox_Console.AppendText(" Архив " + cmdFile + " не найден ");return (false); }
            string UNZIPer;
            UNZIPer = Environment.GetEnvironmentVariable("ProgramFiles")+ "\\WinRAR\\Rar.exe";
            if (!File.Exists(UNZIPer))
            {
                UNZIPer = Environment.GetEnvironmentVariable("ProgramFiles(x86)") + "\\WinRAR\\Rar.exe";
                if (!File.Exists(UNZIPer))
                {
                    UNZIPer = updateFolder + "UnRAR.exe";
                    if (!File.Exists(UNZIPer)) { textBox_Console.AppendText(" Не найден распаковщик " + UNZIPer); return (false); }
                }
            }
            int RUN_return=RUN(UNZIPer, "x -y -o+ -sca -idcd  \"" + cmdFile + "\" \"" + workFolder + "\"");
            if (RUN_return == -1) { textBox_Console.AppendText(" Ошибка при запуске распаковщика"); UNZIP_return=false; }
            else if (RUN_return > 0) textBox_Console.AppendText(" Распаковщик завершил работу с кодом " + RUN_return + Environment.NewLine);
            return (UNZIP_return);
        }
        private bool REGimport(string cmdFile)
        {
            textBox_Console.AppendText("Правка реестра" + cmdFile + Environment.NewLine);
            return (true);
        }
        private void SYNC(string cmdFolder)
        {
            textBox_Console.AppendText("Синхронизация" + cmdFolder + Environment.NewLine);
        }
        private int RUN(string FileName, string Arguments)
        {
            int RUN_return = 0;
            try
            {
                using (Process myProcess = new Process())
                {                    
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = FileName;
                    myProcess.StartInfo.Arguments = Arguments;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.ErrorDialog = true;
                    myProcess.StartInfo.RedirectStandardOutput = true;
                    myProcess.StartInfo.RedirectStandardInput = true;
                    myProcess.StartInfo.RedirectStandardError = true;
                    StringBuilder so = new StringBuilder();
                    myProcess.OutputDataReceived += (sender, args) => { so.AppendLine(args.Data); };
                    myProcess.ErrorDataReceived += (sender, args) => { so.AppendLine(args.Data); };
                    myProcess.Start();
                    myProcess.BeginOutputReadLine();
                    myProcess.BeginErrorReadLine();
                    Random random = new Random();
                    int BufLine = 0;
                    while (!myProcess.HasExited)
                    {
                        Thread.Sleep(random.Next(100, 1000));
                        if (so.Length > BufLine)
                        {
                            textBox_Console.AppendText(so.ToString().Substring(BufLine));
                            BufLine = so.Length;
                        }
                    }
                    if (so.Length > BufLine) textBox_Console.AppendText(so.ToString().Substring(BufLine));
                    RUN_return = myProcess.ExitCode;                    
                    myProcess.Dispose();
                }
            }
            catch (Exception ex)
            {
                RUN_return=-1;
            }
            return (RUN_return);
        }
    }
}
