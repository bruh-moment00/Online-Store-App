using Microsoft.EntityFrameworkCore;
using Online_Store_Backend;
using Online_Store_Backend.Database.Contexts;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.ConfigureServices(builder.Configuration, connection);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.MapGet("/", (OnlineStoreDbContext db) => db.Employees.ToList());

app.Run();
