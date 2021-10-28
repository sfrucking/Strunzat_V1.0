using PrototypePrjEntityFramework.Data;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public class ProcedimentoService : IRelationService<Procedimenti>
    {
        private readonly DataContext _contesto;

        public ProcedimentoService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Procedimenti Aggiorna(int x, int y, Procedimenti up)
        {
            Procedimenti p = _contesto.Procedimenti.FirstOrDefault(ri => ri.PiattoId == x && ri.IngredienteId == y);
            _contesto.Entry(p).CurrentValues.SetValues(up);
            _contesto.SaveChanges();

            return p;
        }

        public Procedimenti Aggiungi(Procedimenti nuovo)
        {
            var nuovoP = _contesto.Procedimenti.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoP.Entity;
        }

        public Procedimenti CercaChiaveCombinata(int x, int y)
        {
            var pr = _contesto.Procedimenti.FirstOrDefault(ri => ri.PiattoId == x && ri.IngredienteId == y);

            return pr;
        }

        public List<Procedimenti> CercaPerX(int x)
        {
            var pia = _contesto.Procedimenti.Where(p => p.PiattoId == x).ToList();

            if (pia is null)
                throw new Exception("Piatto non trovato");

            return pia;
        }

        public List<Procedimenti> CercaPerY(int y)
        {
            var ing = _contesto.Procedimenti.Where(p => p.PiattoId == y).ToList();

            if (ing is null)
                throw new Exception("Ingrediente non trovato");

            return ing;
        }

        public List<Procedimenti> Elenca() => _contesto.Procedimenti.ToList();

        public Procedimenti Elimina(int x, int y)
        {
            Procedimenti pr = _contesto.Procedimenti.FirstOrDefault(ri => ri.PiattoId == x && ri.IngredienteId == y);
            _contesto.Procedimenti.Remove(pr);
            _contesto.SaveChanges();

            return pr;
        }
    }
}
