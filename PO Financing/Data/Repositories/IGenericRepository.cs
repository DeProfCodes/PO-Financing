using PO_Financing.Models.Entities;
using System.Collections.Generic;

namespace PO_Financing.Data.Repositories
{
    public interface IGenericRepository <T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);  
    }
}
