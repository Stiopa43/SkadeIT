using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IBaseRepository<T>
         where T : BaseEntity
    {

        int Count();
        int ArchivedCount();
        IQueryable<T> All();
        T Insert(T entity);
       
        T InsertAndSave(T entity);
        IEnumerable<T> InsertRangeAndSave(IEnumerable<T> entities);
        T Update(T entity);
        bool Archivate(T entity);
        bool ArchivateAndSave(T entity);
        bool ForceDeleteAll();
        bool Delete(T entity);
        bool DeleteAndSave(T entity);
        int SaveChanges();
    }
}
