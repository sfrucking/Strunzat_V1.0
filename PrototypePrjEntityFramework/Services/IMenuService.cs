
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    interface IMenuService
    {

        public List<Menu> Elenco();
        public List<Menu> CercaPerRistorante(int r);
        public List<Menu> CercaPerPiatto(int p);
        public Menu Aggiungi(Menu nuovo);
        public Menu Aggiorna(int p, int r, Menu m);
        public Menu Remove(int mn);

    }
}
