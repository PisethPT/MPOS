using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MPOS.WebMVC.Controllers;
using MPOS.WebMVC.Data;


namespace MPOS.WebMVC
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<DemoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MPOSDB") ?? throw new InvalidOperationException("Data connection strings 'MPOSDB' is not found."))
            );

			builder.Services.AddHttpContextAccessor();
			builder.Services.AddSession();
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromHours(2);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromHours(2);
				options.SlidingExpiration = true;

			});
			builder.Services.Configure<FormOptions>(options =>
			{
				options.ValueCountLimit = int.MaxValue;
			});

            builder.Services.AddScoped<IFileService, FileService>();


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath + "\\Images\\")), RequestPath = "/Resources"
			});

			app.UseRouting();
            app.UseSession();
           
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
