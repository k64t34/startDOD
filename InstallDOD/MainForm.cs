using System;
//using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
//using System.Runtime.InteropServices;
using IWshRuntimeLibrary; //TODO:Избавиться от использования Dll из WSH для создания ярлыка http://csharpcoding.org/sozdanie-yarlyka/#more-192
using System.Reflection;
using System.Security.Permissions;

namespace InstallDOD
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	
	public partial class MainForm : Form
	{
		const string Mod="День Победы";
        //AppDomain.CurrentDomain.BaseDirectory;			
        //Application.ExecutablePath;
        //Assembly.GetExecutingAssembly().Location;
        //Application.StartupPath;
        string ScriptFolder = AppDomain.CurrentDomain.BaseDirectory;
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
            panel_Folder.Visible = false;            
            System.Threading.Thread.Sleep(1000);
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
			label_CE.Text += " "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();

			/*TODO: Устранить мерцание
             * http://qaru.site/questions/108054/how-to-stop-flickering-c-winforms
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);*/
			panel_Folder.BackColor=Color.FromArgb(200, 128, 128, 128);			
			comboBox_Disks.Items.Clear();
			DriveInfo[] allDrives = DriveInfo.GetDrives();//https://docs.microsoft.com/ru-ru/dotnet/api/system.io.driveinfo.getdrives?view=netframework-4.7.2
			foreach (DriveInfo d in allDrives)
			{
				if (d.DriveType==DriveType.Fixed || d.DriveType==DriveType.Removable )				
					comboBox_Disks.Items.Add(d.Name+" "+d.VolumeLabel+"("+ d.DriveFormat+") "+ HumanFormatByte(d.TotalFreeSpace)+" Байт свободно из "+ HumanFormatByte(d.TotalSize));
				//TODO:Human format disk size Т,Г,М,К,Байт
			}			
			
			//comboBox_Disks.SelectedIndex=0;
			comboBox_Disks.SelectedIndex = comboBox_Disks.Items.Count-1;
			//System.Threading.Thread.Sleep(1000);
            panel_Folder.Visible = true;
        }
		String HumanFormatByte(long Bytes) 
		{
			string result;
			//if (Byte >= 1024) 
			result = String.Format("{0:N0}",Bytes);
			return result;
		}
		void ComboBox_DisksSelectedIndexChanged(object sender, EventArgs e)
		{
			string DiskString = comboBox_Disks.Items[comboBox_Disks.SelectedIndex].ToString();
			textBox_TargetFolder.Text= DiskString.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0];			
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
				string newFolder = textBox_TargetFolder.Text + form_newFolder.StrNewFolder.Trim();
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
					textBox_TargetFolder.Text=newFolder+"\\";
					listBox_FoldersDirectoryInfo();
				}
			}
			
			
		}
        // Button_folder_OKClick
        void Button_folder_OKClick(object sender, EventArgs e)
		{
			panel_Folder.Enabled = false;
			panel_Folder.Visible = false;
			string strFile = textBox_TargetFolder.Text + Mod + ".log";			
			try {
				System.IO.File.WriteAllText(strFile, DateTime.Now.ToString("dd.MM.yyyy-hh:mm:ss")+" Install "+ Mod +" version "+ Assembly.GetExecutingAssembly().GetName().Version.ToString() +Environment.NewLine);
			}
			catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Ошибка при создании журнала\n", MessageBoxButtons.OK, MessageBoxIcon.Error); };

			strFile = textBox_TargetFolder.Text + Mod + ".dat";            
            try
            {
                //Create log file
                System.IO.File.WriteAllText(strFile, DateTime.Now.ToString("ddMMyyyy-hhmmss") +"\tFolderSourceUpdate\t"+ScriptFolder+"update");
                //Starter
                strFile = textBox_TargetFolder.Text + Mod + ".exe";
                try
                {
                    // Copy starter to destination folder
                    System.IO.File.Copy(ScriptFolder + "update\\" +Mod + ".exe", strFile, true);
                    try
                    {
                        //Ярлык на рабочем столе
                        string desktopShortcut = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" +Mod + ".lnk";                                                 
                        if (System.IO.File.Exists(desktopShortcut)) System.IO.File.Delete(desktopShortcut);
                        try
                        {
                            WshShell shell = new WshShell();
                            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(desktopShortcut);
                            shortcut.Description = "Day of Defeat";
                            shortcut.TargetPath = strFile;
                            shortcut.WorkingDirectory = textBox_TargetFolder.Text;
                            shortcut.Save();                        
                            try
                            {
                                using (Process myProcess = new Process())
                                {
                                    myProcess.StartInfo.UseShellExecute = false;                                    
                                    myProcess.StartInfo.WorkingDirectory = textBox_TargetFolder.Text;
                                    myProcess.StartInfo.FileName = myProcess.StartInfo.WorkingDirectory + Mod + ".exe";
                                    myProcess.Start();
                                    System.Threading.Thread.Sleep(3000);
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.ToString(), "Ошибка при запуске стартера\n", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Ошибка при создании ярлыка стартера", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Ошибка при обновлении ярлыка стартера", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Ошибка при копировании стартера", MessageBoxButtons.OK, MessageBoxIcon.Error);  }               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Ошибка при подготовке конфигурации стартера", MessageBoxButtons.OK, MessageBoxIcon.Error); }            
            this.Close();
		}
        
    }
}
