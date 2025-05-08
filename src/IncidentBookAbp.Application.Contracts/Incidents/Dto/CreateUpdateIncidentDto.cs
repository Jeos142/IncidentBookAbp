using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentBookAbp.Incidents.Dto
{
    public class CreateUpdateIncidentDto
    {
        [Required]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsComplete { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid ClassificationId { get; set; }

        public Guid? ResolutionId { get; set; }
    }
}
