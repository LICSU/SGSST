using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_EditarTrabajador : System.Web.UI.Page
{
    SqlConnection cnBDCentral = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_BD_Central"].ConnectionString);
    string sqlQuery = "", Err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["TrabajadorID"]  = Request.QueryString["id"];
        
        if (!IsPostBack)
        {
            CargarUsuario();
        }
    }

    protected void CargarUsuario()
    {
        sqlQuery = "SELECT id_municipio as VAL, nombre as TXT FROM Municipio";
        Utilidades.CargarListado(ref ddlMunicipio, sqlQuery, cnBDCentral, ref Err, true);
        sqlQuery = "SELECT id_area as VAL, nombre as TXT FROM Area";
        Utilidades.CargarListado(ref ddlArea, sqlQuery, cnBDCentral, ref Err, true);
        sqlQuery = "SELECT id_usuario as VAL, login as TXT FROM Usuario";
        Utilidades.CargarListado(ref ddlUsuario, sqlQuery, cnBDCentral, ref Err, true);
        sqlQuery = "SELECT id_trabajador, cedula, primer_nombre, segundo_nombre, "+
                  " primer_apellido, segundo_apellido, id_area, email, convert(varchar(11), fecha_nacimiento,103) as fecha_nacimiento, " +
                  " edo_civil, sexo, telefono_casa, telefono_movil, eps, direccion, id_municipio, id_usuario "+
                  " FROM Trabajador WHERE id_trabajador = "+ViewState["TrabajadorID"];
        SqlCommand cmd = new SqlCommand(sqlQuery, cnBDCentral);
        SqlDataReader reader;
        txtCedula.Enabled = false;
        try
        {
            cnBDCentral.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtCedula.Text = reader["cedula"].ToString();
                txtNombre1.Text = reader["primer_nombre"].ToString();
                txtNombre2.Text = reader["segundo_nombre"].ToString();
                txtApellido1.Text = reader["primer_apellido"].ToString();
                txtApellido2.Text = reader["segundo_apellido"].ToString();
                ddlArea.SelectedValue = reader["id_area"].ToString();
                txtEmail.Text = reader["email"].ToString();
                txtFechadeNacimiento.Text = reader["fecha_nacimiento"].ToString();
                ddlEdoCivil.SelectedValue = reader["edo_civil"].ToString();
                ddlSexo.SelectedValue = reader["sexo"].ToString();
                txtTelCasa.Text = reader["telefono_casa"].ToString();
                txtTelCelular.Text = reader["telefono_movil"].ToString();
                txtEps.Text = reader["eps"].ToString();
                txtDireccion.Text = reader["direccion"].ToString();
                ddlMunicipio.SelectedValue = reader["id_municipio"].ToString();
                ddlUsuario.SelectedValue = reader["id_usuario"].ToString();
            }
            reader.Close();
            cnBDCentral.Close();
        }
        catch (SqlException sq)
        {
            cnBDCentral.Close();
            MostrarMsjModal("Error al Cargar los datos: "+sq.Message, "ERR");
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        string PrimerNombre = txtNombre1.Text;
        string SegundoNombre = txtNombre2.Text;
        string PrimerApellido = txtApellido1.Text;
        string SegundoApellido = txtApellido2.Text;
        string Email = txtEmail.Text;
        string FechaNacimiento = txtFechadeNacimiento.Text;
        string TelefonoCasa = txtTelCasa.Text;
        string TelefonoCel = txtTelCelular.Text;
        string Eps = txtEps.Text;
        string Direccion = txtDireccion.Text;
        string AreaID = ddlArea.SelectedValue;
        string EdoCivil = ddlEdoCivil.SelectedValue;
        string Sexo = ddlSexo.SelectedValue;
        string MunicipioID = ddlMunicipio.SelectedValue;
        string UsuarioID = ddlUsuario.SelectedValue;

        sqlQuery = "UPDATE Trabajador SET primer_nombre = '" + PrimerNombre + "'," +
                   "segundo_nombre = '" + SegundoNombre + "'," +
                   "primer_apellido = '" + PrimerApellido + "'," +
                   "segundo_apellido = '" + SegundoApellido + "'," +
                   "id_area = " + AreaID + "," +
                   "email = '" + Email + "'," +
                   "fecha_nacimiento = CONVERT(DATE,'" + FechaNacimiento + "',103)," +
                   "edo_civil = '" + EdoCivil + "'," +
                   "sexo = '" + Sexo + "'," +
                   "telefono_casa = '" + TelefonoCasa + "'," +
                   "telefono_movil = '" + TelefonoCel + "'," +
                   "eps = '" + Eps + "'," +
                   "direccion = '" + Direccion + "'," +
                   "id_municipio = " + MunicipioID + "," +
                   "id_usuario = " + UsuarioID + " " +
                   "WHERE id_trabajador = " + ViewState["TrabajadorID"];

        Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
        if (Err == "")
        {
            MostrarMsjModal("Trabajador Modificado con Éxito", "EXI");
        }
        else
            MostrarMsjModal("Ocurrió un Error: " + Err, "ERR");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    private void MostrarMsjModal(string msj, string tipo)
    {
        string sTitulo = "Información";
        string sCcsClase = "fa fa-check fa-2x text-info";
        switch (tipo)
        {
            case "ERR":
                sTitulo = "ERROR";
                sCcsClase = "fa fa-times fa-2x text-danger";
                break;
            case "ADV":
                sTitulo = "ADVERTENCIA"; //
                sCcsClase = "fa fa-exclamation-triangle fa-2x text-warning";
                break;
            case "EXI":
                sTitulo = "ÉXITO";
                sCcsClase = "fa fa-check fa-2x text-success";
                break;
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMsjModal", "MostrarMsjModal('" + msj.Replace("'", "").Replace("\r\n", " ") + "','" + sTitulo + "','" + sCcsClase + "');", true);
    }
}