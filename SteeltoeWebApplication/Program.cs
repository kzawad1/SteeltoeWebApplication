using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Steeltoe distributed tracing
builder.Services.AddDistributedTracingAspNetCore();

// Steeltoe actuators
builder.AddHealthActuator();
builder.AddInfoActuator();
builder.AddLoggersActuator();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
