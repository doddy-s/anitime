using Kelompok01.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok01.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SearchViewCommand { get; set; }
        public RelayCommand HistoryViewCommand { get; set; }
        public RelayCommand AnimeInfoViewCommand { get; set; }

        public HomeViewModel HomeVM;
        public SearchViewModel SearchVM;
        public HistoryViewModel HistoryVM;
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

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SearchVM = new SearchViewModel();
            HistoryVM = new HistoryViewModel();
            AnimeInfoVM = new AnimeInfoViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;

            });

            SearchViewCommand = new RelayCommand(o =>
            {
                CurrentView = SearchVM;

            });

            HistoryViewCommand = new RelayCommand(o =>
            {
                CurrentView = HistoryVM;

            });

            AnimeInfoViewCommand = new RelayCommand(o =>
            {
                CurrentView = AnimeInfoVM;

            });
        }
    }
}
    
    
