using System;

namespace FACTURACION.mantenimiento
{
    /// <summary>
    /// Página única del módulo de Mantenimiento. Agrupa en secciones todas las opciones
    * de mantenimiento (Empresa, Cajas, Bodegas, Clientes, Productos, Suplidores, Código de Barras y QR)
    * y permite navegar entre ellas mediante anclas (#id).
    /// </summary>
    public partial class MaintenancePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Por el momento no requiere lógica de carga
        }
    }
}
