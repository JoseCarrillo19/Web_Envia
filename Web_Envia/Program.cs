using Microsoft.EntityFrameworkCore;
using Web_Envia.Infrastructure.Data;
using Web_Envia.Infrastructure.Repository;
using Web_Envia.Infrastructure.Repository.IRepository;
using Web_Envia.Services;
using Web_Envia.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                               options.UseSqlServer(
                                  builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGuidesRegistrationRepository, GuidesRegistrationRepository>();
builder.Services.AddScoped<IGuidesRegistrationServices, GuidesRegistrationServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
