using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class CustomerBasketDTO
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDTO> Items { get; set; } 
    }
}