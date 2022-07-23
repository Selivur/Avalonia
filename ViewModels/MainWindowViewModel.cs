using Avalonia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.ViewModels.Base;

namespace Avalonia.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Avalonia";
        public string Title
        {
            get => _Title; 
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }
        private List<PlaylistData> _playlistList =PlaylistList.GetList();
        public List<PlaylistData> playlistList
        {
            get => _playlistList;
            set
            {
                _playlistList = value;
                OnPropertyChanged();
            }
        }
        private static int _selector = 0;
        public  int selector
        {
            get => _selector;
            set
            {
                _selector = value;
                songList = SongList.GetList(selector);
                OnPropertyChanged();
            }
        }
        private List<Song> _songList;
        public List<Song> songList
        {
            get => _songList;
            set
            {
                _songList = value;
                OnPropertyChanged();
            }
        }
    }
}
