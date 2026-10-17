using System;
using System.Data;
using System.Data.SqlClient;

namespace FACTURACION.LOGIN
{
    /// <summary>
    /// Master page principal del sistema. Define la estructura común
    /// (cabecera, menú, columnas y pie de página) para todas las páginas hijas.
    /// </summary>
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLogo();
                CargarUsuarioPie();
            }
        }

        /// <summary>
        /// Intenta cargar el logotipo de la empresa desde la base de datos.
        /// Si no existe o falla la conexión, muestra el logotipo por defecto.
        /// </summary>
        private void CargarLogo()
        {
            try
            {
                using (SqlConnection sqlConnection = DatabaseConnection.GetInstance().CreateConnection())
                using (SqlCommand sqlCommand = new SqlCommand("SELECT TOP 1 Emp_Logo FROM empresa WHERE Emp_Logo IS NOT NULL", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);
                        if (dt.Rows.Count > 0 && dt.Rows[0]["Emp_Logo"] != DBNull.Value && ((byte[])dt.Rows[0]["Emp_Logo"]).Length > 0)
                        {
                            logoRepeater.DataSource = dt;
                            logoRepeater.DataBind();
                            pnlDefaultLogo.Visible = false;
                            return;
                        }
                    }
                }
            }
            catch
            {
                // Fallback automático al logotipo estático en caso de cualquier error
            }

            pnlDefaultLogo.Visible = true;
        }

        /// <summary>
        /// Muestra el nombre de usuario autenticado en la barra inferior.
        /// </summary>
        private void CargarUsuarioPie()
        {
            string usuario = (Session["LoginUser"] ?? Session["Log_Usuario1"] ?? "").ToString();
            if (!string.IsNullOrEmpty(usuario))
            {
                lblUsuarioPie.Text = usuario;
            }
        }
    }
}
