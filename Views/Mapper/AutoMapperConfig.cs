using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Views.ViewModels;

namespace Views.MapperFilter
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Init() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Region, RegionViewModel>();
                cfg.CreateMap<RegionViewModel, Region>();
                cfg.CreateMap<Municipality, MunicipalityViewModel>();
                cfg.CreateMap<MunicipalityViewModel, Municipality>();
                cfg.CreateMap<SaveEditRegionViewModel, Region>();
                cfg.CreateMap<Region, SaveEditRegionViewModel>();
                cfg.CreateMap<Municipality, MunicipalitySelectionViewModel>();
                cfg.CreateMap<MunicipalitySelectionViewModel, Municipality>();
            });

            Mapper = config.CreateMapper();
        }
    }
}