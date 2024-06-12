using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BaseDto
{
    public abstract class BaseIdPublicDto<TId> : BasePublicDto
    {
        public TId Id { get; set; }

        public BaseIdPublicDto()
        {
        }

        public BaseIdPublicDto(BaseIdEntity<TId> entity)
            : base(entity)
        {
            Id = entity.Id;
        }
    }
}
