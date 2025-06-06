using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Resolutions.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IncidentBookAbp.Resolutions
{
    [Authorize]
    public class ResolutionAppService : CrudAppService<
         Resolution,
         ResolutionDto,
         Guid,
         PagedAndSortedResultRequestDto,
         CreateUpdateResolutionDto
     >, IResolutionAppService
    {
        public ResolutionAppService(IRepository<Resolution, Guid> repository)
            : base(repository)
        {
        }
        //Сортировка
        public override async Task<PagedResultDto<ResolutionDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var resolutions = await queryable
                .OrderBy(x => x.ResolutionName) 
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ResolutionDto>(
                totalCount,
                ObjectMapper.Map<List<Resolution>, List<ResolutionDto>>(resolutions)
            );
        }

    }
}
