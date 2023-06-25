using AutoMapper;
using Business.Mapper;

namespace WebAPI.Extension
{
    public static class MapperExtension
    {
        public static void AddMapperExtension(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            services.AddSingleton(config.CreateMapper());
        }
    }
}
