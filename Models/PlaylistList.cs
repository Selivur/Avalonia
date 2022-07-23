using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Models
{
    internal class PlaylistList
    {
        public static List<PlaylistData> GetList() 
        {
            List<PlaylistData> list = new List<PlaylistData>();
            list.Add(new PlaylistData("https://www.deezer.com/en/playlist/1479458365"));
            list.Add(new PlaylistData("https://www.deezer.com/en/album/274337972"));
            list.Add(new PlaylistData("https://www.deezer.com/en/playlist/2578576804"));
            return list;
        }
    }
}
