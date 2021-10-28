using Microsoft.EntityFrameworkCore;
using PrototypePrjEntityFramework.Data;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace PrototypePrjEntityFramework.Services
{
    public class RistoranteService : IService<Ristorante>
    {

        private readonly DataContext _contesto;

        public RistoranteService(DataContext contesto)
        {
            _contesto = contesto;
        }
        
        public Ristorante Aggiorna(int id, Ristorante up)
        {
            up.Id = id;
            var ris = _contesto.Ristoranti.Find(up.Id);

            _contesto.Ristoranti.Update(up);
            _contesto.SaveChanges();

            return ris;

            /*
            _contesto.Entry(ris).CurrentValues.SetValues(up);

            if (ris == null)
            {
                return null;
            }
            */

            //_contesto.Entry(ris).Property(p => p.NomeRistorante).IsModified = false;
            /*
           if (up.NomeRistorante != ris.NomeRistorante)
           {
               _contesto.Entry(ris).Property(p => p.NomeRistorante).IsModified = false;
           }
          */

            //string currentName1 = _contesto.Entry(ris).Property(u => u.).CurrentValue;

            /*
            foreach(PropertyInfo propertyRS in ris.GetType().GetProperties())
            {
                foreach(PropertyInfo propertyUP in up.GetType().GetProperties())
                {
                    if (propertyRS.Name.ToLower().EndsWith("id"))
                    {
                        break;
                    }

                    if(propertyUP.GetValue(up) == null && !propertyUP.Name.ToString().EndsWith("id") && propertyUP.Name == propertyRS.Name)
                    {
                        object val = propertyRS.GetValue(ris);
                        propertyUP.SetValue(ris, val);
                    }
                }
            }
            */
            //_contesto.Entry(ris).CurrentValues.SetValues(up);
            //((IObjectContextAdapter)_contesto).ObjectContext.ApplyCurrentValues("Ristorante", up);

        }

        public Ristorante Aggiungi(Ristorante nuovo)
        {
            var nuovoRis = _contesto.Ristoranti.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoRis.Entity;
        }

        public Ristorante Cerca(int id)
        {
            var ris = _contesto.Ristoranti.FirstOrDefault(r => r.Id == id);

            if(ris is null)
                throw new Exception("Ristorante non trovato");

            return ris;
        }

        public List<Ristorante> Elenco()
        {
            //return _contesto.Ristoranti.Include(m => m.Menus).ThenInclude(p => p.Piatto).ToList();
            return _contesto.Ristoranti.ToList();
        }

        public Ristorante Rimuovi(int id)
        {
            var toBeRemoved = _contesto.Ristoranti.FirstOrDefault(ris => ris.Id == id);

            if (toBeRemoved is null)
            {
                return toBeRemoved;
            }

            _contesto.Ristoranti.Remove(toBeRemoved);
            _contesto.SaveChanges();
            return toBeRemoved;
        }

    }
}
