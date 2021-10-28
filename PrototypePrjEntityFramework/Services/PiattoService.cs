
using PrototypePrjEntityFramework.Data;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public class PiattoService : IService<Piatto>
    {

        private readonly DataContext _contesto;

        public PiattoService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Piatto Aggiorna(int id, Piatto up)
        {
            /*
            var piatto = Cerca(id);

            _contesto.Piatti.Update(up).Where(p => p == piatto);
            */

            var ris = _contesto.Piatti.Update(up);
            _contesto.SaveChanges();

            return ris.Entity;
        }

        public Piatto Aggiungi(Piatto nuovo)
        {
            var nuovoPiatto = _contesto.Piatti.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoPiatto.Entity;
        }

        public Piatto Cerca(int id)
        {
            var piatto = _contesto.Piatti.FirstOrDefault(p => p.Id == id);

            if (piatto is null)
                throw new Exception("Ristorante non trovato");

            return piatto;
        }

        public List<Piatto> Elenco()
        {
            return _contesto.Piatti.ToList();
        }

        public Piatto Rimuovi(int id)
        {
            var piatto = _contesto.Piatti.Remove(Cerca(id));
            _contesto.SaveChanges();

            return piatto.Entity;
        }
    }
}
