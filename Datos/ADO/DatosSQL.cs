using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Datos.ADO
{
    public class DatosSQL
    {

        private readonly string strConnection;
        private SqlConnection iConnection;
        private SqlTransaction iTransaction;

        /// <summary>
        /// Constructor que inicializa la cadena de conexión a la base de datos con la cadena proporcionada.
        /// </summary>
        /// <param name="cs"></param>
        public DatosSQL(string connectionString)
        {
            strConnection = connectionString;
        }



        /// <summary>
        /// Permite realizar conexión con el servidor de base de datos SQL.
        /// </summary>
        /// <param name="CadenaConexion">String, con la cadena de conexión al servidor</param>
        /// <returns>Retorna la conexión abierta al servidor en modo de interface</returns>
        private SqlConnection Conectar(String CadenaConexion)
        {
            try
            {
                // Verificamos si no se ha instanciado a la conexión anteriormente
                if (iConnection == null || iConnection.DataSource == "")
                    iConnection = new SqlConnection(CadenaConexion);

                // Abrimos la conexion
                if (iConnection.State != ConnectionState.Open)
                    iConnection.Open();

                return iConnection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con el servidor: " + ex.Message + "=>" + ex.Source);
            }
        }

        /// <summary>
        /// Ejecuta una consulta y devuelve los datos
        /// </summary>
        /// <param name="Query">Consulta que se desea ejecutar en el servidor</param>
        /// <returns>Dataset con el conjunto de resultados de la consulta. Un dataset puede tener varios datatable.</returns>
        public DataSet ObtenerDatos(String Query)
        {
            try
            {
                //Query = String.Concat("set dateformat dmy; ", Query);

                // Comando para ejecutar las consultas
                SqlCommand cmSQL = new SqlCommand(Query, Conectar(strConnection));
                cmSQL.CommandTimeout = 30000;

                // Variable del dataset y adaptador para generar los datos
                DataSet dsResult = new DataSet();
                SqlDataAdapter daSQL = new SqlDataAdapter(cmSQL);

                daSQL.Fill(dsResult);

                // Liberamos la memoria
                cmSQL.Dispose();
                daSQL.Dispose();

                iConnection.Close();
                iConnection = null;

                // Resultado
                return dsResult;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron obtener los datos de la consulta..." + Environment.NewLine + ex.Message);
            }
        }


        /// <summary>
        /// Crea un comando para ejecutar un procedimiento y obtiene los parametros del procedimiento almacenado
        /// </summary>
        /// <param name="spName">Nombre del procedimiento que se desea ejecutar</param>
        /// <returns></returns>
        private IDbCommand CrearComando(String spName)
        {
            try
            {
                // Creamos una conexión temporal
                SqlConnection cnSQL = Conectar(strConnection);
                //cnSQL.Open();

                // Creamos el comando para el procedimiento indicado en el parametro
                SqlCommand Comando = new SqlCommand(spName, cnSQL);

                Comando.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(Comando);

                // Cerramos la conexión temporal
                cnSQL.Close();
                cnSQL.Dispose();


                // Asignamos la conexión principal al procedimiento y retornamos el comando creado
                Comando.Connection = Conectar(strConnection);
                return Comando;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el comando hacia la base de datos" + ex.Message);
            }

        }

        /// <summary>
        /// Permite agregar valores a cada uno de los parametros de un comando
        /// </summary>
        /// <param name="Comando">Comando que contiene los parametros</param>
        /// <param name="Valores">Colección de valores que se le asignaran al comando</param>
        private void CargarParametros(IDbCommand Comando, Object[] Valores)
        {
            // Recorremos cada uno de los parametros contenidos en el comando
            for (int i = 1; i < Comando.Parameters.Count; i++)
            {
                // Creamos la variable de tipo parametro SQL y le asignamos el parametro correspondiente del comando
                SqlParameter Parametro = (SqlParameter)Comando.Parameters[i];

                //Asignamos el valor del parametro 
                Parametro.Value = (i <= Valores.Length) ? Valores[i - 1] : null;
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado (sin parametros) en la base de datos
        /// </summary>
        /// <param name="spName">Nombre del procedimiento almacenado que se desea ejecutar</param>
        /// <returns></returns>
        public int EjecutarProcedimiento(String spName)
        {
            return CrearComando(spName).ExecuteNonQuery();
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado (con parametros) en la base de datos
        /// </summary>
        /// <param name="spName">Nombre del procedimiento almacenado que se desea ejecutar</param>
        /// <param name="Parametros">Parametros que necesita el procedimiento, los parametros deben ser indicados en el orden de declaración del procedimiento</param>
        /// <returns>Retorna los parametros conteniendo los valores output</returns>
        public Object EjecutarProcedimiento(String spName, params Object[] Parametros)
        {
            // Creamos el comando
            SqlCommand cmProcedure = (SqlCommand)CrearComando(spName);

            // Cargamos los parametros del procedimiento
            CargarParametros(cmProcedure, Parametros);

            // Ejecutamos el procedimiento almacenado
            cmProcedure.CommandTimeout = 30000;
            cmProcedure.ExecuteNonQuery();

            // Verificamos los parametros de salida para asignar los valores devueltos
            for (int i = 0; i <= Parametros.Length; i++)
            {
                IDataParameter ParametroTemp = (IDataParameter)cmProcedure.Parameters[i];
                if (ParametroTemp.Direction == ParameterDirection.InputOutput || ParametroTemp.Direction == ParameterDirection.Output)
                {
                    Parametros.SetValue(ParametroTemp.Value, i - 1);
                }
            }

            //destruir rastro de conexion
            cmProcedure.Dispose();
            iConnection = null;

            //retornar resultado
            return Parametros;
        }

        /// <summary>
        /// Ejecutar procedimiento con tabla como parametro
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="Nameparam1"></param>
        /// <param name="tabla1"></param>
        /// <param name="Nameparam2"></param>
        /// <param name="tabla2"></param>
        /// <param name="Nameparam3"></param>
        /// <param name="tabla3"></param>
        /// <returns></returns>
        public String EnviarTablaParametroProc(String procName, String Nameparam1 = "", DataTable tabla1 = null, String Nameparam2 = "", DataTable tabla2 = null, String Nameparam3 = "", DataTable tabla3 = null)
        {
            String Salida = "";
            try
            {
                using (var conn = new SqlConnection(this.strConnection))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(procName, conn))
                    {
                        //SqlTransaction transaction;
                        //transaction = conn.BeginTransaction("Transacion");
                        cmd.Connection = conn;
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            //1Tabla
                            if (Nameparam1 != "" && Nameparam2 == "" && Nameparam3 == "")
                            {
                                //parametro de salida
                                var salidaParam = cmd.Parameters.AddWithValue("@Salida", DbType.String);
                                salidaParam.Direction = ParameterDirection.Output;
                                salidaParam.SqlDbType = SqlDbType.VarChar;
                                salidaParam.Size = 700;

                                //tabla como parametro
                                var tabla1Param = cmd.Parameters.AddWithValue(Nameparam1, tabla1);
                                tabla1Param.SqlDbType = SqlDbType.Structured;
                            }
                            //2Tabla
                            if (Nameparam1 != "" && Nameparam2 != "" && Nameparam3 == "")
                            {
                                var salidaParam = cmd.Parameters.AddWithValue("@Salida", DbType.String);
                                salidaParam.Direction = ParameterDirection.Output;
                                salidaParam.SqlDbType = SqlDbType.VarChar;
                                salidaParam.Size = 100;

                                var tabla1Param = cmd.Parameters.AddWithValue(Nameparam1, tabla1);
                                var tabla2Param = cmd.Parameters.AddWithValue(Nameparam2, tabla2);
                                tabla1Param.SqlDbType = SqlDbType.Structured;
                                tabla2Param.SqlDbType = SqlDbType.Structured;
                            }
                            //3Tabla
                            if (Nameparam1 != "" && Nameparam2 != "" && Nameparam3 != "")
                            {
                                //parametro de salida
                                var salidaParam = cmd.Parameters.AddWithValue("@Salida", DbType.String);
                                salidaParam.Direction = ParameterDirection.Output;
                                salidaParam.SqlDbType = SqlDbType.VarChar;
                                salidaParam.Size = 700;

                                var tabla1Param = cmd.Parameters.AddWithValue(Nameparam1, tabla1);
                                var tabla2Param = cmd.Parameters.AddWithValue(Nameparam2, tabla2);
                                var tabla3Param = cmd.Parameters.AddWithValue(Nameparam3, tabla3);
                                tabla1Param.SqlDbType = SqlDbType.Structured;
                                tabla2Param.SqlDbType = SqlDbType.Structured;
                                tabla3Param.SqlDbType = SqlDbType.Structured;
                            }
                            //ejecutar proceso y capturar el parametro de salida
                            cmd.ExecuteNonQuery();
                            Salida = cmd.Parameters["@Salida"].Value.ToString();
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex) { return ex.ToString(); }
            return Salida;
        }

        /// <summary>
        /// Obtiene la estructura de una tabla, incluyendo tipos de datos, tamaños de campos, si acepta o no valores null, etc.
        /// </summary>
        /// <param name="Tabla">Datatable con esquema de la tabla</param>
        /// <returns></returns>
        public DataTable ObtenerEsquemaTabla(String Tabla)
        {
            DataTable dtEsquema;
            // Comando para ejecutar la consulta
            SqlCommand cmSQL = new SqlCommand("Select * From " + Tabla, this.Conectar(strConnection));

            // Obtenemos los datos del esquema de toda la tabla
            using (IDataReader Reader = cmSQL.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                dtEsquema = Reader.GetSchemaTable();
            }

            //destruir rastro de conexión
            cmSQL.Dispose();
            iConnection = null;

            //retornar esquema de la tabla
            return dtEsquema;
        }

        /// <summary>
        /// Obtiene Registros de una Tabla Utilizando SQLDATAREADER
        /// </summary>
        /// <param name="spname">Nombre del Procedimiento que Obtiene los Datos</param>
        /// <returns>Retorna Registros</returns>
        public DataTable SelectAll(string spname)
        {
            SqlCommand cmProcedure = (SqlCommand)CrearComando(spname);

            DataTable dt = new DataTable();
            try
            {
                SqlDataReader reader = cmProcedure.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al Intentar Obtener Registros" + Environment.NewLine + ex.Message);
            }

            //eliminar la conexion
            iConnection.Close();
            iConnection = null;

            //retornar registros
            return dt;
        }

        /// <summary>
        /// Obtiene datos en base a un procediiento almacenado
        /// </summary>
        /// <param name="spname"></param>
        /// <param name="Parametros"></param>
        /// <returns></returns>
        public DataTable SelectRecord(string spname, params Object[] Parametros)
        {
            SqlCommand cmProcedure = (SqlCommand)CrearComando(spname);
            CargarParametros(cmProcedure, Parametros);

            DataTable dt = new DataTable();
            try
            {
                SqlDataReader reader = cmProcedure.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al Intentar Cargar Datos" + Environment.NewLine + ex.Message);
            }

            cmProcedure.Dispose();

            //eliminar la conexion
            iConnection.Close();
            iConnection = null;

            //retornar resultado
            return dt;
        }


        /// <summary>
        /// Ejecuta un procedimiento almacenado (con parametros) en la base de datos
        /// </summary>
        /// <param name="spName">Nombre del procedimiento almacenado que se desea ejecutar</param>
        /// <param name="Parametros">Parametros que necesita el procedimiento, los parametros deben ser indicados en el orden de declaración del procedimiento</param>
        /// Para ejecutar las setencias es necesario usar el orden de los indices
        /// Indice 1 = List<1> spName y sus parametros List<Object(1)> Parametros    
        /// <returns>Retorna los parametros conteniendo los valores output</returns>
        public String EjecutarTransaccion(List<String> spName, List<Object[]> Parametros)
        {
            //mesage error
            String Message = "";

            //crear transaccion
            //SqlTransaction transaccion = null;
            // Creamos el comando
            SqlTransaction transaction = null;
            SqlCommand cmProcedure = new SqlCommand();
            SqlConnection connection = Conectar(strConnection);

            try
            {
                using (transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    cmProcedure.Transaction = transaction;
                    cmProcedure.Connection = connection;
                    cmProcedure.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < spName.Count; i++)
                    {

                        foreach (var item in Parametros[i])
                        {
                            cmProcedure.CommandText = spName[i];
                            SqlCommandBuilder.DeriveParameters(cmProcedure);
                            CargarParametros(cmProcedure, (Object[])item);

                            // Ejecutamos el procedimiento almacenado
                            cmProcedure.ExecuteNonQuery();


                        }
                    }

                    transaction.Commit();
                    Message = "OK";
                }


            }
            catch (Exception es)
            {
                transaction.Rollback();
                Message = es.Message;
            }
            finally
            {
                //destruir rastro de conexion
                cmProcedure.Dispose();
                transaction.Dispose();


                transaction = null;
                cmProcedure = null;
                iConnection = null;


            }

            //retornar resultado
            return Message;

        }


        /// <summary>
        /// Ejecuta un procedimiento almacenado (con parametros) en la base de datos
        /// </summary>
        /// <param name="consultas">lista de consulta a ejecutar</param>
        /// <param name="isolacion">metodo de insolaction</param>
        /// <returns></returns>
        public string EjecutarTransaccion(List<String> consultas, IsolationLevel isolacion)
        {
            //bandera de exito de la transaccion
            string Message = "";
            string strMessage_SQL = "";

            //crear objeto de trasaccion, comando, conexion
            SqlCommand cmSQL = null;
            SqlTransaction transaccion = null;
            SqlConnection conexion = null;

            try
            {
                //instancia comando SqlCommand
                cmSQL = new SqlCommand();
                //crear conexion
                conexion = Conectar(this.strConnection);
                //crear la conexion del SqlCommand
                cmSQL.Connection = conexion;
                cmSQL.CommandTimeout = 30000;
                //crear transaccion con niveles de insolacion
                transaccion = conexion.BeginTransaction(isolacion);
                //adjuntar al comando la informacion de la transaccion
                cmSQL.Transaction = transaccion;

                //ejecutar la consulta segun la lista
                for (int i = 0; i < consultas.Count; i++)
                {
                    //obtener temporalmente la sentencia actual de ejecución
                    strMessage_SQL = consultas[i].ToString();

                    // Comando para ejecutar las consultas
                    cmSQL.CommandText = consultas[i].ToString();
                    cmSQL.ExecuteNonQuery();

                    //limpiar parametros
                    cmSQL.Parameters.Clear();
                }

                //si todo esta bien, ejecutar el commit para aplicar los cambios
                transaccion.Commit();

                //retornar true
                Message = "OK";

            }
            catch (Exception ex)
            {
                //si todo sale mal en el ciclo, deshacer cambios
                transaccion.Rollback();
                //retornar false
                Message = "Error al Intentar realizar la transacción: " + ex.Message + "=> Revisar la sentencia " + strMessage_SQL;
            }

            finally
            {
                //cerrar comando y conexion
                cmSQL.Dispose();
                iConnection.Close();
                iConnection = null;
            }
            return Message;
        }



        /// <summary>
        /// Devuelve un solo valor en la consulta.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">Consulta SQL</param>
        /// <returns>Tipo de datos variable: Entero, Cadena</returns>
        public T EjecutarScalar<T>(string sql)
        {
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand(sql, Conectar(this.strConnection));
                return (T)comando.ExecuteScalar();
            }
            catch (Exception)
            {
                return default(T);
            }
            finally
            {
                comando.Dispose();
                iConnection.Close();
                iConnection = null;
            }
        }

    }
}
