using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.TechnologyDto
{
    public class CreateTechnologyDto
    {
        public string Title { get; set; }
        public Technology ToEntity()
        {
            return new Technology() 
            { 
                Title = Title
            };
        }
    }
}
