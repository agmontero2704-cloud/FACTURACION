using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FACTURACION
{
    public partial class _Default : System.Web.UI.Page
    {
        //Conexion a la DB
        SqlConnection SqlCon = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar que el usuario haya iniciado sesion
            if (Session["Log_Usuario1"] == null)
            {
                Response.Redirect("~/LOGIN/FRMLOGIN.aspx");
                return;
            }

            //Login Seguridad
            LblCodigo.Text = (string)Session["Log_Codigo"];
            LblUsuario.Text = (string)Session["Log_Usuario1"];
            LblNombre.Text = (string)Session["Log_Nombre"];
            LblApellido.Text = (string)Session["Log_Apellido"];
            LblDepartamento.Text = (string)Session["Log_Departamento"];
            LblCargo.Text = (string)Session["Log_Cargo"];

            try
            {
                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("sp_Insert_SeguridadLogin", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();

                cmd.Parameters.AddWithValue("@Log_Codigo", LblCodigo.Text ?? "");
                cmd.Parameters.AddWithValue("@Log_Usuario1", LblUsuario.Text ?? "");
                cmd.Parameters.AddWithValue("@Log_Nombre", LblNombre.Text ?? "");
                cmd.Parameters.AddWithValue("@Log_Apellido", LblApellido.Text ?? "");
                cmd.Parameters.AddWithValue("@Log_Departamento", LblDepartamento.Text ?? "");
                cmd.Parameters.AddWithValue("@Log_Cargo", LblCargo.Text ?? "");
                cmd.Parameters.AddWithValue("@Log_FechaEntrada", DateTime.Now);

                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al insertar seguridad login: " + ex.Message);
            }
            finally
            {
                if (SqlCon != null && SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }
    }
}