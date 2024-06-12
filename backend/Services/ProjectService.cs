using Common.Exceptions;
using DTO.ServiceDtos;
using Entities;
using Microsoft.AspNetCore.Http;
using Repositories.Interfaces;
using ViewModels;

namespace Services
{
    public class ProjectService : IServiceService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IBaseIdRepository<Technology, int> technologyRepository;
        private readonly IBaseIdRepository<ProjectPhoto, int> photoRepository;

        public ProjectService(IProjectRepository projectRepository, IBaseIdRepository<Technology, int> technologyRepository, 
            IBaseIdRepository<ProjectPhoto, int> photoRepository)
        {
            this.projectRepository = projectRepository;
            this.technologyRepository = technologyRepository;
            this.photoRepository = photoRepository;
        }
        public List<Project> GetActiveProjects()
        {
            return projectRepository.GetActiveFiltered().ToList();
        }
        public List<ProjectPhoto> GetAllPhotos()
        {
            return photoRepository.All().ToList();
        }
        public Project Create(ProjectViewModel createServiceViewModel)
        {
            List<Technology> technologies = technologyRepository.GetByIds(createServiceViewModel.Technologies).ToList();
            projectRepository.Insert(createServiceViewModel.ToDto(technologies).ToEntity());
            projectRepository.SaveChanges();
            return createServiceViewModel.ToDto(technologies).ToEntity();
        }
        public Project UpdateEntity(UpdateProjectDto updateServiceDto, int Id)
        {
            Project project = projectRepository.Get(Id);
            if (project == null)
            {
                throw new CSNotFoundException($"Entity with id {Id} wasn't found,",
                    "can't found entity");
            }
            var technologies = projectRepository.GetTechnologiesOfProject(Id);
            updateServiceDto.UpdateEntity(project, technologies);
            projectRepository.SaveChanges();
            return project;
        }
        public List<ProjectPhoto> UploadPhoto(IFormFileCollection files)
        {
            List<ProjectPhoto> photos = new List<ProjectPhoto>();
            foreach (IFormFile file in files)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            }
            return photos;
        }
        public List<ProjectPhoto> GetPhotos(int projectId)
        {
            Project project = projectRepository.Get(projectId);
            if (project == null)
            {
                throw new CSNotFoundException("Object is not found",
                    $"object with id {projectId} wasn't found");
            }
            List<ProjectPhoto> photos = project.ProjectPhotos.ToList();
            if (photos == null)
                return [];
            return photos;
        }
        public ProjectPhoto UploadPhotoFromFolder(ProjectPhoto servicePhoto)
        {
            ProjectPhoto createPhoto = new()
            {
                FileUrl = servicePhoto.FileUrl,
                ProjectId = servicePhoto.ProjectId,
            };
            photoRepository.InsertAndSave(createPhoto);
            return createPhoto;
        }

    }
}
