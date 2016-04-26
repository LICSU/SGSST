using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Utilidades
{
    /**
     * @param name="query" Sentencia SQL 
     * @param name="connection" Conexion a la base de Datos
     * @param name="err" Referencia en caso de que se genere un error
     * @param name="EjecutaEscalar" True en caso de Select, False en caso de INSERT, DELETE o UPDATE.
     * @returns Valores si existen en caso de Select ó 0 o 1 en otro caso.
     */
    public static string EjeSQL(string query, SqlConnection connection, ref string err, bool EjecutaEscalar = true)
    {
        string functionReturnValue = null;
        SqlCommand cmd = new SqlCommand();
        object result = null;
        bool SinAbrir = true;
        try
        {
            if (connection.State == ConnectionState.Open)
                SinAbrir = false;
            if (SinAbrir)
                connection.Open();
            cmd.CommandText = query;
            cmd.Connection = connection;
            cmd.CommandTimeout = connection.ConnectionTimeout;
            if (EjecutaEscalar)
                result = cmd.ExecuteScalar();
            else
                result = cmd.ExecuteNonQuery();
            try
            {
                functionReturnValue = result.ToString().Trim();
                connection.Close();
            }
            catch (Exception)
            {
                functionReturnValue = "";
                connection.Close();
            }
        }
        catch (SqlException sqlex)
        {
            err += "Función EjeSQL, Error de ejecución del SQL: " + sqlex.Message;
            return "-1";
        }
        catch (Exception ex)
        {
            err += "Función EjeSQL, Error: " + ex.Message;
            return "-1";
        }
        finally
        {
            if (SinAbrir)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        return functionReturnValue;
    }
}