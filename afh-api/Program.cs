using System.Runtime.CompilerServices;
using System.Text;
using afh_api.Mappings;
using afh_be.Auth.Data;
using afh_be.Auth.Models;
using afh_db;
using afh_db.Libraries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

// Add services to the container.
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder
    .Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Configure JWT Bearer Auth
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });

// Add authorization
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataProtection();

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

app.UseAuthentication();

app.MapControllers();

app.MapGet(
    "/username",
    (HttpContext ctx, IDataProtectionProvider idp) =>
    {
        var protector = idp.CreateProtector("auth-cookie");

        var authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith(".Asp"));
        if (authCookie != null)
        {
            var protectedPayload = authCookie.Split("=").Last();
            var payload = protector.Unprotect(protectedPayload);
            var parts = payload.Split(":");
            var key = parts[0];
            var value = parts[1];
            return value;
        }
        else
        {
            return "no cookie";
        }
        // return "anton";
    }
);

app.MapGet(
    "/login",
    (HttpContext ctx, IDataProtectionProvider idp) =>
    {
        var protector = idp.CreateProtector("auth-cookie");
        ctx.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:anton")}";
        return "anton, we have sent the cookie";
    }
);

app.Run();

public partial class Program { };
