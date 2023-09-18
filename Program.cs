using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Pramerica_Assignment.Claims;
using Pramerica_Assignment.Context;
using Pramerica_Assignment.Models;
using Pramerica_Assignment.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AccountContext>(options => options.UseSqlServer("Server=.; Database=StudentRegistration; Integrated Security=True; "));
builder.Services.AddDbContext<StudentDetailsContext>(options => options.UseSqlServer("Server=.; Database=StudentDetails; Integrated Security=True; "));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IStudentDetailsRepository, StudentDetailsRepository>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaims>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AccountContext>()
    .AddRoles<IdentityRole>();
builder.Services.ConfigureApplicationCookie(config => { config.LoginPath = "/"; });

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
/*Adding Authentication Middleware for Using Authorize Attribute*/
app.UseAuthentication();
app.UseAuthorization();


/*Here Is my Conventional way of routing */
app.MapControllerRoute(
                 name: "default",
                    pattern: "{controller=Account}/{action=LoginForm}/{id?}"

    );

app.Run();
