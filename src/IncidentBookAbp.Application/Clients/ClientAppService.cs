using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Clients.DTO;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IncidentBookAbp.Clients
{
    public class ClientAppService : CrudAppService<
        Client,                 // Сущность
        ClientDto,              // DTO для отображения
        Guid,                   // Тип ID
        PagedAndSortedResultRequestDto, // Пагинация и сортировка
        CreateUpdateClientDto   // DTO для создания/обновления
    >, IClientAppService
    {
        public ClientAppService(IRepository<Client, Guid> repository)
            : base(repository)
        {
        }
        //Сортировка
        public override async Task<PagedResultDto<ClientDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var clients = await queryable
                .OrderBy(c => c.Name) // Сортировка по имени
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ClientDto>(
                totalCount,
                ObjectMapper.Map<List<Client>, List<ClientDto>>(clients)
            );
        }
    }
    

}
    