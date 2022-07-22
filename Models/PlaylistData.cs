using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Avalonia.Models
{
    internal class PlaylistData
    {
        public PlaylistData(string url)
        {
            HtmlWeb web;
            HtmlDocument doc;
            this.url = url;
            web = new HtmlWeb();
            doc = web.Load(url);
            plImgUrl = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:image']").GetAttributeValue("content", "");
            plName = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:title']").GetAttributeValue("content", "");
            plDescription = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:description']").GetAttributeValue("content", "");
        }
        public string url { get; set; }
        public string plName { get; set; }
        public string plImgUrl { get; set; }
        public string plDescription { get; set; }
        /*public static PlaylistData[] GetPlaylistData()
        {
            var result = new PlaylistData[3];
            {
                new PlaylistData("https://www.deezer.com/en/playlist/1479458365");
                new PlaylistData("https://www.deezer.com/en/album/274337972");
                new PlaylistData("https://www.deezer.com/en/playlist/2578576804");
            }
            return result;
        }*/
    }
}
