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
            var nameNodes = doc.DocumentNode.SelectNodes("//td/div/a/span[@itemprop='name']");
            var artistNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='byArtist']");
            var albumNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='inAlbum']");
            var timeNodes = doc.DocumentNode.SelectNodes("//td/div[@class='wrapper ellipsis timestamp']");
            for (int i = 0; i < nameNodes.Count; i++)
            {
                // Create Grid
                Grid myGrid = new Grid();
                myGrid.ShowGridLines = true;
                // Define Columns
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
                ColumnDefinition colDef4 = new ColumnDefinition();
                colDef2.Width = new GridLength(0.3, GridUnitType.Star);
                colDef4.Width = new GridLength(0.1, GridUnitType.Star);
                myGrid.ColumnDefinitions.Add(colDef1);
                myGrid.ColumnDefinitions.Add(colDef2);
                myGrid.ColumnDefinitions.Add(colDef3);
                myGrid.ColumnDefinitions.Add(colDef4);
                // Add song name to the Grid
                TextBlock songName = new TextBlock();
                songName.Text = nameNodes[i].InnerText; 
                songName.FontSize = 14;
                songName.TextWrapping=TextWrapping.Wrap;
                songName.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(songName, 0);
                myGrid.Children.Add(songName);
                // Add author name to the Grid
                TextBlock artistName = new TextBlock();
                artistName.Text = artistNodes[i].InnerText;
                artistName.FontSize = 14;
                songName.TextWrapping = TextWrapping.Wrap;
                artistName.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(artistName, 1);
                myGrid.Children.Add(artistName);
                // Add album name to the Grid
                TextBlock albumName = new TextBlock();
                albumName.Text = albumNodes[i].InnerText;
                albumName.FontSize = 14;
                songName.TextWrapping = TextWrapping.Wrap;
                albumName.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(albumName, 2);
                myGrid.Children.Add(albumName);
                // Add duration to the Grid
                TextBlock duration = new TextBlock();
                duration.Text = timeNodes[i].InnerText.Trim();
                duration.FontSize = 14;
                songName.TextWrapping = TextWrapping.Wrap;
                duration.TextAlignment = TextAlignment.Center;
                Grid.SetColumn(duration, 3);
                myGrid.Children.Add(duration);
                // Add Grid to the ListBox
                Songs_box.Items.Add(myGrid);
            }
        }
    }
}
