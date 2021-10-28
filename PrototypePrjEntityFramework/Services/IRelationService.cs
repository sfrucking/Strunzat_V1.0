using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public interface IRelationService<T>
    {
        public List<T> Elenca();
        public List<T> CercaPerX(int x);
        public List<T> CercaPerY(int y);
        public T CercaChiaveCombinata(int x, int y);
        public T Aggiungi(T nuovo);
        public T Aggiorna(int x, int y, T up);
        public T Elimina(int x, int y);
    }
}
