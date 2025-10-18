using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options) //server options per il program.cs
{
     public required DbSet<Activity> Activities { get; set; }
}
