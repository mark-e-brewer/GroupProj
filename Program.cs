using GroupProj.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using GroupProj;
using System.Runtime.CompilerServices;
using System.Net;


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
=======

//Registe a new user Issue #47
app.MapPost("/newUser", (RareUsersDbContext db, RareUsers user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/newUser/{user.Id}", user);

});

//Create a new reaction  as an admin Issue #5
app.MapPost("/newReaction", (RareUsersDbContext db, Reaction reaction, int UserId) =>
{
    var getUser = db.Users.FirstOrDefault (u => u.Id == UserId);

    if (getUser.IsStaff == true) { 
        db.Reactions.Add(reaction);
        db.SaveChanges();
        return Results.Created($"/newReaction/{reaction.Id}", reaction);
    }

    else
    {
        throw new ("You must be an admin to create a reation!");
    }
});


//Show subscriber count on UserProfile Issue #3
app.MapGet("/subscribersCount", (RareUsersDbContext db, int authorId) =>
{
    var subCount= db.Subscriptions.Where(s => s.AuthorId == authorId).Count();
    return subCount;

});

app.Run();


