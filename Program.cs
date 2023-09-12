using GroupProj.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using GroupProj;
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

app.UseHttpsRedirection();


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


