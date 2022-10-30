using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class UsuarioDatos
    {
        public async Task<bool> LoginAsync(string correo, string clave)
        {
            bool valido = false;
            try
            {
                string sql = "SELECT 1 FROM usuario WHERE Correo=@Correoo AND Clave=@Clave;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = correo;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 50).Value = clave;
                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return valido;
        }

        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM usuario;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        

       

        

    }
}

