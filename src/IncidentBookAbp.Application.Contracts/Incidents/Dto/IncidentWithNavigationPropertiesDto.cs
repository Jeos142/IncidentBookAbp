using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Clients.DTO;
using IncidentBookAbp.IncidentClassifications.Dto;
using IncidentBookAbp.Resolutions.Dto;

namespace IncidentBookAbp.Incidents.Dto
{
    public class IncidentWithNavigationPropertiesDto
    {
        public IncidentDto Incident { get; set; }
        public ClientDto Client { get; set; }
        public IncidentClassificationDto Classification { get; set; }
        public ResolutionDto Resolution { get; set; }
    }
}
