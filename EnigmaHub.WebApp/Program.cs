using EliteDomus.WebApp;
using EnigmaHub.Domain.Context;
using EnigmaHub.Domain.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = LogManager.Setup()
    .LoadConfigurationFromFile("NLog.config")
    .GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Configuration
        .SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile($"./Config/appsettings.{builder.Environment.EnvironmentName}.json", true)
        .AddEnvironmentVariables();
    
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseNLog();
    
    ConfigurationManager Configuration = builder.Configuration;
    
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
    
    builder.Services.AddIdentity<MyUser, IdentityRole>(opts =>
        {
            opts.SignIn.RequireConfirmedEmail = true;
            opts.SignIn.RequireConfirmedAccount = false;
            opts.Password.RequireDigit = true;
            opts.Password.RequireLowercase = true;
            opts.Password.RequireUppercase = true;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
    
    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30); 
        options.Cookie.HttpOnly = true; 
        options.Cookie.IsEssential = true; 
    });
    
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/auth/login";
        options.LogoutPath = "/auth/logout";
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = ctx =>
            {
                var returnUrl = ctx.Request.Path + ctx.Request.QueryString;
                ctx.Response.Redirect(options.LoginPath + $"?ReturnUrl={Uri.EscapeDataString(returnUrl)}");
                return Task.FromResult(0);
            }
        };
    });
    
    builder.Services.RegisterServices();

    var app = builder.Build();
    
    app.UseSession();
    
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials());

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<MyUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        
        context.Database.Migrate();
        await DbInitializer.SeedUsersAndRoles(userManager, roleManager, context, Configuration);
    }
    
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}