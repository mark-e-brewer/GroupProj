using GroupProj.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using GroupProj;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<RareUsersDbContext>(builder.Configuration["RareUsersDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/Categories", (RareUsersDbContext db) =>
{
    return db.Categories.ToList();
});

app.MapGet("/api/Categories/{id}", (RareUsersDbContext db, int id) =>
{
    return db.Categories.FirstOrDefault(c => c.Id == id);
});

app.MapPost("/api/Categories", (RareUsersDbContext db, Categories category) =>
{
    db.Categories.Add(category);
    db.SaveChanges();
    return Results.Ok();
});

app.MapDelete("/api/categories/{id}", (RareUsersDbContext db, int id) =>
{
    Categories categories = db.Categories.SingleOrDefault(categories => categories.Id == id);
    if (categories == null)
    {
        return Results.NotFound();
    }
    db.Categories.Remove(categories);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPut("/api/categories/{id}", (RareUsersDbContext db, int id, Categories categories) =>
{
    Categories categoriesToUpdate = db.Categories.SingleOrDefault(c => c.Id == id);
    if (categoriesToUpdate == null)
    {
        return Results.NotFound();
    }
    categoriesToUpdate.Label = categories.Label;
    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/posts/categories/{id}", (RareUsersDbContext db, int id) =>
{
    var posts = db.Posts.Where(p => p.CategoriesId == id).Include(x => x.Categories).ToList();
    
    if (posts == null || posts.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(posts);
});





app.UseHttpsRedirection();

app.Run();


