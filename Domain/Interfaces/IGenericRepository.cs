using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        T Add(T entity); // no va void porque no se puede agregar el vacio
        void Update(T entity);
        void Delete(int id);


    }
}