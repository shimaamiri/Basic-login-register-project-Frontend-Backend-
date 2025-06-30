using Microsoft.EntityFrameworkCore;
using UserAuthApi.Data;
using UserAuthApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controller services
builder.Services.AddControllers();

//Add Swagger for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AuthService for dependency injection
builder.Services.AddScoped<AuthService>();

// Configure EF Core to use SQL Server with connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable CORS for requests from Angular (localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply CORS policy
app.UseCors("AllowAngularApp");

// Enable Swagger only in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP to HTTPS and enforce security
app.UseHttpsRedirection();

// Authorization middleware
app.UseAuthorization();

// Map controller endpoints (API routes)
app.MapControllers();

app.Run();
