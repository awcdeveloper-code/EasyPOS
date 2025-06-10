using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace EasyPOS.Backoffice.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Boolean Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
