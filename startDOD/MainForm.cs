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
//using System.IO;
//using System.Net;
using System.Threading;
//using System.Reflection;
using System.Text;

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
		void Button1Click(object sender, EventArgs e)
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
		void button_installClick(object sender, EventArgs e)
		{
			button_install2.Enabled=false;
			textBox_Console.AppendText("Start thread\r\n");
			cmd = new Process();
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.RedirectStandardError = true;
			cmd.StartInfo.CreateNoWindow = true;
			//cmd.StartInfo.WorkingDirectory=srcds_folder;			
			//"C:\Program Files\7-Zip\7z.exe" a -bb1 -uz2 E:\tmp\test-startDOD "D:\Program Files (x86)\Steam\steamapps\common\Day of Defeat Source\dod"
			cmd.StartInfo.FileName = @"C:\Program Files\7-Zip\7z.exe";			
			cmd.StartInfo.UseShellExecute=false;	//https://msdn.microsoft.com/ru-ru/library/system.diagnostics.processstartinfo.workingdirectory(v=vs.110).aspx			
			cmd.StartInfo.Arguments=@"a -bb1 -uz2 E:\tmp\test-startDOD";
			cmd.StartInfo.Arguments+=@" ""D:\Program Files (x86)\Steam\steamapps\common\Day of Defeat Source\dod""";
			cmd.StartInfo.Arguments+=@" 2>&1";
			//cmd.StartInfo.Arguments+=@"\materials""";
			cmd.StartInfo.UseShellExecute = false;
			cmd.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
			cmd.ErrorDataReceived  += new DataReceivedEventHandler(OutputHandler);
			
			thread = new Thread(this.RunCMD);
			thread.Name="RunCMD";			
			AppendText= new delegateAppendText(this.textBox_Console.AppendText);
			thread.Start();			
			textBox_Console.AppendText("Finish method\r\n");
			
		}
		 private  void RunCMD()
		 	// создание трита внутри формы https://docs.microsoft.com/ru-ru/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls
		{			
			
		 	//origin  this.Invoke(AppendText, new object[] { "sadf" });
		 	this.Invoke(AppendText,"Start cmd\r\n");		 	
		 	cmd.Start();
		 	cmd.BeginOutputReadLine();			
			cmd.WaitForExit();
			this.Invoke(AppendText,"finish cmd\r\n");
			
			
			//cmd.StartInfo.RedirectStandardOutput = false;			
			//this.button_install.Enabled=true;
			//cmd.Dispose();
			cmd=null;
		}
		private  async void OutputHandler(object sendingProcess, 
            DataReceivedEventArgs outLine)
        {
            numOutputLines++;
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
		
		void Button2Click(object sender, EventArgs e)
		{
			this.textBox_Console.AppendText(numOutputLines.ToString());
			//this.textBox_Console.Refresh();
		} 
	}
}
