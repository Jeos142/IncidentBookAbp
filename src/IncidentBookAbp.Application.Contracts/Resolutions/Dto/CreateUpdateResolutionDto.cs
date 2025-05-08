using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentBookAbp.Resolutions.Dto
{
    public class CreateUpdateResolutionDto
    {
        [Required]
        public string ResolutionName { get; set; }
    }
}
