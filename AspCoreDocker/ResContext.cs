using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreDocker.Entities;

namespace AspCoreDocker
{
    public class ResContext: DbContext
    {
        public DbSet<ResourceItem> Resources { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ResContext(DbContextOptions opt): base(opt)
        {

        }
    }
}
