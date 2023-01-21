using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DIP
builder.Services.AddDbContext<HastaneDB>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));


//builder.Services.AddDefaultIdentity<Uye>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<KutuphaneDB>();

//Varsay�lan Identity ayarlar� i�in kullan�l�r
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<KutuphaneDB>();

builder.Services.AddIdentity<Uye, Rol>().AddEntityFrameworkStores<HastaneDB>();


builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "AdminPanel",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "UyePanel",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
