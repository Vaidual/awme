global using awme.Data;
using awme.Controllers;
using awme.Data.Dto.Profile;
using awme.Services.AnimalServices;
using awme.Services.AnimalTypeServices;
using awme.Services.ProfileSevices;
using awme.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SimplePatch;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnimalTypeService, AnimalTypeService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IProfileSevice, ProfileSevice>();

//await AnimalDataController.Handle_Received_Application_Message();
builder.Services.AddSingleton(new AnimalDataController().Handle_Received_Application_Message());

//DeltaConfig.Init(cfg => {
//    cfg.AddEntity<ProfileUpdateRequest>();
//});
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.UseInlineDefinitionsForEnums();
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard authorization header using Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
}).AddSwaggerGenNewtonsoftSupport();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration["JwtConfig:Secret"]!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
});

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

app.MapControllers();

app.Run();