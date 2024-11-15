using practices.Model;

namespace Application.Mapper
{
    public interface IMapper
    {
        Product MapToEntity(CreateProductCommand command, string imagePath);
        Product MapToEntity(UpdateProductCommand command, string imagePath);
    }
}
