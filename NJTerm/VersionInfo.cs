using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NanoTerm
{
    public partial class VersionInfo : Form
    {
        public VersionInfo()
        {
            InitializeComponent();
            // C#
            // バージョン名（AssemblyInformationalVersion属性）を取得
            string appVersion = Application.ProductVersion;
            // 製品名（AssemblyProduct属性）を取得
            string appProductName = Application.ProductName;
            // 会社名（AssemblyCompany属性）を取得
            string appCompanyName = Application.CompanyName;
            // C#
            Assembly mainAssembly = Assembly.GetEntryAssembly();

            // コピーライト情報を取得
            string appCopyright = "-";
            object[] CopyrightArray =
              mainAssembly.GetCustomAttributes(
                typeof(AssemblyCopyrightAttribute), false);
            if ((CopyrightArray != null) && (CopyrightArray.Length > 0))
            {
                appCopyright =
                  ((AssemblyCopyrightAttribute)CopyrightArray[0]).Copyright;
            }

            // 詳細情報を取得
            string appDescription = "-";
            object[] DescriptionArray =
              mainAssembly.GetCustomAttributes(
                typeof(AssemblyDescriptionAttribute), false);
            if ((DescriptionArray != null) && (DescriptionArray.Length > 0))
            {
                appDescription =
                  ((AssemblyDescriptionAttribute)DescriptionArray[0]).Description;
            }
            label1.Text = appCompanyName + " " + appProductName;
            label2.Text = "Version " + appVersion;
            label3.Text = appCopyright;
            label4.Text = appDescription; 
        }
    }
}
