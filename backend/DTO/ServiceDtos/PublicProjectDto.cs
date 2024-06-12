using Common.Enums;
using DTO.BaseDto;
using DTO.TechnologyDto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ServiceDtos
{
    public class PublicProjectDto:BaseIdPublicDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Stage Stage { get; set; }
        public string? StageDescription { get; set; }
        public float Price { get; set; }
        public List<PublicTechnologyDto>? Technologies { get; set; } = [];
        public virtual IEnumerable<ProjectPhoto>? ServicePhotos { get; set; }
        public PublicProjectDto() { }
        public PublicProjectDto(Project service) 
        { 
            Title = service.Title;
            Description = service.Description;
            Stage = service.Stage;
            StageDescription = service.StageDescription;
            Price = service.Price;
            Technologies = (service.Technologies != null) ? service.Technologies.Select(t=>new PublicTechnologyDto(t)).ToList():new List<PublicTechnologyDto>();
            ServicePhotos = (service.ProjectPhotos!=null) ? service.ProjectPhotos : new List<ProjectPhoto>();
        }

    }
}
