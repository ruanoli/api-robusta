using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {
            
        }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {}

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        // {
        //     optionsbuilder.UseSqlServer(@"Data Source=NOTE-RC\SQLEXPRESS;Initial Catalog=USERMANAGERAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        // }

        public virtual DbSet<User> Users { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
        
    }
}