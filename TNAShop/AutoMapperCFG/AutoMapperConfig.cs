using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;
using TNAShop.Helpers;
using TNAShop.ViewModels.ProductViewModel;

namespace TNAShop.AutoMapperCFG {
    public class AutoMapperConfig {
        public static void Config() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Product, ProductDetailViewModel>()
                .ForMember(x => x.Brand, m => m.MapFrom(a => a.Brand.Name))
                .ForMember(x => x.Category, m => m.MapFrom(a => a.Category.CategoryName))
                .ForMember(x => x.Gender, m => m.MapFrom(a => a.Gender == 1 ? "Nam" : "Nữ"))
                .ForMember(x => x.Status, m => m.MapFrom(a => a.Status == true ? "Còn hàng" : "Hết hàng"))
                .ForMember(x => x.Price, m => m.MapFrom(a => PriceHelper.NormalizePrice(a.Price.ToString())))
                .ForMember(x => x.PromotionalPrice, m => m.MapFrom(a => PriceHelper.NormalizePrice(a.PromotionalPrice.ToString())))
                .ForMember(x => x.Save, m => m.MapFrom(a => PriceHelper.NormalizePrice((a.Price - a.PromotionalPrice).ToString())))
                .ForMember(x => x.Strap, m => m.MapFrom(a => StrapsToString(a.ProductStrap)))
                ;
                cfg.CreateMap<Product, ProductIndexViewModel>()
                .ForMember(x => x.Price, m => m.MapFrom(a => PriceHelper.NormalizePrice(a.Price.ToString())))
                .ForMember(x => x.PromotionalPrice, m => m.MapFrom(a => PriceHelper.NormalizePrice(a.PromotionalPrice.ToString())))
                ;
                cfg.CreateMap<ProductDetailViewModel, ProductShoppingCart>();
                cfg.CreateMap<PlaceOrderViewModel, OrderStatusViewModel>();
                cfg.CreateMap<PlaceOrderViewModel, Order>();

                cfg.CreateMap<ProductShoppingCart, Product>();
                cfg.CreateMap<Product, ProductShoppingCart>();
            });
        }

        static string StrapsToString(ICollection<ProductStrap> straps) {
            string res = "";
            foreach (var a in straps) {
                res += a.Strap.StrapName + " ";
            }
            return res;
        }
    }
}