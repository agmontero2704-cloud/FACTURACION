using System;

namespace FACTURACION.LOGIN
{
    /// <summary>
    /// Master page principal del sistema. Define la estructura común
    * (cabecera, menú, columnas y pie de página) para todas las páginas hijas.
    /// </summary>
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Por el momento no requiere lógica de carga
        }
    }
}
