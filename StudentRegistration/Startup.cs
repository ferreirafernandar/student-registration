using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace StudentRegistration
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
            services.AddSwaggerGen(c =>
                                   {
                                       c.SwaggerDoc("v1",
                                                    new Info
                                                    {
                                                        Title = "Student Registration",
                                                        Version = "v1",
                                                        Description = "API REST criada com o ASP.NET Core",
                                                        Contact = new Contact
                                                        {
                                                            Name = "Fernanda Ferreira",
                                                            Url = "https://github.com/ferreirafernandar"
                                                        }
                                                    });

                                       var applicationPath  = PlatformServices.Default.Application.ApplicationBasePath;
                                       var applicationName = PlatformServices.Default.Application.ApplicationName;
                                       var xmlDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");

                                       c.IncludeXmlComments(xmlDocPath);
                                   });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();
            services.AddScoped<IMapper>(serviceProvider => new Mapper(serviceProvider.GetRequiredService<IConfigurationProvider>(), serviceProvider.GetService));
            services.AddCors();
            services.AddCors(options => options.AddPolicy("AllowMyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                             {
                                 c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                                   "StudentRegistration");
                             });
            app.UseCors("AllowMyOrigin");
        }
    }
}
