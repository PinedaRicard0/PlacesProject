﻿using AutoMapper;
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
                cfg.CreateMap<Region, RegionViewModel>().
                    ForMember(dest => dest.Id, opt => opt.MapFrom(sou => sou.Id.ToString()));
            });

            Mapper = config.CreateMapper();
        }
    }
}