using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace FACTURACION
{
    public class ConexionDB
    {
        // Atributos
        private string Base;
        private string Servidor;
        private string Usuario; // Aunque no se use con Windows Auth, conviene dejarlo para que coincida con el if/else de la diapositiva
        private string Clave;
        private bool seguridad;
        private static ConexionDB Con = null;

        // Constructor
        private ConexionDB()
        {
            this.Base = "Facturacion";
            this.Servidor = "localhost"; // O puedes usar "."
            this.Usuario = "";
            this.Clave = "";
            this.seguridad = true;       // Activa la Autenticación de Windows
        }

        // Método de Conexión efectivo
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                var cnSetting = ConfigurationManager.ConnectionStrings["CnFact"];
                if (cnSetting != null && !string.IsNullOrWhiteSpace(cnSetting.ConnectionString))
                {
                    Cadena.ConnectionString = cnSetting.ConnectionString;
                }
                else
                {
                    Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";

                    if (this.seguridad)
                    {
                        Cadena.ConnectionString += "Integrated Security = SSPI;";
                    }
                    else
                    {
                        Cadena.ConnectionString += "User Id=" + this.Usuario + "; Password=" + this.Clave + ";";
                    }
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }

        // Método para obtener la instancia
        public static ConexionDB getInstancia()
        {
            if (Con == null)
            {
                Con = new ConexionDB();
            }
            return Con;
        }
    }
}
