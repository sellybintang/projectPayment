using Microsoft.EntityFrameworkCore;
using project.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();


//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection DB
builder.Services.AddDbContext<paymentDetailContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors(options =>
options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
