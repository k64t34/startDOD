/*
 * Created by SharpDevelop.
 * User: Andrew
 * Date: 05.01.2019
 * Time: 19:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//using System.Collections.Generic;
//using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//using System.Net;
using System.Threading;
//using System.Reflection;
using System.Text;
using System.Drawing;

namespace startDOD
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>	
	public partial class MainForm : Form
	{
		
		private Process cmd = null;		
		private Thread thread = null;		
		delegate  void delegateAppendText (string text);
		delegateAppendText AppendText;
		int numOutputLines=0;
		string textBox_TargetFolderParent;
		
		//AppDomain.CurrentDomain.BaseDirectory;			
		//Application.ExecutablePath;
		//Assembly.GetExecutingAssembly().Location;
		//Application.StartupPath;
		string workFolder=AppDomain.CurrentDomain.BaseDirectory;
		const string RunMOD="День Победы";
		const string revLoader="revLoader.exe";
		public MainForm()
		{			
		
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//		
		}
		
		void RunInstall()
		{
			
			textBox_Console.AppendText("Start thread\r\n");
			cmd = new Process();
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.RedirectStandardError = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute=false;	//https://msdn.microsoft.com/ru-ru/library/system.diagnostics.processstartinfo.workingdirectory(v=vs.110).aspx			
			//cmd.StartInfo.WorkingDirectory=srcds_folder;			
			//"C:\Program Files\7-Zip\7z.exe" a -bb1 -uz2 E:\tmp\test-startDOD "D:\Program Files (x86)\Steam\steamapps\common\Day of Defeat Source\dod"
			
			cmd.StartInfo.FileName = @"C:\Program Files\7-Zip\7z.exe";
			cmd.StartInfo.Arguments=@"a -bb1 -uz2 E:\tmp\test-startDOD";
			cmd.StartInfo.Arguments+=@" ""D:\Program Files (x86)\Steam\steamapps\common\Day of Defeat Source\dod""";
			//cmd.StartInfo.Arguments+=@" 2>&1";
			//cmd.StartInfo.Arguments+=@"\materials""";
			
			cmd.StartInfo.FileName = @"ping.exe";
			cmd.StartInfo.Arguments=@"-n 100 8.8.8.8";
			
			cmd.StartInfo.FileName = @"C:\Program Files\WinRAR\Rar.exe";
			cmd.StartInfo.Arguments=@"a E:\tmp\test-startDOD";
			cmd.StartInfo.Arguments+=@" ""D:\Program Files (x86)\Steam\steamapps\common\Day of Defeat Source\dod""";
			
			 
			
			
			cmd.StartInfo.UseShellExecute = false;
			cmd.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
			cmd.ErrorDataReceived  += new DataReceivedEventHandler(OutputHandler);
			
			thread = new Thread(this.RunCMD);
			thread.Name="RunCMD";			
			AppendText= new delegateAppendText(this.textBox_Console.AppendText);
			thread.Start();			
			textBox_Console.AppendText("Finish method\r\n");
			//timer1.Start();
			
		}
		 private  void RunCMD()
		 	// создание трита внутри формы https://docs.microsoft.com/ru-ru/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls
		{			
			
		 	//origin  this.Invoke(AppendText, new object[] { "sadf" });
		 	this.Invoke(AppendText,"Start cmd\r\n");		 	
		 	cmd.Start();
		 	cmd.BeginOutputReadLine();	
			cmd.BeginErrorReadLine();		 	
			cmd.WaitForExit();
			this.Invoke(AppendText,"finish cmd\r\n");
			
			
			//this.button_install.Enabled=true;
			//cmd.Dispose();
			cmd=null;
			//timer1.Stop();
		}
		void OutputHandler(object sendingProcess, 
            DataReceivedEventArgs outLine)
        {
            numOutputLines++;
            //this.Invoke(AppendText,Environment.NewLine +numOutputLines.ToString());
		 	// Collect the sort command output.
		 	//String result;
		 	//result = await cmd.StandardOutput.ReadLineAsync();		 	
            if (!String.IsNullOrEmpty(outLine.Data))
            	{
            	//StringBuilder sortOutput = new StringBuilder("");
            	//sortOutput.Append(outLine.Data);
            	//this.Invoke(AppendText,sortOutput.ToString());
            	this.Invoke(AppendText,Environment.NewLine +outLine.Data.ToString());
            /*// Add the text to the collected output.
                sortOutput.Append(Environment.NewLine + 
                    "[" + numOutputLines.ToString() + "] - " + outLine.Data);*/
            }
        }	
		
		void Label8Click(object sender, EventArgs e)
		{
			this.Hide();
			if (thread != null)
			{
				if (cmd !=null) //if (cmd.StartInfo.RedirectStandardOutput)//if (!cmd.HasExited)
				{
				try
					{
						cmd.Kill();
					}
					finally{}
				}
				
				thread.Abort();
			}
			this.Close();
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			panel_Console.BackColor=Color.FromArgb(200, 128, 128, 128);		
			string iniFile=workFolder+RunMOD+".ini";
			if (File.Exists(iniFile))
			{		
				Process emu = new Process();
				emu.StartInfo.WorkingDirectory=workFolder;			
				emu.StartInfo.FileName = emu.StartInfo.WorkingDirectory + revLoader;				
				try 
					{					
				     emu.Start();
	            	}        	
	        	catch 
	        		{;
		        	}
			}
		}
		
		
	}
}
