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
        public MainWindowViewModel() 
        {
            ChangePlaylistButton = new RelayCommand(OnChangePlaylistButtonExecute, CanChangePlaylistButtonExecute);
        }
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
        public RelayCommand ChangePlaylistButton { get; }
        private bool CanChangePlaylistButtonExecute(object arg) => true;
        private void OnChangePlaylistButtonExecute(object obj)
        {
            //TODO что делает кнопка 
            //TODO тут привязка
            OnPropertyChanged();
        }
    }
}
