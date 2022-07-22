﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Models
{
    internal class Song
    {
        public string name { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public string time { get; set; }

        public Song(string name, string artist, string album,  string time)
        {
            this.name = name;
            this.artist = artist;
            this.album = album;
            this.time = time;
        }   
    }
}
