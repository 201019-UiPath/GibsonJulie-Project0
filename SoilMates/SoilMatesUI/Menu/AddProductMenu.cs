using System;
using SoilMatesBL;
using SoilMatesDB.Models;
using SoilMatesDB;
using SoilMatesLib;


namespace SoilMatesUI.Menu
{
    public class AddProductMenu : IMenu
    {

        ProductService productService;
        IRepository repo;
        private LocationMenu locationMenu;

        public AddProductMenu(IRepository repo)
        {
            this.repo = repo;
            this.productService = new ProductService(repo);
            this.locationMenu = new LocationMenu(repo);
        }
        public void Start()
        {
            string name, description;
            decimal price;

            Console.WriteLine("Enter plant name: ");
            name = Console.ReadLine();
            Console.WriteLine("Add plant description: ");
            description = Console.ReadLine();
            Console.WriteLine("Add plant price:");
            price = Convert.ToDecimal(Console.ReadLine());
            try
            {
                productService.AddNewProduct(name, price, description);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            productService.SaveChanges();

            Console.WriteLine("New plant added! All plants in catalog listed below:");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"\tProduct id: {product.ProductId} \tProduct name: {product.Name}");
            }
        }
    }
}