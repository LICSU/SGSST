using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class source_Rol : System.Web.UI.Page
{
    SqlConnection cnBDCentral = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDCentral"].ConnectionString);
    string sqlQuery = "", Err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {            
            BindGridView();
            sqlQuery = "SELECT id_rol_sistema as VAL, nombre as TXT FROM rol_sistema";
            Utilidades.CargarListado(ref ddlRolSistema, sqlQuery, cnBDCentral, ref Err, true);
            sqlQuery = "SELECT id_rol_sistema as VAL, nombre as TXT FROM rol_sistema";
            Utilidades.CargarListado(ref ddlRolSistemaEdit, sqlQuery, cnBDCentral, ref Err, true);
        }
    }
    protected void BindGridView()
    {
        try
        {
            cnBDCentral.Open();
            sqlQuery = "SELECT rol.id_rol AS id_rol, "+
                       " rol.nombre AS nombre, " +
                       " rol_sistema.id_rol_sistema AS rs_id, " +
                       " rol_sistema.nombre AS nombre_rs"+
                       " FROM rol INNER JOIN"+
                       " rol_sistema ON rol.id_rol_sistema = rol_sistema.id_rol_sistema";
            SqlDataAdapter sbAdapter = new SqlDataAdapter(sqlQuery, cnBDCentral);
            DataSet ds = new DataSet();
            sbAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            string[] TablaID = new string[1];
            TablaID[0] = "id_rol";
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
            hdfRolID.Value = (gvrow.FindControl("id_rol") as Label).Text;
            txtNombreEdit.Text = (gvrow.FindControl("nombre") as Label).Text;
            ddlRolSistemaEdit.SelectedValue= (gvrow.FindControl("rs_id") as HiddenField).Value;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal({ show: true });");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false); 
        }
        if (e.CommandName.Equals("eliminar"))
        {
            hdfRolIDDel.Value = (gvrow.FindControl("id_rol") as Label).Text;
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
        if (ddlRolSistema.SelectedValue != "" && txtNombre.Text != "")
        {
            Err = "";
            sqlQuery = "INSERT INTO Rol (nombre, id_rol_sistema) "+
                       " VALUES ('"+txtNombre.Text+"', "+ddlRolSistema.SelectedValue+")";
            Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, true);
            if (Err == "")
            {
                //Se ejecuto sin problema
                MostrarMsjModal("Registrado agregado con Éxito", "EXI");
                BindGridView();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("document.getElementById('closeAdd').click();");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            }
            else
            {
                MostrarMsjModal("Error al insertar el registro", "ERR");
            }
        }
        else
        {
            MostrarMsjModal("Todos los campos son necesarios", "ERR");
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (ddlRolSistemaEdit.SelectedValue != "" && txtNombreEdit.Text != "")
        {
            Err = "";
            sqlQuery = "UPDATE Rol SET nombre = '"+txtNombreEdit.Text+"',"+
                       " id_rol_sistema = "+ddlRolSistemaEdit.SelectedValue+
                       " WHERE id_rol = "+hdfRolID.Value;
            Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
            if (Err == "")
            {
                //Se ejecuto sin problema
                MostrarMsjModal("Registrado modificado con Éxito", "EXI");
                BindGridView();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("document.getElementById('closeEdit').click();");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            }
            else
            {
                MostrarMsjModal("Error al modificar el registro", "ERR");
            }
        }
        else
        {
            MostrarMsjModal("Todos los campos son necesarios", "ERR");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        sqlQuery = "DELETE FROM Rol WHERE id_rol = " + hdfRolIDDel.Value;
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