
using PrototypePrjEntityFramework.Data;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public class MenuService : IMenuService
    {
        private readonly DataContext _contesto;

        public MenuService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Menu Aggiorna(int p, int r, Menu m)
        {
            /*var piatto = (CercaPerPiatto(p));
            var ristorante = (CercaPerRistorante(r));*/

            //Menu mn = _contesto.Menus.FirstOrDefault(ri => ri.RistoranteId == r && ri.PiattoId == p);
            //_contesto.Entry(mn).CurrentValues.SetValues(m);
            //_contesto.SaveChanges();

            return m;
        }

        public Menu Aggiungi(Menu nuovo)
        {
            if(nuovo == null) 
            {
                return null;
            }
            _contesto.Menus.Add(nuovo);
            return nuovo;
        }

        public List<Menu> CercaPerPiatto(Piatto p)
        {
            var pia = _contesto.Menus.Select(pi => pi.PiattoId == p.Id);

            if (pia is null)
                throw new Exception("Ristorante non trovato");

            return (List<Menu>)pia;
        }

        public List<Menu> CercaPerPiatto(int p)
        {
            throw new NotImplementedException();
        }

        public List<Menu> CercaPerRistorante(Ristorante ris)
        {
            var risto = _contesto.Menus.Where(r => r.RistoranteId == ris.Id).ToList();

            if (risto is null)
                throw new Exception("Ristorante non trovato");

            return risto;
        }

        public List<Menu> CercaPerRistorante(int r)
        {
            throw new NotImplementedException();
        }

        public List<Menu> Elenco()
        {
            return _contesto.Menus.ToList();
        }

        public Menu Remove(Menu mn)
        {
            if(mn == null)
            {
                return null;
            }

            var mndel = _contesto.Menus.FirstOrDefault(ri => ri.PiattoId == mn.PiattoId && ri.RistoranteId == mn.RistoranteId);

            _contesto.Menus.Remove(mndel);
            _contesto.SaveChanges();

            return mndel;
        }

        public Menu Remove(int mn)
        {
            throw new NotImplementedException();
        }
    }
}
