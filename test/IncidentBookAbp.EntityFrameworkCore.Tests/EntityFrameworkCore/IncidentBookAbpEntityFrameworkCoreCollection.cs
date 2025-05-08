using Xunit;

namespace IncidentBookAbp.EntityFrameworkCore;

[CollectionDefinition(IncidentBookAbpTestConsts.CollectionDefinitionName)]
public class IncidentBookAbpEntityFrameworkCoreCollection : ICollectionFixture<IncidentBookAbpEntityFrameworkCoreFixture>
{

}
