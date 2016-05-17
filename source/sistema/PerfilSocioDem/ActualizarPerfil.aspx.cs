using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_sistema_PerfilSocioDem_ActualizarPerfil : System.Web.UI.Page
{
    SqlConnection cnBDCentral = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDCentral"].ConnectionString);
    SqlConnection cnBDSGSST = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString);
    string sqlQuery = "", Err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["DescID"] = Request.QueryString["id"];
        if (!IsPostBack)
        {
            sqlQuery = "SELECT id_trabajador as VAL, (primer_nombre+' '+primer_apellido) as TXT FROM Trabajador";
            Utilidades.CargarListado(ref ddlTrabajador, sqlQuery, cnBDCentral, ref Err, true);
            CargarUsuario();
        }
    }
    protected void CargarUsuario()
    {
        sqlQuery = "SELECT id_desc_socio, id_trabajador, RTRIM(lugar_nac) as lugar_nac, RTRIM(nivel_escol) as nivel_escol, RTRIM(años_aprob) as años_aprob,"+
                  " RTRIM(cabeza_fam) as cabeza_fam, RTRIM(num_hijos) as num_hijos, RTRIM(repart_resp) as repart_resp, RTRIM(menores_dep) as menores_dep"+
                  ", RTRIM(cond_social) as cond_social, " +
                  " RTRIM(mot_despl) as mot_despl, RTRIM(tipo_vivienda) as tipo_vivienda, RTRIM(serv_pub) as serv_pub, RTRIM(sist_seg_soc) as sist_seg_soc"+
                  ", RTRIM(reg_afiliacion) as reg_afiliacion, RTRIM(nivel_sisben) as nivel_sisben, RTRIM(eps) as eps, RTRIM(afi_sssp) as afi_sssp" +
                  ", RTRIM(fondo) as fondo, RTRIM(afi_riesgo) as afi_riesgo, RTRIM(arp) as arp, RTRIM(estrato) as estrato " +
                  " FROM desc_socio WHERE id_desc_socio = " + ViewState["DescID"];
        SqlCommand cmd = new SqlCommand(sqlQuery, cnBDSGSST);
        SqlDataReader reader;
        ddlTrabajador.Enabled = false;
        try
        {
            cnBDSGSST.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ddlTrabajador.SelectedValue = reader["id_trabajador"].ToString();
                txtLugar.Text = reader["lugar_nac"].ToString();
                rblNivel.SelectedValue = reader["nivel_escol"].ToString();
                txtAnhosApro.Text = reader["años_aprob"].ToString();
                rdlCabeza.SelectedValue = reader["cabeza_fam"].ToString();
                ddlHijos.SelectedValue = reader["num_hijos"].ToString();
                rblResponsabilidad.SelectedValue = reader["repart_resp"].ToString();
                ddlMenores.SelectedValue = reader["menores_dep"].ToString();
                rblCondicion.SelectedValue = reader["cond_social"].ToString();
                rblMotivo.SelectedValue = reader["mot_despl"].ToString();
                dblVivienda.SelectedValue = reader["tipo_vivienda"].ToString();
                cblServicios.SelectedValue = reader["serv_pub"].ToString();
                dblSeguridad.SelectedValue = reader["sist_seg_soc"].ToString();
                rblRegimen.SelectedValue = reader["reg_afiliacion"].ToString();
                rblNivelSisben.SelectedValue = reader["nivel_sisben"].ToString();
                txtEps.Text = reader["eps"].ToString();
                rblPensiones.SelectedValue = reader["afi_sssp"].ToString();
                txtFondo.Text = reader["fondo"].ToString();
                rblRiesgos.SelectedValue = reader["afi_riesgo"].ToString();
                txtARP.Text = reader["arp"].ToString();
                rblEstrato.Text = reader["estrato"].ToString();
            }
            reader.Close();
            cnBDSGSST.Close();
        }
        catch (SqlException sq)
        {
            cnBDSGSST.Close();
            MostrarMsjModal("Error al Cargar los datos: " + sq.Message, "ERR");
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

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        string lugar_nac = txtLugar.Text;
        string nivel_escol = string.Empty;
        if (rblNivel.SelectedValue == "Otro")
            nivel_escol = txtNivel.Text;
        else
            nivel_escol = rblNivel.SelectedValue;
        string años_aprob = txtAnhosApro.Text;
        string cabeza_fam = rdlCabeza.SelectedValue;
        string num_hijos = ddlHijos.SelectedValue;
        string repart_resp = rblResponsabilidad.SelectedValue;
        string menores_dep = ddlMenores.SelectedValue;
        string cond_social = rblCondicion.SelectedValue;
        string mot_despl = string.Empty;
        if (rblMotivo.SelectedValue == "Desplazado")
            mot_despl = rblMotivo.SelectedValue;
        string tipo_vivienda = dblVivienda.SelectedValue;
        string serv_pub = cblServicios.SelectedValue;
        string sist_seg_soc = dblSeguridad.SelectedValue;
        string reg_afiliacion = rblRegimen.SelectedValue;
        string nivel_sisben = rblNivelSisben.SelectedValue;
        string eps = txtEps.Text;
        string afi_sssp = rblPensiones.SelectedValue;
        string fondo = txtFondo.Text;
        string afi_riesgo = rblRiesgos.SelectedValue;
        string arp = txtARP.Text;
        string estrato = rblEstrato.SelectedValue;
        sqlQuery = "UPDATE desc_socio SET lugar_nac = '" + lugar_nac + "', nivel_escol = '" + nivel_escol + "', "+
                   " años_aprob = '" + años_aprob + "', cabeza_fam = '" + cabeza_fam + "', num_hijos = '" + num_hijos + "',"+
                   " repart_resp = '" + repart_resp + "', menores_dep = '" + menores_dep + "', cond_social = '" + cond_social + "',"+
                   " mot_despl = '" + mot_despl + "', tipo_vivienda = '" + tipo_vivienda + "', serv_pub = '" + serv_pub + "', "+
                   " sist_seg_soc = '" + sist_seg_soc + "', reg_afiliacion = '" + reg_afiliacion + "', nivel_sisben = '" + nivel_sisben + "',"+
                   " eps = '" + eps + "', afi_sssp = '" + afi_sssp + "', fondo = '" + fondo + "', afi_riesgo = '" + afi_riesgo + "',"+
                   " arp = '" + arp + "', estrato = '" + estrato + "' WHERE id_desc_socio = " + ViewState["DescID"];
        Utilidades.EjeSQL(sqlQuery, cnBDSGSST, ref Err, false);
        if (Err == "")
        {
            MostrarMsjModal("Registro Modificado con Éxito", "EXI");
            limpiarCampos();
        }
        else
        {
            MostrarMsjModal("Error al actualizar el registro", "ERR");
        }
    }
    protected void rblMotivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMotivo.SelectedValue == "Desplazado")
            rblMotivo.Enabled = true;
        else
            rblMotivo.Enabled = false;
    }
    protected void rblNivel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblNivel.SelectedValue == "Otro")
            txtNivel.Visible = true;
        else
            txtNivel.Visible = false;
    }
    private void limpiarCampos()
    {
        txtLugar.Text = string.Empty;
        txtNivel.Text = string.Empty;
        txtAnhosApro.Text = string.Empty;
        txtEps.Text = string.Empty;
        txtFondo.Text = string.Empty;
        txtARP.Text = string.Empty;
    }
}