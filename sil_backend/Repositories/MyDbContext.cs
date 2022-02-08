using Microsoft.EntityFrameworkCore;
using sil_backend.Models;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ResetPassword> ResetPassword { get; set; }
    
    public string DbPath { get; }

    public MyDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "sayitlouder.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
}