using Business.Abstarct;
using Business.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideTree
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
            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ISoftwareLangueDal, EfSoftwareLangueDal>();
            services.AddScoped<ISoftwareBranchDal, EfSoftwareBranchDal>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IArticleService,ArticleManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ISoftwareLangueService, SoftwareLangueManager>();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//uygulama geliþtrime aþamasýnda çalýþan bir yapý.uygulama yayýnlandýktan sonra burasý çlýþmaz 
            {
                //"!!!!!!Uygulama yayýnlanacaðý zaman proje ayarýndan env degiþtirilmeli"
                //SeedDatabase.Seed();
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
            {//sayfa route'yi yukardan aþagý dogru iner istenilen name'i bulduðunda aþaðý inmez.

                endpoints.MapControllerRoute(
                    name: "adminarticles",
                    pattern: "admin/articles",
                   defaults: new { controller = "Admin", action = "ArticleList" }
                 );
                endpoints.MapControllerRoute(
                   name: "adminarticlecreate",
                   pattern: "admin/articles/create",
                   defaults: new { controller = "Admin", action = "ArticlesCreate" }
                );
                endpoints.MapControllerRoute(
                name: "adminarticlelist",
                pattern: "admin/articles/{id?}",//id kýsmý degiþken olduðu için parantez içinde yazýlýr,sabit olan normal//? null ise hata döndürülebilir
               defaults: new { controller = "Admin", action = "ArticleEdit" }
               );
                endpoints.MapControllerRoute(
                    name: "admincategories",
                    pattern: "admin/categories",
                   defaults: new { controller = "Admin", action = "CategoryList" }
                 );
                endpoints.MapControllerRoute(
                 name: "admincategoriescreate",
                 pattern: "admin/categories/create",
                defaults: new { controller = "Admin", action = "CategoryCreate" }
              );
                endpoints.MapControllerRoute(
                name: "admincategorylist",
                pattern: "admin/categories/{id?}",//id kýsmý degiþken olduðu için parantez içinde yazýlýr,sabit olan normal//? null ise hata döndürülebilir
               defaults: new { controller = "Admin", action = "CategoryEdit" }
               );
                endpoints.MapControllerRoute(
                   name: "adminarticlelist",
                   pattern: "admin/articles",
                  defaults: new { controller = "Admin", action = "ArticleList" }
                );

                endpoints.MapControllerRoute(
                    name: "search",//Url nerde kullanýldýðýný bul
                    pattern: "search",//karþýlancak olan link ismi
                   defaults: new { controller = "Home", action = "Search" }
                 );

                endpoints.MapControllerRoute(
                    name: "articledetails",//Url nerde kullanýldýðýný bul
                    pattern: "{url}",//karþýlancak olan link ismi
                   defaults: new { controller = "Home", action = "articledetails" }
                 );

                endpoints.MapControllerRoute(
                 name: "languedetails",
                 pattern: "ProgrammerGuide/{langueurl}",
                defaults: new { controller = "GuideTree", action = "languedetails" }
                );
                endpoints.MapControllerRoute(
                    name: "articles",
                    pattern: "articles/{category?}",//category articleDetails'taki asp-route-category="URL" 'de kullanýlýyor articles="kendi baþýna ifade etmez home-index çalýþýr.category.url verilince farklý sayfaya yönlendirilir."
                   defaults: new { controller = "Home", action = "index" }
                 );          

                   endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
