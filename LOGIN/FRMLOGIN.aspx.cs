using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FACTURACION.LOGIN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Iniciar el foco en el primer textbox
            TxtUsuario.Focus();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            //Conexion a la DB
            SqlConnection SqlCon = new SqlConnection();

            //Insercccion de los datos a la DB
            try
            {
                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlParameter param = new SqlParameter("@usuario", TxtUsuario.Text.Trim());
                SqlParameter param1 = new SqlParameter("@clave", TxtClave.Text.Trim());
                SqlCommand cmd = new SqlCommand("sp_checlogin", SqlCon);
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //Variables de seccion
                    Session["Log_Status"]      = dr["log_status"].ToString();
                    Session["Log_Codigo"]      = dr["log_codigo"].ToString();
                    Session["Log_Usuario1"]    = TxtUsuario.Text;
                    Session["Log_Nombre"]      = dr["log_nombre"].ToString();
                    Session["Log_Apellido"]    = dr["log_apellido"].ToString();
                    Session["Log_Departamento"] = dr["log_departamento"].ToString();
                    Session["Log_Cargo"]       = dr["log_cargo"].ToString();

                    if (dr["log_status"].ToString() == "Activo")
                    {
                        LblMensaje.Text = "Mensaje.: Login correcto";

                        TxtUsuario.Enabled = false;
                        TxtClave.Enabled   = false;
                        BtnAceptar.Enabled = false;

                        ImgCerradura.ImageUrl = "~/Imagenes/CerraduraVerde.png";
                        Timer2.Enabled = true;
                    }
                    else
                    {
                        LblMensaje.Text = "Mensaje.: Usuario Inabilitado";
                        Timer2.Enabled  = true;
                    }
                }
                else
                {
                    LblMensaje.Text = "Mensaje.: Login incorrecto";
                    Timer2.Enabled  = true;
                }
            }
            catch
            {
                LblMensaje.Text = "Mensaje.: No hay conexion con la Base de Datos";
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            //Acceder al menu de la aplicacion y quitar mensajes
            if (LblMensaje.Text == "Mensaje.: Login correcto")
            {
                Session["Log_Usuario"] = LblMensaje.Text;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                LblMensaje.Text    = "";
                Timer2.Enabled     = false;
                TxtUsuario.Enabled = true;
                TxtClave.Enabled   = true;
                BtnAceptar.Enabled = true;
                TxtUsuario.Focus();
            }
        }
    }
}