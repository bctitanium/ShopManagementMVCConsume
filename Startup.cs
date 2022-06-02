using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ShopManagementMVCConsume
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
            
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
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
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Login}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });





            //app.UseDefaultFiles();
            //app.UseFileServer();
            //StaticFileOptions options = new StaticFileOptions();
            //FileExtensionContentTypeProvider contentTypeProvider = (FileExtensionContentTypeProvider)options.ContentTypeProvider ?? new FileExtensionContentTypeProvider();
            //contentTypeProvider.Mappings.Add(".unityweb", "application/octet—stream");
            //contentTypeProvider.Mappings.Add(".br", "application/octet—stream");
            //options.ContentTypeProvider = contentTypeProvider; app.UseStaticFiles(options);

            app.UseFileServer();
            StaticFileOptions option = new StaticFileOptions();
            FileExtensionContentTypeProvider contentTypeProvider = (FileExtensionContentTypeProvider)option.ContentTypeProvider ??
            new FileExtensionContentTypeProvider();
            contentTypeProvider.Mappings.Remove(".unityweb");
            contentTypeProvider.Mappings.Add(".unityweb", "application/unityweb");
            // Datafile mappings
            contentTypeProvider.Mappings.Add(".data", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".data.gz", "application/octet-stream");
            contentTypeProvider.Mappings.Add(".data.br", "application/octet-stream");
            // js filemappings
            contentTypeProvider.Mappings.Add(".js.gz", "application/javascript");
            contentTypeProvider.Mappings.Add(".js.br", "application/javascript");
            //wasm file mappings
            contentTypeProvider.Mappings.Remove(".wasm");
            contentTypeProvider.Mappings.Add(".wasm", "application/wasm");
            contentTypeProvider.Mappings.Add(".wasm.gz", "application/wasm");
            contentTypeProvider.Mappings.Add(".wasm.br", "application/wasm");

            option.ContentTypeProvider = contentTypeProvider;
            option.OnPrepareResponse = context =>
            {
                IHeaderDictionary headers = context.Context.Response.Headers;
                string contentType = headers["Content-Type"];

                if (context.File.Name.EndsWith("js.br"))
                {
                    contentType = "application/javascript";
                    headers.Add("Content-Encoding", "br");
                }
                else if (context.File.Name.EndsWith("data.br"))
                {
                    contentType = "application/octet-stream";
                    headers.Add("Content-Encoding", "br");
                }
                else if (context.File.Name.EndsWith("wasm.br"))
                {
                    contentType = "application/wasm";
                    headers.Add("Content-Encoding", "br");
                }

                headers["Content-Type"] = contentType;

            };
            app.UseStaticFiles(option);

            var provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".unityweb"] = "application/unityweb";

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                //RequestPath = "/StaticContentDir",
                ContentTypeProvider = provider
            });

        }
    }
}
