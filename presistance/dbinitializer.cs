using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using domain.contracts;
using domain.entites;
using domain.entites.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using presistance.data;
using presistance.identity;
namespace presistance
{
    public class dbinitializer : idbinitializer
    {
        private readonly storedbcontext _context;
        private readonly Storeidentitydb _storeidentitydb;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<user> _userManager;
        public dbinitializer(storedbcontext context, Storeidentitydb storeidentitydb, RoleManager<IdentityRole> roleManager, UserManager<user> userManager)
        {
            _context = context;
             _storeidentitydb = storeidentitydb;
            _roleManager = roleManager;
            _userManager = userManager;
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

        public async Task Initializeidentity()
        {
            if (_storeidentitydb.Database.GetPendingMigrations().Any())
            {
                await _storeidentitydb.Database.MigrateAsync();
            }
            if (!_roleManager.Roles.Any())
            {
               await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("superadmin"));

            }
            if (!_userManager.Users.Any())
            {
                var superadmin = new user
                {
                    DisplayName = "superadmin",
                    Email= "superadmin@gmail.com",
                    UserName = "superadmin",
                    PhoneNumber = "123456789",
                };
                var admin = new user
                {
                    DisplayName = "admin",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    PhoneNumber = "987654321",
                };
                await _userManager.CreateAsync(superadmin, "Passw0rd");
                 await _userManager.CreateAsync(admin, "Passw0rd");
                await _userManager.AddToRoleAsync(superadmin, "superadmin");
                await _userManager.AddToRoleAsync(admin, "admin");


            }

        }
    }
    }

   
