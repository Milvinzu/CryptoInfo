using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.ViewModel
{
    class AllCoinsViewModel : ObservableObject
    {
        private ObservableCollection<Model.CoinInfo> AllConinsInfo;
    }
}
