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
    /// Логика взаимодействия для statistics.xaml
    /// </summary>
    public partial class statistics : Page
    {
        private GameData _gameData;
        public statistics(GameData gameData)
        {
            _gameData = gameData;
            InitializeComponent();
            kills.Text = "Kills: " + gameData.kills.ToString();
            deaths.Text = "Deaths: " + gameData.deaths.ToString();
        }

        private void nullStat_Click(object sender, RoutedEventArgs e)
        {
            _gameData.kills = 0;
            _gameData.deaths = 0;
            kills.Text = "Kills: 0";
            deaths.Text = "Deaths: 0";
            MainWindow.SaveGameData(MainWindow.statsFilePath, _gameData);
        }
    }
}
