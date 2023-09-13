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

app.MapGet("/users", (RareUsersDbContext db) =>
{
    return db.Users.ToList();
});

app.MapGet("/user/{id}", (RareUsersDbContext db, int id) =>
{
    var user = db.Users.Where(u => u.Id == id);
    return user;
});

app.MapGet("/comments", (RareUsersDbContext db) =>
{
    return db.Comments.ToList();
});

app.MapPost("/comment", (RareUsersDbContext db, Comments comment) =>
{
        comment.CreatedOn = DateTime.Now;

        db.Comments.Add(comment);
        db.SaveChanges();
        return Results.Ok(comment);
});

app.MapPut("/comment/{id}", (RareUsersDbContext db, int id, Comments comment) =>
{
    Comments commentToUpdate = db.Comments.FirstOrDefault(c => c.Id == id);
    if (commentToUpdate == null)
    {
        return Results.NotFound();
    }
    commentToUpdate.Content = comment.Content;
    db.SaveChanges();
    return Results.Ok(comment);
});

app.MapDelete("/comment/{id}", (RareUsersDbContext db, int id) =>
{
    Comments commentToDelete = db.Comments.FirstOrDefault(c => c.Id == id);
    if (commentToDelete == null)
    {
        return Results.NotFound(id);
    }
    db.Comments.Remove(commentToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/postcomments/{id}", (RareUsersDbContext db, int id) =>
{
    var postToGetComments = db.Posts.Where(c => c.Id == id).Include(c => c.Comments).ToList();
    return postToGetComments;
    
});

app.MapGet("/subs", (RareUsersDbContext db) =>
{
    return db.Subscriptions.ToList();
});

app.MapPost("/subscribe", (RareUsersDbContext db, Subscriptions sub) => 
{
    sub.CreatedOn = DateTime.Now;

    db.Subscriptions.Add(sub);
    db.SaveChanges();
    return Results.Ok(sub);
});

app.MapPut("/unsubscribe/{id}", (RareUsersDbContext db, int id, Subscriptions sub) => 
{
    Subscriptions unsubTo = db.Subscriptions.FirstOrDefault(s => s.Id == id);
    if (unsubTo ==  null)
    {
        return Results.NotFound();
    }
    unsubTo.EndedOn = DateTime.Now;
    db.SaveChanges();
    return Results.Ok(unsubTo);
});

app.Run();
