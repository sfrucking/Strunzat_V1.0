using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Models
{
    public class Ristorante
    {
        public int Id { get; set; }
        public string NomeRistorante { get; set; }
        public string RagioneSociale { get; set; }
        public string PIVA { get; set; }
        public string Regione { get; set; }
        public string Citta { get; set; }
        public string Via { get; set; }
        public int NCivico { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
