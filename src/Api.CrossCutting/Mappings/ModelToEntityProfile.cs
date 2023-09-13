using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ReverseMap();

            CreateMap<UfModel, UfEntity>()
                .ReverseMap();

            CreateMap<CountryModel, CountryEntity>()
                .ReverseMap();

            CreateMap<CepModel, CepEntity>()
                .ReverseMap();
        }
    }
}
