using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Models
{
    internal class SongList
    {
        public static List<Song> GetList(int index) //TODO maybe singletone?
        {
            List<Song> list = new List<Song>();
            HtmlWeb web;
            HtmlDocument doc;
            web = new HtmlWeb();
            doc = web.Load(PlaylistList.GetList()[index].url);
            var nameNodes = doc.DocumentNode.SelectNodes("//td/div/a/span[@itemprop='name']");
            var artistNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='byArtist']");
            var albumNodes = doc.DocumentNode.SelectNodes("//td/div/a[@itemprop='inAlbum']");
            var timeNodes = doc.DocumentNode.SelectNodes("//td/div[@class='wrapper ellipsis timestamp']");
            for (int i = 0; i < nameNodes.Count; i++)
            {
                list.Add(new Song(nameNodes[i].InnerText, artistNodes[i].InnerText, albumNodes[i].InnerText, timeNodes[i].InnerText.Trim()));
            }
            return list;
        }
    }
}
