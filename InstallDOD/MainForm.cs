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

namespace InstallDOD
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
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
		
	}
}
