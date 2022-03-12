using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Core.Entities.OrderAggregate;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    context.Database.OpenConnection();
                    try
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands ON");
                        await context.SaveChangesAsync();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands OFF");
                    }
                    finally
                    {
                        context.Database.CloseConnection();
                    }                   
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    context.Database.OpenConnection();
                    try
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes ON");
                        await context.SaveChangesAsync();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes OFF");
                    }
                    finally
                    {
                        context.Database.CloseConnection();
                    }  
                }
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    context.Database.OpenConnection();
                    try
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON");
                        await context.SaveChangesAsync();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products OFF");
                    }
                    finally
                    {
                        context.Database.CloseConnection();
                    }  
                }
                if (!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    context.Database.OpenConnection();
                    try
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DeliveryMethods ON");
                        await context.SaveChangesAsync();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DeliveryMethods OFF");
                    }
                    finally
                    {
                        context.Database.CloseConnection();
                    }  
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);

            }
        }
    }
}