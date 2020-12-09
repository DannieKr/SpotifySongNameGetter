using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SpotifySongNameGetter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = GetSpotifySongName();
        }

        private string GetSpotifySongName()
        {
            try
            {
                var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                return proc.MainWindowTitle;
            }
            catch
            {
                MessageBox.Show("No Spotify process was found! Please open Spotify and DON'T minimize it to tray");
                return txtBox.Text;
            }
        }

        private void BtnCheckAndClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GetSpotifySongName());
            txtBox.Text = GetSpotifySongName();
        }

        private void MenuItemAbout_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DannieKr/SpotifySongNameGetter");
            e.Handled = true;
        }
    }
}
