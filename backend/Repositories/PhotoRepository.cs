using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PhotoRepository:BaseIdRepository<ProjectPhoto, int>,IPhotoRepository
    {
        public PhotoRepository(ProjectDbContext dbContext):base(dbContext) 
        { 
        }
        public IQueryable<ProjectPhoto> GetActivePhotos()
        {
            return WithMainIncludes(AvailableEntities);
        }
        private IQueryable<ProjectPhoto> WithMainIncludes(IQueryable<ProjectPhoto> photos)
        {
            return photos.Include(p=>p.Project);
        }
    }
}
