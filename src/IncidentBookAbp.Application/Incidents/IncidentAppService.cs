using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Clients;
using IncidentBookAbp.Clients.DTO;
using IncidentBookAbp.IncidentClassifications;
using IncidentBookAbp.IncidentClassifications.Dto;
using IncidentBookAbp.Incidents.Dto;
using IncidentBookAbp.Resolutions;
using IncidentBookAbp.Resolutions.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
namespace IncidentBookAbp.Incidents
{
    [Authorize]
    public class IncidentAppService : CrudAppService<
     Incident,
     IncidentDto,
     Guid,
     PagedAndSortedResultRequestDto,
     CreateUpdateIncidentDto
 >, IIncidentAppService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentAppService(IIncidentRepository incidentRepository)
            : base(incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<PagedResultDto<IncidentWithNavigationPropertiesDto>> GetListWithNavigationAsync(PagedResultRequestDto input)
        {
            var totalCount = await _incidentRepository.GetCountAsync();

            var incidents = await _incidentRepository.GetListWithNavigationPropertiesAsync(input.SkipCount, input.MaxResultCount);

            var result = incidents.Select(i =>
            {
                var dto = ObjectMapper.Map<Incident, IncidentWithNavigationPropertiesDto>(i);
                dto.Client = ObjectMapper.Map<Client, ClientDto>(i.Client);
                dto.Classification = ObjectMapper.Map<IncidentClassification, IncidentClassificationDto>(i.Classification);
                dto.Resolution = i.Resolution != null ? ObjectMapper.Map<Resolution, ResolutionDto>(i.Resolution) : null;
                return dto;
            }).ToList();

            return new PagedResultDto<IncidentWithNavigationPropertiesDto>(totalCount, result);
        }
    }


}
