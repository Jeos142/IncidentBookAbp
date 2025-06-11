using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IncidentBookAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IncidentBookAbp.Incidents.Repositories
{
    public class IncidentRepository : EfCoreRepository<IncidentBookAbpDbContext, Incident, Guid>, IIncidentRepository
    {
        public IncidentRepository(IDbContextProvider<IncidentBookAbpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Incident>> GetListWithNavigationPropertiesAsync(int skipCount, int maxResultCount, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.Incidents
                .Include(x => x.Client)
                .Include(x => x.Classification)
                .Include(x => x.Resolution)
                .OrderByDescending(x => x.DateTime)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(cancellationToken);
        }
    }

}
