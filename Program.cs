using AppStoreScarpper.StartUp;
using AppStoreScarpper.Utilities;
using System;
using System.Threading.Tasks;
[assembly: ArmDot.Client.ObfuscateControlFlow]
[assembly: ArmDot.Client.VirtualizeCode]
[assembly: ArmDot.Client.ObfuscateNames]
[assembly: ArmDot.Client.HideStrings]
[assembly: ArmDot.Client.ProtectEmbeddedResources]
[assembly: ArmDot.Client.ObfuscateNamespaces]
namespace AppStoreScarpper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Scrapper process has been started!");
            try
            {
                try
                {
                    var startup = new Startup();
                    await Task.Run(async () =>
                    {
                        await startup.StartScrapping(Constants.MagicStoreUrl);
                    });
                    //await Task.Run(async () =>
                    //{
                    //    await startup.StartScrapping(Constants.DappRadarUrl);
                    //});
                    Console.WriteLine("Process SuccessFully completed..!!!");
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
