using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Incidents;
using Volo.Abp.Domain.Entities;

namespace IncidentBookAbp.Resolutions
{
    public class Resolution : Entity<Guid>
    {
       
        public string ResolutionName { get; set; }

        

        
    }
}
