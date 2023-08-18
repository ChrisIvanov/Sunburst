namespace Sunburst.Services.Config
{
    using AutoMapper;
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Cart.CartItem;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CartItem, GetCartItemModel>();
            CreateMap<GetCartItemModel, CartItem>();
            //CreateMap<CartItem, GetCartItemModel>();
            //CreateMap<CartItem, GetCartItemModel>();
            //CreateMap<CartItem, GetCartItemModel>();
            //CreateMap<CartItem, GetCartItemModel>();
            //CreateMap<CartItem, GetCartItemModel>();

        }
    }
}
