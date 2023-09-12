using GroupProj.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using GroupProj;

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

app.UseHttpsRedirection();

//all posts crud
//create posts
app.MapPost("/api/posts", async (RareUsersDbContext db, Posts post) =>
{
    db.Posts.Add(post);
    await db.SaveChangesAsync();
    return Results.Created($"/api/posts/{post.Id}", post);
});

//read posts
app.MapGet("/api/posts", (RareUsersDbContext db) =>
{
    var posts = db.Posts.ToList();
    return Results.Ok(posts);
});

//update posts
app.MapPut("/api/posts/{id}", async (RareUsersDbContext db, int id, Posts post) =>
{
    if (id != post.Id)
    {
        return Results.BadRequest();
    }

    db.Entry(post).State = EntityState.Modified;

    try
    {
        await db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!db.Posts.Any(s => s.Id == id))
        {
            return Results.NotFound();
        }
        else
        {
            throw;
        }
    }

    return Results.NoContent();
});

//delete posts
app.MapDelete("/api/posts/{id}", async (RareUsersDbContext db, int id) =>
{
    var post = await db.Posts.FindAsync(id);
    if (post == null)
    {
        return Results.NotFound();
    }

    db.Posts.Remove(post);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();


