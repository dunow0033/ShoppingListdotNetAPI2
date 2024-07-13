using ShoppingListdotNetAPI2.Dtos;

namespace ShoppingListdotNetAPI2.Services
{
    public interface IShoppingListService
    {
        Task<List<ShoppingItemResponse>> GetItems();
        Task<ShoppingItemResponse> GetItem(Guid id);
        Task<ShoppingItemResponse> AddItem(CreateShoppingItem request);
        Task DeleteItem(Guid id);
        Task MarkAsPicked(Guid id);
    }
}
