using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace IncidentBookAbp.Incidents
{
    public interface IIncidentRepository : IRepository<Incident, Guid>
    {
        Task<List<Incident>> GetListWithNavigationPropertiesAsync(int skipCount, int maxResultCount, CancellationToken cancellationToken = default);
    }
}
