using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SM_Consulta_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            //Env file loading.
            DotNetEnv.Env.Load();
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        } 
    }
}
