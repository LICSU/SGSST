using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_sistema_PerfilSocioDem_PerfilSocio : System.Web.UI.Page
{
    SqlConnection cnTodo = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionTodo"].ConnectionString);
    SqlConnection cnBDSGSST = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString);
    string sqlQuery = "", Err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }
    protected void BindGridView()
    {
        try
        {
            cnTodo.Open();
            sqlQuery = "SELECT bd_central.dbo.trabajador.cedula as cedula, sgsst.dbo.desc_socio.id_desc_socio as id_desc_socio, " +
                   " (bd_central.dbo.trabajador.primer_nombre+' '+bd_central.dbo.trabajador.primer_apellido) as nombres " +
                   " FROM bd_central.dbo.trabajador " +
                   " INNER JOIN sgsst.dbo.desc_socio  " +
                   " ON sgsst.dbo.desc_socio.id_trabajador " +
                   " = bd_central.dbo.trabajador.id_trabajador";
            SqlDataAdapter sbAdapter = new SqlDataAdapter(sqlQuery, cnTodo);
            DataSet ds = new DataSet();
            sbAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            string[] TablaID = new string[1];
            TablaID[0] = "id_desc_socio";
            GridView1.DataKeyNames = TablaID;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cnTodo.Close();
        }
        catch (SqlException sq)
        {
            cnTodo.Close();
            MostrarMsjModal(sq.Message, "ERR");
        }
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

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("NuevoPerfil.aspx");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvrow = GridView1.Rows[index];
        if (e.CommandName.Equals("editar"))
        {
            string id_trabajador = (gvrow.FindControl("id_desc_socio") as Label).Text;
            Response.Redirect("ActualizarPerfil.aspx?id="+id_trabajador);
        }
        if (e.CommandName.Equals("ver"))
        {
            string id_trabajador = (gvrow.FindControl("id_desc_socio") as Label).Text;
            Response.Redirect("VerPerfil.aspx?id=" + id_trabajador);
        }
        if (e.CommandName.Equals("eliminar"))
        {
            hdfPerfilIDDel.Value = (gvrow.FindControl("id_desc_socio") as Label).Text;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal({ show: true });");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        sqlQuery = "DELETE FROM desc_socio WHERE id_desc_socio = " + hdfPerfilIDDel.Value;
        Utilidades.EjeSQL(sqlQuery, cnBDSGSST, ref Err, false);
        if (Err == "")
        {
            //Se ejecuto sin problema
            MostrarMsjModal("Registrado Eliminado con Éxito", "EXI");
            BindGridView();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("document.getElementById('closeDelete').click();");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
        }
        else
        {
            MostrarMsjModal("Error al realizar el Update: " + Err, "ERR");
        }
    }
}