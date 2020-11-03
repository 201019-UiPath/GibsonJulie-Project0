using System;
using System.Reflection;
using Xunit;
using SoilMatesDB.Models;
using SoilMatesDB;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace SoilMatesTest.SoilMatesDBTest
{
    public class DBRepoTest
    {
        private DBrepo repo;

        private readonly Customer testCustomer = new Customer()
        {
            Id = 1,
            UserType = 0,
            Name = "Shadow",
            Email = "ShadowIncLLC@gmail.com",
            Password = "woofwoof"
        };

        private readonly Manager testManager = new Manager()
        {
            Id = 1,
            UserType = 1,
            Name = "Karen",
            Email = "KarensWW@gmail.com",
            Password = "password"
        };

        private readonly Inventory testInventory = new Inventory()
        {
            InventoryId = 0,
            ProductForeingId = 1,
            LocationForeignId = 1,
        };

        private readonly List<Inventory> testInventories = new List<Inventory>() {
            new Inventory() {
                 InventoryId = 1,
            ProductForeingId = 2,
            LocationForeignId =2,
            },
              new Inventory() {
                 InventoryId = 2,
            ProductForeingId = 3,
            LocationForeignId =3,
            }
        };

        private readonly Location testLocation = new Location()
        {
            LocationId = 0,
            Name = "TreeMates",
            Address = "Tampa, FL",
        };

        private readonly Order testOrder = new Order()
        {
            OrderId = 1,
            CustomerId = 1,
            LocationId = 1,
            Address = "Sebring, Fl",
            OrderTime = DateTime.Now,
            TotalPrice = 2.00m,
        };

        private readonly OrderProduct testOrderProduct = new OrderProduct()
        {
            Id = 2,
            OrderForiegnId = 3,
            ProductForiegnId = 1,
        };

        private readonly Product testProduct = new Product()
        {
            ProductId = 2,
            Description = "Edible",
            Name = "BlueBerry",
            Price = 3.00m,
        };

        private readonly List<Product> testProducts = new List<Product>(){
            new Product(){
                ProductId = 6,
                Description = "Succulent",
                Name = "Aloe",
                Price = 2.00m,
            },
            new Product(){
                ProductId = 3,
                Description = "Edible",
                Name = "Mango Tree",
                Price = 20.00m,
            }
        };

        private readonly List<Location> testLocations = new List<Location>(){
            new Location (){
                LocationId = 3,
                Name = "FlowerMates",
                Address = "Tampa, FL",
            },
            new Location (){
                LocationId = 1,
                Name = "EdibleMates",
                Address = "Dallas, TX",
            }
        };

        private readonly List<Customer> testCustomers = new List<Customer>(){
           new Customer(){
               Id = 2,
               UserType = 0,
               Name = "Eric",
               Email = "EricTheElectric@mail.usf.edu",
               Password = "WOWmoment"
           },
           new Customer() {
                Id = 3,
               UserType = 0,
               Name = "Will",
               Email = "OllieAndWill@mail.com",
               Password = "BostonCream",
           },
       };


        private readonly List<Manager> testManagers = new List<Manager>(){
           new Manager(){
               Id = 4,
               UserType = 1,
               Name = "Babish",
               Email = "Binging@mail.usf.edu",
               Password = "Basics"
           },
           new Manager() {
                Id = 5,
               UserType = 0,
               Name = "Schitt",
               Email = "ShittsCreek@mail.com",
               Password = "AlittleBitAlexis",
           },
       };



        private void seed(SoilMatesContext testcontext)
        {
            testcontext.Customers.AddRange(testCustomers);
            testcontext.Managers.AddRange(testManagers);
            testcontext.Inventories.AddRange(testInventories);
            testcontext.Locations.AddRange(testLocations);
            testcontext.Products.AddRange(testProducts);
            testcontext.SaveChanges();
        }


        [Fact]
        public void AddCustomerShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddCustomerShouldAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddCustomer(testCustomer);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Customers.SingleAsync(n => n.Name == testCustomer.Name));
        }

        [Fact]
        public void AddManagerShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddManagerShouldAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddManager(testManager);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Managers.SingleAsync(n => n.Name == testManager.Name));
        }

        [Fact]
        public void AddInventoryShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddInventoryShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddInventory(testInventory);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Inventories.SingleAsync(n => n.InventoryId == testInventory.InventoryId));
        }

        [Fact]
        public void AddLocationShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddLocationShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddLocation(testLocation);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Inventories.SingleAsync(n => n.InventoryId == testInventory.InventoryId));
        }

        [Fact]
        public void AddOrderShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddOrderShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddOrder(testOrder);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Orders.SingleAsync(n => n.OrderId == testOrder.OrderId));
        }

        [Fact]
        public void AddOrderProductShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddOrderProductShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddOrderProduct(testOrderProduct);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.OrderProducts.SingleAsync(n => n.Id == testOrderProduct.Id));
        }

        [Fact]
        public void AddProductShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddProductShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddProduct(testProduct);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Products.SingleAsync(n => n.Name == testProduct.Name));
        }

        [Fact]
        public void GetCustomerShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetCustomerShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetCustomer(3);

            Assert.NotNull(result);
            Assert.Equal("Will", result.Name);
        }

        [Fact]
        public void GetManagerShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetManagerShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetManagerById(4);

            Assert.NotNull(result);
            Assert.Equal("Babish", result.Name);
        }

        [Fact]
        public void GetProductShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetProductShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetProduct(6);

            Assert.NotNull(result);
            Assert.Equal("Aloe", result.Name);
        }




    }
}