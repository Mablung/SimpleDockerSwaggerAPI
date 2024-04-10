using TiklaGelsinAPI.Domain.Repositories;
using TiklaGelsinAPI.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x => x.AddPolicy("CorsPolicy", builder =>
{
    builder.SetIsOriginAllowed((x) => true).AllowCredentials().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSingleton<IProductrepository, ProductRepository>();
builder.Services.AddSingleton<IProductService, ProductService>();
//builder.Services.AddSingleton<ICategoryrepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
