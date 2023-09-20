using AutoMapper;
using update.Input;
using Infrastructure.Model;
using update.Response;

namespace update.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Community, CommunityData>();
        CreateMap<Activity, ActivityData>();
        CreateMap<Participation, ParticipationData>();
        CreateMap<Location, LocationData>();
        CreateMap<Role, RoleData>();
        CreateMap<User, UserResponse>();
    }
}