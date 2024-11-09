using CrudApplicationWithMySql3.RepositoryLayer;
using CrudApplicationWithMySql3.ServiceLayer;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your services and repositories
builder.Services.AddScoped<ICrudApplicationSL, CrudApplicationSL>();
builder.Services.AddScoped<ICrudApplicationRL, CrudApplicationRL>();

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
