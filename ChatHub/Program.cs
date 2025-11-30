using ChatHub;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();



//allowing cors from client
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7024/")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();


app.MapHub<MainChatHub>("/chathub");

app.UseCors();

app.Run();
