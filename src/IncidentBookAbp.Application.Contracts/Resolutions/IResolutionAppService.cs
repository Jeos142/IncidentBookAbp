using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Resolutions.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IncidentBookAbp.Resolutions
{
    public interface IResolutionAppService : ICrudAppService<
       ResolutionDto,
       Guid,
       PagedAndSortedResultRequestDto,
       CreateUpdateResolutionDto>
    {
    }
}
