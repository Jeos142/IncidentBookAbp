using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.Clients.DTO;
using IncidentBookAbp.IncidentClassifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IncidentBookAbp.Clients
{
    [Authorize]
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
        //Сортировка по умолчанию
        protected override IQueryable<Client> ApplyDefaultSorting(IQueryable<Client> query)
        {
            return query.OrderBy(x => x.Name);
        }
    }
    

}
    