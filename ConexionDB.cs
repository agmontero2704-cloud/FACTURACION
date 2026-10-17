using System.Configuration;
using System.Data.SqlClient;

namespace FACTURACION
{
    /// <summary>
    /// Clase encargada de gestionar la conexión a la base de datos del sistema.
    /// Implementa el patrón Singleton para garantizar una única instancia de conexión.
    /// </summary>
    public class DatabaseConnection
    {
        // Instancia única de la clase (patrón Singleton)
        private static DatabaseConnection _instance;

        // Constructor privado para evitar instanciación externa
        private DatabaseConnection()
        {
        }

        /// <summary>
        /// Obtiene la instancia única de la conexión a base de datos.
        /// </summary>
        /// <returns>Instancia de DatabaseConnection</returns>
        public static DatabaseConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnection();
            }
            return _instance;
        }

        /// <summary>
        /// Crea una conexión SQL usando la cadena de conexión "CnFact" definida en Web.config.
        /// Si no existe la cadena de configuración, usa valores por defecto (localhost, Facturacion, seguridad integrada).
        /// </summary>
        /// <returns>Objeto SqlConnection listo para abrirse</returns>
        public SqlConnection CreateConnection()
        {
            // Lee la configuración de cadena de conexión desde Web.config
            var connectionSetting = ConfigurationManager.ConnectionStrings["CnFact"];
            string connectionString = connectionSetting != null && !string.IsNullOrWhiteSpace(connectionSetting.ConnectionString)
                ? connectionSetting.ConnectionString
                : "Server=localhost; Database=Facturacion; Integrated Security=SSPI;";

            return new SqlConnection(connectionString);
        }
    }
}
