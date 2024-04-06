using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Model.DBContext;
using PizzaPlaceSalesAPI.Services.IServices;
using PizzaPlaceSalesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PizzaDBContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<ICSVService, CSVService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IPizzaTypesService, PizzaTypesService>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

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
