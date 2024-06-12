using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPhotoRepository:IBaseIdRepository<ProjectPhoto, int>
    {
        IQueryable<ProjectPhoto> GetActivePhotos();
    }
}
