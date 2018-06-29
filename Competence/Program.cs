using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Competence
{
    /// <summary>
    /// Main entry point to the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The app is run through a console application, it is built here
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //var host = BuildWebHost(args);

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<CompanyDBContext>();

            //        SeedData.EnsurePopulated(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while seeding the database.");
            //    }
            //}

            //host.Run();


            BuildWebHost(args).Run();

            
        }
        /// <summary>
        /// Method to set the startup class as the main configuration class for the program. Tell the program to use kestral and iss integration
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false).UseKestrel().UseIISIntegration()
                .Build();
    }
}
