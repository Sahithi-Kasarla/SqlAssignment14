using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppTwo.Models;

namespace WebAppTwo.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext (DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppTwo.Models.Product> Product { get; set; } = default!;
    }
}
