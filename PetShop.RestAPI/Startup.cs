using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Concrete;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Infrastructure.Static.Data;
using PetShop.Infrastructure.Static.Data.RepositoryConcrete;

namespace PetShop.RestAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IPetRepositary, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                using (var scope = app.ApplicationServices.CreateScope()) {
                    var petService = scope.ServiceProvider.GetRequiredService<IPetService>();
                    var ownerService = scope.ServiceProvider.GetRequiredService<IOwnerService>();
                    var dataInit = new DataInitializer(petService, ownerService);
                    dataInit.initPets();
                }
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
