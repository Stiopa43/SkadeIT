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
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly ProjectDbContext DbContext;
        protected DbSet<T> Entities;
        protected IQueryable<T> AvailableEntities
        {
            get
            {
                return Entities
                    .Where(e => !e.IsArchieved && !e.IsDeleted);
            }
        }
        protected IQueryable<T> EntitiesFromArchive
        {
            get
            {
                return Entities
                    .Where(e => e.IsArchieved && !e.IsDeleted);
            }
        }
        protected IQueryable<T> EntitiesFromCan
        {
            get
            {
                return Entities
                    .Where(e => e.IsDeleted);
            }
        }

        public BaseRepository(ProjectDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = dbContext.Set<T>();
        }

        public int Count()
        {
            return AvailableEntities
                .Count();
        }

        public int ArchivedCount()
        {
            return EntitiesFromArchive
                .Count();
        }

        public IQueryable<T> All()
        {
            return AvailableEntities;
        }


        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entity)}` is null!",
                    "Error! There is no data passed.");
            }

            Entities.Add(entity);

            return entity;
        }

        public virtual T InsertAndSave(T entity)
        {
            if (entity == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entity)}` is null!",
                    "Error! There is no data passed.");
            }

            Entities.Add(entity);

            SaveChanges();

            return entity;
        }

        public virtual IEnumerable<T> InsertRangeAndSave(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entities)}` is null!",
                    "Error! There is no data passed.");
            }

            if (entities.Count() == 0)
            {
                return entities;
            }

            Entities.AddRange(entities);

            SaveChanges();

            return entities;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entity)}` is null!",
                    "Error! There is no data passed.");
            }

            Entities.Update(entity);

            SaveChanges();

            return entity;
        }

        public bool Archivate(T entity)
        {
            if (entity == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entity)}` is null!",
                    "Error! There is no data passed.");
            }

            entity.IsArchieved = true;

            Entities.Update(entity);

            return true;
        }

        public bool ArchivateAndSave(T entity)
        {
            if (entity == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entity)}` is null!",
                    "Error! There is no data passed.");
            }

            entity.IsArchieved = true;

            Entities.Update(entity);

            return SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entity)}` is null!",
                    "Error! There is no data passed.");
            }

            entity.IsDeleted = true;

            Entities.Update(entity);

            return true;
        }
        public bool ForceDeleteAll()
        {
            if (EntitiesFromCan == null || !EntitiesFromCan.Any())
            {
                throw new CSNotFoundException(
                    $"There are no entities typeof `{typeof(T)} in can`",
                    "There is nothing to delete"
                    );
            }
            DbContext.RemoveRange(EntitiesFromCan);
            return SaveChanges() > 0;
        }
        public bool DeleteAndSave(T entity)
        {
            if (entity == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(entity)}` is null!",
                    "Error! There is no data passed.");
            }

            entity.IsDeleted = true;

            Entities.Update(entity);

            return SaveChanges() > 0;
        }
        public int SaveChanges()
        {
            return DbContext
                .SaveChanges();
        }
    }
}
