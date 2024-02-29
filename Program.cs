using AppStoreScarpper.StartUp;
using AppStoreScarpper.Utilities;
using System;
using System.Threading.Tasks;

namespace AppStoreScarpper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Scrapper process has been started!");
            try
            {
                // var metricServer = new MetricServer(Constants.Server, Constants.Port);
                // metricServer.Start();

                try
                {
                    var startup = new Startup();
                    await Task.Run(async () =>
                    {
                        await startup.StartScrapping(Constants.MagicStoreUrl);
                    });
                    await Task.Run(async () =>
                    {
                        await startup.StartScrapping(Constants.DappRadarUrl);
                    });
                    Console.WriteLine("Processed complete, please start again after 10 seconds!");
                    await Task.Delay(1000 * 10 * 1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Throws Exception.Process will start again after 1 minute.");
                    await Task.Delay(1000 * 60 * 1);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }


}
