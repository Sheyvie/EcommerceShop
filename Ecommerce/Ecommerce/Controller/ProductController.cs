using Ecommerce.Helpers;
using Ecommerce.Models;
using Ecommerce.Services;


namespace Ecommerce.Controller
{
    public class ProductController
       
    {
        
        ProductService productService = new ProductService();


        //To communicate with the service
        public static async Task  Init()
        { 
            
            
        
            Console.WriteLine("Hello! Welcome to SKIN BEAUTY SHOP");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. View a product");
            Console.WriteLine("3. Update a product");
            Console.WriteLine("4. Delete a product");

            var input = Console.ReadLine();
            var validateResult = Validation.Validate(new List<string> { input });
            if (!validateResult)
            {
               await ProductController.Init();
            }

            else
            {

              await new ProductController().MenuRedirect(input);
            }

        }
        public async Task MenuRedirect(string id)
        {
            switch (id)
            {
                case "1":
                  await AddnewProduct();
                    break;
                case "2":
                   await ViewProducts();
                    break;
                case "3":
                    await UpdateaProduct();
                    break;

                case "4":
                  await   DeleteaProduct();
                        break;
                default:
                  await ProductController.Init();

                   break;


            }

        }
        public async Task AddnewProduct()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product price: ");
            string productPrice = Console.ReadLine();

            Console.Write("Enter product description: ");
            string productDescription = Console.ReadLine();

            AddProduct newProduct = new AddProduct
            { Name = productName, Price = productPrice, Description = productDescription };
            

            try
            {
                var res = await productService.CreateProductAsync(newProduct);
                Console.WriteLine(res.Message);

              
            }
            catch(Exception ex) 
            {
                await Console.Out.WriteLineAsync(ex.Message);

            }
            
            
        }
        public  async Task UpdateaProduct()
        {
            await ViewProducts();
            Console.Write("Enter Product Id you want to update");

            var  id = Console.ReadLine();
                
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter product price: ");
                string productPrice = Console.ReadLine();

                Console.Write("Enter product description: ");
                string productDescription = Console.ReadLine();
            Product updateProduct = new Product
            { Id =id ,Name = productName, Price = productPrice, Description = productDescription };
            try
            {
               var res = await productService.UpdateProductAsync(updateProduct);
                Console.WriteLine( res.Message);
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }
        public async Task ViewProducts()
        {

            try
            {
                var products = await productService.GetAllProductAsync();
                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                   await Console.Out.WriteLineAsync($"ID:{product.Id}, Name: {product.Name}, Price: {product.Price} , Description:{product.Description}");
                }
            }
            catch (Exception ex)

            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public  async Task DeleteaProduct()
        {


            

              await ViewProducts();
              await Console.Out.WriteLineAsync("Enter Product Id you want to delete");
              var id = Console.ReadLine();

            try
            {
                    var res = await productService.DeleteProductAsync(id);
                    Console.WriteLine(res.Message);
            }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }

            
        }
       
    }
}
