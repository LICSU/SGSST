using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Base_Datos
{
    SqlConnection sqlConexionBd;
    static Modal objModal;

    public Base_Datos(string strNombreBd)
    {
        objModal = new Modal();

        if (strNombreBd == "sgsst")
        {
            this.sqlConexionBd = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_BD_SGSST"].ConnectionString);
        }
        if (strNombreBd == "central")
        {
            this.sqlConexionBd = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_BD_Central"].ConnectionString);
        }
    }
    public static DataSet SelectMatriz(String _strQuery, SqlConnection _sqlConexionBd)
    {
        _sqlConexionBd.Open();
        SqlDataAdapter sbAdapter = new SqlDataAdapter(_strQuery, _sqlConexionBd);
        DataSet ds = new DataSet();
        sbAdapter.Fill(ds);
        _sqlConexionBd.Close();
        return ds;
    }
    public SqlConnection getConector()
    {
        return this.sqlConexionBd;
    }

    public static void CrearMatrizPrincipal(string strQuery,SqlConnection _sqlConexionBd, string idtabla, GridView _objGridView, Page _Page)
    {
        try
        {
            DataSet dsObjDataSet = SelectMatriz(strQuery, _sqlConexionBd);
            DataTable dtObjDataTable = dsObjDataSet.Tables[0];
            string[] strTablaID = new string[1];
            strTablaID[0] = idtabla;
            _objGridView.DataKeyNames = strTablaID;
            _objGridView.DataSource = dtObjDataTable;
            _objGridView.DataBind();
        }
        catch (SqlException sq)
        {
            _sqlConexionBd.Close();
            objModal.MostrarMsjModal(sq.Message, "ERR", _Page);
        }
    }

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