using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteData.DataRepository.Models
{
    public class Station
    {
        public int id { get; set; }
        public string name { get; set; }
        public int system_id { get; set; }
        public string max_landing_pad_size { get; set; }
        public int distance_to_start { get; set; }
        public string faction { get; set; }
        public string government { get; set; }
        public string allegiance { get; set; }
        public string state { get; set; }
        public int? type_id { get; set; }
        public string type { get; set; }
        public int? has_blackmarket { get; set; }
        public int? has_market { get; set; }
        public int? has_reful { get; set; }
        public int? has_repair { get; set; }
        public int? has_rearm { get; set; }
        public int? has_outfitting { get; set; }
        public int? has_shipyard { get; set; }
        public int? has_commodities { get; set; }
        public IEnumerable<string> import_commodities { get; set; }
        public IEnumerable<string> export_commodities { get; set; }
        public IEnumerable<string> prohibited_commodities { get; set; }
        public IEnumerable<string> economies { get; set; }
        public uint updated_at { get; set; }
        public uint? shipyard_upadted_at { get; set; }
        public uint? outfitting_updated_at { get; set; }
        public uint? market_updated_at { get; set; }
        public int is_planetary { get; set; }
        public IEnumerable<string> selling_ships { get; set; }
        public IEnumerable<int> selling_modules { get; set; }
    }
}
