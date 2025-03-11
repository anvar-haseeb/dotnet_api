using Dependency_Injection.Infrastructure;
using Dependency_Injection.Middleware;
using Dependency_Injection.Services;
using NLog.Web;

var builder = WebApplication.CreateBuilder( new WebApplicationOptions
{
    WebRootPath ="StaticFiles"
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailSenderServices, EmailSenderServices>();

builder.Services.AddTransient<IRandomNumberService, RandomNumberService>();
//builder.Services.AddScoped<IRandomNumberService, RandomNumberService>();
//builder.Services.AddSingleton<IRandomNumberService, RandomNumberService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Logging.ClearProviders();  // Removes default logging providers
builder.Host.UseNLog();  // Use NLog as the logging provider

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//serve static files
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

// 🔹 Required before UseEndpoints()
app.UseRouting();
app.UseExceptionHandler();

//app.UseMiddleware<CustomMiddleware>();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/Home"), appBuilder =>
{
    appBuilder.UseMiddleware<CustomMiddleware>();
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
