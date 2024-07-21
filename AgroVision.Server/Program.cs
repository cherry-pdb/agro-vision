using AgroVision.Core.Repositories;
using AgroVision.Database.Context;
using AgroVision.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgroVision", Version = "v1" });
});

services.AddDbContext<AgroVisionContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IAgrochemicalCharacteristicsRepository, AgrochemicalCharacteristicsRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "AgroVision v1"));

}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(routeBuilder => routeBuilder.MapControllers());

app.Run();