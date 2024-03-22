using App_Todo_Backend.Configurations;
using App_Todo_Backend.Contract;
using App_Todo_Backend.Contract.Users;
using App_Todo_Backend.Data;
using App_Todo_Backend.Middleware;
using App_Todo_Backend.Repository;
using App_Todo_Backend.Repository.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TodoDbConnectionString");
builder.Services.AddDbContext<TodoDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddTokenProvider<DataProtectorTokenProvider<User>>(builder.Configuration["RefreshToken:LoginProvider"])
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TodoDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall",
           builder =>
           {
               builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
           });
});


//Serilog configuration to register logs in different destinations, including console, file and Seq server.
builder.Host.UseSerilog((context, loggerConfig)  => loggerConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));    
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    }); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionsMiddleware>();

app.UseHttpsRedirection();

app.UseCors("allowall");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
