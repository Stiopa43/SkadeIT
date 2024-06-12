using Common.Enums;
using DTO.ServiceDtos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UpdateProjectViewModel
    {
        public string? Title { get; set; }
        public string Description { get; set; }
        public Stage Stage { get; set; }
        public string? StageDescription { get; set; }
        public float Price { get; set; }
        public List<int>? TechnologyIds { get; set; }
        public UpdateProjectDto ToDto()
        {
            return new UpdateProjectDto
            {
                Title = Title,
                Description = Description,
                Stage = Stage,
                StageDescription = StageDescription,
                Technologies = []
            };
        }
    }
}
