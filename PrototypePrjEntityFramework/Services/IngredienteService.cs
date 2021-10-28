
using PrototypePrjEntityFramework.Data;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public class IngredienteService : IService<Ingrediente>
    {
        private readonly DataContext _contesto;

        public IngredienteService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Ingrediente Aggiorna(int id, Ingrediente up)
        {
            var ing = Cerca(id);

            _contesto.Ingredienti.Where(p => p == ing);
            _contesto.SaveChanges();

            return ing;
        }

        public Ingrediente Aggiungi(Ingrediente nuovo)
        {
            var nuovoIng = _contesto.Ingredienti.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoIng.Entity;
        }

        public Ingrediente Cerca(int id)
        {
            var ing = _contesto.Ingredienti.FirstOrDefault(p => p.Id == id);

            if (ing is null)
                throw new Exception("Ingrediente non trovato");

            return ing;
        }

        public List<Ingrediente> Elenco() => _contesto.Ingredienti.ToList();

        public Ingrediente Rimuovi(int id)
        {
            var ing = _contesto.Ingredienti.Remove(Cerca(id));
            _contesto.SaveChanges();

            return ing.Entity;
        }
    }
}
