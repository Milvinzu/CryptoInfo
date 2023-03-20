using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoInfo.Model
{
    class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal PriceUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public decimal ChangePercent24Hr { get; set; }
        public string Market { get; set; }
    }
}
