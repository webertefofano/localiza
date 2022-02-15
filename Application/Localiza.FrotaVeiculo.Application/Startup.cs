using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.CrossCutting;
using Localiza.FrotaVeiculo.Infra.CrossCutting.Extensions;
using Localiza.FrotaVeiculo.Infra.Data.Context.Localiza;
using Localiza.FrotaVeiculo.Infra.Data.Repository;
using Localiza.FrotaVeiculo.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application
{
    public class Startup
    {
        readonly string CORS_Allow = Constantes.CORS;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            // Add Response compression services
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy(CORS_Allow, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
                options.DefaultPolicyName = CORS_Allow;
            });

            services.AddGlobalExceptionHandlerMiddleware();

            services.AddDbContext<ContextLocaliza>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("LOCALIZA_DB"));
            });

            services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            services.AddScoped<IBaseService<Usuario>, BaseService<Usuario>>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                options.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            });

            var key = System.Text.Encoding.ASCII.GetBytes(Util.GetJwtKey());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Localiza.FrotaVeiculo.Application", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Localiza.FrotaVeiculo.Application v1"));
            }

            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;

                    //when authorization has failed, should retrun a json message to client
                    if (error != null && error.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            State = "Unauthorized",
                            Msg = "token expired"
                        }));
                    }
                    //when orther error, retrun a error message json to client
                    else if (error != null && error.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            State = "Internal Server Error",
                            Msg = error.Error.Message
                        }));
                    }
                    //when no error, do next.
                    else await next();
                });
            });

            app.UseCors(CORS_Allow);

            app.UseAuthentication(); // Isso aplica o sistema de autenticação na sua aplicação

            app.UseGlobalExceptionHandlerMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}