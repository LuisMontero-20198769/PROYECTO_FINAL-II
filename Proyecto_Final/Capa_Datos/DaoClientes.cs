using Capa_Datos.Contract;
using Capa_Datos.Repositorio;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class DaoClientes : OracleConexion, IOperacionCrud<ClientesBO>
    {
        public string actualizar(ClientesBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection conn = new OracleConnection(strOracle))
                {
                    conn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_CLIENTE", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID", OracleType.Int32)).Value = dto.ID;
                        command.Parameters.Add(new OracleParameter("P_CEDULA", OracleType.VarChar)).Value = dto.CEDULA;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", OracleType.Int32)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleType.VarChar)).Value = dto.CATEGORIA;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string eliminar(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection conn = new OracleConnection(strOracle))
                {
                    conn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_CLIENTE", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID", OracleType.VarChar)).Value = dto;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string insertar(ClientesBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection conn = new OracleConnection(strOracle))
                {
                    conn.Open();
                    using (OracleCommand command = new OracleCommand("SP_INSERT_CLIENTE", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID", OracleType.Int32)).Value = dto.ID;
                        command.Parameters.Add(new OracleParameter("P_CEDULA", OracleType.VarChar)).Value = dto.CEDULA;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", OracleType.Int32)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleType.VarChar)).Value = dto.CATEGORIA;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ClientesBO> Listar()
        {
            List<ClientesBO> list = new List<ClientesBO>();
            ClientesBO dto = null;
            try
            {
                using (OracleConnection conn = new OracleConnection(strOracle))
                {
                    conn.Open();
                    using (OracleCommand command = new OracleCommand("SP_SELECT_CLIENTE", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter
                        ("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new ClientesBO();
                                dto.ID = Convert.ToInt32(dr["ID"]);
                                dto.CEDULA = Convert.ToString(dr["NOMBRE"]);
                                dto.NOMBRE = Convert.ToString(dr["APELLIDO"]);
                                dto.TELEFONO = Convert.ToInt32(dr["TELEFONO"]);
                                dto.CORREO= Convert.ToString(dr["CORREO"]);
                                dto.CATEGORIA = Convert.ToString(dr["CATEGORIA"]);
                                list.Add(dto);
                               
                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                new Exception("Error en el metodo Listar: " + ex.Message);

            }
            return list;
        }
    }
}
