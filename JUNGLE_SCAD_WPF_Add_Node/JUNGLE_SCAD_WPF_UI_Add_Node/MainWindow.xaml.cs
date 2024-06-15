using JUNGLE_SCAD_WPF_UI_Add_Node.Model;
using System.Windows;
using Newtonsoft.Json;

namespace JUNGLE_SCAD_WPF_UI_Add_Node
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private EditorModelInfo _modelInfo;
        private string _jsonObj = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        public string GetModelInfo()
        {
            return _jsonObj;
        }

        private void CreateModel()
        {
            _modelInfo = new EditorModelInfo();

            _modelInfo.Name = tb_name.Text;

            _modelInfo.X = double.Parse(tb_x.Text) / 1000;

            _modelInfo.Y = double.Parse(tb_y.Text) / 1000;

            _modelInfo.Z = double.Parse(tb_z.Text) / 1000;
        }

        private void btn_Add_Node_Click(object sender, RoutedEventArgs e)
        {
            CreateModel();
            _jsonObj = JsonConvert.SerializeObject(_modelInfo);
            Close();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            _jsonObj = string.Empty;
            Close();
        }
    }
}
