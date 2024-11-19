using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

    }
}
