using server.Data;
using server.Helper;
using server.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi;
using server.Interface.Repository;
using server.Service;
using server.Interface.Service;
using Microsoft.Extensions.FileProviders;
using server.Mapper;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Base de datos (InMemory por ahora, cambia a SQL Server cuando quieras)
builder.Services.AddDbContext<DataContex>();

builder.Services.AddControllers();                                                                                                                                                                                                                                                                                                                                                                                  
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

// ✅ AutoMapper (FALTABA)
builder.Services.AddAutoMapper(typeof(MappingProfile));

// JWT
var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"], // CORREGIDO
        IssuerSigningKey = new SymmetricSecurityKey(key),
        RequireExpirationTime = true,
        ValidateLifetime = true
    };
});

// Inyección de dependencias
builder.Services.AddScoped<IJwtHelper, JwtHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("auth", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // URL de tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Swagger con seguridad JWT
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

var app = builder.Build();



// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("auth");

app.UseAuthentication(); // CRÍTICO: Faltaba
app.UseAuthorization();


// ✅ Crear la carpeta Uploads si no existe (antes de UseStaticFiles)
var uploadsPath = Path.Combine(builder.Environment.ContentRootPath, "Uploads");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/image"
});


app.MapControllers();

app.Run();
