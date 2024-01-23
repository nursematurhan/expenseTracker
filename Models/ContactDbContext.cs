using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // if (!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=ContactDB; integrated security =true;");

    }
}
