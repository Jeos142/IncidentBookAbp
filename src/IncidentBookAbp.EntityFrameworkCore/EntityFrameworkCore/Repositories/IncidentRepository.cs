using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IncidentBookAbp.Incidents;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace IncidentBookAbp.EntityFrameworkCore.Repositories
{
    public class IncidentRepository : EfCoreRepository<IncidentBookAbpDbContext, Incident, Guid>, IIncidentRepository
    {
        public IncidentRepository(IDbContextProvider<IncidentBookAbpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Incident> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableWithDetailsAsync())
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Incident>> GetListWithDetailsAsync(
            string sorting = null,
            int skipCount = 0,
            int maxResultCount = int.MaxValue,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableWithDetailsAsync();

            if (!sorting.IsNullOrWhiteSpace())
            {
                var parts = sorting.Split(' ');
                var property = parts[0];
                var direction = parts.Length > 1 ? parts[1] : "ASC";

                switch (property)
                {
                    case "DateTime":
                        query = direction == "DESC"
                            ? query.OrderByDescending(x => x.DateTime)
                            : query.OrderBy(x => x.DateTime);
                        break;
                    
                    
                    default:
                        query = query.OrderByDescending(x => x.DateTime);
                        break;
                }
            }

            return await query
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(cancellationToken);
        }

        public async Task<IQueryable<Incident>> GetQueryableWithDetailsAsync()
        {
            return (await GetQueryableAsync())
                .Include(x => x.Client)
                .Include(x => x.Classification)
                .Include(x => x.Resolution);
        }
    }
}
