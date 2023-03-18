using CryptoInfo.Model;
using CryptoInfo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoInfo.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand TopCryptoViewCommand { get; set; }
        public RelayCommand SearchViewCommand { get; set; }

        public TopCryptoViewModel TopCryptoVM { get; set; }
        public SearchViewModel SearchlVM { get; set; }
        

        private object _currentView;

        public object  CurrentView
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
            TopCryptoVM = new TopCryptoViewModel();
            SearchlVM = new SearchViewModel();

            CurrentView = TopCryptoVM;
            TopCryptoViewModel viewModel = new TopCryptoViewModel();

            TopCryptoViewCommand = new RelayCommand(o =>
            {
                CurrentView = TopCryptoVM;
            });

            SearchViewCommand= new RelayCommand(o =>
            {
                CurrentView = SearchlVM;
            });
        }
    }
}
