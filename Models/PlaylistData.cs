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
            HtmlWeb web= new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            this.url = url;
            playlistImageUrl = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:image']").GetAttributeValue("content", "");
            playlistName = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:title']").GetAttributeValue("content", "");
            playlistDescription = doc.DocumentNode.SelectSingleNode("/html/head/meta[@property='og:description']").GetAttributeValue("content", "");
        }
        public string url { get; set; }
        public string playlistName { get; set; }
        public string playlistImageUrl { get; set; }
        public string playlistDescription { get; set; }
    }
}
