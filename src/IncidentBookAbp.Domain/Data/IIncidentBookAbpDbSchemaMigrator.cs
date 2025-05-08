using System.Threading.Tasks;

namespace IncidentBookAbp.Data;

public interface IIncidentBookAbpDbSchemaMigrator
{
    Task MigrateAsync();
}
