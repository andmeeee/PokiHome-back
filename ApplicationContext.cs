using Microsoft.EntityFrameworkCore;
using PokiHome.Demo.Data.Entities;

namespace PokiHome.Demo.Data;

public class ApplicationContext : DbContext
{
    
    public DbSet<Home> Home { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

}


