using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace FACTURACION
{
    /// <summary>
    /// Configura las rutas de Friendly URLs para la aplicación web.
    /// Permite direcciones más limpias y amigables para el usuario y los motores de búsqueda.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registra las rutas personalizadas y habilita Friendly URLs.
        /// </summary>
        /// <param name="routes">Colección de rutas de la aplicación</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Configuración de Friendly URLs con redirección permanente
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
