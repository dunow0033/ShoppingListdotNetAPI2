using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListdotNetAPI2.Models
{
    public class ShoppingListItem
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsPickedUp { get; set; }
        [MaxLength(100)] public string Item { get; set; }
    }
}
