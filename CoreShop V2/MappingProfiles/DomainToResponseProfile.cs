using AutoMapper;
using CoreShop_V2.Areas.Admin.Models;
using CoreShop_V2.Areas.Admin.ViewModel;
using CoreShop_V2.Areas.Admin.ViewModel.CustomClass;
using CoreShop_V2.Areas.Admin.ViewModel.CustomViewModel;
using CoreShop_V2.Areas.Admin.ViewModel.MemberViewModel;
using CoreShop_V2.Areas.Client.ViewModel;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop_V2.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {            
            CreateMap<Category, ProductTypeViewModel>()
                .ForMember(dest=>dest.Products,opt=>
                opt.MapFrom(src=>src.product));
            CreateMap<BillViewModel, Bill>()
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreatedDate))
                .AfterMap((s, d) => d.BillId = Guid.NewGuid().ToString())
                .AfterMap((s, d) => d.Status = true);
            CreateMap<CartItem, BillDetails>()
                .ForMember(dest=>dest.ProductId,opt=>
                    opt.MapFrom(src=>src.product.ProductId))
                .ForMember(dest => dest.ProductName, opt =>
                    opt.MapFrom(src => src.product.ProductName))
                .ForMember(dest => dest.Quantity, opt =>
                    opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TotalPrice, opt =>
                    opt.MapFrom(src => src.product.DiscountPrice*src.Quantity))                    
                .ForMember(dest=>dest.BillId,opt=>opt.Ignore());
            CreateMap<Bill, BillMgnViewModel>()                
                .AfterMap((src, dest) => dest.BillDetails = src.BillDetails.Where(x => x.BillId == dest.BillId).ToList())
                .AfterMap((s,d)=>d.AccountId = (s.AccountId != null)? "Yes" : "No")
                .AfterMap((s, d) => d.Status = (s.Status != false) ? "SUCCESS" : "FAIL")
                .AfterMap((s,d)=>d.CreateDate = String.Format("{0:d/M/yyyy HH:mm:ss tt}",s.CreateDate));
            CreateMap<Product, ProductViewModel>();                
        }
    }
}
