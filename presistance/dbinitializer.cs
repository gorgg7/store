using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using domain.contracts;
using domain.entites;
using Microsoft.EntityFrameworkCore;
using presistance.data;
namespace presistance
{
    public class dbinitializer : idbinitializer
    {
        private readonly storedbcontext _context;
        public dbinitializer(storedbcontext context)
        {
            _context = context;
        }
        public async Task Initialize()
        {
            try
            {
                //if(_context.Database.GetPendingMigrations().Any())
                //{
                //    _context.Database.Migrate();
                //}
                if (!_context.producttypes.Any())
                {
                    var typesdata = File.ReadAllText(@"..\presistance\data\seeding\types.json");
                    var types = JsonSerializer.Deserialize<List<producttype>>(typesdata);
                    if (types is not null && types.Any())
                    {
                       await _context.producttypes.AddRangeAsync(types);
                        await _context.SaveChangesAsync();

                    }
                }
                if (!_context.productbrands.Any())
                {
                    var brandsdata = File.ReadAllText(@"..\presistance\data\seeding\brands.json");
                    var brand = JsonSerializer.Deserialize<List<productbrand>>(brandsdata);
                    if (brand is not null && brand.Any())
                    {
                       await _context.productbrands.AddRangeAsync(brand);
                        await _context.SaveChangesAsync();

                    }
                }
                
                if (!_context.products.Any())
                {
                    var productsdata = File.ReadAllText(@"..\presistance\data\seeding\products.json");
                    var product = JsonSerializer.Deserialize<List<product>>(productsdata);
                    if (product is not null && product.Any())
                    {
                     await _context.products.AddRangeAsync(product);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
    // Check if the database exists and create it if it doesn't

   