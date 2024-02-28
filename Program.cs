using AppStoreScarpper.StartUp;
using AppStoreScarpper.Utilities;
using System;
using System.Threading.Tasks;

namespace AppStoreScarpper
{
    public class Program
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        public static async Task Main(string[] args)
        {
            Log.Info("Scrapper process has been started!");
            Console.WriteLine("Scrapper process has been started!");
            try
            {
               // var metricServer = new MetricServer(Constants.Server, Constants.Port);
               // metricServer.Start();
                while (true)
                {
                    try
                    {
                        var startup = new Startup();
                        await startup.StartScrapping(Constants.MagicStoreUrl);
                        Log.Info("Processed complete, will start again after 10 seconds!");
                        await Task.Delay(1000 * 10 * 1);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                        Log.Info("Throws Exception.Process will start again after 1 minute.");
                        await Task.Delay(1000 * 60 * 1);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
   
    
}
