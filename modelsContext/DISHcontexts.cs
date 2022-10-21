using Microsoft.EntityFrameworkCore;

public class dishContext:DbContext
{
    public dishContext(DbContextOptions<dishContext> options):base(options)
    {
        
    }
    public DbSet<dishes> dishes{get;set;}

}


