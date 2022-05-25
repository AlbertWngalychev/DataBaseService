using DataBaseService.Data;
using DataBaseService.Logger;
using DataBaseService.Models;
//using NLog;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<dipContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IClientRepo, ClientRepo>();
builder.Services.AddScoped<IDelAddessRepo, DelAddessRepo>();
builder.Services.AddScoped<ITypeRepo, TypeRepo>();
builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
builder.Services.AddScoped<IGenderRepo, GenderRepo>();
builder.Services.AddScoped<IClothRepo, ClothRepo>();
builder.Services.AddScoped<IPriceRepo, PriceRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IMaterialRepo, MaterialRepo>();
builder.Services.AddScoped<IClothesRepo, ClothesRepo>();
builder.Services.AddScoped<IPhotoRepo, PhotoRepo>();
builder.Services.AddScoped<IValueRepo, ValueRepo>();
builder.Services.AddScoped<IOrderElementRepo, OrderElementRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<ICharacteristicsRepo, CharacteristicsRepo>();
builder.Services.AddScoped<IModifRepo, ModifRepo>();
builder.Services.AddScoped<IStatusRepo, StatusRepo>();
builder.Services.AddScoped<IShopingCartRepo, ShopingCartRepo>();
builder.Services.AddScoped<ICharacteristicsModificationRepo, CharacteristicsModificationRepo>();
builder.Services.AddScoped<ICharacteristicsValueRepo, CharacteristicsValueRepo>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

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