using Api_DataAccess_ADO.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_DataAccess_ADO.Data
{
    public class AdoDbContext
    {
        private readonly string cadenaConexion;

        public AdoDbContext(IConfiguration configuration)
        {
            cadenaConexion = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(cadenaConexion))
                throw new ArgumentNullException("Connection string no configurada");
        }

        public async Task<DataSet> ListarTablasAsync(string nombreProcedimiento, SqlParameter[] parametros = null)
        {
            using SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                await conexion.OpenAsync();

                using SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                DataSet dataSet = new DataSet();
                do
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    dataSet.Tables.Add(table);
                } while (!reader.IsClosed && await reader.NextResultAsync());

                return dataSet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<DataRow> BuscarPorIdAsync(string nombreProcedimiento, SqlParameter[] parametros = null)
        {
            DataTable tabla = await ListarAsync(nombreProcedimiento, parametros);

            if (tabla != null && tabla.Rows.Count > 0)
                return tabla.Rows[0];

            return null;
        }


        public async Task<DataTable> ListarAsync(string nombreProcedimiento, SqlParameter[] parametros = null)
        {
            using SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                await conexion.OpenAsync();

                using SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                DataTable tabla = new DataTable();
                tabla.Load(reader);

                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        // Este metodo sirve para Insertar, Actualizar y Eliminar
        public async Task<bool> EjecutarAsync(string nombreProcedimiento, SqlParameter[] parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros);
                    //foreach (var parametro in parametros)
                    //{
                    //    //cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    //    cmd.Parameters.AddRange(parametros);
                    //}
                }

                int i = await cmd.ExecuteNonQueryAsync();

                return (i > 0) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}