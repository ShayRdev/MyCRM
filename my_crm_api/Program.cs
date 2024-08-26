using my_crm_api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using my_crm_api.Options;

var builder = WebApplication.CreateBuilder(args);

// Configure Authentication Secrets

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("CRMAppCon"));
});

//JSON serializer Shayr
builder.Services.AddControllersWithViews().AddNewtonsoftJson();

var app = builder.Build();

//Enable CORS - Shayr
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



// Configure the HTTP request pipeline.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
