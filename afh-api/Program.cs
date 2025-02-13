using System.Runtime.CompilerServices;
using afh_api.Mappings;
using afh_db;
using afh_db.Libraries;
using Microsoft.EntityFrameworkCore;

[assembly: InternalsVisibleTo("afh-be.Tests")]

;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddScoped<IUserLibrary, UserLibrary>();
builder.Services.AddScoped<IMovieLibrary, MovieLibrary>();
builder.Services.AddScoped<ICollectionLibrary, CollectionLibrary>();

builder.Services.AddControllers();
builder.Services.AddDbContext<MovieDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieDBContextSQLite"))
);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MovieDBContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { };
