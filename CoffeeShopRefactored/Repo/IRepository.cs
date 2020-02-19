using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IRepository<T> where T : class
    {
        void CreateNewEntity(T entity);
        List<T> ReadAll();
        T FindById(int id);

        void UpdateEntity(T entity);
        void DeleteEntity(int id);
        void Save();
    }
}
