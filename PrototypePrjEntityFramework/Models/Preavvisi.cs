using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Models
{
    public class Preavvisi
    {
        public int PiattoId { get; set; }
        public int AllergeneId { get; set; }
        public Piatto Piatto { get; set; }
        public Allergene Allergene { get; set; }
    }
}
