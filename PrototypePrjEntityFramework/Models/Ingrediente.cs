using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string nomeIngrediente { get; set; }
        public List<Procedimenti> Ingredienti { get; set; }
    }
}
