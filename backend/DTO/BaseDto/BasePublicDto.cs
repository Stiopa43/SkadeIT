using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BaseDto
{
    public abstract class BasePublicDto
    {
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? LastModifiedDateUtc { get; set; }

        public BasePublicDto()
        {
        }

        public BasePublicDto(BaseEntity entity)
        {
            CreatedDateUtc = entity.CreatedDateUtc;
            LastModifiedDateUtc = entity.LastModifiedDateUtc;
        }
    }
}
