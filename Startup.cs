using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PROJECT_GESTOR_V3.Data;
using PROJECT_GESTOR_V3.Filters;
using PROJECT_GESTOR_V3.Helper;
using PROJECT_GESTOR_V3.Repositorio;
using PROJECT_GESTOR_V3.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;

namespace PROJECT_GESTOR_V3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // String de conex�o para o banco de dados.
            services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddControllersWithViews();

            // Inje��o de dependencia da sess�o do usu�rio
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Inje��o de dependencia das Interfaces
            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<IEmail, Email>();
            services.AddScoped<ILivroRepositorio, LivroRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IDespesaRepositorio, DespesaRepositorio>();

            // Registrando os servi�os
            services.AddScoped<GameService>();
            services.AddScoped<FabricaService>();


            // Servi�o de cookies relacionado a sess�o do usu�rio
            services.AddMemoryCache();
            services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var enBR = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enBR),
                SupportedCultures = new List<CultureInfo> { enBR },
                SupportedUICultures = new List<CultureInfo> { enBR },
            };

            app.UseRequestLocalization(localizationOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();         

            app.UseSession(); // Decla��o fas parte da sess�o do usu�rio

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
