using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Country;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();
            CreateMap<UserCreateResultDto, UserEntity>()
                .ReverseMap();
            CreateMap<UserUpdateResultDto, UserEntity>()
                .ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfDto, UfEntity>()
                .ReverseMap();
            #endregion

            #region Country
            CreateMap<CountryDto, CountryEntity>()
                .ReverseMap();
            CreateMap<CountryFullDto, CountryEntity>()
                .ReverseMap();
            CreateMap<CountryCreateResultDto, CountryEntity>()
                .ReverseMap();
            CreateMap<CountryUpdateResultDto, CountryEntity>()
                .ReverseMap();
            #endregion

            #region Cep
            CreateMap<CepDto, CepEntity>()
                .ReverseMap();
            CreateMap<CepCreateResultDto, CepEntity>()
                .ReverseMap();
            CreateMap<CepUpdateResultDto, CepEntity>()
                .ReverseMap();
            #endregion
        }
    }
}
