using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

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

    /**
     * @param name="lst" DropDownList de referencia  
     * @param name="cn" Conexion a la Base de Datos
     * @param name="sSelectSQL" Sentencia SQL
     * @param name="sErr" Mensaje de error en caso de existir
     * @param name="bIndex0" False en caso de no querer el valor Vacio (indice 0)
     **/
    public static void CargarListado(ref DropDownList lst, string sSelectSQL, SqlConnection cn, ref string sErr, bool bIndex0 = false)
    {
        string sRes = "";
        lst.Items.Clear();
        SqlCommand cmd = new SqlCommand(sSelectSQL, cn);
        SqlDataReader reader;
        try
        {
            cn.Open();
            reader = cmd.ExecuteReader();
            Int16 i = 0;
            if (bIndex0)
            {
                lst.Items.Add(new ListItem("Seleccione un Valor", ""));
                i += 1;
            }
            while (reader.Read())
            {
                ListItem newItem = new ListItem();
                newItem.Text = reader["TXT"].ToString();
                newItem.Value = reader["VAL"].ToString();
                lst.Items.Add(newItem);
            }
            reader.Close();
            if (lst.Items.Count == 1) { lst.Enabled = false; } else { lst.Enabled = true; }
        }
        catch (SqlException Sqlex)
        {
            sRes = "Error de SQL cargando el Listado " + lst.ID + ", detalle: " + Sqlex.Message;
        }
        catch (Exception err)
        {
            sRes = "Error cargando el Listado " + lst.ID + ", detalle: " + err.Message;
        }
        finally
        {
            cn.Close();
        }
        sErr += sRes;
    }
}