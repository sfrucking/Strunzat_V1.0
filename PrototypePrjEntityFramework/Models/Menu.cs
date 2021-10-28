using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Models
{
    public class Menu
    {
        public int RistoranteId { get; set; }
        public int PiattoId { get; set; }
        public float Prezzo { get; set; }
        [JsonIgnore]
        public Ristorante Ristorante { get; set; }
        public Piatto Piatto { get; set; }
    }
}
