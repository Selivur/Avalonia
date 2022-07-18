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
        private TextBlock CreateStandartTextBlock(string str, int column)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = str;
            textBlock.FontSize = 14;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(textBlock, column);
            return textBlock;
            
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)//TODO add Parse
        {
            foreach (string link in url)
            {
                doc = web.Load(link);
                // Create Grid
                Grid myGrid = new Grid();
                // Define Columns
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
                colDef1.Width = new GridLength(0.3, GridUnitType.Star);
                colDef3.Width = new GridLength(2, GridUnitType.Star);
                myGrid.ColumnDefinitions.Add(colDef1);
                myGrid.ColumnDefinitions.Add(colDef2);
                myGrid.ColumnDefinitions.Add(colDef3);
                // Add img to the Grid
                Image albumImg = new Image();
                albumImg.Width = 50;
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:image']").GetAttributeValue("content", ""));
                myBitmapImage.DecodePixelWidth = 50;
                myBitmapImage.EndInit();
                albumImg.Source = myBitmapImage;
                Grid.SetColumn(albumImg, 0);
                myGrid.Children.Add(albumImg);
                // Add album name to the Grid
                TextBlock albumName = new TextBlock();
                albumName.Text = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:title']").GetAttributeValue("content", "");
                albumName.FontSize = 18;
                albumName.TextAlignment = TextAlignment.Center;
                albumName.VerticalAlignment = VerticalAlignment.Center;
                albumName.FontWeight = FontWeights.Bold;
                Grid.SetColumn(albumName, 1);
                myGrid.Children.Add(albumName);
                // Add description to the Grid
                var descriptionText = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='description']");
                myGrid.Children.Add(CreateStandartTextBlock( descriptionText== null ? "None" : descriptionText.GetAttributeValue("content", ""), 2));
                // Add Grid to the ListBox
                Playlist_box.Items.Add(myGrid);
            }
            
        }
        private void ChangePlaylist_Button(object sender, RoutedEventArgs e) //TODO add parsing
        {
            Songs_box.Items.Clear();
            doc = web.Load(url[Playlist_box.SelectedIndex]);
            var nameNodes = doc.DocumentNode.SelectNodes("//td/div/a/span[@itemprop='name']");
            var artistNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='byArtist']");
            var albumNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='inAlbum']");
            var timeNodes = doc.DocumentNode.SelectNodes("//td/div[@class='wrapper ellipsis timestamp']");
            for (int i = 0; i < nameNodes.Count; i++)
            {
                // Create Grid
                Grid myGrid = new Grid();
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
                myGrid.Children.Add(CreateStandartTextBlock(nameNodes[i].InnerText, 0));
                myGrid.Children.Add(CreateStandartTextBlock(artistNodes[i].InnerText, 1));
                myGrid.Children.Add(CreateStandartTextBlock(albumNodes[i].InnerText, 2));
                myGrid.Children.Add(CreateStandartTextBlock(timeNodes[i].InnerText.Trim(), 3));
                Songs_box.Items.Add(myGrid);
            }
        }
    }
}
