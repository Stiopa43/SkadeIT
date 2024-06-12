using Common.Enums;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Favor:BaseIdEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Technology> Technologies { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
