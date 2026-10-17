using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FACTURACION
{
    /// <summary>
    /// Página de inicio del sistema. Muestra los datos del usuario autenticado
    /// y registra el ingreso en la tabla de seguridad.
    /// </summary>
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Valida que el usuario haya iniciado sesión; de lo contrario, redirige al login
            if (Session["LoginUser"] == null)
            {
                Response.Redirect("~/LOGIN/FRMLOGIN.aspx");
                return;
            }

            // Asigna los datos del usuario obtenidos de la sesión a las etiquetas de pantalla
            codeLabel.Text = (string)Session["LoginCode"];
            usernameLabel.Text = (string)Session["LoginUser"];
            nameLabel.Text = (string)Session["LoginName"];
            surnameLabel.Text = (string)Session["LoginSurname"];
            departmentLabel.Text = (string)Session["LoginDepartment"];
            roleLabel.Text = (string)Session["LoginRole"];

            try
            {
                // Crea conexión y comando para registrar el ingreso en el log de seguridad
                using (SqlConnection sqlConnection = DatabaseConnection.GetInstance().CreateConnection())
                using (SqlCommand sqlCommand = new SqlCommand("sp_Insert_SecurityLog", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    // Agrega parámetros con los datos del usuario y la fecha de entrada
                    sqlCommand.Parameters.AddWithValue("@LoginCode", codeLabel.Text ?? "");
                    sqlCommand.Parameters.AddWithValue("@LoginUser", usernameLabel.Text ?? "");
                    sqlCommand.Parameters.AddWithValue("@LoginName", nameLabel.Text ?? "");
                    sqlCommand.Parameters.AddWithValue("@LoginSurname", surnameLabel.Text ?? "");
                    sqlCommand.Parameters.AddWithValue("@LoginDepartment", departmentLabel.Text ?? "");
                    sqlCommand.Parameters.AddWithValue("@LoginRole", roleLabel.Text ?? "");
                    sqlCommand.Parameters.AddWithValue("@Log_FechaEntrada", DateTime.Now);

                    sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception exception)
            {
                // Registra el error en el depurador sin interrumpir la aplicación
                System.Diagnostics.Debug.WriteLine("Error al insertar seguridad login: " + exception.Message);
            }
        }
    }
}
