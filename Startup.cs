﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autenticacaoefcookie.Dados;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autenticacaoefcookie
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }
        public IConfiguration configuration {get;}


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AutenticacaoContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("BancoAutenticacao")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {options.LoginPath= "/Conta/Login";});
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes => {routes.MapRoute(name: "default", template:"{controller=Home}/{action=Index}/{id?}");});

        }
    }
}
