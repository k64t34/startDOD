/*
 * Created by SharpDevelop.
 * User: skorik
 * Date: 09.01.2019
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InstallDOD
{
	/// <summary>
	/// Description of newFolder.
	/// </summary>
	public partial class newFolder : Form
	{
		public string StrNewFolder;
		public newFolder()
		{
				
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		void Button_CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button_OKClick(object sender, EventArgs e)
		{
			//textBox_newFolder.Text=this.Owner.Text+textBox_newFolder.Text;
			StrNewFolder=textBox_newFolder.Text;
			this.Close();
		}
		private void newFolder_Paint(object sender, PaintEventArgs e)
        {
            /*int width  =this.Width-1;
            int height = this.Height-1;
            Pen fPen = new Pen(Color.FromArgb(250, 0, 0, 0), 1);
            e.Graphics.DrawRectangle(fPen, 0, 0, width, height);*/            
        }
		
		
	}
}
