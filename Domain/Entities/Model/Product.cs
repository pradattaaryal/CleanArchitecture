using MediatR;
using Microsoft.AspNetCore.Http;

namespace practices.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

    // DTOs for command operations
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
    }

    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; }
    }

    public class GetProductByIdQuery : IRequest<Product>  // Specify IRequest<Product> here
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
