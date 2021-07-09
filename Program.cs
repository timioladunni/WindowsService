using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using Topshelf;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WindowService2
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger("Logs.xml");
        
        static void Main(string[] args)
        {
            try
            {
                HostFactory.Run(hostConfig =>
                {
                    hostConfig.Service<WIndowService2>(serviceConfig =>
                    {
                        serviceConfig.ConstructUsing(() => new WIndowService2());
                        
                        serviceConfig.WhenStarted(s => s.Start());
                        serviceConfig.WhenStopped(s => s.Stop());

                    });
                    hostConfig.RunAsLocalSystem();
                    hostConfig.SetServiceName("TestService");
                    hostConfig.SetDisplayName("TestService");
                    hostConfig.SetDescription("This service increases the price of the CarValueApi table by 100 daily");
                });
            }
            catch (Exception eq)
            {

                var b = Convert.ToString(new Exception(eq.Message));
                _log.Error(b);
            }
           

        }

       
            
                  
    }
}
