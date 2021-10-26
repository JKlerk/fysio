using Core.Domain;
using Core.DomainServices;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fysio
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
            services.AddDbContext<FysioContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("MvcPatientContext"), x => x.MigrationsAssembly("Infrastructure"))
            );

            services.AddDbContext<IdentityContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("IdentityContext"), x => x.MigrationsAssembly("Infrastructure")));
            
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<IdentityContext>().AddRoles<IdentityRole>().AddDefaultTokenProviders();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Role.TherapistRole, policy => policy.RequireRole(Role.TherapistRole));
                options.AddPolicy(Role.StudentRole, policy => policy.RequireRole(Role.StudentRole));
                options.AddPolicy(Role.AdminRole, policy => policy.RequireRole(Role.AdminRole));
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Fysio.Cookie";
                config.LoginPath = "/user/login";
            });
            
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientFileRepository, PatientFileRepository>();
            services.AddScoped<ITherapistRepository, TherapistRepository>();
            services.AddScoped<ITreatmentPlanRepository, TreatmentPlanRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddHealthChecks();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Dashboard",
                    pattern: "/",
                    defaults: new { controller = "Dashboard", action = "Index" }
                );
                
                endpoints.MapControllerRoute(
                    name: "Patient",
                    pattern: "{controller=Patient}/{action=Index}/{id?}"
                );
                
                endpoints.MapControllerRoute(
                    name: "Treatment",
                    pattern: "{controller=TreatmentPlan}/{action=Index}/{id?}"
                );
                
                endpoints.MapControllerRoute(
                    name: "Treatment",
                    pattern: "{controller=Treatment}/{action=Index}/{id?}"
                );

                endpoints.MapRazorPages();
            });
        }
    }
}
