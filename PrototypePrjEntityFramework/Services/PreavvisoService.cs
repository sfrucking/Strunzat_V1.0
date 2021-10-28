
using PrototypePrjEntityFramework.Data;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public class PreavvisoService : IRelationService<Preavvisi>
    {
        private readonly DataContext _contesto;

        public PreavvisoService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Preavvisi Aggiorna(int x, int y, Preavvisi up)
        {
            Preavvisi p = _contesto.Preavvisi.FirstOrDefault(ri => ri.PiattoId == x && ri.AllergeneId == y);
            _contesto.Entry(p).CurrentValues.SetValues(up);
            _contesto.SaveChanges();

            return p;
        }

        public Preavvisi Aggiungi(Preavvisi nuovo)
        {
            var nuovoP = _contesto.Preavvisi.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoP.Entity;
        }

        public Preavvisi CercaChiaveCombinata(int x, int y)
        {
            var pr = _contesto.Preavvisi.FirstOrDefault(ri => ri.PiattoId == x && ri.AllergeneId == y);

            return pr;
        }

        public List<Preavvisi> CercaPerX(int x)
        {
            var pia = _contesto.Preavvisi.Where(p => p.PiattoId == x).ToList();

            if (pia is null)
                throw new Exception("Piatto non trovato");

            return pia;
        }

        public List<Preavvisi> CercaPerY(int y)
        {
            var all = _contesto.Preavvisi.Where(p => p.AllergeneId == y).ToList();

            if (all is null)
                throw new Exception("Piatto non trovato");

            return all;
        }

        public List<Preavvisi> Elenca() => _contesto.Preavvisi.ToList();

        public Preavvisi Elimina(int x, int y)
        {
            Preavvisi pr = _contesto.Preavvisi.FirstOrDefault(ri => ri.PiattoId == x && ri.AllergeneId == y);
            _contesto.Preavvisi.Remove(pr);
            _contesto.SaveChanges();

            return pr;
        }
    }
}
