using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core_NewServie
{
    /// <summary>
    /// All Global Settings for the Application
    /// WebForm / MVC / APIs
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// IHostBuilder Interface
        /// 1. Creating Hosting Environment (IIS / Apache /  Ngix / Docker)
        ///     1a. Kestral ENgine CreateDefaultBuilder
        /// 2. Configure Global Services using Startup Class
        ///     2a. Security
        ///     2b. Database Connections
        ///     2c. Sessions
        ///     2d. Custom Dependencies
        ///     2e. MVC Request Processing
        ///     2f. API Request Processing
        ///     2g. Web Form Request Processing
        ///     2h. CORS
        /// 3. Start the Process Request
        ///     3a. INitialze HttpContext
        ///     3b. I itialze and execute all Middlewares (Important)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
