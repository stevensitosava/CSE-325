
using Microsoft.EntityFrameworkCore;
using StevenMovies.Data;

var builder = WebApplication.CreateBuilder(args);

// Register MVC services
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core with SQLite
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("MovieContext")
    )
);

var app = builder.Build();

// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
