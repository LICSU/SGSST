﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuario : System.Web.UI.Page
{
    SqlConnection cnBDCentral = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDCentral"].ConnectionString);
    string sqlQuery = "", Err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
            sqlQuery = "SELECT id_rol as VAL, nombre as TXT FROM Rol";
            Utilidades.CargarListado(ref ddlRol, sqlQuery, cnBDCentral, ref Err, true);
            Utilidades.CargarListado(ref ddlRolEdit, sqlQuery, cnBDCentral, ref Err, true);
        }
    }
    protected void BindGridView()
    {
        try
        {
            cnBDCentral.Open();
            sqlQuery = "SELECT Usuario.id_usuario as id_usuario, Usuario.[login] as login1,"+
                        " Usuario.clave as clave, rol.id_rol as rol_id,rol.nombre as rol" +
                        " FROM Usuario INNER JOIN "+
                        " usuario_rol ON Usuario.id_usuario = usuario_rol.id_usuario INNER JOIN "+
                        " rol ON usuario_rol.id_rol = rol.id_rol";
            SqlDataAdapter sbAdapter = new SqlDataAdapter(sqlQuery, cnBDCentral);
            DataSet ds = new DataSet();
            sbAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            string[] TablaID = new string[1];
            TablaID[0] = "id_usuario";
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
            hdfUsuarioID.Value = (gvrow.FindControl("id_usuario") as Label).Text;
            txtLoginEdit.Text = (gvrow.FindControl("login") as Label).Text;
            string clave = (gvrow.FindControl("clave") as Label).Text;
            txtClaveEdit.Attributes.Add("value", clave);
            ddlRolEdit.SelectedValue = (gvrow.FindControl("rol_id") as HiddenField).Value;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal({ show: true });");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
        if (e.CommandName.Equals("eliminar"))
        {
            hdfUsuarioIDDel.Value = (gvrow.FindControl("id_usuario") as Label).Text;
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
        if (txtLogin.Text != "" && txtClave.Text != "" && ddlRol.SelectedValue != "")
        {
            Err = "";
            sqlQuery = "INSERT INTO Usuario (login, clave) " +
                       " VALUES ('" + txtLogin.Text + "', '" + txtClave.Text+ "')";
            Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
            string id_usuario = Utilidades.EjeSQL("SELECT id_usuario From Usuario WHERE login = '"+txtLogin.Text+"' and clave ='"+txtClave.Text+"'", cnBDCentral, ref Err, true);
            if (Err == "")
            {
                //Se ejecuto sin problema
                sqlQuery = "INSERT INTO usuario_rol(id_usuario, id_rol) VALUES ("+id_usuario+", "+ddlRol.SelectedValue+")";
                Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
                if (Err == "")
                {
                    MostrarMsjModal("Registrado agregado con Éxito", "EXI");
                    BindGridView();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("document.getElementById('closeAdd').click();");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
                }
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
        if (txtLoginEdit.Text != "" && txtClaveEdit.Text != "" && ddlRolEdit.SelectedValue != "")
        {
            Err = "";
            sqlQuery = "UPDATE Usuario SET login = '" + txtLoginEdit.Text + "'," +
                       " clave = '" + txtClaveEdit.Text +"' "+
                       " WHERE id_usuario = " + hdfUsuarioID.Value;
            Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
            if (Err == "")
            {
                //Se ejecuto sin problema
                sqlQuery = "UPDATE Usuario_rol SET id_rol = "+ddlRolEdit.SelectedValue+" WHERE id_usuario = "+hdfUsuarioID.Value;
                Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
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
                MostrarMsjModal("Error al modificar el registro "+Err, "ERR");
            }
        }
        else
        {
            MostrarMsjModal("Todos los campos son necesarios", "ERR");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        sqlQuery = "DELETE FROM usuario_rol WHERE id_usuario = " + hdfUsuarioIDDel.Value;
        Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
        if (Err == "")
        {
            sqlQuery = "DELETE FROM usuario WHERE id_usuario = " + hdfUsuarioIDDel.Value;
            Utilidades.EjeSQL(sqlQuery, cnBDCentral, ref Err, false);
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