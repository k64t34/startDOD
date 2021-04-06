﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
//using System.Data.Common;
//using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace startDOD
{    

    public partial class Form1 : Form
    {
        #region Update control from othe thread     
        //https://www.youtube.com/watch?v=9AIApJmbulY&t=196s
        public delegate void DelegateConsoleWrite(string Text);
        ThreadStart threadStartReadConfig;
        Thread threadReadConfig;
        DelegateConsoleWrite delegateConsoleWrite;
        #endregion
        #region Global vars & consts
        //const string _CR = "\r";
        //const string _CRLF = "\r\n";
        //const string _TAB = "\t";
        string workFolder = AppDomain.CurrentDomain.BaseDirectory;        
        string updateFolder;
        const string RunMOD = "dod";
        const string RunMODTitle="День победы";
        string logFile;
        String FileStarterVersion;
        const string revLoader = "revLoader.exe";
        string ProgUNZIP = "UnRAR.exe";
        char[] separatingChars = { ' ', '\t' };
        SynchronizationContext _syncContext;       
        #endregion
        public Form1() { InitializeComponent();
        }
        private void label8_Click(object sender, EventArgs e) { this.Close(); }        
        private void ConsoleWrite(string text){this.textBox_Console.AppendText(text);}
        private void Form1_Load(object sender, EventArgs e)
        {
            //TOD:Моргание при старте
            logFile = workFolder + RunMODTitle + ".log";
            FileStarterVersion = exeFileVersion(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);             
            label_CE.Text += " " + FileStarterVersion;
            #region Tune form control
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
            #endregion
            delegateConsoleWrite = new DelegateConsoleWrite(ConsoleWrite);
            #region 
            //TODO:Is copy of this programm running

            WriteLineLog("Версия файла " + FileStarterVersion);//            textBox_Console.AppendText("Версия файла " + FileStarterVersion + Environment.NewLine);
            WriteLineLog("Рабочая папка " + workFolder);// textBox_Console.AppendText("Рабочая папка " + workFolder + Environment.NewLine);
            #endregion
            #region Is old update file still exist  
            string RunningProcess = Path.GetFileNameWithoutExtension(System.Environment.GetCommandLineArgs()[0]);
#if DEBUG
            WriteLineLog("Запущенный процесс " + RunningProcess);//            textBox_Console.AppendText("Запущенный процесс " + RunningProcess + Environment.NewLine);
            #endif            
            string UpdateProcess = RunMODTitle + ".update";
            string UpdateFile = workFolder + UpdateProcess + ".exe";
            if (String.Compare(RunMODTitle, RunningProcess, true) == 0)//Rurning *.exe
            {                
                if (File.Exists(UpdateFile))
                {
                    WriteLineLog("Найден файл "+UpdateFile);
                    try
                    {
                        Process[] updateProcesses = Process.GetProcessesByName(UpdateProcess);
                        if (updateProcesses.Length > 0)
                        {
                            for (int i = updateProcesses.Length - 1; i >= 0; i--){ updateProcesses[i].Kill(); }
                            Thread.Sleep(3000);
                            updateProcesses = Process.GetProcessesByName(UpdateProcess);
                            if (updateProcesses.Length > 0) throw new Exception("Process is still running");
                        }                        
                    }
                    catch (Exception e1) { WriteLineLog("Не удалось остановить процесс " + UpdateProcess + " "+ e1.Message);// textBox_Console.AppendText("Не удалось остановить процесс " + UpdateProcess + Environment.NewLine + e1.Message + Environment.NewLine);
                                                           Environment.Exit(0);                                                           }                   
                    try {
                        File.Delete(UpdateFile);
                        WriteLineLog("Удаление временного файла " + UpdateFile+" прошло успешно");
                    }
                    catch(Exception e1) { WriteLineLog("Не удалось удалить файл обновлений " + UpdateFile + " " + e1.Message );// textBox_Console.AppendText("Не удалось удалить файл обновлений " + UpdateFile  + Environment.NewLine +e1.Message+Environment.NewLine);
                                                          Environment.Exit(0);  }
                }
            }
            else if (String.Compare(UpdateProcess, RunningProcess, true) == 0) //Rurning *.update.exe
            {
                string exeFileName = workFolder + RunMODTitle + ".exe";
                try
                {
                    if (File.Exists(exeFileName))
                    {
                        WriteLineLog("Найден файл "+ exeFileName);
                        string oldexeFileNameVersion = exeFileVersion(RunMODTitle);
                        if (String.Compare(oldexeFileNameVersion, FileStarterVersion, true) == 0) { WriteLineLog("Версии файлов " + exeFileName+" и "+ UpdateFile+" одинаковые. Версия файлов "+oldexeFileNameVersion+". Обновление не требуется");Thread.Sleep(3000); Environment.Exit(0); }
                        WriteLineLog("Версии файлов " + exeFileName + " и " + UpdateFile + " разные. Требуется обновление");
                        
                        Process[] exeProcesses = Process.GetProcessesByName(RunMODTitle);
                        if (exeProcesses.Length > 0)
                        {
                            WriteLineLog("Завершение процесса "+ RunMODTitle);
                            for (int i = exeProcesses.Length - 1; i >= 0; i--) { exeProcesses[i].Kill(); }
                            Thread.Sleep(3000);
                            exeProcesses = Process.GetProcessesByName(RunMODTitle);
                            if (exeProcesses.Length > 0) throw new Exception("Process is still running");
                        }                        
                    }
                }
                catch (Exception e1) { WriteLineLog("Не удалось остановить процесс " + RunMODTitle + " " + e1.Message);// textBox_Console.AppendText("Не удалось остановить процесс " + RunMODTitle + Environment.NewLine + e1.Message + Environment.NewLine);
                    Thread.Sleep(3000); Environment.Exit(0); }
                try 
                {
                    File.Copy(UpdateFile, exeFileName, true);
                    WriteLineLog("Замена файла завершена успешно");
                }
                catch (Exception e1) { WriteLineLog("Не удалось удалить старую версию " + RunMODTitle + " "+  e1.Message);// textBox_Console.AppendText("Не удалось удалить старую версию " + RunMODTitle + Environment.NewLine + e1.Message + Environment.NewLine);
                    Thread.Sleep(3000); Environment.Exit(0); }
                WriteLineLog("Запуск новой версии"); 
                Process.Start(exeFileName);
                Environment.Exit(0);
            }
            else 
            {
                WriteLineLog("Запущенный процесс " + RunningProcess + ".exe не распознан");// textBox_Console.AppendText("Запущенный процесс " + RunningProcess + ".exe не распознан" + Environment.NewLine);
                textBox_Console.AppendText("Попробуйте перезапустить " + RunningProcess + Environment.NewLine);
                return;
            }            
            #endregion
            _syncContext = SynchronizationContext.Current;
            

            #region https://www.youtube.com/watch?v=9AIApJmbulY&t=196s
            
            threadStartReadConfig = new ThreadStart(readConfig);
            threadReadConfig = new Thread(threadStartReadConfig);
            threadReadConfig.Start();            
            #endregion            
        }                
        void readConfig()
        {
            string iniFile = workFolder + RunMODTitle + ".dat";//	iniFile = workFolder + iniFile;
            if (!File.Exists(iniFile)) 
            {
                WriteLineLog("Файл конфигурации " + iniFile + " не найден. Обновление невозможно.");//                this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Файл конфигурации " + iniFile + " не найден. Обновление невозможно." + Environment.NewLine);
                return;
            }
            WriteLineLog("Чтение файла конфигурации " + iniFile );// this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Чтение файла конфигурации " + iniFile + Environment.NewLine);
            using (StreamReader sClientINI = new StreamReader(iniFile))
            {
                bool needUpdate = true;
                string INIline;
                int StartLogLine = 0;
                List<ConfigLine> ClientconfigLine = new List<ConfigLine>();
                //Make ClientconfigLine array
                while ((INIline = sClientINI.ReadLine()) != null)
                {
                    StartLogLine++;
                    INIline = INIline.Trim();
                    if (INIline.Length == 0) continue;
                    if (INIline.StartsWith("#")) continue;
                    ClientconfigLine.Add(new ConfigLine(INIline));

                    if (ClientconfigLine.Last().Command == ConfigLineCommand.FolderSourceUpdate) { updateFolder = ClientconfigLine.Last().File; }
                    else if (ClientconfigLine.Last().Command == ConfigLineCommand.UNKNOWN)
                    {
                        WriteLineLog("Ошибка! Нераспознанная команда: " + INIline);// this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Ошибка! Нераспознанная команда: " + INIline + Environment.NewLine);
                        ClientconfigLine.Remove(ClientconfigLine.Last());
                    }
                }
                if (updateFolder == null)
                {
                    this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Файла конфигурации не содержить ссылку на папку обновлений" + Environment.NewLine);
                    return;
                }
                if (!updateFolder.EndsWith("\\")) updateFolder += "\\";
                //updateFolder += "update\\";
                if (!Directory.Exists(updateFolder))
                {
                    this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Указанная папка обновлений не найдена " + updateFolder + Environment.NewLine);
                    return;
                }
                #region Check for update STARTER
                WriteLineLog("Папка обновлений " + updateFolder);//this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Папка обновлений " + updateFolder + Environment.NewLine);
                try
                {
                    string newFileStarter = updateFolder + RunMODTitle + ".exe";

                    if (File.Exists(newFileStarter))
                    {
                        String newFileStarterVersion = exeFileVersion(newFileStarter);
                        if (String.Compare(newFileStarterVersion, FileStarterVersion, true) != 0)
                        {
                            WriteLineLog("Обновление стартера версии " + FileStarterVersion + " до версии " + newFileStarterVersion);// this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Обновление стартера версии " + FileStarterVersion + " до версии " + newFileStarterVersion);
                            //TODO:Try
                            File.Copy(newFileStarter, workFolder + RunMODTitle + ".update.exe", true);
                            WriteLineLog("Скопирована новая версия стартера. Запуск .update.exe");// this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Обновление стартера версии " + FileStarterVersion + " до версии " + newFileStarterVersion);
                            Process.Start(workFolder + RunMODTitle + ".update.exe");
                            //Application.Exit();
                            //Process.GetCurrentProcess().Kill();
                            Environment.Exit(0);
                            //System.Environment.Exit(0);
                        }
                    }

                }
                catch (Exception e) { }
                #endregion
                
                string updateFile = updateFolder + "update.ini";
                if (!File.Exists(updateFile))
                {
                    this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Файл обновлений не найден " + updateFile + Environment.NewLine);
                    return;
                }
                WriteLineLog("Чтение файла обновлений " + updateFile );//                this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Чтение файла обновлений " + updateFile + Environment.NewLine);
                using (StreamReader sServerINI = new StreamReader(updateFile))
                {
                    List<ConfigLine> ServerconfigLine = new List<ConfigLine>();
                    string UPDATEline;                    
                    //TODO:Если на сервере изменилась ссылка на папку, то необходимо заново перечитать новую папку
                    while ((UPDATEline = sServerINI.ReadLine()) != null)
                    {
                        UPDATEline = UPDATEline.TrimStart();
                        if (UPDATEline.StartsWith("#")) continue;// skip comment
                        if (UPDATEline.Length == 0) continue; // skip empty line
                        {
                            ServerconfigLine.Add(new ConfigLine(UPDATEline, 1));
                            if (ServerconfigLine.Last().Command == ConfigLineCommand.UNKNOWN)
                            {
                                this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Ошибка! Команда нераспознана: " + UPDATEline + Environment.NewLine);
                                ServerconfigLine.Remove(ServerconfigLine.Last());
                                continue;
                            }
                            //#if DEBUG
                            //                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, UPDATEline + Environment.NewLine);
                            //#endif
                            WriteBeginLineLog(ServerconfigLine.Last().File);//                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, ServerconfigLine.Last().File); 
                            int ClientLineIndex = ClientconfigLine.FindIndex(clcfg => clcfg.File.Equals(ServerconfigLine.Last().File));
                            needUpdate = true;
                            if (ClientLineIndex != -1)
                            {
                                WriteLog(" " + ClientconfigLine[ClientLineIndex].Version);//                                this.textBox_Console.BeginInvoke(delegateConsoleWrite, " "+ClientconfigLine[ClientLineIndex].Version);                                
                                if (String.Compare(ClientconfigLine[ClientLineIndex].Version,ServerconfigLine.Last().Version, true) == 0)
                                    needUpdate = false;
                            }
                            if (!needUpdate) { WriteLog(" = " + ServerconfigLine.Last().Version + Environment.NewLine);// this.textBox_Console.BeginInvoke(delegateConsoleWrite, " = " + ServerconfigLine.Last().Version + Environment.NewLine);
                                                           }
                            else
                            {
                                WriteLog(" update to " + ServerconfigLine.Last().Version + Environment.NewLine);// this.textBox_Console.BeginInvoke(delegateConsoleWrite, " update to " + ServerconfigLine.Last().Version + Environment.NewLine);
                                if (ServerconfigLine.Last().Command == ConfigLineCommand.UNZIP)     needUpdate = UNZIP(ServerconfigLine.Last().File);
                                else if (ServerconfigLine.Last().Command == ConfigLineCommand.REG)  needUpdate = REGimport(ServerconfigLine.Last().File);                                
                                else needUpdate = false;
                                if (needUpdate)
                                {
                                    if (ClientLineIndex == -1)ClientconfigLine.Add(ServerconfigLine.Last());       
                                    else ClientconfigLine[ClientLineIndex].Date = String.Empty;
                                }                                
                            }
                        }
                    }
                    sServerINI.Close();
                    sClientINI.Close();
                    //int i = 1;
                    needUpdate = false;
                    foreach (ConfigLine l in ClientconfigLine)
                    {                        
                        //this.textBox_Console.BeginInvoke(delegateConsoleWrite,i+". "+ l.Date+" "+l.Command+" "+l.File+" "+l.Version + Environment.NewLine);
                        if (String.IsNullOrEmpty(l.Date))
                        {
                            //this.textBox_Console.BeginInvoke(delegateConsoleWrite, "update ^" + Environment.NewLine);
                            needUpdate = true;
                            l.Date = DateTime.Now.ToString("ddMMyyyy-HHmmss");
                        }                        
                        //i++;
                    }                   
                    if (needUpdate)
                    {
                        INIline = "";
                        foreach (ConfigLine l in ClientconfigLine) INIline += l.Date + "\t" +l.Command+"\t"+l.Version+"\t"+l.File//+"\t"+l.Parameters.ToString()
                                                                                                                                 + Environment.NewLine;
                        #if DEBUG
                        this.textBox_Console.BeginInvoke(delegateConsoleWrite, INIline);
                        #endif
                        using (StreamWriter swClientINI = new StreamWriter(iniFile, false))                        
                            swClientINI.Write(INIline);                                                
                    }
                }
            }
            WriteLineLog("Запуск " + RunMOD + Environment.NewLine);//            this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Запуск " + RunMOD + Environment.NewLine);
#if !DEBUG
            LoadRevEmu();
            System.Threading.Thread.Sleep(5000);
            Environment.Exit(0);
#endif
        }
        private void LoadRevEmu()        {        }
        private void CFG(string cmdFile, string Param, string Value)        {            this.textBox_Console.BeginInvoke(delegateConsoleWrite,"Конфигурация" + cmdFile + " " + Param + " " + Value + Environment.NewLine);        }    
        private bool REGimport(string regFile)
        {
            bool result = false;
            int RUN_return = RUN("REG.EXE", "IMPORT \""+ updateFolder+regFile+ "\"");
            if (RUN_return == 0) { result = true;}            
            return (result);
        }
        private void SYNC(string cmdFolder)        {                       textBox_Console.AppendText("Синхронизация" + cmdFolder + Environment.NewLine);        }
        private int RUN(string FileName, string Arguments)
        {
#if DEBUG
            this.textBox_Console.BeginInvoke(delegateConsoleWrite, FileName + " "+ Arguments + Environment.NewLine);
#endif
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
                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, OEM866_to_Win1251(so.ToString().Substring(BufLine)));
                            BufLine = so.Length;
                        }
                    }
                    if (so.Length > BufLine) this.textBox_Console.BeginInvoke(delegateConsoleWrite, so.ToString().Substring(BufLine));
                    RUN_return = myProcess.ExitCode;
                    myProcess.Dispose();
                }
            }
            catch (Exception e)
            {
                {
                    RUN_return = -1;
                    this.textBox_Console.BeginInvoke(delegateConsoleWrite, e.Message + Environment.NewLine);
                }
            }
            return (RUN_return);
        }
        private bool UNZIP(string Source)
        {

            bool result = false;
            //TODO:Use local winrar
            //UNZIPer = Environment.GetEnvironmentVariable("ProgramFiles") + "\\WinRAR\\Rar.exe";
            //    if (!File.Exists(UNZIPer))
            //    {
            //        UNZIPer = Environment.GetEnvironmentVariable("ProgramFiles(x86)") + "\\WinRAR\\Rar.exe";
            //        if (!File.Exists(UNZIPer))
            //        {
            //            UNZIPer = updateFolder + "UnRAR.exe";
            //            if (!File.Exists(UNZIPer)) { textBox_Console.AppendText(" Не найден распаковщик " + UNZIPer); return (false); }
            //        }
            //    }
#if DEBUG
            this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Begin unzip file "+ Source+" to "+ workFolder+ Environment.NewLine);
#endif
            this.textBox_Console.BeginInvoke(delegateConsoleWrite,"Распаковка " + Source+".");            
            int RUN_return = RUN(updateFolder+ProgUNZIP, "x -y -o+ -sca -idcd  \"" + updateFolder+Source + "\" \"" + workFolder + "\"");
            if (RUN_return == 0) { result = true; this.textBox_Console.BeginInvoke(delegateConsoleWrite, "OK" + Environment.NewLine); }
            else if (RUN_return == -1) { this.textBox_Console.BeginInvoke(delegateConsoleWrite, " Ошибка при запуске распаковщика" + Environment.NewLine); }
            else if (RUN_return > 0) this.textBox_Console.BeginInvoke(delegateConsoleWrite, " Распаковщик завершил работу с кодом " + RUN_return + Environment.NewLine);
            this.textBox_Console.BeginInvoke(delegateConsoleWrite, Environment.NewLine+ Environment.NewLine);
            return result;
        }

        private void label8_MouseEnter(object sender, EventArgs e)        {            label8.ForeColor = System.Drawing.Color.Yellow;        }

        private void label8_MouseLeave(object sender, EventArgs e)        {            label8.ForeColor = System.Drawing.Color.White;        }
        public string OEM866_to_Win1251(string line)
        {            
            Encoding w1251 = Encoding.GetEncoding("Windows-1251");            
            Encoding cp866 = Encoding.GetEncoding("cp866");
            return  cp866.GetString(w1251.GetBytes(line));
        }
        string exeFileVersion(string File) {
            string result = String.Empty;
            try
            {
                result = System.Diagnostics.FileVersionInfo.GetVersionInfo(File).FileVersion;
            }
            catch { }
            return result;
        }
        void WriteLog(string Text) 
        {
        this.textBox_Console.BeginInvoke(delegateConsoleWrite, Text);
        try
        {
            File.AppendAllText(logFile, Text);
        }
        catch { }
        }
        void WriteLineLog(string Text)
        {
            this.textBox_Console.BeginInvoke(delegateConsoleWrite, Text + Environment.NewLine);
            File.AppendAllText(logFile,DateTime.Now.ToString("dd.MM.yyyy-HH:mm:ss") + " " + Text + Environment.NewLine);
        }
        void WriteBeginLineLog(string Text)
        {
            this.textBox_Console.BeginInvoke(delegateConsoleWrite, Text);
            File.AppendAllText(logFile, DateTime.Now.ToString("dd.MM.yyyy-HH:mm:ss") + " " + Text );
        }

    }
}
    
