using AutoMapper;
using IncidentBookAbp.Clients.DTO;
using IncidentBookAbp.Clients;
using IncidentBookAbp.Incidents;
using IncidentBookAbp.IncidentClassifications.Dto;
using IncidentBookAbp.IncidentClassifications;
using IncidentBookAbp.Resolutions.Dto;
using IncidentBookAbp.Resolutions;
using IncidentBookAbp.Incidents.Dto;

namespace IncidentBookAbp;

public class IncidentBookAbpApplicationAutoMapperProfile : Profile
{
    public IncidentBookAbpApplicationAutoMapperProfile()
    {
        CreateMap<Incident, IncidentDto>();
        CreateMap<CreateUpdateIncidentDto, Incident>();
        CreateMap<Client, ClientDto>();
        CreateMap<CreateUpdateClientDto, Client>();
        CreateMap<IncidentClassification, IncidentClassificationDto>();
        CreateMap<CreateUpdateIncidentClassificationDto, IncidentClassification>();
        CreateMap<Resolution, ResolutionDto>();
        CreateMap<CreateUpdateResolutionDto, Resolution>();
        CreateMap<Incident, IncidentDto>();
        CreateMap<CreateUpdateIncidentDto, Incident>();
        CreateMap<Incident, IncidentWithNavigationPropertiesDto>()
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.Classification, opt => opt.MapFrom(src => src.Classification))
            .ForMember(dest => dest.Resolution, opt => opt.MapFrom(src => src.Resolution));
    }
}
