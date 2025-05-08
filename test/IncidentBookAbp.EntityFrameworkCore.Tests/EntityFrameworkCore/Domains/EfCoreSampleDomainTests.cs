using IncidentBookAbp.Samples;
using Xunit;

namespace IncidentBookAbp.EntityFrameworkCore.Domains;

[Collection(IncidentBookAbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<IncidentBookAbpEntityFrameworkCoreTestModule>
{

}
