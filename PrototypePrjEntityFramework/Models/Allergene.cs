using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Models
{
    public class Allergene
    {
        public int Id { get; set; }
        public string AllergeneNome { get; set; }
        public List<Preavvisi> Allergeni { get; set; }
    }
}
