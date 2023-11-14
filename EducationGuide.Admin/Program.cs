using EducationGuide.Admin.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using EducationGuide.Admin.Authentication;
using Infrastructure.Data;
using Core.Models.Repository;
using Radzen;
using EducationGuide.Admin.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<IUserRepositoty, UserRepository>();
builder.Services.AddTransient<ISectionRepository, SectionRepository>();
builder.Services.AddTransient<IPageRepository, PageRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EducationGuideAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp
	=> sp.GetRequiredService<EducationGuideAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();
builder.Services.AddDbContext<PageContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
