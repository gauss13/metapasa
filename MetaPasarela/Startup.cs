using Meta.Entities;
using Meta.Entities.Contextos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Meta.Repository;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace MetaPasarela
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // EF

           // services.AddDbContext<AppDbContext>(options =>
           // {
           //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConecction"));
           // }
           //);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConecction"),
                    b => b.MigrationsAssembly("MetaPasarela"));//Meta.Entities  //MetaPasarela
            });


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Midleware Repository
            services.AddScoped<IRepositorioWrapper, RepositorioWrapper>();

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "*",
                    ValidAudience = "*",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superCrete246754d(=?34ddsdBXsdg%$%FG&6HHfQWAccgt8678FGFASDF&%&56zx#$%GHCVBTYTRYFGGFHfgh&/ghtdgfd989dfgDFGdfg98dfgE5345dsf5sd6fsdf%$654fdgdfgd3681=(3459&#232342fsdf)=fadfgdfgdgwefrwR54WE#43d#$%@13"))
                };

            });


            // Configura CORS
            services.AddCors(options => {

                options.AddPolicy("EnableCORS", builder => {

                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();                    
                });
            });

            // LOG Serilog
            services.AddSingleton<Serilog.ILogger>(options =>
            {
                var connString = Configuration["Serilog:DefaultConecction"];
                var tableName = Configuration["Serilog:TableName"];

                return new LoggerConfiguration().WriteTo.MSSqlServer(connString, tableName, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning, autoCreateSqlTable: true).CreateLogger();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();//abc
            }


            //Logger txt
            loggerFactory.AddFile("metalog-{Date}.txt");

            app.UseCors("EnableCORS");

            //Jwt
            app.UseAuthentication();

            //app.UseHttpsRedirection();//abc
            app.UseStaticFiles();
            app.UseSpaStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
