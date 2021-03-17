using ApiTesterV01.Common;
using ApiTesterV01.Entities;
using ApiTesterV01.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Data
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            #region Unit 
            CreateMap<Unit, UnitViewModel>();
            CreateMap<UnitViewModel, Unit>();
            #endregion
           
            #region Category
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            #endregion
            
            #region City
            CreateMap<City, CityViewModel>();
            CreateMap<CityViewModel, City>();
            #endregion

            #region Discount
            CreateMap<DiscountViewModel, Discount>()
                .ForMember(x => x.StartDate, opt => { opt.PreCondition(x => x.ShamsiStartDate != null); opt.MapFrom(x => x.ShamsiStartDate.ToMiladi()); })
                 .ForMember(x => x.EndDate, opt => { opt.PreCondition(x => x.ShamsiEndDate != null); opt.MapFrom(x => x.ShamsiEndDate.ToMiladi()); });
            CreateMap<Discount, DiscountViewModel>()
                .ForMember(x => x.ShamsiStartDate, opt => { opt.PreCondition(x => x.StartDate != null); opt.MapFrom(x => x.StartDate.Value.ToShamsi()); })
                .ForMember(x => x.ShamsiEndDate, opt => { opt.PreCondition(x => x.EndDate != null); opt.MapFrom(x => x.EndDate.Value.ToShamsi()); });
            #endregion
            
            #region Factory
            CreateMap<Factory, FactoryViewModel>();
            CreateMap<FactoryViewModel, Factory>();
            #endregion

            #region User
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            #endregion
        }

    }
}
