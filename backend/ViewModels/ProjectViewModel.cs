using Common.Enums;
using DTO.ServiceDtos;
using Entities;

namespace ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public Stage Stage { get; set; }
        public string? StageDescription { get; set; }
        public float Price { get; set; }
        public IEnumerable<int>? Technologies { get; set; }
        public ProjectDto ToDto(List<Technology> technologies)
        {
            return new ProjectDto
            {
                Title = Title,
                Description = Description,
                Stage = Stage,
                StageDescription = StageDescription,
                Technologies = technologies
            };
        }
    }
}
