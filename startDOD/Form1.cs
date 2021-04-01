using System;
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
        #region      
        //https://www.youtube.com/watch?v=9AIApJmbulY&t=196s
        public delegate void DelegateConsoleWrite(string Text);
        ThreadStart threadStartReadConfig;
        Thread threadReadConfig;
        DelegateConsoleWrite delegateConsoleWrite;
        #endregion
        #region Global vars & consts
        //const string _CR = "\r";
        //const string _CRLF = "\r\n";
        const string _TAB = "\t";
        string workFolder = AppDomain.CurrentDomain.BaseDirectory;
        string updateFolder;
        const string RunMOD = "dod";
        const string RunMODTitle = "День Победы";
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
            label_CE.Text += " " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
            _syncContext = SynchronizationContext.Current;
            textBox_Console.AppendText("Рабочая папка " + workFolder + Environment.NewLine);

            #region https://www.youtube.com/watch?v=9AIApJmbulY&t=196s
            delegateConsoleWrite = new DelegateConsoleWrite(ConsoleWrite);
            threadStartReadConfig = new ThreadStart(readConfig);
            threadReadConfig = new Thread(threadStartReadConfig);
            threadReadConfig.Start();            
            #endregion            
        }

        //static void ConsoleWrite(string message)
        //{
        //    if (THIS.textBox_Console.InvokeRequired)
        //    {
        //        THIS.textBox_Console.BeginInvoke(new Action<string>((s) => {
        //            THIS.textBox_Console.AppendText(message);                    
        //        }), message);

        //    }
        //    else
        //    {
        //        THIS.textBox_Console.AppendText(message);                
        //    }
        //}
        void readConfig()
        {
            //await Task.Run(() =>            {
                string iniFile = workFolder + RunMODTitle + ".log";//	iniFile = workFolder + iniFile;
            if (!File.Exists(iniFile)) this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Файл конфигурации " + iniFile + " не найден. Обновление невозможно." + Environment.NewLine);
                else
                {
                this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Чтение файла конфигурации " + iniFile + Environment.NewLine);
                    using (StreamReader sINI = new StreamReader(iniFile))
                    {
                        string INIline;
                        int StartLogLine = 0;
                        List<ConfigLine> ClientconfigLine = new List<ConfigLine>();
                                //Make ClientconfigLine array
                                while ((INIline = sINI.ReadLine()) != null)
                        {
                            StartLogLine++;
                            INIline = INIline.Trim();
                            if (INIline.Length == 0) continue;
                            if (INIline.StartsWith("#")) continue;
                            ClientconfigLine.Add(new ConfigLine(INIline));

                            if (ClientconfigLine.Last().Command == ConfigLineCommand.FolderSourceUpdate) { updateFolder = ClientconfigLine.Last().File; }
                            else if (ClientconfigLine.Last().Command == ConfigLineCommand.UNKNOWN)
                            {
                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Ошибка! Нераспознанная команда: " + INIline + Environment.NewLine);
                                ClientconfigLine.Remove(ClientconfigLine.Last());
                            }
                        }
                        if (updateFolder == null) textBox_Console.AppendText("Файла конфигурации не содержить ссылку на папку обновлений" + Environment.NewLine);
                        else
                        {
                            if (!updateFolder.EndsWith("\\")) updateFolder += "\\";
                            //updateFolder += "update\\";
                            if (!Directory.Exists(updateFolder)) this.textBox_Console.BeginInvoke(delegateConsoleWrite,"Указанная папка обновлений не найдена " + updateFolder + Environment.NewLine);
                            else
                            {
                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Папка обновлений " + updateFolder + Environment.NewLine);
                            string updateFile = updateFolder + "update.ini";
                                if (!File.Exists(updateFile)) this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Файл обновлений не найден " + updateFile + Environment.NewLine);
                                else
                                {
                                this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Чтение файла обновлений " + updateFile + Environment.NewLine);
                                    using (StreamReader sUPDATE = new StreamReader(updateFile))
                                    {
                                        List<ConfigLine> ServerconfigLine = new List<ConfigLine>();
                                        string UPDATEline;
                                        string[] UpdateLineWords;
                                        string[] INILineWords;
                                                //StreamWriter swINI = File.AppendText(iniFile);
                                                //swINI.WriteLine();
                                                //System.Environment.SetEnvironmentVariable("FolderInstall", workFolder, EnvironmentVariableTarget.User);
                                                //TODO:Если на сервере изменилась ссылка на папку, то необходимо заново перечитать новую папку
                                                while ((UPDATEline = sUPDATE.ReadLine()) != null)
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
#if DEBUG
                                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, UPDATEline + Environment.NewLine);
#endif
                                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, ServerconfigLine.Last().File);
                                                bool needUpdate = true;
                                                if (!ClientconfigLine.Exists(x => x.File.Contains(ServerconfigLine.Last().File))) needUpdate = true;
                                                else { needUpdate = false; }
                                                        //check this update in client INI file

                                                        //int LogLineCounter = 0;
                                                        //bool needUpdate = true;
                                                        //while ((INIline = sINI.ReadLine()) != null)
                                                        //{
                                                        //    LogLineCounter++;
                                                        //    if (LogLineCounter < StartLogLine) continue;                                                
                                                        //    INIline = INIline.Trim();
                                                        //    if (INIline.Length == 0) continue;
                                                        //    if (INIline.StartsWith("#")) continue;
                                                        //    INIline = INIline.TrimEnd();
                                                        //    INILineWords = INIline.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries);
                                                        //    if (INILineWords[0] == UpdateLineWords[0])
                                                        //    {
                                                        //        if (INILineWords.Length>=2)
                                                        //        {                                                        
                                                        //            if (INILineWords[1] == UpdateLineWords[1])
                                                        //                needUpdate = false;
                                                        //         }                                                        
                                                        //    }       
                                                        //}
                                                        if (!needUpdate) { this.textBox_Console.BeginInvoke(delegateConsoleWrite, " = " + ServerconfigLine.Last().Version + Environment.NewLine); }
                                                else
                                                {
                                                this.textBox_Console.BeginInvoke(delegateConsoleWrite, " update to " + ServerconfigLine.Last().Version + Environment.NewLine);
                                                    if (ServerconfigLine.Last().Command == ConfigLineCommand.UNZIP)
                                                    {
                                                        if (UNZIP(ServerconfigLine.Last().File))
                                                        {
                                                        ClientconfigLine
                                                        }

                                                    }

                                                            //    UpdateLineWords[2] = UpdateLineWords[2].ToUpper();
                                                            //    textBox_Console.AppendText(" updating... " + UpdateLineWords[2] +" " );
                                                            //    if (String.Equals(UpdateLineWords[2], "UNZIP"))
                                                            //    {
                                                            //        if (UpdateLineWords.Length < 4)
                                                            //            textBox_Console.AppendText(" Файл архива не указан" + Environment.NewLine);
                                                            //        else
                                                            //        if (UNZIP(UpdateLineWords[3]))
                                                            //        {
                                                            //            textBox_Console.AppendText(" OK" + Environment.NewLine);
                                                            //            //TODO: Записать в MOD.ini успех обновления
                                                            //            //https://docs.microsoft.com/ru-ru/dotnet/api/system.io.filestream?view=netframework-4.8
                                                            //            //sINI.Close();
                                                            //            //StreamWriter swINI = File.AppendText(iniFile);
                                                            //            //swINI.WriteLine(UpdateLineWords[0]+" "+ UpdateLineWords[1]);
                                                            //            //swINI.Close();
                                                            //            //sINI.open(iniFile);
                                                            //        }
                                                            //        else { textBox_Console.AppendText(" Ошибка" + Environment.NewLine); }
                                                            //    }
                                                            //    else if (String.Equals(UpdateLineWords[2], "REG"))
                                                            //    {
                                                            //        if (UpdateLineWords.Length < 4)
                                                            //            textBox_Console.AppendText(" Файл реестра не указан" + Environment.NewLine);
                                                            //        else
                                                            //        if (REGimport(UpdateLineWords[3]))
                                                            //        {
                                                            //            textBox_Console.AppendText(" OK" + Environment.NewLine);
                                                            //            //TODO: Записать в MOD.ini успех обновления
                                                            //        }
                                                            //    }
                                                            //    else
                                                            //        textBox_Console.AppendText(" Invalid command." + Environment.NewLine);
                                                        }
                                            }
                                        }
                                        sINI.Close();
                                    }
                                }
                            }
                        }
                    }
                this.textBox_Console.BeginInvoke(delegateConsoleWrite, "Запуск " + RunMOD + Environment.NewLine);
#if !DEBUG
                        LoadRevEmu();
                        System.Threading.Thread.Sleep(5000);
                        this.Close();
#endif
                        }
            //});

        }
        private void LoadRevEmu()
        {
        }
        private void CFG(string cmdFile, string Param, string Value)
        {
            textBox_Console.AppendText("Конфигурация" + cmdFile + " " + Param + " " + Value + Environment.NewLine);
        }
        //private bool UNZIP(string cmdFile)
        //{
        //    bool UNZIP_return = true;
        //    textBox_Console.AppendText("Распаковка " + cmdFile);
        //    cmdFile = updateFolder + cmdFile;
        //    if (!File.Exists(cmdFile)) { textBox_Console.AppendText(" Архив " + cmdFile + " не найден "); return (false); }
        //    string UNZIPer;
        //    UNZIPer = Environment.GetEnvironmentVariable("ProgramFiles") + "\\WinRAR\\Rar.exe";
        //    if (!File.Exists(UNZIPer))
        //    {
        //        UNZIPer = Environment.GetEnvironmentVariable("ProgramFiles(x86)") + "\\WinRAR\\Rar.exe";
        //        if (!File.Exists(UNZIPer))
        //        {
        //            UNZIPer = updateFolder + "UnRAR.exe";
        //            if (!File.Exists(UNZIPer)) { textBox_Console.AppendText(" Не найден распаковщик " + UNZIPer); return (false); }
        //        }
        //    }
        //    int RUN_return = RUN(UNZIPer, "x -y -o+ -sca -idcd  \"" + cmdFile + "\" \"" + workFolder + "\"");
        //    if (RUN_return == -1) { textBox_Console.AppendText(" Ошибка при запуске распаковщика"); UNZIP_return = false; }
        //    else if (RUN_return > 0) textBox_Console.AppendText(" Распаковщик завершил работу с кодом " + RUN_return + Environment.NewLine);
        //    return (UNZIP_return);
        //}
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
                            this.textBox_Console.BeginInvoke(delegateConsoleWrite, so.ToString().Substring(BufLine));
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
    }
}
