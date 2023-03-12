using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace AnılBurakYamaner_Proje.Web.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var host  = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
#if DEBUG
                    .UseIISIntegration()
#endif
                    .UseUrls("Http://localhost:4000")
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
