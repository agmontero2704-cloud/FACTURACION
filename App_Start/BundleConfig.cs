using System.Web.Optimization;

namespace FACTURACION
{
    /// <summary>
    /// Configura los bundles (agrupaciones) de scripts y estilos de la aplicación.
    /// Se ejecuta en Application_Start a través de Global.asax.cs.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registra los bundles utilizados por el sitio.
        /// Actualmente incluye jQuery y el script propio site.js.
        /// </summary>
        /// <param name="bundles">Colección de bundles de la aplicación</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bundle de jQuery (librería externa)
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery-3.7.0.js"));

            // Bundle de script propio del sitio (desplazamiento suave y menú activo)
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                            "~/Scripts/site.js"));
        }
    }
}
