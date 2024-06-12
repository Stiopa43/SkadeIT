using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProjectPhoto:BaseIdEntity<int>
    {
        public string FileUrl { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
