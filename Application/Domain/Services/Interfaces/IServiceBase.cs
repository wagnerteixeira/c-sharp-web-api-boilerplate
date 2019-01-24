using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        string Add(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        string Update(T entity);
        string Remove(int id);
        void Dispose();
    }
}
