
using PrototypePrjEntityFramework.Data;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public class AllergeneService : IService<Allergene>
    {
        private readonly DataContext _contesto;

        public AllergeneService(DataContext contesto)
        {
            _contesto = contesto;
        }
        public Allergene Aggiorna(int id, Allergene up)
        {
            var al = Cerca(id);

            _contesto.Allergeni.Where(a => a == al);
            _contesto.SaveChanges();

            return al;
        }

        public Allergene Aggiungi(Allergene nuovo)
        {
            var nal = _contesto.Allergeni.Add(nuovo);
            _contesto.SaveChanges();

            return nal.Entity;
        }

        public Allergene Cerca(int id)
        {
            var al = _contesto.Allergeni.FirstOrDefault(a => a.Id == id);

            if (al is null)
                throw new Exception("Ristorante non trovato");

            return al;
        }

        public List<Allergene> Elenco() => _contesto.Allergeni.ToList();

        public Allergene Rimuovi(int id)
        {
            var al = _contesto.Allergeni.Remove(Cerca(id));
            _contesto.SaveChanges();

            return al.Entity;
        }
    }
}
