using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReabrProject.RebarProject.Repositories.Entities;
using ReabrProject.RebarProject.Repositories.Interfaces;
using ReabrProject.RebarProject.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add this code to the ConfigureServices method in your Startup.cs file

builder.Services.Configure<RebarStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(RebarStoreDatabaseSettings)));
builder.Services.AddSingleton<IRebarStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<RebarStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>(
        "RebarStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentDBRepository,PaymentDBRepository>();

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