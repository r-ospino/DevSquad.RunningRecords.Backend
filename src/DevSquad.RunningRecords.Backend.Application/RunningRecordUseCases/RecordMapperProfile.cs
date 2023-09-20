using AutoMapper;
using DevSquad.RunningRecords.Backend.Domain;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class RecordMapperProfile: Profile
{
    public RecordMapperProfile()
    {
        CreateMap<Record, RecordDto>();
    }
}
