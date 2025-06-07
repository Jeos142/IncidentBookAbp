using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.IncidentClassifications;
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
        //Сортировка по умолчанию
        protected override IQueryable<Resolution> ApplyDefaultSorting(IQueryable<Resolution> query)
        {
            return query.OrderBy(x => x.ResolutionName);
        }

    }
}
