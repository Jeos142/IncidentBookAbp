using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Clients;
using IncidentBookAbp.IncidentClassifications;
using IncidentBookAbp.Resolutions;
using Volo.Abp.Domain.Entities;

namespace IncidentBookAbp.Incidents
{
    public class Incident : Entity<Guid>
    {
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsComplete { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid ClassificationId { get; set; }
        public IncidentClassification Classification { get; set; }
        public Guid? ResolutionId { get; set; }
        public Resolution Resolution { get; set; }

    }
}
