using GalacticTitans.ApplicationServices.Services;
using GalacticTitans.Core.ServiceInterface;
using GalacticTitans.Data;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/* Adding titanservices as if it was a normal service */
builder.Services.AddScoped<ITitansServices, TitansServices>();
//builder.Services.AddScoped<ITagHelper, TagHelper>();

builder.Services.AddDbContext<GalacticTitansContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("UnstableBranchConnection")));

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
