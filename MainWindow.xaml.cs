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
using HtmlAgilityPack;

namespace Avalonia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HtmlWeb web;
        private HtmlDocument doc;

        private List<string> url = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            web = new HtmlWeb();
            url.Add("https://www.deezer.com/en/playlist/1479458365");
            url.Add("https://www.deezer.com/en/album/274337972");
            
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)//TODO add Parse
        {
            foreach (string link in url)
            {
                doc = web.Load(link);
                // Create Grid
                Grid myGrid = new Grid();
                myGrid.ShowGridLines = true;
                // Define Columns
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
                colDef3.Width = new GridLength(2, GridUnitType.Star);
                myGrid.ColumnDefinitions.Add(colDef1);
                myGrid.ColumnDefinitions.Add(colDef2);
                myGrid.ColumnDefinitions.Add(colDef3);
                // Add img to the Grid
                Image albumImg = new Image();
                albumImg.Width = 50;
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(doc.DocumentNode.SelectSingleNode("/html/head/meta[8]").GetAttributeValue("content", ""));
                myBitmapImage.DecodePixelWidth = 50;
                myBitmapImage.EndInit();
                albumImg.Source = myBitmapImage;
                Grid.SetColumn(albumImg, 0);
                myGrid.Children.Add(albumImg);
                // Add album name to the Grid
                TextBlock albumName = new TextBlock();
                albumName.Text = doc.DocumentNode.SelectSingleNode("/html/head/meta[6]").GetAttributeValue("content", "");
                albumName.FontSize = 18;
                albumName.TextAlignment = TextAlignment.Center;
                albumName.VerticalAlignment = VerticalAlignment.Center;
                albumName.FontWeight = FontWeights.Bold;
                Grid.SetColumn(albumName, 1);
                myGrid.Children.Add(albumName);
                // Add description to the Grid
                TextBlock description = new TextBlock();
                description.Text = doc.DocumentNode.SelectSingleNode("/html/head/meta[7]").GetAttributeValue("content", "");
                description.FontSize = 14;
                description.TextAlignment = TextAlignment.Center;
                description.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(description, 2);
                myGrid.Children.Add(description);
                // Add Grid to the ListBox
                Playlist_box.Items.Add(myGrid);
            }
            
        }
        private void ChangePlaylist_Button(object sender, RoutedEventArgs e) //TODO add parsing
        {
            doc = web.Load(url[Playlist_box.SelectedIndex]);
            //doc.DocumentNode.SelectNodes("//div[@class=\"_2OACy\"]").Count
            for (int i = 0; i < 3; i++)//TODO change counter(doc.DocumentNode.SelectNodes("/html/body/div[1]/div[1]/div[5]/div/div[1]/div/div[3]/div[2]/div/div/div[@class='_2OACy']").Count)
            {
                // Create Grid
                Grid myGrid = new Grid();
                myGrid.ShowGridLines = true;
                // Define Columns
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
                ColumnDefinition colDef4 = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef1);
                myGrid.ColumnDefinitions.Add(colDef2);
                myGrid.ColumnDefinitions.Add(colDef3);
                myGrid.ColumnDefinitions.Add(colDef4);
                // Add song name to the Grid
                TextBlock songName = new TextBlock();
                songName.Text = "songName"; 
                songName.FontSize = 14;
                songName.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(songName, 0);
                myGrid.Children.Add(songName);
                // Add author name to the Grid
                TextBlock authorName = new TextBlock();
                authorName.Text = "authorName";
                authorName.FontSize = 14;
                authorName.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(authorName, 1);
                myGrid.Children.Add(authorName);
                // Add album name to the Grid
                TextBlock albumName = new TextBlock();
                albumName.Text = "albumName";
                albumName.FontSize = 14;
                albumName.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(albumName, 2);
                myGrid.Children.Add(albumName);
                // Add duration to the Grid
                TextBlock duration = new TextBlock();
                duration.Text = "duration";
                duration.FontSize = 14;
                duration.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(duration, 3);
                myGrid.Children.Add(duration);
                // Add Grid to the ListBox
                Songs_box.Items.Add(myGrid);
            }
        }
    }
}
