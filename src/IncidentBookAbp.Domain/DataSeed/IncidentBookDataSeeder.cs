using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using IncidentBookAbp.Clients;
using IncidentBookAbp.IncidentClassifications;
using IncidentBookAbp.Resolutions;
using System;

public class IncidentBookDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Client, Guid> _clientRepo;
    private readonly IRepository<IncidentClassification, Guid> _classificationRepo;
    private readonly IRepository<Resolution, Guid> _resolutionRepo;

    public IncidentBookDataSeeder(
        IRepository<Client, Guid> clientRepo,
        IRepository<IncidentClassification, Guid> classificationRepo,
        IRepository<Resolution, Guid> resolutionRepo)
    {
        _clientRepo = clientRepo;
        _classificationRepo = classificationRepo;
        _resolutionRepo = resolutionRepo;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _clientRepo.GetCountAsync() <= 0)
        {
            await _clientRepo.InsertAsync(new Client { Name = "Василий И.И." }, autoSave: true);
            await _clientRepo.InsertAsync(new Client { Name = "Иван П.П." }, autoSave: true);
            await _clientRepo.InsertAsync(new Client { Name = "Петр И.И." }, autoSave: true);
        }

        if (await _classificationRepo.GetCountAsync() <= 0)
        {
            await _classificationRepo.InsertAsync(new IncidentClassification { ClassificationName = "Сетевая проблема" }, autoSave: true);
            await _classificationRepo.InsertAsync(new IncidentClassification { ClassificationName = "Программный сбой" }, autoSave: true);
        }

        if (await _resolutionRepo.GetCountAsync() <= 0)
        {
            await _resolutionRepo.InsertAsync(new Resolution { ResolutionName = "Закрыто ТП 1 уровня" }, autoSave: true);
            await _resolutionRepo.InsertAsync(new Resolution { ResolutionName = "Закрыто ТП 2 уровня" }, autoSave: true);
            await _resolutionRepo.InsertAsync(new Resolution { ResolutionName = "Закрыто ТП 3 уровня" }, autoSave: true);
            await _resolutionRepo.InsertAsync(new Resolution { ResolutionName = "Другое" }, autoSave: true);
        }
    }
}
