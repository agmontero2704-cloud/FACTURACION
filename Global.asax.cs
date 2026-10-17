using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace FACTURACION
{
    /// <summary>
    /// Clase de configuración global de la aplicación. Se ejecuta al iniciar la aplicación web.
    /// </summary>
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            // Registra las rutas de Friendly URLs y los bundles de scripts y estilos
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
