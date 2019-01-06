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
		
		void Button2Click(object sender, EventArgs e)
		{
			this.textBox_Console.AppendText(numOutputLines.ToString());
			this.textBox_Console.Refresh();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			if (cmd.StandardOutput!=null)
			{
			String result;
		 	result = this.cmd.StandardOutput.ToString();
			this.textBox_Console.AppendText(result);
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			textBox_TargetFolderParent=radioButton_Disk_C.Text+"\\";
			textBox_TargetFolder.Text=textBox_TargetFolderParent;
			string[] fileArray = Directory.GetDirectories(textBox_TargetFolderParent);
           for (int i = 0; i < fileArray.Length; i++)
           {
           	//listBox_Folders.Items.Add(fileArray[i]+Environment.NewLine);
           	listBox_Folders.Items.Add(fileArray[i]);
           	
            	
           }
			
			
		}
		void ListBox_FoldersDoubleClick(object sender, EventArgs e)
		{
			textBox_TargetFolder.Text=textBox_TargetFolderParent+listBox_Folders.SelectedItem;
		}
	}
}
