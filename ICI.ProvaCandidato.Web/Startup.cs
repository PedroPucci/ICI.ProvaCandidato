using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Repository;
using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio;
using ICI.ProvaCandidato.Negocio.Services;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ICI.ProvaCandidato.Web
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddDbContext<DataBaseContext>(options =>
			{
				options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste Pedro Ighor", Version = "v1" });
			});

			services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
			services.AddScoped<IRepositoryUoW, RepositoryUoW>();

			//services.AddTransient<IRepositoryUoW, RepositoryUoW>();
			//services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste"));
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}