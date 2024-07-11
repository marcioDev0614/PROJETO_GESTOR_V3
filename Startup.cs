using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PROJECT_GESTOR_V3.Data;
using PROJECT_GESTOR_V3.Helper;
using PROJECT_GESTOR_V3.Models;
using PROJECT_GESTOR_V3.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // String de conexão para o banco de dados.
            services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddControllersWithViews();

            // Injeção de dependencia da sessão do usuário
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Injeção de dependencia das Interfaces
            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<ILivroRepositorio, LivroRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            // Serviço de cookies relacionado a sessão do usuário
            services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseSession(); // Declação fas parte da sessão do usuário

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
