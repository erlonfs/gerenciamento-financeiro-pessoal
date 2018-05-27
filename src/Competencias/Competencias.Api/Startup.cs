using Competencias.Api;
using Competencias.Domain;
using Competencias.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Common;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;

public class Startup
{
	private Container container = new Container();
	public IConfiguration Configuration { get; }

	public Startup(IHostingEnvironment env, IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc();

		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new Info { Title = "Competencia API", Version = "v1" });
		});

		services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDatabase")));

		IntegrateSimpleInjector(services);
	}

	private void IntegrateSimpleInjector(IServiceCollection services)
	{
		container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		services.AddSingleton<IControllerActivator>(
			new SimpleInjectorControllerActivator(container));
		services.AddSingleton<IViewComponentActivator>(
			new SimpleInjectorViewComponentActivator(container));

		services.EnableSimpleInjectorCrossWiring(container);
		services.UseSimpleInjectorAspNetRequestScoping(container);
	}

	// Configure is called after ConfigureServices is called.
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		InitializeContainer(app);

		container.Verify();

		app.UseMvc();
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "Competencia API V1");
		});
	}

	private void InitializeContainer(IApplicationBuilder app)
	{
		container.RegisterMvcControllers(app);
		container.RegisterMvcViewComponents(app);

		container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

		var assemblies = new[] { typeof(CompetenciaCriadaHandler).Assembly };
		container.RegisterCollection(typeof(IHandler<>), assemblies);

		// Allow Simple Injector to resolve services from ASP.NET Core.
		container.AutoCrossWireAspNetComponents(app);

		DomainEvents.Init(container);

	}
}