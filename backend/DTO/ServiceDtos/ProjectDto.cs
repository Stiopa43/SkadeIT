using Common.Enums;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ServiceDtos
{
    public class ProjectDto
    {
        [MaxLength(30, ErrorMessage = "FileUrl can't be longer than 30 characters.")]
        public string Title { get; set; }
        [MaxLength(500, ErrorMessage = "FileUrl can't be longer than 500 characters.")]
        public string Description { get; set; }
        public Stage Stage { get; set; }
        public string? StageDescription { get; set; }
        public float Price { get; set; }
        public List<Technology>? Technologies { get; set; }
        public Project ToEntity()
        {
            return new Project { Title = Title, Description = Description, Stage = Stage, StageDescription = StageDescription,
                Technologies = Technologies
            };
        }
    }
}
