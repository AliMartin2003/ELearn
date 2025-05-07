using ELearn.Core.Interfaces;
using ELearn.Core.Services;
using ELearn.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext
    <ELearnContext>
    (options =>
    options.UseSqlServer("server=;" +
    "DataBase=ELearnDb;" +
    "Initial Catalog=ELearnDb;" +
    "Integrated Security=True;" +
    "MultipleActiveResultSets=True;")
    );

builder.Services.AddScoped<ICourseGroup, CourseGroupServices>();
builder.Services.AddScoped<ICourse, CourseServices>();
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
    pattern: "{controller=Home}/{action=Index}/{id}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exist}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
