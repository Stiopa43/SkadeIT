using Common.Exceptions;
using DTO.ServiceDtos;
using DTO.TechnologyDto;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories
{
    public class ProjectRepository:BaseIdRepository<Project, int>, IProjectRepository
    {
        public ProjectRepository(ProjectDbContext dbContext):base(dbContext)
        {
        }
        public IQueryable<Project> GetActiveFiltered()
        {
            IQueryable<Project> projects = WithMainIncludes(AvailableEntities);
            return projects;
        }
        public List<Technology> GetTechnologiesOfProject(int projectId)
        {
            Project project = Get(projectId);
            if(project == null)
            {
                throw new CSBadRequestException(
                    $"Argument `{nameof(projectId)}` is null!",
                    "Error! There is no data passed.");
            }
            return project.Technologies.ToList() ??[];
        }
        
        private IQueryable<Project> WithMainIncludes(IQueryable<Project> projects)
        {
            return projects.Include(s=>s.Technologies.Where(t=>!t.IsDeleted&& !t.IsArchieved))
                .Include(s=>s.ProjectPhotos.Where(t => !t.IsDeleted && !t.IsArchieved));
        }
    }
}
