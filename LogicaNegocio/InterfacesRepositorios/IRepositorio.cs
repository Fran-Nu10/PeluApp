using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        void Add(T nuevo);
        List<T> FindAll();
        T FindById(int id);
        void Remove(int id);
        void Update(T obj);
    }
}

