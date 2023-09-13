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

// TAG ENDPOINTS
// View All Tags
app.MapGet("api/Tags", (RareUsersDbContext db) =>
{
    return db.Tags;
});
// Add A Tag to a Post
app.MapPost("api/posts/{postId}/tags/{tagId}", (RareUsersDbContext db, int postId, int tagId) =>
{
    var post = db.Posts
        .Include(p => p.Tags)
        .FirstOrDefault(p => p.Id == postId);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }

    var tag = db.Tags.Find(tagId);

    if (tag == null)
    {
        return Results.NotFound("Tag not found");
    }

    post.Tags.Add(tag);
    db.SaveChanges();
    return Results.Ok(post);
});
// Remove A Tag From A Post
app.MapDelete("api/posts/{postId}/tags/{tagId}", (RareUsersDbContext db, int postId, int tagId) =>
{
    var post = db.Posts
       .Include(p => p.Tags)
       .FirstOrDefault(p => p.Id == postId);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }

    var tag = db.Tags.Find(tagId);

    if (tag == null)
    {
        return Results.NotFound("Tag not found");
    }

    post.Tags.Remove(tag);
    db.SaveChanges();
    return Results.Ok(post);
});
// Create A Tag
app.MapPost("api/tags", (RareUsersDbContext db, Tags Tag) =>
{
    db.Tags.Add(Tag);
    db.SaveChanges();
    return Results.Created($"api/tags{Tag.Id}", Tag);
});
// Update A Tag
app.MapPut("api/tags/{id}", async (RareUsersDbContext db, int id, Tags Tag) =>
{
    Tags tagToUpdate = await db.Tags.SingleOrDefaultAsync(t => t.Id == id);
    if (tagToUpdate == null)
    {
        return Results.NotFound();
    }
    tagToUpdate.Label = Tag.Label;
    db.SaveChanges();
    return Results.NoContent();
});
// Delete A Tag
app.MapDelete("api/tags/{id}", (RareUsersDbContext db, int id) =>
{
    Tags tagToDelete = db.Tags.SingleOrDefault(t => t.Id == id);
    if (tagToDelete == null)
    {
        return Results.NotFound();
    }
    db.Tags.Remove(tagToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();


