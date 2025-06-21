using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Models
{
    public class SaloonViewModel
    {
        public TableOrSeat? TableOrSeat { get; set; }
        public List<CategoryList>? Categories { get; set; }
        public Dictionary<int, List<ProductList>>? CategoryItems { get; set; }
    }

    public class CategoryList
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
    }

    public class ProductList
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = "https://placehold.co/64x64/444444/ffffff?text=Sin+Imagen";
    }
    public class SelectedItem
    {
        public int id { get; set; }
        public int quantity { get; set; }
    }
}
