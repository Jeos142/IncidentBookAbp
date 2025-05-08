using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace IncidentBookAbp.Incidents.Dto
{
    public class IncidentDto : EntityDto<Guid>
    {
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsComplete { get; set; }

        public Guid ClientId { get; set; }
        public Guid ClassificationId { get; set; }
        public Guid? ResolutionId { get; set; }
    }
}
