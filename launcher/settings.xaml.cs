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

namespace launcher
{
    /// <summary>
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        private GameData _gameData;

        public settings(GameData gameData)
        {
            InitializeComponent();
            _gameData = gameData;

            //передача данных в элементы интерфейса
            ResolutionComboBox.SelectedItem = $"{_gameData.width}x{_gameData.height}";
            FullscreenCheckBox.IsChecked = _gameData.fullscreen;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //если выбрано разрешение передача в класс с данными   
            if (ResolutionComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string[] resolution = selectedItem.Content.ToString().Split('x');
                _gameData.width = int.Parse(resolution[0]);
                _gameData.height = int.Parse(resolution[1]);
            }

            
            _gameData.fullscreen = FullscreenCheckBox.IsChecked == true;

            // Сохраняем изменения в JSON
            MainWindow.SaveGameData(MainWindow.statsFilePath, _gameData);

            
            MessageBox.Show("Settings applied successfully!");

        }
    }
}
