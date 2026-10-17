using System;
using System.Data;
using System.Data.SqlClient;

namespace FACTURACION.LOGIN
{
    /// <summary>
    /// Página de inicio de sesión. Valida al usuario contra la base de datos
    /// y, si es correcto, almacena los datos en sesión y redirige al inicio.
    /// </summary>
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Establece el foco en el campo de usuario al cargar la página
            usernameTextBox.Focus();
        }

        /// <summary>
        /// Evento al hacer clic en el botón Aceptar. Valida credenciales del usuario.
        /// </summary>
        protected void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Crea conexión y comando para ejecutar el procedimiento de validación de login
                using (SqlConnection sqlConnection = DatabaseConnection.GetInstance().CreateConnection())
                using (SqlCommand sqlCommand = new SqlCommand("sp_CheckLogin", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@usuario", usernameTextBox.Text.Trim()));
                    sqlCommand.Parameters.Add(new SqlParameter("@clave", passwordTextBox.Text.Trim()));
                    sqlConnection.Open();

                    // Lee el resultado del procedimiento almacenado
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            // Almacena los datos del usuario en variables de sesión
                            Session["LoginStatus"] = dataReader["log_status"].ToString();
                            Session["LoginCode"] = dataReader["log_codigo"].ToString();
                            Session["LoginUser"] = usernameTextBox.Text;
                            Session["LoginName"] = dataReader["log_nombre"].ToString();
                            Session["LoginSurname"] = dataReader["log_apellido"].ToString();
                            Session["LoginDepartment"] = dataReader["log_departamento"].ToString();
                            Session["LoginRole"] = dataReader["log_cargo"].ToString();

                            // Si el usuario está activo, bloquea campos y redirige tras el temporizador
                            if (dataReader["log_status"].ToString() == "Activo")
                            {
                                messageLabel.Text = "Mensaje.: Login correcto";

                                usernameTextBox.Enabled = false;
                                passwordTextBox.Enabled = false;
                                acceptButton.Enabled = false;

                                lockImage.ImageUrl = "~/IMAGENES/CerraduraVerde.png";
                                sessionTimer.Enabled = true;
                            }
                            else
                            {
                                // Usuario existe pero está inhabilitado
                                messageLabel.Text = "Mensaje.: Usuario Inhabilitado";
                                sessionTimer.Enabled = true;
                            }
                        }
                        else
                        {
                            // Credenciales incorrectas
                            messageLabel.Text = "Mensaje.: Login incorrecto";
                            sessionTimer.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // Error de conexión con la base de datos
                System.Diagnostics.Debug.WriteLine("Error de conexion con la Base de Datos: " + exception.Message);
                messageLabel.Text = "Mensaje.: No hay conexion con la Base de Datos";
            }
        }

        /// <summary>
        /// Temporizador de sesión. Si el login fue correcto, redirige a la página de inicio.
        /// Si no, limpia el mensaje y reactiva los campos para un nuevo intento.
        /// </summary>
        protected void SessionTimer_Tick(object sender, EventArgs e)
        {
            // Si el mensaje indica login exitoso, redirige al menú principal
            if (messageLabel.Text == "Mensaje.: Login correcto")
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // Limpia mensaje y habilita los campos para otro intento
                messageLabel.Text = "";
                sessionTimer.Enabled = false;
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                acceptButton.Enabled = true;
                usernameTextBox.Focus();
            }
        }
    }
}
