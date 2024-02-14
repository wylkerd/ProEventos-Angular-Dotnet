using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProEventos.API.Injectors;
using ProEventos.Repository;

namespace ProEventos.API
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
          // Config do DbContext - configs do tipo de DB do contexto
          // Passando configs ao construtor de DataContext
          services.AddDbContext<DataContext>(
            context => context.UseSqlite(Configuration.GetConnectionString("sqliteConnectionString"))
          );

          services.AddControllers()
            .AddJsonOptions(options => 
              {
                  options.JsonSerializerOptions.IgnoreNullValues = true; // api ignora os valores nulos
              })
            .AddNewtonsoftJson(options => 
              {
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; // ignora referencias circulares / ciclicas entre Entidades
              }
            );

          // configuraçao dos Scopes <Interface, Class>
          RepositoryInjector.RegisterRepositories(services);

          services.AddCors(c => 
          {
              c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
          });
          
          services.AddSwaggerGen(c =>
          {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
              app.UseDeveloperExceptionPage();
              app.UseSwagger();
              app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors => 
              cors.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}