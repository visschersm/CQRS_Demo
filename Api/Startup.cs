using Api.Interfaces;
using Api.Model;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CQRS_DemoDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            //services.AddScoped(typeof(IQueryHandler<,>));
            //services.AddScoped<IQueryHandler<GetUserListQuery, UserListView>, GetUserListQuery.GetUserListQueryHandler>();

            services.AddCommandQueryHandlers(typeof(ICommandHandler<>));
            services.AddCommandQueryHandlers(typeof(IQueryHandler<,>));

            services.AddScoped<IHandler, DefaultHandler>();

            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
