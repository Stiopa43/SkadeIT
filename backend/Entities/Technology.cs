using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Technology:BaseIdEntity<int>
    {
        public string Title { get; set; }
        public virtual List<Project> Projects { get; set; } = [];
    }
}
