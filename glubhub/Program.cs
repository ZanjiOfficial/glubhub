using glubhub.Components;
using glubhub.Models;
using glubhub.Persistent.Repositories;
using glubhub.Components;
using glubhub.Data;
using glubhub.Persistent.Interfaces;
using glubhub.Persistent.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime;
using glubhub.Data;
using glubhub.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace glubhub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
               




            //DBContext ConnectionString
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
            builder.Services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));
            builder.Services.AddScoped(typeof(IFishRepository<>), typeof(FishRepository<>));
            builder.Services.AddScoped(typeof(IGearRepository<>), typeof(GearRepository<>));
            builder.Services.AddScoped(typeof(IGroupRepository<>), typeof(GroupRepository<>));
            builder.Services.AddScoped(typeof(ILocationRepository<>), typeof(LocationRepository<>));
            builder.Services.AddScoped(typeof(IMessageRepository<>), typeof(MessageRepository<>));
            builder.Services.AddScoped(typeof(IPictureRepository<>), typeof(PictureRepository<>));
            builder.Services.AddScoped(typeof(IPostRepository<>), typeof(PostRepository<>));
            builder.Services.AddScoped(typeof(ITechniqueRepository<>), typeof(TechniqueRepository<>));
            builder.Services.AddScoped(typeof(ITimeRepository<>), typeof(TimeRepository<>));
            builder.Services.AddScoped(typeof(ITipsRepository<>), typeof(TipsRepository<>));
            builder.Services.AddScoped(typeof(IWeatherRepository<>), typeof(WeatherRepository<>));

            builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true);
            builder.Services.AddHttpClient<WeatherService>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();

app.MapAdditionalIdentityEndpoints();;

app.Run();
