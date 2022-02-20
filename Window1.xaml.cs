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
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;
using System.Threading;


namespace KeepSolid
{
    /// <summary>
    /// Логика взаимодействия для Window.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static Window1 Window;
        public static Window2 ExitSetup;
        public int step = 0;
        public string where;
        public string where1;
        public bool shorcutperemenaya;

        public Window1()
        {
            InitializeComponent();
            Next.IsEnabled = false;
        }

        private void SwitchPages()
        {
            if (step == 5)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;

                worker.RunWorkerAsync();
            }
            switch (step)
            {
                case 0:
                    agremeentText.Visibility = Visibility.Visible;
                    radiobutton1.Visibility = Visibility.Visible;
                    radiobutton2.Visibility = Visibility.Visible;
                    Back.Visibility = Visibility.Collapsed;
                    text5.Visibility = Visibility.Collapsed;
                    text4.Visibility = Visibility.Collapsed;
                    text3.Visibility = Visibility.Collapsed;
                    text1.Visibility = Visibility.Visible;
                    Folder.Visibility = Visibility.Collapsed;
                    Browse1.Visibility = Visibility.Collapsed;
                    SetupFolder.Visibility = Visibility.Collapsed;
                    text1.Text = "Please read the following License Agremeent. You must accept the terms of this agremeent before continuing with th installation.";
                    text2.Text = "Please read the following important infrormation before continuing.";
                    LicenseAgremeent.Text = "License Agremeent";
                    break;
                case 1:
                    agremeentText.Visibility = Visibility.Collapsed;
                    radiobutton1.Visibility = Visibility.Collapsed;
                    radiobutton2.Visibility = Visibility.Collapsed;
                    Back.Visibility = Visibility.Visible;
                    text1.Visibility = Visibility.Collapsed;
                    Folder.Visibility = Visibility.Visible;
                    NoFolder.Visibility = Visibility.Collapsed;
                    Browse1.Visibility = Visibility.Visible;
                    Browse2.Visibility = Visibility.Collapsed;
                    text5.Visibility = Visibility.Visible;
                    text4.Visibility = Visibility.Visible;
                    text3.Visibility = Visibility.Visible;
                    SetupFolder.Visibility = Visibility.Visible;
                    SetupFolder2.Visibility = Visibility.Collapsed;
                    if (where != null && where.Length != 0) SetupFolder.Text = where;
                    text4.Text = "To continue, click Next. If you would like to select a different folder, click Browse.";
                    text3.Text = "Setup will install VPN Unlimited into the following folder.";
                    text2.Text = "Where should VPN Unlimited be installed?";
                    LicenseAgremeent.Text = "Select Destination Location";
                    break;
                case 2:
                    Browse1.Visibility = Visibility.Visible;
                    text5.Visibility = Visibility.Collapsed;
                    Folder.Visibility = Visibility.Collapsed;
                    NoFolder.Visibility = Visibility.Visible;
                    SetupFolder.Visibility = Visibility.Collapsed;
                    Browse1.Visibility = Visibility.Collapsed;
                    Browse2.Visibility = Visibility.Visible;
                    SetupFolder2.Visibility = Visibility.Visible;
                    text1.Visibility = Visibility.Collapsed;
                    CheckBoxShorcut.Visibility = Visibility.Collapsed;
                    text4.Text = "To continue, click Next. If you would like to select a different folder, click Browse.";
                    text3.Text = "Setup will create the program shortcuts in the following Start Menu folder.";
                    text2.Text = "Where should Setup place the program's shortcuts?";
                    LicenseAgremeent.Text = "Select Start Menu Folder.";
                    break;
                case 3:
                    Browse1.Visibility = Visibility.Collapsed;
                    NoFolder.Visibility = Visibility.Collapsed;
                    SetupFolder.Visibility = Visibility.Collapsed;
                    Browse2.Visibility = Visibility.Collapsed;
                    text3.Visibility = Visibility.Collapsed;
                    text1.Visibility = Visibility.Visible;
                    CheckBoxShorcut.Visibility = Visibility.Visible;
                    SetupFolder2.Visibility = Visibility.Collapsed;
                    finalpath.Visibility = Visibility.Collapsed;
                    text4.Text = "Additional shorcuts:";
                    text2.Text = "Which additional tasks should be performed?";
                    text1.Text = "Select the additional tasks you would like Setup to perform while installing VPN Unlimited, then click Next.";
                    LicenseAgremeent.Text = "Select Additional Tasks";
                    break;
                case 4:
                    finalpath.Visibility = Visibility.Visible;
                    CheckBoxShorcut.Visibility = Visibility.Collapsed;
                    text4.Visibility = Visibility.Collapsed;
                    finalpath.Text = "Destination location:\n\t" + where + "\n\nStart Menu folder:\n\t" + SetupFolder.Text + "\n\nAdditional tasks:\n\t" + (shorcutperemenaya ? "Additional shortcuts:\n\t" + where1 +"  Create a desktop shortcut" : "-");
                    text2.Text = "Setup is now ready to begin installing VPN Unlimited on your computer.";
                    text1.Text = "Click Install to continue with the installation, or click Back if you want to review or change any settings.";
                    LicenseAgremeent.Text = "Ready to Install";
                    bar.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    text2.Text = "Please wait while Setup installs VPN Unlimited on your computer.";
                    text1.Text = "Extracting files...";
                    LicenseAgremeent.Text = "Installing";
                    text2.Visibility = Visibility.Visible;
                    text1.Visibility = Visibility.Visible;
                    bar.Visibility = Visibility.Visible;
                    finalpath.Visibility = Visibility.Collapsed;
                    Next.Visibility = Visibility.Collapsed;
                    Back.Visibility = Visibility.Collapsed;
                    break;
                case 6:
                    bar.Visibility = Visibility.Collapsed;
                    text2.Visibility = Visibility.Collapsed;
                    text1.Visibility = Visibility.Collapsed;
                    LicenseAgremeent.Visibility = Visibility.Collapsed;
                    rectangle1.Visibility = Visibility.Collapsed;
                    finallogo.Visibility = Visibility.Visible;
                    lasttext1.Visibility = Visibility.Visible;
                    lasttext2.Visibility = Visibility.Visible;
                    lasttext3.Visibility = Visibility.Visible;
                    Logo.Visibility = Visibility.Collapsed;
                    finish.Visibility = Visibility.Visible;
                    lastshortcuts.Visibility = Visibility.Visible;
                    Cancel.Visibility = Visibility.Collapsed;
                    break;

            }
        }
        private void Button_finish(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void StatusBar(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (bar.Value == 100)
            {
                step++;
                SwitchPages();
            }
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bar.Value = e.ProgressPercentage;
        }

        private void Shorcut(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckBoxShorcut.IsChecked)
            {
                shorcutperemenaya = true;
            }
            else
            {
                shorcutperemenaya = false;
            }
        }

        private void Browse1_Method(object sender, RoutedEventArgs e)
        {
            //как подключить System.Windows.Forms в .Net 5 непонятно и FolderBrowserDialog соответственно тоже, так что воооот..
            OpenFileDialog openFileDlg = new OpenFileDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                SetupFolder.Text = openFileDlg.FileName;
                where = openFileDlg.FileName;
            }
        }

        private void Browse2_Method(object sender, RoutedEventArgs e)
        {
            //как подключить System.Windows.Forms в .Net 5 непонятно и FolderBrowserDialog соответственно тоже, так что воооот..
            OpenFileDialog openFileDlg = new OpenFileDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                SetupFolder2.Text = openFileDlg.FileName;
                where1 = openFileDlg.FileName;
            }
        }

        private void Check_AcceptRadioButton(object sender, RoutedEventArgs e)
        {
            Next.IsEnabled = true;
        }

        private void Check_NotAcceptRadioButton(object sender, RoutedEventArgs e)
        {
            Next.IsEnabled = false;
        }

        private void Button_Next(object sender, RoutedEventArgs e)
        {
            step++;
            SwitchPages();
        }

        private void Button_back(object snder, RoutedEventArgs e)
        {
            step--;
            SwitchPages();
        }
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            ExitSetup = new Window2();
            ExitSetup.ShowDialog();
        }

    }
}
