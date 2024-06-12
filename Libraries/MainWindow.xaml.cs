using System.Windows;
using LibraryJson;
using Path = System.IO.Path;

namespace Libraries
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Themkanumber1_Click(object sender, RoutedEventArgs e)
        {
            App.Theme = "Themkanumber1";
        }

        private void Themkanumber2_Click(object sender, RoutedEventArgs e)
        {
            App.Theme = "Themkanumber2";
        }

        private void serializacia_Click(object sender, RoutedEventArgs e)
        {
            string textToSerialize = inputText.Text;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "serialized_text.json");
            Json.SerializeToFile(textToSerialize, jsonFilePath);

            inputText.Text = "";
        }

        private void deserializacia_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "serialized_text.json");
            string deserializedText = Json.DeserializeFromFile<string>(jsonFilePath);
            if (!string.IsNullOrEmpty(deserializedText))
            {
                dataLbx.Items.Add(deserializedText);
            }
        }

        private void vihodBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}