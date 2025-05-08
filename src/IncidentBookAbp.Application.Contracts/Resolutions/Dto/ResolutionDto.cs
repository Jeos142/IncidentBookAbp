using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace IncidentBookAbp.Resolutions.Dto
{
    public class ResolutionDto : EntityDto<Guid>
    {
        public string ResolutionName { get; set; }
    }
}
