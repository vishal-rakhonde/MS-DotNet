namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //http://localhost:5055/Home/Index
            //http://localhost:5055/Home/Index/12345
            app.MapControllerRoute(
                           name: "default",
                           pattern: "{controller=Default}/{action=Index}/{id?}");
            //pattern: "{controller=Default}/{action=Index}/{id?}/{a?}/{b?}");
            //http://localhost:5055/Home/Index/12345/100/200

            //querystring
            //http://localhost:5055/Home/Index/12345?a=100&b=200
            //http://localhost:5055/Home/Index/12345?b=200
            //http://localhost:5055/Home/Index/12345?a=100
            //http://localhost:5055/Home/Index/12345?b=200&a=100


            app.Run();
        }
    }
}
