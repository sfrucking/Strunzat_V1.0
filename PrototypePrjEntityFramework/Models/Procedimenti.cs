using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Models
{
    public class Procedimenti
    {
        public int PiattoId { get; set; }
        public int IngredienteId { get; set; }
        public Piatto Piatto { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
