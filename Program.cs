using App_Todo_Backend.Core.Configurations;
using App_Todo_Backend.Core.Contract;
using App_Todo_Backend.Core.Contract.Todo;
using App_Todo_Backend.Core.Contract.Users;
using App_Todo_Backend.Core.Middleware;
using App_Todo_Backend.Core.Repository;
using App_Todo_Backend.Core.Repository.Auth;
using App_Todo_Backend.Core.Repository.Todo;
using App_Todo_Backend.Data;
using Asp.Versioning;
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

builder.Services.AddApiVersioning(config =>
{
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.ReportApiVersions = true;
    config.ApiVersionReader = ApiVersionReader.Combine(
            new HeaderApiVersionReader("api-version"),
            new QueryStringApiVersionReader("X-Version"),
            new MediaTypeApiVersionReader("ver")
        );
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

//Serilog configuration to register logs in different destinations, including console, file and Seq server.
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

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

builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 1024;
    options.UseCaseSensitivePaths = true;
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

app.UseResponseCaching();
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
    {
        Public = true,
        MaxAge = TimeSpan.FromSeconds(10) // This indicates that the response can be cached by the client for a maximum of 10 seconds before it needs to be revalidated with the serve 
    };
    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] { "Accept-Encoding" };

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
