using Database.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public class Context : DbContext
    {

        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<SchoolModel> Schools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost,1433;Initial Catalog=IndexTest;Integrated Security=True;Trusted_Connection=False;User Id=sa;Password=MyPass@word");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.ToTable("Schools");

                entity.HasIndex(s => s.Name);
            });
        }
    }
}
