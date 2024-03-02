using App_Todo_Backend.Configurations;
using App_Todo_Backend.Contract;
using App_Todo_Backend.Contract.Users;
using App_Todo_Backend.Data;
using App_Todo_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TodoDbConnectionString");
builder.Services.AddDbContext<TodoDbContext>(options => options.UseNpgsql(connectionString));

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
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("allowall");

app.UseAuthorization();

app.MapControllers();

app.Run();
