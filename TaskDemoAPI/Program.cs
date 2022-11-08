using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using TaskDemoAPI.Entities;
using TaskDemoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up MongoDB conventions
var pack = new ConventionPack
{
    new EnumRepresentationConvention(BsonType.String)
};

ConventionRegistry.Register("EnumStringConvention", pack, t => true);

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