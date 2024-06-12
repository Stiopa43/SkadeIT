using Common.Exceptions;
using Entities;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Base
{
    public class BaseIdRepository<T, TId> : BaseRepository<T>, IBaseIdRepository<T, TId>
        where T : BaseIdEntity<TId>
    {
        public BaseIdRepository(ProjectDbContext dbContext)
            : base(dbContext)
        {
        }

        public virtual T Get(TId entityId)
        {
            return AvailableEntities
                .FirstOrDefault(f => f.Id.Equals(entityId));
        }

        public virtual T GetFromArchive(TId entityId)
        {
            return EntitiesFromArchive
                .FirstOrDefault(f => f.Id.Equals(entityId));
        }

        public virtual IQueryable<T> GetByIds(IEnumerable<TId> entitiesIds)
        {
            return AvailableEntities
                .Where(f => entitiesIds.Contains(f.Id));
        }

        public bool Archivate(TId entityId)
        {
            T dbEntity = Get(entityId);

            if (dbEntity == null)
            {
                throw new CSNotFoundException(dbEntity.GetType(), entityId.ToString());
            }

            dbEntity.IsArchieved = true;

            return true;
        }

        public bool ArchivateAndSave(TId entityId)
        {
            T dbEntity = Get(entityId);

            if (dbEntity == null)
            {
                throw new CSNotFoundException(dbEntity.GetType(), entityId.ToString());
            }

            dbEntity.IsArchieved = true;

            return SaveChanges() > 0;
        }

        public bool UnarchivateAndSave(TId entityId)
        {
            T dbEntity = GetFromArchive(entityId);

            if (dbEntity == null)
            {
                throw new CSNotFoundException(dbEntity.GetType(), entityId.ToString());
            }

            dbEntity.IsArchieved = false;

            return SaveChanges() > 0;
        }

        public bool Delete(TId entityId)
        {
            T dbEntity = Entities
                .FirstOrDefault(f => f.Id.Equals(entityId));

            if (dbEntity == null)
            {
                throw new CSNotFoundException(dbEntity.GetType(), entityId.ToString());
            }

            dbEntity.IsDeleted = true;

            return true;
        }

        public virtual bool DeleteAndSave(TId entityId)
        {
            T dbEntity = Entities
                .FirstOrDefault(f => f.Id.Equals(entityId));

            if (dbEntity == null)
            {
                throw new CSNotFoundException(dbEntity.GetType(), entityId.ToString());
            }

            dbEntity.IsDeleted = true;

            return SaveChanges() > 0;
        }

        public virtual bool ForceDeleteAndSave(TId entityId)
        {
            T dbEntity = Entities
                .FirstOrDefault(f => f.Id.Equals(entityId));

            if (dbEntity == null)
            {
                throw new CSNotFoundException(dbEntity.GetType(), entityId.ToString());
            }

            Entities.Remove(dbEntity);

            return SaveChanges() > 0;
        }
    }
}
