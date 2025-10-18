using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<Persistence.AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    //in caso di db diversi, usare diverse connection string
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//Map controler server per appunto mappare i controller >
//e usarli per le richieste http
app.MapControllers();

//app.Services ci da accesso a tutti i servizi della nostra app (controller, logger, ecc)
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AppDbContext>();
    //MigrateAsync applica eventuali migrazioni pendenti al database se e' vuoto
    await context.Database.MigrateAsync();
    //DbInitializer lo possiamo usare cosi perche e' static
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
