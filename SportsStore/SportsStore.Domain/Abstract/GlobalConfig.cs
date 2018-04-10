using SportsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    public class GlobalConfig
    {
        public static List<IProductsRepository> Connections { get; private set; } = new List<IProductsRepository>();
        public static List<IOrderProcessor> OrderConnections { get; private set; } = new List<IOrderProcessor>();
        public static EmailSettings emailSettings = new EmailSettings
        {
            WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
        };

        public static void InitializeConnection(bool EF)
        {
            if (EF)
            {
                 EFProductRepository Entity = new EFProductRepository();
                Connections.Add(Entity);

                EmailOrderProcessor Order = new EmailOrderProcessor(GlobalConfig.emailSettings);
                OrderConnections.Add(Order);
            }
        }
    }
}
