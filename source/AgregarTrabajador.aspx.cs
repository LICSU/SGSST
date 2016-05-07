using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_AgregarTrabajador : System.Web.UI.Page
{
    SqlConnection cnBDCentral = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDCentral"].ConnectionString);
    string sqlQuery = "", Err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sqlQuery = "SELECT id_municipio as VAL, nombre as TXT FROM Municipio";
            Utilidades.CargarListado(ref ddlMunicipio, sqlQuery, cnBDCentral, ref Err, true);
            sqlQuery = "SELECT id_area as VAL, nombre as TXT FROM Area";
            Utilidades.CargarListado(ref ddlArea, sqlQuery, cnBDCentral, ref Err, true);
            sqlQuery = "SELECT id_usuario as VAL, login as TXT FROM Usuario";
            Utilidades.CargarListado(ref ddlUsuario, sqlQuery, cnBDCentral, ref Err, true);
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        string PrimerNombre = txtNombre1.Text;
        string SegundoNombre = txtNombre2.Text;
        string PrimerApellido = txtApellido1.Text;
        string SegundoApellido = txtApellido2.Text;
        string Cedula = txtCedula.Text;
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

        sqlQuery = "INSERT INTO Trabajador (cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido,"+
                    "id_area, email, fecha_nacimiento, edo_civil, sexo, foto, telefono_casa, telefono_movil, activo, fecha_registro,"+
                    "eps, direccion, id_municipio, id_usuario) VALUES ('"+Cedula+"', '"+PrimerNombre+"', '"+SegundoNombre+"', "+
                    "'"+PrimerApellido+"', '"+SegundoApellido+"', "+AreaID+", '"+Email+"', CONVERT(DATE, '"+FechaNacimiento+"', 103), "+
                    "'"+EdoCivil+"', '"+Sexo+"', NULL, '"+TelefonoCasa+"', '"+TelefonoCel+"', 1, CONVERT(DATE, SYSDATETIME(), 103), '"+Eps+"',"+
                    "'"+Direccion+"', "+MunicipioID+", "+UsuarioID+")";
        //MostrarMsjModal(sqlQuery, "");
        Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
        if (Err == "")
        {
            limpiarCampos();
            MostrarMsjModal("Trabajador Agregado con Éxito", "EXI");
        }
        else
            MostrarMsjModal("Ocurrió un Error: " + Err, "ERR");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Trabajador.aspx");
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
    protected void limpiarCampos()
    {
        txtNombre1.Text = string.Empty;
        txtNombre2.Text = string.Empty;
        txtApellido1.Text = string.Empty;
        txtApellido2.Text = string.Empty;
        txtCedula.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtFechadeNacimiento.Text = string.Empty;
        txtTelCasa.Text = string.Empty;
        txtTelCelular.Text = string.Empty;
        txtEps.Text = string.Empty;
        txtDireccion.Text = string.Empty;
        ddlArea.SelectedValue = string.Empty;
        ddlEdoCivil.SelectedValue = string.Empty;
        ddlSexo.SelectedValue = string.Empty;
        ddlMunicipio.SelectedValue = string.Empty;
        ddlUsuario.SelectedValue = string.Empty;
    }
}