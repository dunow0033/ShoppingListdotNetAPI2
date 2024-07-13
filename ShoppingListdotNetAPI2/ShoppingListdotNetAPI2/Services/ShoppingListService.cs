using AutoMapper;
using ShoppingListdotNetAPI2.Dtos;
using ShoppingListdotNetAPI2.Models;
using ShoppingListdotNetAPI2.Exceptions;
using ShoppingListdotNetAPI2.Repositories;


namespace ShoppingListdotNetAPI2.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _repository;
        private readonly IMapper _mapper;

        public ShoppingListService(
            IShoppingListRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ShoppingItemResponse> AddItem(CreateShoppingItem request)
        {
            var item = _mapper.Map<ShoppingListItem>(request);

            var created = await _repository.AddItem(item);
            await _repository.SaveChanges();

            return _mapper.Map<ShoppingItemResponse>(created);
        }

        public async Task DeleteItem(Guid id)
        {
            var item = await _repository.GetItem(id);

            if(item is null)
            {
                throw new NotFoundException($"item with id {id} not found");
            }

            _repository.DeleteItem(item);
            await _repository.SaveChanges();
        }

        public Task<ShoppingItemResponse> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShoppingItemResponse>> GetItems()
        {
            var items = await _repository.GetItems();

            if(items.Count == 0)
            {
                throw new NotFoundException("There are no items in the database");
            }

            return _mapper.Map<List<ShoppingItemResponse>>(items);
        }

        public async Task MarkAsPicked(Guid id)
        {
            var item = await _repository.GetItem(id);

            if(item is null)
            {
                throw new NotFoundException($"item with id {id} not found");
            }

            item.IsPickedUp = !item.IsPickedUp;

            _repository.UpdateItem(item);
            await _repository.SaveChanges();
        }
    }
}
