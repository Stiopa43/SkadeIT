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
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "FileUrl can't be longer than 30 characters.")]
        public string Title { get; set; }
        [MaxLength(500, ErrorMessage = "FileUrl can't be longer than 500 characters.")]
        public string Description { get; set; }
        public Stage Stage { get; set; }
        public string? StageDescription { get; set; }
        public float Price { get; set; }
        public List<Technology>? Technologies { get; set; }
        public void UpdateEntity(Project entity, List<Technology> technologies)
        {
            entity.Title = Title;
            entity.Description = Description;
            entity.Stage = Stage;
            entity.StageDescription = StageDescription;
            entity.Price = Price;
            entity.Technologies = technologies;
        }
    }
}
