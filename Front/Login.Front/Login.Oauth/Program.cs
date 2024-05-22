using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Login.Oauth.Data;
using Login.Oauth;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FitZoneContextConnection") ?? throw new InvalidOperationException("Connection string 'LoginOauthContextConnection' not found.");

builder.Services.AddDbContext<LoginOauthContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ContextoBaseDatos>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LoginOauthContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration.GetValue<string>("Authentication:Google:ClientId")??"";
    googleOptions.ClientSecret = builder.Configuration.GetValue<string>("Authentication:Google:ClientSecret")??"";
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
