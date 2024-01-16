using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class IdentityDataBaseContext:IdentityDbContext<User>
    {
        public IdentityDataBaseContext(DbContextOptions<IdentityDataBaseContext> options)
            :base(options)
        {
            
        }
    }
}
