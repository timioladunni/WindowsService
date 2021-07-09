using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Web.Mvc;

namespace WindowService2
{
    class WIndowService2 
    {
        public cardatabaseContext _cardatabase;
        private static readonly ILog _log = LogManager.GetLogger("Logs.xml");
        private readonly Timer timer;
      
        public WIndowService2()
        {
            timer = new System.Timers.Timer(2000) { AutoReset = true };
            timer.Elapsed += ExecuteEvent;
            
        }

        public void UpdatePrice(int id)
        {
            try
            {
                if (id > 0)
                {
                    cardatabaseContext sig = new cardatabaseContext();
                    var sin = sig.CarValueApis.ToList();
                    var sip = sin.FirstOrDefault(t => t.Id == id);
                    if ( !(sip == null))
                    {
                        sip.Price = sip.Price + 100;
                        sig.SaveChanges();
                        
                    }
                }
            }
            catch (Exception eq)
            {

                var b = Convert.ToString(new Exception(eq.Message));
                _log.Error(b);
            }
            
        }



        public void ExecuteEvent(object sender, ElapsedEventArgs e)
        {
            _log.Info("Service Starting....");
            try
            {
                    // if (DateTime.Now.Hour == 19 )
                
                    cardatabaseContext context = new cardatabaseContext();
                  
                    if (context.UserMasters.Any(r => r.UserRoles < DateTime.Today))
                    {
                        var id = context.CarValueApis.Where(t=> t.Id > 0);
                        foreach (var item in id)
                        {
                                UpdatePrice(item.Id);
                            _log.Info("Updated");
                        }
                        var sem = new UserMaster { UserRoles = DateTime.Today };
                        context.UserMasters.Add(sem);

                        context.SaveChanges();
                    }

                    else
                    {
                        timer.Stop();
                        timer.Start();
                    }
                  

            }
            catch (Exception ea)
            {
                var a = Convert.ToString(new Exception(ea.Message));
                _log.Error(a);
            }
           
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void Start()
        {
            timer.Start();
        }


    }
}
