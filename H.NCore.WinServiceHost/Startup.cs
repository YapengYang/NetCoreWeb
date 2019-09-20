using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace H.NCore.WinServiceHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string root = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            //TContent AppDbContext = new TContent();
            services.AddDirectoryBrowser();
            services.AddMvc()
                //services.AddMvc(o => o.Conventions.Add(new ExternalApiControllerConvention()))
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    //o.SerializerSettings.TypeNameHandling = TypeNameHandling.All;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting();
            //services.AddDbContext<AppDbContext>();
            //services.AddCap(x =>
            //{
            //    //如果你使用的 EF 进行数据操作，你需要添加如下配置：
            //    //x.UseEntityFramework<AppDbContext>();  //可选项，你不需要再次配置 x.UseSqlServer 了
            //    //如果你使用的ADO.NET，根据数据库选择进行配置：
            //    x.UseSqlServer("数据库连接字符串");
            //    //x.UseMySql("数据库连接字符串");
            //    //x.UsePostgreSql("数据库连接字符串");
            //    //如果你使用的 MongoDB，你可以添加如下配置：
            //    //x.UseMongoDB("ConnectionStrings");  //注意，仅支持MongoDB 4.0+集群
            //    //CAP支持 RabbitMQ、Kafka、AzureServiceBus 等作为MQ，根据使用选择配置：                
            //    x.UseRabbitMQ("ConnectionStrings");
            //    //x.UseKafka("ConnectionStrings");
            //    //x.UseAzureServiceBus("ConnectionStrings");
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("ServiceAPI", new Info
                {
                    Title = "后台接口",
                    Version = "v1.0.0",
                    Contact = new Contact
                    {
                        Email = "506147318@qq.com",
                        Name = "yapengyang",
                        Url = "https://github.com/YapengYang"
                    }
                });

                string xml = Path.Combine(root, "H.SPS.BusinessService.xml");
                if (File.Exists(xml))
                {
                    c.IncludeXmlComments(xml);
                }
            });
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvc();

            app.UseStaticFiles();

            //需要在当前目录建一个wwwroot文件夹
            app.UseDirectoryBrowser();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                builder.AllowCredentials();
                //builder.WithOrigins("http://localhost:8080");
            });
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            // {
            //     FileProvider = new PhysicalFileProvider(env.ContentRootPath),
            //        RequestPath = "/wwwroot"
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.ShowExtensions();
                options.SwaggerEndpoint("/swagger/ServiceAPI/swagger.json", "后台接口 V1.0.0");
            });

            //初始化环境
            //Env.Instance = new Env();
            //Env.Instance.ApplicationServices = app.ApplicationServices;
            //Env.Instance.LoggerFactory = loggerFactory;

            //WebsocketEventDispatcher.Instance = new WebsocketEventDispatcher();
            //WebsocketEventDispatcher.Instance.Init();
        }
    }
}
