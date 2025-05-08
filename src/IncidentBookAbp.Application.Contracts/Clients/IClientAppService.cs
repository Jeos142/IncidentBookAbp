using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Clients.DTO;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IncidentBookAbp.Clients
{
    public interface IClientAppService : ICrudAppService<
       ClientDto,
       Guid,
       PagedAndSortedResultRequestDto,
       CreateUpdateClientDto>
    {
    }
}
