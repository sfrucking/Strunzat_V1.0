using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Services
{
    public interface IService<T>
    {
        public List<T> Elenco();
        public T Cerca(int id);
        public T Rimuovi(int id);
        public T Aggiungi(T nuovo);
        public T Aggiorna(int id, T up);
    }
}
