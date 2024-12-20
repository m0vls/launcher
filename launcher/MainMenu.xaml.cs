using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
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
using System.Diagnostics;


namespace launcher
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TDGame.exe");
            if (!File.Exists(exePath))
            {
                string Path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TDGame1.zip");
                string Path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TDGame2.zip");

                string extractPath = AppDomain.CurrentDomain.BaseDirectory;

                ZipFile.ExtractToDirectory(Path1, extractPath);
                ZipFile.ExtractToDirectory(Path2, extractPath);
            }

            InitializeComponent();
        }

        private void goToSettings_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToSettings();
        }

        private void goToStatistics_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToStatistics();
        }

        private void launchGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TDGame.exe");
                

                // Проверка существует ли файл
                if (File.Exists(exePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Файл игры не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при запуске игры: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Application.Current.Shutdown();
        }
    }
}
