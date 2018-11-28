using AutoMapper;
using DC = ListersDemo.API.DataContracts;
using S = ListersDemo.API.Common;

namespace ListersDemo.IoC.Configuration.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<S.Vehicle, DC.Vehicle>();
          
        }
    }
}
