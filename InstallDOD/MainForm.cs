/*
 * Created by SharpDevelop.
 * User: Andrew
 * Date: 07.01.2019
 * Time: 13:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace InstallDOD
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	
	public partial class MainForm : Form
	{
		const string RunDOD="День Победы.exe";
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
			this.Close();
		}
		void Label8Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void Label8MouseLeave(object sender, EventArgs e)
		{		
			label8.ForeColor=System.Drawing.Color.White;
		}
		
		void Label8MouseEnter(object sender, EventArgs e)
		{
			label8.ForeColor=System.Drawing.Color.Yellow;
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			panel_Folder.BackColor=Color.FromArgb(200, 128, 128, 128);			
			comboBox_Disks.Items.Clear();
			DriveInfo[] allDrives = DriveInfo.GetDrives();//https://docs.microsoft.com/ru-ru/dotnet/api/system.io.driveinfo.getdrives?view=netframework-4.7.2
			foreach (DriveInfo d in allDrives)
			{
				if (d.DriveType==DriveType.Fixed || d.DriveType==DriveType.Removable )
				comboBox_Disks.Items.Add(d.Name);
			}			
			comboBox_Disks.SelectedIndex=0;
		}
		void ComboBox_DisksSelectedIndexChanged(object sender, EventArgs e)
		{
			textBox_TargetFolder.Text=comboBox_Disks.Items[comboBox_Disks.SelectedIndex].ToString();
			listBox_FoldersDirectoryInfo();			
		}
		void listBox_FoldersDirectoryInfo()
		{
			listBox_Folders.Items.Clear();
			string[] fileArray = Directory.GetDirectories(textBox_TargetFolder.Text);
			DirectoryInfo dir;
			foreach (string f in fileArray)
			{
				dir = new DirectoryInfo(f);
				if (dir.Attributes.HasFlag(FileAttributes.Hidden)) continue;
				if (dir.Attributes.HasFlag(FileAttributes.System)) continue;
				if (dir.Attributes.HasFlag(FileAttributes.ReadOnly)) continue;
				if (dir.Name[0]=='$') continue;
				listBox_Folders.Items.Add(dir.Name);
			}
		}
			
		void ListBox_FoldersSelectedIndexChanged(object sender, EventArgs e)
		{	
			textBox_TargetFolder.Text+=listBox_Folders.Items[listBox_Folders.SelectedIndex].ToString()+@"\";			 
			listBox_FoldersDirectoryInfo();
		}
		void Button_FolderUpClick(object sender, EventArgs e)
		{
			if (textBox_TargetFolder.Text.Length>3)
			{
				
				textBox_TargetFolder.Text=System.IO.Directory.GetParent(textBox_TargetFolder.Text.Remove(textBox_TargetFolder.Text.Length-1)).FullName;				
				if (textBox_TargetFolder.Text.Length>3)
					textBox_TargetFolder.Text+=@"\";					
				listBox_FoldersDirectoryInfo();
			}
		}
		void Button_newFolderClick(object sender, EventArgs e)
		{
			newFolder form_newFolder = new newFolder();			
			if (form_newFolder.ShowDialog(this) == DialogResult.OK)
			{
				string newFolder = textBox_TargetFolder.Text + form_newFolder.StrNewFolder;
				form_newFolder.Dispose();				
				if(!Directory.Exists(newFolder)) 
				{
					try 
					{
						Directory.CreateDirectory(newFolder);
					}
					catch (Exception  ex)
					{
					
						//if(!Directory.Exists(newFolder))
						MessageBox.Show(/*"Не удалось создать папку "+Environment.NewLine+newFolder+Environment.NewLine+*/ex.Message.ToString(),
						                "Ошибка при создании папки",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}
				}
				if(Directory.Exists(newFolder))
				{
					textBox_TargetFolder.Text=newFolder;
					listBox_FoldersDirectoryInfo();
				}
			}
			
			
		}
		void Button_folder_OKClick(object sender, EventArgs e)
		{
			try 
			{
			//AppDomain.CurrentDomain.BaseDirectory;			
			//Application.ExecutablePath;
			//Assembly.GetExecutingAssembly().Location;
			//Application.StartupPath;

				File.Copy(AppDomain.CurrentDomain.BaseDirectory+RunDOD, textBox_TargetFolder.Text+RunDOD, true);
				try
	            {
	                using (Process myProcess = new Process())
	                {
	                    myProcess.StartInfo.UseShellExecute = false;	                    
	                    myProcess.StartInfo.FileName = RunDOD;	
	                    myProcess.StartInfo.WorkingDirectory = textBox_TargetFolder.Text;
	                    myProcess.Start();
	                }
	            }
	            catch (Exception ex)
	            {
	                MessageBox.Show(/*"Не удалось создать папку "+Environment.NewLine+newFolder+Environment.NewLine+*/ex.Message.ToString(),
				                "Ошибка при запуске установщика",MessageBoxButtons.OK,MessageBoxIcon.Error);
	            }
			}
			catch (Exception  ex)
			{
				
				MessageBox.Show(/*"Не удалось создать папку "+Environment.NewLine+newFolder+Environment.NewLine+*/ex.Message.ToString(),
				                "Ошибка при копировании",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		this.Close();
		}
		
		
	}
}
