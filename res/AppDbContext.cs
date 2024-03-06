using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.res
{
    public class AppDbContext : DbContext
    {

        public DbSet<User>? Users { get; set; }
        public DbSet<Messages>? Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"DATA SOURCE=[Server Name]; DATABASE=[Database Name]; UID=[Username]; PWD=[Password]; TrustServerCertificate=True;");
        }
    }
}
