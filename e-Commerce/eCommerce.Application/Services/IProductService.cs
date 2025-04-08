using AutoMapper;
using eCommerce.Domain.Entities;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductDto> GetProductByNameAsync(string name);
    Task<ProductDto> AddProductAsync(ProductDto productDto);
    Task<ProductDto> UpdateProductAsync(ProductDto productDto);
    Task<bool> DeleteProductAsync(int id);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> AddProductAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var createdProduct= await  _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(createdProduct);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> GetProductByNameAsync(string name)
    {
        var product = await _productRepository.GetProductByNameAsync(name);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return false;
        }
        await _productRepository.Delete(product);
        return true;
    }

    public async Task<ProductDto> UpdateProductAsync(ProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(productDto.Id.Value);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        _mapper.Map(productDto, product);
        await _productRepository.Update(product);
        return _mapper.Map<ProductDto>(product);
    }
}