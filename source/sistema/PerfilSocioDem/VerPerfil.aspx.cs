using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_sistema_PerfilSocioDem_VerPerfil : System.Web.UI.Page
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
        sqlQuery = "SELECT id_desc_socio, id_trabajador, RTRIM(lugar_nac) as lugar_nac, RTRIM(nivel_escol) as nivel_escol, RTRIM(años_aprob) as años_aprob," +
                  " RTRIM(cabeza_fam) as cabeza_fam, RTRIM(num_hijos) as num_hijos, RTRIM(repart_resp) as repart_resp, RTRIM(menores_dep) as menores_dep" +
                  ", RTRIM(cond_social) as cond_social, " +
                  " RTRIM(mot_despl) as mot_despl, RTRIM(tipo_vivienda) as tipo_vivienda, RTRIM(serv_pub) as serv_pub, RTRIM(sist_seg_soc) as sist_seg_soc" +
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
                txtNivel.Text = reader["nivel_escol"].ToString();
                txtAnhosApro.Text = reader["años_aprob"].ToString();
                lblCabeza.Text = reader["cabeza_fam"].ToString();
                lblHijos.Text = reader["num_hijos"].ToString();
                lblResponsabilidad.Text = reader["repart_resp"].ToString();
                lblMenores.Text = reader["menores_dep"].ToString();
                lblCondicion.Text = reader["cond_social"].ToString();
                lblMotivo.Text = reader["mot_despl"].ToString();
                lblVivienda.Text = reader["tipo_vivienda"].ToString();
                lblServicios.Text = reader["serv_pub"].ToString();
                lblSistema.Text = reader["sist_seg_soc"].ToString();
                lblRegimen.Text = reader["reg_afiliacion"].ToString();
                lblNivel.Text = reader["nivel_sisben"].ToString();
                txtEps.Text = reader["eps"].ToString();
                lblPensiones.Text = reader["afi_sssp"].ToString();
                txtFondo.Text = reader["fondo"].ToString();
                lblRiesgos.Text = reader["afi_riesgo"].ToString();
                txtARP.Text = reader["arp"].ToString();
                lblEstrato.Text = reader["estrato"].ToString();
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
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("PerfilSocio.aspx");
    }
}