using Kelompok01.Core;
using Kelompok01.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok01.MVVM.ViewModel
{
    internal class HomeViewModel : ObservableObject
    {
        public RelayCommand NewAnimeViewCommand { get; set; }
        public static RelayCommand AnimeInfoViewCommand { get; set; }

        public NewAnimeViewModel NewAnimeVM;
        public AnimeInfoViewModel AnimeInfoVM;

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            AnimeInfoVM = new AnimeInfoViewModel();
            NewAnimeVM = new NewAnimeViewModel();

            CurrentView = NewAnimeVM;

            NewAnimeViewCommand = new RelayCommand(o =>
            {
                CurrentView = NewAnimeVM;

            });

            AnimeInfoViewCommand = new RelayCommand(o =>
            {
                CurrentView = AnimeInfoVM;

            });
        }
    }
}
