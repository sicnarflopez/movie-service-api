using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using movie_api.Authentication;
using movies_api.Data.Context;
using movies_api.Logic.Interfaces;
using movies_api.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase"))
{
    builder.Services.AddDbContext<MovieDbContext>(options =>
        options.UseInMemoryDatabase("MovieDb"));
}
else
{
    builder.Services.AddDbContext<MovieDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
        {
            options.MigrationsAssembly("movies-api.Data");
            options.EnableRetryOnFailure();
        });
    });
}

builder.Services.AddScoped<IMovieDbContext>(provider => provider.GetRequiredService<MovieDbContext>());
builder.Services.AddScoped<DbContextInitializer>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowMyApp");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<DbContextInitializer>();

    if (!builder.Configuration.GetValue<bool>("UseInMemoryDatabase"))
    {
        //Initialize database
        await initialiser.InitialiseAsync();
    }

    //Seed database
    await initialiser.SeedDefaultDataAsync();
}

app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
