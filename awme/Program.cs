global using awme.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=awme;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var a = builder.Configuration.GetSection("ConnectionString:DefaultConnection").Value;
app.Run();
