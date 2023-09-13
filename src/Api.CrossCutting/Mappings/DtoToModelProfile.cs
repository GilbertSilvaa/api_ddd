using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Country;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDto>()
                .ReverseMap();
            CreateMap<UserModel, UserCreateDto>()
                .ReverseMap();
            CreateMap<UserModel, UserUpdateDto>()
                .ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfModel, UfDto>()
                .ReverseMap();
            #endregion

            #region Country
            CreateMap<CountryModel, CountryDto>()
                .ReverseMap();
            CreateMap<CountryModel, CountryCreateDto>()
                .ReverseMap();
            CreateMap<CountryModel, CountryUpdateDto>()
                .ReverseMap();
            #endregion

            #region Cep
            CreateMap<CepModel, CepDto>()
               .ReverseMap();
            CreateMap<CepModel, CepCreateDto>()
                .ReverseMap();
            CreateMap<CepModel, CepUpdateDto>()
                .ReverseMap();
            #endregion
        }
    }
}
