using IAAI_CAR.Data;
using IAAI_CAR.Repositories;
using IAAI_CAR.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging(config => config.AddConsole());
builder.Logging.AddConsole(); // Add this line

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<MongoDBSettings>(
builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddSingleton<MongoDBContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");


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
