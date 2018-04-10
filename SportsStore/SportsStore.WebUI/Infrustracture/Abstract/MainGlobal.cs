using SportsStore.WebUI.Infrustracture.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Infrustracture.Abstract
{
    public class MainGlobal
    {
        public static List<IAuthProvider> Connections { get; private set; } = new List<IAuthProvider>();

        public static void InitializeConnection(bool EF)
        {
            if (EF)
            {
                FormsAuthProvider formsAuthProvider = new FormsAuthProvider();
                Connections.Add(formsAuthProvider);
            }
        }
    }
}