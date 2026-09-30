using server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Helper;
using server.Repository;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration=builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<DataContex>(opt=>opt.UseInMemoryDatabase(configuration["ConnectionStrings:DbName"]?? "authDb"));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var key= Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
builder.Services.AddAuthentication(x=>
{
    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters=new TokenValidationParameters
    {
        ValidateIssuerSigningKey=true,
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidIssuer=configuration["Jwt:Issuer"],
        ValidAudience=configuration["Jwt:Issuer"],
        IssuerSigningKey=new SymmetricSecurityKey(key),
        RequireExpirationTime=true,
        ValidateLifetime=true
    };
});

builder.Services.AddScoped<IJwtHelper,JwtHelper>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
