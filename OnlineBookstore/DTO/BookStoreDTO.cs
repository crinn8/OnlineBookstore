using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.DTO
{
    public class BookStoreDTO
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Address { get; set; } = null!;
    }
}
