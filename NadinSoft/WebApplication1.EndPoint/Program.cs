using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connection String 
builder.Services.AddDbContext<DataBaseContext>(
    p => p.UseSqlServer(
        "Server=.;Database=Db_NadinSoft;Trusted_Connection=True;TrustServerCertificate =True"
         ));

builder.Services.AddDbContext<IdentityDataBaseContext>(
    p => p.UseSqlServer(
        "Server=.;Database=Db_NadinSoft;Trusted_Connection=True;TrustServerCertificate =True"
         ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
