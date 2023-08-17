using Ecommerce.Models;

namespace Ecommerce.Services.Iservices
{
    public  interface IProductInterface
    {
        //contains the structure of all the mehods in the service


        
        
       
        
        //Add a product
        Task<SuccessMessage> CreateProductAsync(AddProduct product);

        //Update a product
        Task<SuccessMessage> UpdateProductAsync(Product product);


        //Delete a product
        Task<SuccessMessage> DeleteProductAsync( string id);

        //Get a product
        Task<Product> GetProductAsync( string id);

        //Get all products
        Task<List<Product>> GetAllProductAsync();
    }
}
