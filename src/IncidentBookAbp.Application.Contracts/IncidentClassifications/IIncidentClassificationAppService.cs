
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.IncidentClassifications.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IncidentBookAbp.IncidentClassifications
{
    public interface IIncidentClassificationAppService : ICrudAppService<
        IncidentClassificationDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateIncidentClassificationDto>
    {
    }
}
