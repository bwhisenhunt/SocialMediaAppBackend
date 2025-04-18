using Backend.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class PostDbContextFactory : IDesignTimeDbContextFactory<PostDbContext>
{
    public PostDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PostDbContext>();
        optionsBuilder.UseSqlite("Data Source=Backend.db");

        return new PostDbContext(optionsBuilder.Options);
    }
}
