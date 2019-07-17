using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_MVC_Repository.Models.DAL
{
    public interface _IALLRepository<T> where T : class
    {
        IEnumerable<T> GetModel();
        T GetModelByID(int modelid);
        void InsertModel(T model);
        void UpdateModel(T model);
        void DeleteModel(int modelID);
        void Save();
    }
}
