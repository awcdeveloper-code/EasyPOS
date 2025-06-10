using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace EasyPOS.Backoffice.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
