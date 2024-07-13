using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListdotNetAPI2.Models;
using ShoppingListdotNetAPI2.Dtos;
using ShoppingListdotNetAPI2.Services;
using ShoppingListdotNetAPI2.Exceptions;

namespace ShoppingListdotNetAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly ILogger<ShoppingListController> _logger;

        public ShoppingListController(
            IShoppingListService shoppingListService, 
            ILogger<ShoppingListController> logger)
        {
            _shoppingListService = shoppingListService;
            _logger = logger;
        }

        // GET: api/ShoppingList
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<ShoppingItemResponse>>> GetAll()
        {
            _logger.LogInformation("Getting all the items");

            try
            {
                var items = await _shoppingListService.GetItems();

                return Ok(items);
            }
            catch(NotFoundException exception)
            {
                _logger.LogError("Error getting items: {exception}", exception);
                return NotFound(exception.Message);
            }
        }

        [HttpPatch("{itemId:Guid}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Patch(Guid itemId)
        {
            _logger.LogInformation("Updating item status");
            try
            {
                await _shoppingListService.MarkAsPicked(itemId);

                return NoContent();
            }
            catch (NotFoundException exception)
            {
                _logger.LogError("Error updating item: {exception}", exception);
                return NotFound(exception.Message);
            }
        }

        // GET: api/ShoppingList/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ShoppingListItem>> GetShoppingListItem(int id)
        //{
        //    var shoppingListItem = await _shoppingListService.FindAsync(id);

        //    if (shoppingListItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return shoppingListItem;
        //}

        // PUT: api/ShoppingList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutShoppingListItem(Guid id, ShoppingListItem shoppingListItem)
        //{
        //    if (id != shoppingListItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(shoppingListItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ShoppingListItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ShoppingList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ShoppingItemResponse>> Post(CreateShoppingItem request)
        {
            _logger.LogInformation("Adding new item");
            try
            {
                var added = await _shoppingListService.AddItem(request);
           

                return StatusCode(200);
            }
            catch(Exception exception)
            {
                _logger.LogError("Error creating item: {exception}", exception);
                return BadRequest(exception.Message);
            }
        }

        // DELETE: api/ShoppingList/5
        [HttpDelete("{itemId:Guid}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(Guid itemId)
        {
            _logger.LogInformation("Deleting item={itemId}", itemId);
            try
            {
                await _shoppingListService.DeleteItem(itemId);

                return NoContent();
            }
            catch(NotFoundException exception)
            {
                _logger.LogError("Error deleting item: {exception}", exception);
                return NotFound(exception.Message);
            }
        }

        //private bool ShoppingListItemExists(Guid id)
        //{
        //    return _context.ShoppingListItems.Any(e => e.Id == id);
        //}
    }
}
