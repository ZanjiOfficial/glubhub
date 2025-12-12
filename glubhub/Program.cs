using glubhub.Components;
using glubhub.Components.Account;
using glubhub.Data;
using glubhub.Models;
using glubhub.Persistent.Interfaces;
using glubhub.Persistent.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Reflection;


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

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });

            builder.Services.Configure<HubOptions>(options =>
            {
                options.EnableDetailedErrors = true;
                options.KeepAliveInterval = TimeSpan.FromSeconds(15);
                options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
            });

            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    ["application/octet-stream"]);
            });

            builder.Services.AddMudServices();

            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddScoped<IdentityUserAccessor>();

            builder.Services.AddScoped<IdentityRedirectManager>();



            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();


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
            builder.Services.AddScoped(typeof(ICommentsRepository<>), typeof(CommentsRepository<>));
            builder.Services.AddScoped(typeof(ILikeRepository<>), typeof(LikeRepository<>));

            builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true);
            builder.Services.AddHttpClient<WeatherService>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddMudServices();
          




            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                app.UseHsts();
            }

            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAntiforgery();
            app.MapAdditionalIdentityEndpoints();



            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();

        }
    }
}
