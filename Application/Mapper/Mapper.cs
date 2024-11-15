    using practices.Model;

    namespace Application.Mapper
    {
    public class Mapper : IMapper
    {
        public Product MapToEntity(CreateProductCommand command, string imagePath)
        {
            return new Product
            {
                Name = command.Name,
                Price = command.Price,
                Image = imagePath
            };
        }

        public Product MapToEntity(UpdateProductCommand command, string imagePath)
        {
            return new Product
            {
                Id = command.Id,
                Name = command.Name,
                Price = command.Price,
                Image = imagePath
            };
        }
    }
}
