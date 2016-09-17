using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSample.Models;

namespace WebSample.DAL
{
    public interface IMasterClass<T>
    {
        IQueryable<T> GetAll(string keyword);
        T GetByID(string id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
