using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteData.DataRepository.Models
{
    public class Commodity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? category_id { get; set; }
        public int? average_price { get; set; }
        public int? is_rare { get; set; }
        public IEnumerable<CommodityCategory> category { get; set; }
    }
}
