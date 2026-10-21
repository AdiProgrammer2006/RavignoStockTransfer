
using Microsoft.EntityFrameworkCore;
using StockTransfer.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();


// Register OpenAPI
builder.Services.AddOpenApi();

// Register SQLite database
builder.Services.AddDbContext<appDBContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
// Create database and insert seed data


Console.WriteLine("DATABASE INITIALIZATION STARTED");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<appDBContext>();

    Console.WriteLine("Database path: " +
        db.Database.GetDbConnection().DataSource);

    bool created = db.Database.EnsureCreated();

    Console.WriteLine("Database newly created: " + created);

    DbSeeder.Seed(db);
}

Console.WriteLine("DATABASE INITIALIZATION COMPLETED");


// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
