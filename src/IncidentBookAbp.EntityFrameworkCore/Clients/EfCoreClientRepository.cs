using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentBookAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;

namespace IncidentBookAbp.Clients
{
    public class EfCoreClientRepository : EfCoreRepository<IncidentBookAbpDbContext, Client, Guid>, IRepository<Client, Guid>
    {
        public EfCoreClientRepository(IDbContextProvider<IncidentBookAbpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
