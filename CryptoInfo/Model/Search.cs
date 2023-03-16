using CryptoInfo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.Model
{
    class Search : ObservableObject
    {
        private string _searchText;
        public List<string> Items { get; set; }

        public Search()
        {
            Items = new List<string>();
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

                OnPropertyChanged("SearchText");
                OnPropertyChanged("MyFilteredItems");
            }
        }

        public IEnumerable<string> MyFilteredItems
        {
            get
            {
                if (SearchText == null) return Items;

                return Items.Where(x => x.ToUpper().StartsWith(SearchText.ToUpper()));
            }
        }

    }
}
