using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensSkabelon.Database
{
    //indstaller microsoft.entityframeworkcore.sqlserver v. 9.0.11
    public class ClassDbContext : DbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {

        }
        public DbSet<Class1> Items { get; set; }
    }
}
