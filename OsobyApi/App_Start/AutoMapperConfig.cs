using AutoMapper;
using OsobyApi.Models;

namespace OsobyApi.App_Start
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfig { get; set; }

        public static void Register()
        {
            MapperConfig = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<Kontakt, KontaktDto>().ReverseMap();
                 cfg.CreateMap<Bydliste, BydlisteDto>().ReverseMap();
                 cfg.CreateMap<Osoba, OsobaDto>().ReverseMap();
             });

#if DEBUG
            MapperConfig.AssertConfigurationIsValid();
#endif
        }
    }
}