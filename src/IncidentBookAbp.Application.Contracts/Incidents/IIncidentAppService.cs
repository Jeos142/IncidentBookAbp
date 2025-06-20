using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Incidents.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IncidentBookAbp.Incidents
{
    public interface IIncidentAppService : ICrudAppService<
       IncidentDto,
       Guid,
       PagedAndSortedResultRequestDto,
       CreateUpdateIncidentDto>
    {
        Task<PagedResultDto<IncidentWithNavigationPropertiesDto>> GetListWithNavigationAsync(PagedResultRequestDto input);


    }
}
