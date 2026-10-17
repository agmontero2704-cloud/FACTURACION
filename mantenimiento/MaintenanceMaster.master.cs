using System;

namespace FACTURACION.mantenimiento
{
    /// <summary>
    /// Master page anidada para el módulo de Mantenimiento. Define el menú contextual
    * lateral y expone un ContentPlaceHolder para el contenido de cada página de mantenimiento.
    /// </summary>
    public partial class MaintenanceMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Por el momento no requiere lógica de carga
        }
    }
}
