using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentBookAbp.IncidentClassifications.Dto
{
    public class CreateUpdateIncidentClassificationDto
    {
        [Required]
        public string ClassificationName { get; set; }
    }
}
