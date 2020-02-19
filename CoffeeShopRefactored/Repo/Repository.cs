using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Pocos;


namespace Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Model1 db;
        private DbSet<T> table;

        public Repository()
        {
            this.db = new Model1();
            this.table = db.Set<T>();
        }
        //public Repository(DbSet objects)
        //{
            
        //}
        public Repository(Model1 db)
        {
            this.db = db;
            this.table = db.Set<T>();
        }

        public void CreateNewEntity(T entity)
        {
            table.Add(entity);
            db.SaveChanges();
        }
        public List<T> ReadAll()
        {
            return table.ToList();
        }
        public T FindById(int id)
        {
            return table.Find(id);
        }
        public void UpdateEntity(T entity)
        {
            db.Set<T>().AddOrUpdate(entity);
            db.SaveChanges();
        }
        public void DeleteEntity(int id)
        {
            T entity = table.Find(id);
            table.Remove(entity);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
