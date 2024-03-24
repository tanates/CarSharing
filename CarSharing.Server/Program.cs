using CarSharing.Models.AuthorizationModels;
using CarSharing.Server;
using CarSharing.Server.Interface;
using CarSharing.Server.Interface.Auth;
using CarSharing.Server.Interface.Car;
using CarSharing.Server.Interface.CarInterface;
using CarSharing.Server.Models;
using CarSharing.Server.Models.JWT;
using CarSharing.Server.Repository;
using CarSharing.Server.Servisec;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey=true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("top_secrit_key_l_tanatesssssssss"))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["testy-login"];
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRentaACarRepository, RentalRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CartCarsService>();
builder.Services.AddScoped<RentalServisec>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped <IPasswordHash , PasswordHash>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<ICheckingAccountStatus, CheckingAccountStatus>();
builder.Services.AddAutoMapper(typeof(DataBaseMapping));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
