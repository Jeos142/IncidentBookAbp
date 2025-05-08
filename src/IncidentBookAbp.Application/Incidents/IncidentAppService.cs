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

namespace IncidentBookAbp.Incidents
{

    public class IncidentAppService : CrudAppService<
         Incident,
         IncidentDto,
         Guid,
         PagedAndSortedResultRequestDto,
         CreateUpdateIncidentDto
     >, IIncidentAppService
    {
        private readonly IRepository<Incident, Guid> _incidentRepository;
        private readonly IRepository<Client, Guid> _clientRepository;
        private readonly IRepository<IncidentClassification, Guid> _classificationRepository;
        private readonly IRepository<Resolution, Guid> _resolutionRepository;

        public IncidentAppService(
        IRepository<Incident, Guid> incidentRepository,
        IRepository<Client, Guid> clientRepository,
        IRepository<IncidentClassification, Guid> classificationRepository,
        IRepository<Resolution, Guid> resolutionRepository)
        : base(incidentRepository)
            {
                _incidentRepository = incidentRepository;
                _clientRepository = clientRepository;
                _classificationRepository = classificationRepository;
                _resolutionRepository = resolutionRepository;
            }
        public async Task<PagedResultDto<IncidentWithNavigationPropertiesDto>> GetListWithNavigationAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await _incidentRepository.WithDetailsAsync();
            query = query.OrderByDescending(i => i.DateTime); //сортировка
            var totalCount = await AsyncExecuter.CountAsync(query);
            var incidents = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            var result = new List<IncidentWithNavigationPropertiesDto>();

            foreach (var incident in incidents)
            {
                var client = await _clientRepository.GetAsync(x => x.Id == incident.ClientId);
                var classification = await _classificationRepository.GetAsync(x => x.Id == incident.ClassificationId);

                Resolution resolution = null;
                if (incident.ResolutionId.HasValue)
                {
                    resolution = await _resolutionRepository.GetAsync(x => x.Id == incident.ResolutionId.Value);
                }

                result.Add(new IncidentWithNavigationPropertiesDto
                {
                    Incident = ObjectMapper.Map<Incident, IncidentDto>(incident),
                    Client = ObjectMapper.Map<Client, ClientDto>(client),
                    Classification = ObjectMapper.Map<IncidentClassification, IncidentClassificationDto>(classification),
                    Resolution = resolution != null ? ObjectMapper.Map<Resolution, ResolutionDto>(resolution) : null
                });
            }

            return new PagedResultDto<IncidentWithNavigationPropertiesDto>(totalCount, result);
        }


    }

}
