using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace IncidentBookAbp.IncidentClassifications
{
    public class IncidentClassification : Entity<Guid>
    {
        public string ClassificationName { get; set; }

       
    }
}
