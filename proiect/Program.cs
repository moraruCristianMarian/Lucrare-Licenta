using data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql
    ("Host=localhost;Port=5432;Database=AppDb;Username=postgres;Password=postgres")
);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//  CREATE
app.MapPost("/restaurant", async (ApplicationDbContext db, Restaurant r) =>
{
    db.Restaurants.Add(r);
    await db.SaveChangesAsync();

    return Results.Created($"/restaurant/{r.Id}", r);
});

//  READ ALL
app.MapGet("/restaurant", async (ApplicationDbContext db) =>
{
    return await db.Restaurants.ToListAsync();
});
//  READ ONE
app.MapGet("/restaurant/{id}", async (ApplicationDbContext db, Guid id) =>
{
    return db.Restaurants.Find(id);
});

//  UPDATE
app.MapPut("/restaurant/{id}", async (ApplicationDbContext db, Restaurant r, Guid id) =>
{
    var updatedRestaurant = db.Restaurants.Find(id);
    if (updatedRestaurant == null)
        return;

    updatedRestaurant.Name = r.Name;
    updatedRestaurant.City = r.City;

    await db.SaveChangesAsync();
});

//  DELETE
app.MapDelete("/restaurant/{id}", async (ApplicationDbContext db, Guid id) =>
{
    var deletedRestaurant = db.Restaurants.Find(id);
    if (deletedRestaurant == null)
        return;

    db.Restaurants.Remove(deletedRestaurant);
    db.SaveChangesAsync();
});




app.Run();