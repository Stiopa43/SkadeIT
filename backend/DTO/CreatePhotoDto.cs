using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreatePhotoDto
    {
        public string FileUrl { get; set; } = "";

        public int ProjectId { get; set; }
        public ProjectPhoto ToEntity()
        {
            return new ProjectPhoto { 
                FileUrl = FileUrl, 
                ProjectId = ProjectId
            };
        }
    }
}
