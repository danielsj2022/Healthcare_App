using System;
using Library.Healthcare.Models;
using Microsoft.EntityFrameworkCore;


namespace Api.Healthcare.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<Physician> Physicians { get; set; }
}
