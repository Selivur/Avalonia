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
using Avalonia.ViewModels;
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
            DataContext = new MainWindowViewModel();


        }

        /*

        private void ChangePlaylistButton(object sender, RoutedEventArgs e) //TODO add parsing
        {
            Songs_box.Items.Clear();
            doc = web.Load(url[Playlist_box.SelectedIndex]);
            var nameNodes = doc.DocumentNode.SelectNodes("//td/div/a/span[@itemprop='name']");
            var artistNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='byArtist']");
            var albumNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='inAlbum']");
            var timeNodes = doc.DocumentNode.SelectNodes("//td/div[@class='wrapper ellipsis timestamp']");
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
        }*/
    }
}
