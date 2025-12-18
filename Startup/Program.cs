using BlazorAuth.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BlazorAuth.Startup
{
	/// <summary>
	/// Main program entry point
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Main entry point
		/// </summary>
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();

			// Add authentication services
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Cookie.Name = "BlazorAuth.Cookie";
					options.LoginPath = "/login";
					options.LogoutPath = "/logout";
					options.AccessDeniedPath = "/access-denied";
					options.ExpireTimeSpan = TimeSpan.FromHours(8);
					options.SlidingExpiration = true;
				});

			builder.Services.AddAuthorization();
			builder.Services.AddCascadingAuthenticationState();
			builder.Services.AddHttpContextAccessor();

			// Add custom authentication service
			builder.Services.AddScoped<IAuthService, AuthService>();

			WebApplication app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAntiforgery();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapRazorComponents<BlazorAuth.Components.App>()
				.AddInteractiveServerRenderMode();

			app.Run();
		}
	}
}