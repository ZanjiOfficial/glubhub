using glubhub.Components;
using glubhub.Persistent.Repositories;
using glubhub.Persistent.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime;
using glubhub.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();


//DBContext ConnectionString
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



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

app.MapRazorComponents<App>();

app.Run();
