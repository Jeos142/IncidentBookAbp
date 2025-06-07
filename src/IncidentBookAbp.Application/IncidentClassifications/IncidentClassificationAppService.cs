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
using System.Linq.Dynamic.Core; 
using System.Threading.Tasks;  
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
        // Сортировка по умолчанию
        protected override IQueryable<IncidentClassification> ApplyDefaultSorting(IQueryable<IncidentClassification> query)
        {
            return query.OrderBy(x => x.ClassificationName);
        }

    }
}