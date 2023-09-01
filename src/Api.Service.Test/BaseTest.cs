using Api.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Service.Test
{
    public abstract class BaseTest
    {
        public IMapper Mapper { get; set; }

        public BaseTest()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new ModelToEntityProfile());
                conf.AddProfile(new DtoToModelProfile());
                conf.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
