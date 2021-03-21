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

            #region CompanyOwner
            CreateMap<CompanyOwner, CompanyOwnerViewModel>()
                 .ForMember(x => x.BirthDate, opt => opt.MapFrom(x => x.BirthDate.ToShamsi()));
            CreateMap<CompanyOwnerViewModel, CompanyOwner>()
                 .ForMember(x => x.BirthDate, opt => opt.MapFrom(x => x.BirthDate.ToMiladi()));
            #endregion

            #region Company
            CreateMap<Company, CompanyViewModel>()
                 .ForMember(x => x.RegisterDateTime, opt => opt.MapFrom(x => x.RegisterDateTime.ToShamsi()));
            CreateMap<CompanyViewModel, Company>()
                 .ForMember(x => x.RegisterDateTime, opt => opt.MapFrom(x => x.RegisterDateTime.ToMiladi()));
            #endregion

            #region Customer

            CreateMap<Customer, CustomerViewModel>()
                 .ForMember(x => x.BirthDate, opt => opt.MapFrom(x => x.BirthDate.ToShamsi()))
                 .ForMember(x => x.RegisterdateTime, opt => opt.MapFrom(x => x.RegisterdateTime.ToShamsi()));
            CreateMap<CustomerViewModel, Customer>()
                 .ForMember(x => x.BirthDate, opt => opt.MapFrom(x => x.BirthDate.ToMiladi()))
                 .ForMember(x => x.RegisterdateTime, opt => opt.MapFrom(x => x.RegisterdateTime.ToMiladi()));
            #endregion

            #region Order

            CreateMap<Order, OrderViewModel>()
                 .ForMember(x => x.DeliveryDate, opt => { opt.PreCondition(x => x.DeliveryDate != null); opt.MapFrom(x => x.DeliveryDate.Value.ToShamsi()); })
                  .ForMember(x => x.RefundDate, opt => { opt.PreCondition(x => x.RefundDate != null); opt.MapFrom(x => x.RefundDate.Value.ToShamsi()); })
                  .ForMember(x => x.RegisterDateTime, opt => opt.MapFrom(x => x.RegisterDateTime.ToShamsi()));
            CreateMap<OrderViewModel, Order>()
                   .ForMember(x => x.DeliveryDate, opt => { opt.PreCondition(x => x.DeliveryDate.Trim() != string.Empty); opt.MapFrom(x => x.DeliveryDate.ToMiladi()); })
                  .ForMember(x => x.RefundDate, opt => { opt.PreCondition(x => x.RefundDate.Trim() != string.Empty); opt.MapFrom(x => x.RefundDate.ToMiladi()); })
                  .ForMember(x => x.RegisterDateTime, opt => opt.MapFrom(x => x.RegisterDateTime.ToMiladi()));
            #endregion

            #region OrderDetail 
            CreateMap<OrderDetail, OrderDetailViewModel>();
            CreateMap<OrderDetailViewModel, OrderDetail>();
            #endregion

            #region Payment

            CreateMap<Payment, PaymentViewModel>()
                 .ForMember(x => x.PaymentDate, opt => opt.MapFrom(x => x.PaymentDate.ToShamsi()));
            CreateMap<PaymentViewModel, Payment>()
             .ForMember(x => x.PaymentDate, opt => { opt.PreCondition(x => x.PaymentDate.Trim() != string.Empty); opt.MapFrom(x => x.PaymentDate.ToMiladi()); });
            #endregion

            #region Page
            CreateMap<Page, PageViewModel>()
                .ForMember(x => x.PageType, opt => opt.MapFrom(x => (short)x.PageType));
            CreateMap<PageViewModel, Page>()
                .ForMember(x => x.PageType, opt => opt.MapFrom(x => (PageType)x.PageType));
            #endregion

            #region SectionPage
            CreateMap<SectionPage, SectionPageViewModel>()
                .ForMember(x => x.SectionType, opt => opt.MapFrom(x => (short)x.SectionType));
            CreateMap<SectionPageViewModel, SectionPage>()
                .ForMember(x => x.SectionType, opt => opt.MapFrom(x => (PageType)x.SectionType));
            #endregion

            #region StoreHouse
            CreateMap<StoreHouse, StoreHouseViewModel>()
                 .ForMember(x => x.InventoryStartDateTime, opt => opt.MapFrom(x => x.InventoryStartDateTime.ToShamsi()))
                 .ForMember(x => x.InventoryEndDateTime, opt => { opt.PreCondition(x => x.InventoryEndDateTime != null); opt.MapFrom(x => x.InventoryEndDateTime.Value.ToShamsi()); });
            CreateMap<StoreHouseViewModel, StoreHouse>()
                 .ForMember(x => x.InventoryStartDateTime, opt => opt.MapFrom(x => x.InventoryStartDateTime.ToMiladi()))
                 .ForMember(x => x.InventoryEndDateTime, opt => { opt.PreCondition(x => x.InventoryEndDateTime != null); opt.MapFrom(x => (DateTime)x.InventoryEndDateTime.ToMiladi()); });
            #endregion
        }

    }
}
