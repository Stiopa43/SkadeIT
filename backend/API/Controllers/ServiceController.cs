using DTO;
using DTO.ServiceDtos;
using DTO.TechnologyDto;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Services;
using ViewModels;

namespace API.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IProjectRepository serviceRepository;
        private readonly DbDataSeeder dataSeeder;
        private readonly IServiceService serviceService;

        public ServiceController(IProjectRepository serviceRepository, DbDataSeeder dataSeeder, IServiceService serviceService)
        {
            this.serviceRepository = serviceRepository;
            this.dataSeeder = dataSeeder;
            this.serviceService = serviceService;
        }
        [HttpGet]
        public List<Project> GetAll()
        {
            return serviceService.GetActiveProjects();
        }
        [HttpGet("{projectId}/technologies")]
        public List<Technology> GetAllTechnologies([FromQuery] int projectId)
        {
            return serviceRepository.GetTechnologiesOfProject(projectId);
        }
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return serviceRepository.Get(id);
        }
        [HttpGet("{id}/Photos")]
        public List<ProjectPhoto> GetPhoto([FromQuery] int id)
        {
            return serviceService.GetPhotos(id);
        }
        [HttpDelete("{id}")]
        public bool Delete([FromQuery] int id)
        {
            return serviceRepository.DeleteAndSave(id);
        }
        [HttpDelete("all")]
        public bool DeleteAdd()
        {
            return serviceRepository.ForceDeleteAll();
        }
        [HttpPost]
        public Project Create(ProjectViewModel createServiceDto)
        {
            return serviceService.Create(createServiceDto);
        }
        [HttpPost("{serviceId}/Photo")]
        public ProjectPhoto UploadPhoto([FromQuery] int serviceId, [FromBody] CreatePhotoDto servicePhoto)
        {
            return serviceService.UploadPhotoFromFolder(servicePhoto.ToEntity());
        }
        [HttpPut("/{Id}")]
        public Project Update(UpdateProjectViewModel updateServiceDto, int Id)
        {
            return serviceService.UpdateEntity(updateServiceDto.ToDto(), Id);
        }
        [HttpPost("seed")]
        public void SeedData()
        {
            dataSeeder.Seed();
        }
    }
}
