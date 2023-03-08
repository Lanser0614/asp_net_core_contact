using aspNetCoreContact.Models;
using Microsoft.EntityFrameworkCore;

namespace aspNetCoreContact.Configs.DataBase.ApplicationDbContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<StudentDetails> students { get; set; }
    public DbSet<Contact> contacts { get; set; }

}