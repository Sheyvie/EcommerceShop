using Ecommerce.Services.Iservices;
using Newtonsoft.Json;
using System.Text;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public class ProductService : IProductInterface
    {
        private readonly HttpClient _clientHttp;
        private readonly string _url = " http://localhost:3000/products";

        public ProductService()
        {
            _clientHttp = new HttpClient(); 
        }

        public async Task<SuccessMessage> CreateProductAsync(AddProduct product)
        { 
            var content = JsonConvert.SerializeObject(product);
            var bodycontent = new StringContent(content ,Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _clientHttp.PostAsync(_url, bodycontent);

            if (response.IsSuccessStatusCode)
            {
                return new SuccessMessage { Message = "product added successfully" };
            }
            throw new Exception("product creation failed");
         
        }

        public async Task<SuccessMessage> DeleteProductAsync(string id)
        {
            var response = await _clientHttp.DeleteAsync(_url+"/"+ id);

            if (response.IsSuccessStatusCode)
            {
                return new SuccessMessage { Message = "prodcut successfully deleted" };
            }

            throw new Exception("Book deletion failed");
        }

        public async Task<List<Product>> GetAllProductAsync()
        {


            var response = await _clientHttp.GetAsync(_url);
            var products = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());

              if (response.IsSuccessStatusCode)
              {
                return products;
              }
                throw new Exception("product not found");
        }

        public async Task<Product> GetProductAsync(string id)
        {
                    var response = await _clientHttp.GetAsync(_url + "/" + id);
                    var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

                    if (response.IsSuccessStatusCode)
                    {
                        return product;
                    }

                    throw new Exception("product not found");            
        }

         public async Task<SuccessMessage> UpdateProductAsync(Product product)
         {
                    var content = JsonConvert.SerializeObject(product);
                    var bodycontent = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await _clientHttp.PostAsync(_url+ "/" + product.Id, bodycontent);
                    if (response.IsSuccessStatusCode)
                    {
                        return new SuccessMessage { Message = "product updated successfully" };


                    }

                    throw new NotImplementedException("product update failed");

         }

    }
}