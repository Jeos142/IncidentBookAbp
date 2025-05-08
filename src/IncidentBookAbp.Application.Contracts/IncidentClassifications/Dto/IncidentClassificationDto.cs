using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace IncidentBookAbp.IncidentClassifications.Dto
{
    public class IncidentClassificationDto : EntityDto<Guid>
    {
        public string ClassificationName { get; set; }
    }
}
