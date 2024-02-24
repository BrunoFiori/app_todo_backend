using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

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
