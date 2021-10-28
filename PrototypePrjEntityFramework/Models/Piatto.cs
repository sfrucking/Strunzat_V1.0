using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Models
{
    public class Piatto
    {
        public int Id { get; set; }
        public string NomePiatto { get; set; }
        public List<Procedimenti> Ingredienti { get; set; }
        public List<Preavvisi> Allergeni { get; set; }
        [JsonIgnore]
        public List<Menu> Menus { get; set; }
    }
}
