using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteData.ConsoleApplication.Models
{
    public class SolarSystem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public string faction { get; set; }
        public ulong? population { get; set; }
        public string government { get; set; }
        public string allegiance { get; set; }
        public string state { get; set; }
        public string security { get; set; }
        public string primary_economy { get; set; }
        public string power { get; set; }
        public string power_state { get; set; }
        public int? needs_permit { get; set; }
        public uint updated_at { get; set; }
        public string simbad_ref { get; set; }
    }
}
