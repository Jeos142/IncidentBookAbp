using IncidentBookAbp.Samples;
using Xunit;

namespace IncidentBookAbp.EntityFrameworkCore.Applications;

[Collection(IncidentBookAbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<IncidentBookAbpEntityFrameworkCoreTestModule>
{

}
