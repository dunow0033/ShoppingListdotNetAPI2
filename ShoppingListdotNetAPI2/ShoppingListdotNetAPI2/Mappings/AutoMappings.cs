using AutoMapper;
using ShoppingListdotNetAPI2.Dtos;
using ShoppingListdotNetAPI2.Models;

namespace ShoppingListdotNetAPI2.Mappings
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<ShoppingItemResponse, ShoppingListItem>().ReverseMap();
            CreateMap<CreateShoppingItem, ShoppingListItem>().ReverseMap();
        }
    }
}
