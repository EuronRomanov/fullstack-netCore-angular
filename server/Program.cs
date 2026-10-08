using server.Data;
using server.Helper;
using server.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Base de datos (InMemory por ahora, cambia a SQL Server cuando quieras)
builder.Services.AddDbContext<DataContex>(opt =>
    opt.UseInMemoryDatabase(configuration["ConnectionStrings:DbName"] ?? "authDb"));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

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

app.UseAuthentication(); // CRÍTICO: Faltaba
app.UseAuthorization();

app.MapControllers();

app.Run();
