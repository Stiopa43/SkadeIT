using Common.Enums;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Project:BaseIdEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Stage Stage { get; set; }
        public string? StageDescription { get; set; }    
        public float Price { get; set; }
        public List<Technology>? Technologies { get; set; } = [];
        public virtual IEnumerable<ProjectPhoto>? ProjectPhotos { get; set; }
    }
}
