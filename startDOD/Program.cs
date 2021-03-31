using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace startDOD
{
    static class Program
    {
        

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    enum ConfigLineCommand
    {
        UNKNOWN=0,
        FolderSourceUpdate=1,
        UNZIP =10,
        REG=20,
        EDIT_CLIENT_FILE=30        
    }
    class ConfigLine
    {
        public ConfigLineCommand Command = ConfigLineCommand.UNKNOWN;
        public String Version = String.Empty;
        public String File = String.Empty;
        String[] Parameters;
        int Type = 0;//0-clinet;1-server
        public ConfigLine(String StringLine,int ConfigType=0)
        {
            this.Type = ConfigType;
            String[] Part = StringLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (Part.Length >= 3-this.Type)
            {
                if (String.Compare(Part[1 - this.Type], "FolderSourceUpdate", true) == 0) { this.Command = ConfigLineCommand.FolderSourceUpdate; this.File = Part[2 - this.Type]; }
                else
                {
                    if (String.Compare(Part[1 - this.Type], "UNZIP",            true) == 0) this.Command = ConfigLineCommand.UNZIP;
                    if (String.Compare(Part[1 - this.Type], "REG",              true) == 0) this.Command = ConfigLineCommand.REG;
                    if (String.Compare(Part[1 - this.Type], "EDIT_CLIENT_FILE", true) == 0) this.Command = ConfigLineCommand.EDIT_CLIENT_FILE;
                    this.Version = Part[2 - this.Type];
                    this.File = Part[3 - this.Type];
                }
                //foreach (string entry in Part)                    {
                //        Debug.Write($"<{entry}>");                    }
                //Debug.Write("\n\n");
            }
        }
        //public bool Exec()
        //{
        //    bool result = false;
        //    if (this.Command == ConfigLineCommand.UNZIP) result = 
        //            UNZIP();
        //    return result;
        //}
    }
}
