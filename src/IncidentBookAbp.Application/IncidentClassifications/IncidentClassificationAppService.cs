using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.IncidentClassifications.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IncidentBookAbp.IncidentClassifications
{
    [Authorize]
    public class IncidentClassificationAppService : CrudAppService<
       IncidentClassification,
       IncidentClassificationDto,
       Guid,
       PagedAndSortedResultRequestDto,
       CreateUpdateIncidentClassificationDto
   >, IIncidentClassificationAppService
    {
        public IncidentClassificationAppService(IRepository<IncidentClassification, Guid> repository)
            : base(repository)
        {

        }
        // Сортировка
        public override async Task<PagedResultDto<IncidentClassificationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var classifications = await queryable
                .OrderBy(x => x.ClassificationName) 
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<IncidentClassificationDto>(
                totalCount,
                ObjectMapper.Map<List<IncidentClassification>, List<IncidentClassificationDto>>(classifications)
            );
        }

    }
}