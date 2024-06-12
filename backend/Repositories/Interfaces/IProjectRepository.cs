using DTO.TechnologyDto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IProjectRepository:IBaseIdRepository<Project, int>
    {
        IQueryable<Project> GetActiveFiltered();
        List<Technology> GetTechnologiesOfProject(int projectId);
    }
}
