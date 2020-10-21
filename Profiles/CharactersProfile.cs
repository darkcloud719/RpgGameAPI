using AutoMapper;
using RpgGameApi.Dtos.Character;
using RpgGameApi.Models;

namespace RpgGameApi.Profiles
{
    public class CharactersProfile : Profile
    {
        public CharactersProfile()
        {
            CreateMap<Character, CharacterReadDto>()
                .ForMember(destinationMember: des => des.IdForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Id); })
                .ForMember(destinationMember: des => des.NameForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Name); })
                .ForMember(destinationMember: des => des.HitPointsForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.HitPoints); })
                .ForMember(destinationMember: des => des.StrengthForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Strength); })
                .ForMember(destinationMember: des => des.DefenseForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Defense); })
                .ForMember(destinationMember: des => des.IntelligenceForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Intelligence); })
                .ForMember(destinationMember: des => des.RpgClassForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.RpgClass); })
                .ReverseMap();

            CreateMap<Character, CharacterAddDto>()
                .ForMember(destinationMember: des => des.NameForAdd, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Name); })
                .ForMember(destinationMember: des => des.HitPointsForAdd, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.HitPoints); })
                .ForMember(destinationMember: des => des.StrengthForAdd, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Strength);})
                .ForMember(destinationMember: des => des.DefenseForAdd, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Defense);})
                .ForMember(destinationMember: des => des.IntelligenceForAdd, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Intelligence);})
                .ForMember(destinationMember: des => des.RpgClassForAdd, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.RpgClass);})
                .ReverseMap();

            CreateMap<Character, CharacterUpdateDto>()
                .ForMember(destinationMember: des => des.IdForUpdate, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Id);})
                .ForMember(destinationMember: des => des.NameForUpdate, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Name);})
                .ForMember(destinationMember: des => des.HitPointsForUpdate, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.HitPoints);})
                .ForMember(destinationMember: des => des.StrengthForUpdate, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Strength);})
                .ForMember(destinationMember: des => des.DefenseForUpdate, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Defense);})
                .ForMember(destinationMember: des => des.IntelligenceForUpdate, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Intelligence);})
                .ForMember(destinationMember: des => des.RpgClassForUpdate, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.RpgClass);})
                .ReverseMap();

            CreateMap<CharacterUpdateDto, CharacterReadDto>()
                .ForMember(destinationMember: des => des.IdForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.IdForUpdate);})
                .ForMember(destinationMember: des => des.NameForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.NameForUpdate);})
                .ForMember(destinationMember: des => des.HitPointsForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.HitPointsForUpdate);})
                .ForMember(destinationMember: des => des.StrengthForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.StrengthForUpdate);})
                .ForMember(destinationMember: des => des.DefenseForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.DefenseForUpdate);})
                .ForMember(destinationMember: des => des.IntelligenceForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.IntelligenceForUpdate);})
                .ForMember(destinationMember: des => des.RpgClassForRead, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.RpgClassForUpdate);})
                .ReverseMap();

        }
    }
}