using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_Trabajador : System.Web.UI.Page
{
    SqlConnection cnBDCentral = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDCentral"].ConnectionString);
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
            cnBDCentral.Open();
            sqlQuery = "SELECT * FROM Trabajador";
            SqlDataAdapter sbAdapter = new SqlDataAdapter(sqlQuery, cnBDCentral);
            DataSet ds = new DataSet();
            sbAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            string[] TablaID = new string[1];
            TablaID[0] = "id_trabajador";
            GridView1.DataKeyNames = TablaID;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cnBDCentral.Close();
        }
        catch (SqlException sq)
        {
            cnBDCentral.Close();
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
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal({ show: true });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddModalScript", sb.ToString(), false);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvrow = GridView1.Rows[index];
        if (e.CommandName.Equals("editar"))
        {
            string TrabajadorID = (gvrow.FindControl("id_trabajador") as HiddenField).Value;
            Response.Redirect("EditarTrabajador.aspx?id="+TrabajadorID);
        }
        if (e.CommandName.Equals("eliminar"))
        {
            hdfTrabajadorIDDel.Value = (gvrow.FindControl("id_trabajador") as Label).Text;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal({ show: true });");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        BindGridView();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgregarTrabajador.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        sqlQuery = "DELETE FROM Trabajador WHERE id_trabajador = " + hdfTrabajadorIDDel.Value;
        Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
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