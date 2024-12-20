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
//using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;


namespace launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string companyName = "GameBakery";
        static string gameName = "TDGame";

        static string persistentDataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "..", "LocalLow", companyName, gameName);

        public static string statsFilePath = Path.Combine(persistentDataPath, "statistics.json");

        public GameData gameData { get; set; }

        private MainMenu _menu;
        private settings _settings;
        private statistics _statistics;


        public MainWindow()
        {
            InitializeComponent();
            

            if (!Directory.Exists(persistentDataPath))
            {
                Directory.CreateDirectory(persistentDataPath);
            }

            gameData = LoadGameData(statsFilePath);
            //kill.Text = $"Kills: {gameData.kills}";

            _menu = new MainMenu();
            _settings = new settings(gameData);
            _statistics = new statistics(gameData);

            Menu.Navigate(_menu);
        }
        public void NavigateToSettings()
        {
            Menu.Navigate(_settings);
        }

        public void NavigateToStatistics()
        {
            Menu.Navigate(_statistics);
        }

        private GameData LoadGameData(string path)
        {
            if (!File.Exists(path))
            {
                // Если файла не существует, создаём с начальными значениями
                var defaultData = new GameData();
                SaveGameData(path, defaultData);
                return defaultData;
            }

            try
            {
                //Загрузка файла
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<GameData>(json) ?? new GameData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
                return new GameData(); // Возвращаем объект по умолчанию в случае ошибки
            }
        }

        public static void SaveGameData(string path, GameData data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }
        }

    }
    public class GameData
    {
        public int kills;
        public int deaths;
        public int height;
        public int width;
        public bool fullscreen;

        public GameData()
        {
            kills = 0;
            deaths = 0;
            height = 1080;
            width = 1920;
            fullscreen = true;
        }
    }
}
