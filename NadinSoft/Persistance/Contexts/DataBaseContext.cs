using Application.Interfaces.Contexts;
using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class DataBaseContext: DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}
