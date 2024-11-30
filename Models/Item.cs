using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Item Name")]
        [MinLength(1)]
        public required string Name { get; set; }
        [MinLength(1)] [MaxLength(50)]
        public string? Description { get; set; }

    }
}
