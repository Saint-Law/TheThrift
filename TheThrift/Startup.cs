using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using TheThrift.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheThrift.Contracts;
using TheThrift.Repository;
using AutoMapper;
using TheThrift.Mappings;

namespace TheThrift
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //Add reference for Contract and Repository to Startup file : saintlaw
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ILoanTypeRepository, LoanTypeRepository>();
            services.AddScoped<ILoanRequestRepository, LoanRequestRepository>();
            services.AddScoped<ILoanAllocationRepository, LoanAllocationRepository>();

            //Add reference for Automapper to Startup file : saintlaw
            services.AddAutoMapper(typeof(Maps));

            services.AddDefaultIdentity<Employee>()
                //adding default roles and admin user seeding the database
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseDefaultFiles();
            app.UseRouting();
            

            app.UseAuthentication();
            app.UseAuthorization();

            SeedData.Seed(userManager, roleManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
