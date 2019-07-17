using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_MVC_Repository.Models.DAL
{
    public class AllRepository<T> : _IALLRepository<T> where T : class
    {
        private StudentDBEntities _context;
        private IDbSet<T> dbEntity;

        public AllRepository()
        {
            _context = new StudentDBEntities();
            dbEntity = _context.Set<T>();
        }

        public void DeleteModel(int modelID)
        {
            T model = dbEntity.Find(modelID);
            dbEntity.Remove(model);
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelByID(int modelid)
        {
            return dbEntity.Find(modelid);
        }

        public void InsertModel(T model)
        {
            dbEntity.Add(model);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
    }
}