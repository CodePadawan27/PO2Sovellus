using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Entities
{
    public class SovellusIdentityDbContext : IdentityDbContext<User>
    {
        public SovellusIdentityDbContext(DbContextOptions<SovellusIdentityDbContext> options) :base(options)
        {

        }
    }
}
