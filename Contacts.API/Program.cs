using Contacts.Infrastructure.Common;
using Contacts.Application.Common;
using Contacts.API;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});
services.AddInfrastructure(configuration);
services.AddApplication();
services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
