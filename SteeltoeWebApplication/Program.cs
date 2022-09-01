using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;
using Steeltoe.Connector.SqlServer.EFCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SteeltoeWebApplication.Models.TodoDbContext>(options => options.UseSqlServer(builder.Configuration));

// Steeltoe actuators
builder.AddAllActuators();

// Steeltoe distributed tracing
builder.Services.AddDistributedTracingAspNetCore();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<SteeltoeWebApplication.Models.TodoDbContext>();
await dbContext.Database.EnsureCreatedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
