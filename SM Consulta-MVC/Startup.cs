using Auth_Api.Data.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SM_Consulta_MVC.Data;
using SM_Consulta_MVC.service;
using System;
using System.Globalization;

namespace SM_Consulta_MVC
{
    public class Startup
    {
        public readonly double _incomeTax;
        public readonly double _healt_social_innsurance_tax;
        public readonly int _minimumInsuranceIncome;
        public readonly int _maximumInsuranceIncome;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //Reading .env --- > Values storing.
            if (configuration["INCOME_TAX"].ToString() != "")
            {
                this._healt_social_innsurance_tax = Convert.ToDouble(configuration["HEALT_SOCIAL_INSURANCE_TAX"], CultureInfo.InvariantCulture);
                this._incomeTax = Convert.ToDouble(configuration["INCOME_TAX"], CultureInfo.InvariantCulture);
                this._minimumInsuranceIncome = Convert.ToInt32(configuration["MIMUMUM_INSURANCE_INCOME"], CultureInfo.InvariantCulture);
                this._maximumInsuranceIncome = Convert.ToInt32(configuration["MAXIMUM_INSURANCE_INCOME"], CultureInfo.InvariantCulture);
            }

            else
            {
            //Used for testing --- > 
                this._healt_social_innsurance_tax = 0.15;
                this._incomeTax = 0.10;
                this._maximumInsuranceIncome = 3000;
                this._minimumInsuranceIncome = 1000;
                }
            }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserContext>();
            services.AddControllersWithViews();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>(
                provider => new UserService(provider.GetService<IUserRepository>(),
                this._incomeTax, 
                this._healt_social_innsurance_tax, 
                this._maximumInsuranceIncome, 
                this._minimumInsuranceIncome));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
