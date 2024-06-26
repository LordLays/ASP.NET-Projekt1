﻿using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Validation;
using WebApplication1.ViewModels;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TravelAgencyContext>(options =>
                           options.UseSqlServer(connectionString));

            services.AddAutoMapper(typeof(Startup));
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IValidator<Customer>, CustomerValidation>();
            services.AddScoped<IValidator<Review>, ReviewValidation>();
            services.AddScoped<IValidator<Reservation>, ReservationValidation>();
            services.AddScoped<IValidator<Hotel>, HotelValidation>();
            services.AddScoped<IValidator<HotelRoom>, HotelRoomValidation>();
            services.AddScoped<IValidator<Offert>, OffertValidation>();
            services.AddScoped<IValidator<Tag>, TagValidation>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapBlazorHub();
            });
        }
    }
}
