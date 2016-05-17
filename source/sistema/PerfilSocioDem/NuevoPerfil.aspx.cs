using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_sistema_PerfilSocioDem_NuevoPerfil : System.Web.UI.Page
{
    SqlConnection cnBDCentral = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDCentral"].ConnectionString);
    SqlConnection cnBDSGSST = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString);
    string sqlQuery = "", Err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sqlQuery = "SELECT id_trabajador as VAL, (primer_nombre+' '+primer_apellido) as TXT FROM Trabajador";
            Utilidades.CargarListado(ref ddlTrabajador, sqlQuery, cnBDCentral, ref Err, true);
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (ddlTrabajador.SelectedValue != "")
        {
            string id_trabajador = ddlTrabajador.SelectedValue;
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

            sqlQuery = "INSERT INTO  desc_socio(id_trabajador,lugar_nac,nivel_escol,años_aprob,cabeza_fam,num_hijos,repart_resp,menores_dep,"+
                       " cond_social, mot_despl, tipo_vivienda, serv_pub, sist_seg_soc, reg_afiliacion, nivel_sisben, eps, afi_sssp"+
                       " ,fondo,afi_riesgo,arp,estrato) VALUES ("+id_trabajador+",'"+lugar_nac+"', '"+nivel_escol+"', '"+años_aprob+"',"+
                       " '"+cabeza_fam+"', '"+num_hijos+"', '"+repart_resp+"', '"+menores_dep+"', '"+cond_social+"', '"+mot_despl+"',"+
                       " '"+tipo_vivienda+"', '"+serv_pub+"', '"+sist_seg_soc+"', '"+reg_afiliacion+"', '"+nivel_sisben+"', '"+eps+"',"+
                       " '"+afi_sssp+"', '"+fondo+"', '"+afi_riesgo+"', '"+arp+"', '"+estrato+"')";
            Utilidades.EjeSQL(sqlQuery, cnBDSGSST, ref Err, false);
            if (Err == "")
            {
                MostrarMsjModal("Registro Agregado con Éxito", "EXI");
                limpiarCampos();
            }
            else
            {
                MostrarMsjModal("Error al Guardar el registro: "+Err, "ERR");
            }
        }
        else
        {
            MostrarMsjModal("Debe seleccionar un Trabajador", "ERR");
        }
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
    protected void rblNivel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblNivel.SelectedValue == "Otro")
            txtNivel.Visible = true;
        else
            txtNivel.Visible = false;
    }
    protected void rblMotivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMotivo.SelectedValue == "Desplazado")
            rblMotivo.Enabled = true;
        else
            rblMotivo.Enabled = false;
    }
}