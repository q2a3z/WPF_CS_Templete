using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CS_Templete
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExcute_Click(object sender, RoutedEventArgs e)
        {
            tbSelectProject.Text = (chkBox_Clear.IsChecked ??= false) ? "CLEAR Click!!!" : "Excute Click!!!";
            RunBatchFile();
            

        }
        private void RunBatchFile() 
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "ipconfig.exe";
            startInfo.Arguments = "/all";
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.Exited += (sender, e) =>
             {
                 string msgtext = "Do you want to Exit?";
                 string txt = "Process End";
                 MessageBoxButton button = MessageBoxButton.YesNo;//MessageBoxButton.YesNoCancel;
                 MessageBoxResult result = MessageBox.Show(msgtext, txt, button);
                 switch (result)
                 {
                     case MessageBoxResult.Yes:
                         MessageBox.Show("終了しました。");
                         Environment.Exit(0);
                         break;
                 }
             };// Proc_Exited();
            //process.Exited += Proc_Exited;
            process.Start();

            string line = null;
            while ((line = process.StandardOutput.ReadLine()) != null) 
            {
                LogOutputText.AppendText(line);
                LogOutputText.AppendText(Environment.NewLine);
                LogOutputText.ScrollToEnd();
            }
            
        }

        private void btnCopyFile_Click(object sender, RoutedEventArgs e)
        {
            LogOutputText.Document.Blocks.Clear();
        }
    }
}
