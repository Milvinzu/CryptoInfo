using CryptoInfo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand TopCryptoViewCommand { get; set; }
        public RelayCommand AllCoinsViewCommand { get; set; }

        public TopCryptoViewModel TopCryptoVM { get; set; }
        public AllCoinsViewModel AllCoinsVM { get; set; }
        

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
            AllCoinsVM = new AllCoinsViewModel();

            CurrentView = TopCryptoVM;
            TopCryptoViewModel viewModel = new TopCryptoViewModel();

            TopCryptoViewCommand = new RelayCommand(o =>
            {
                CurrentView = TopCryptoVM;
            });

            AllCoinsViewCommand = new RelayCommand(o =>
            {
                CurrentView = AllCoinsVM;
            });
        }
    }
}
