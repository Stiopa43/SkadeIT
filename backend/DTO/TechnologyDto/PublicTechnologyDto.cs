using DTO.BaseDto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TechnologyDto
{
    public class PublicTechnologyDto:BaseIdPublicDto<int>
    {
        public string Title { get; set; }
        public PublicTechnologyDto() 
        {
        }
        public PublicTechnologyDto(Technology technology)
        {
            Title = technology.Title;
        }
    }
}
