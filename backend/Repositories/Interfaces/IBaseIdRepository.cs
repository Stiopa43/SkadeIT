using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IBaseIdRepository<T, in TId> : IBaseRepository<T>
        where T : BaseIdEntity<TId>
    {
        T Get(TId entityId);
        IQueryable<T> GetByIds(IEnumerable<TId> entitiesIds);
        bool Archivate(TId entityId);
        bool ArchivateAndSave(TId entityId);
        bool UnarchivateAndSave(TId entityId);
        bool Delete(TId entityId);
        bool DeleteAndSave(TId entityId);
        bool ForceDeleteAndSave(TId entityId);
    }
}
