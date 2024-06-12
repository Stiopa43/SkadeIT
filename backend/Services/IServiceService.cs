using DTO.ServiceDtos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public interface IServiceService
    {
        List<Project> GetActiveProjects();
        Project Create(ProjectViewModel createServiceViewModel);
        Project UpdateEntity(UpdateProjectDto updateServiceDto, int Id);
        ProjectPhoto UploadPhotoFromFolder(ProjectPhoto servicePhoto);
        List<ProjectPhoto> GetAllPhotos();
        List<ProjectPhoto> GetPhotos(int serviceId);
    }
}
