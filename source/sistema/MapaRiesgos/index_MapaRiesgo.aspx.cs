using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public partial class source_sistema_MapaRiesgos_index_MapaRiesgo : System.Web.UI.Page
{
    #region variable
    Base_Datos objBase_Datos_SGSST = new Base_Datos("sgsst");
    Base_Datos objBase_Datos_Central = new Base_Datos("central");
    string strQuery = "", strError = "";
    string strRuta = "~//source//archivos//mapas//";
    Modal objModal = new Modal();
    ExportFiles objExportFiles = new ExportFiles();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
            Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);
            CargarListas();
        }
    }
    protected void CargarListas()
    {
        strQuery = "SELECT id_empresa as VAL, nombre as TXT FROM Empresa";
        Base_Datos.CargarListado(ref ddlEmpresa, strQuery, objBase_Datos_Central.getConector(), ref strError, true);
        Base_Datos.CargarListado(ref ddlEmpresaEdit, strQuery, objBase_Datos_Central.getConector(), ref strError, true);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvrow = GridView1.Rows[index];


        if (e.CommandName.Equals("editar"))
        {
            hdfPlanID.Value = (gvrow.FindControl("id_plan_mapa") as Label).Text;
            txtNombreEdit.Text = (gvrow.FindControl("nombre") as Label).Text;
            txtFechaEdit.Text = (gvrow.FindControl("fecha_creacion") as Label).Text;
            ddlEmpresaEdit.SelectedValue = (gvrow.FindControl("id_empresa") as HiddenField).Value;

            objModal.registrarModal("#editModal", "EditModalScript", this);
        }


        if (e.CommandName.Equals("eliminar"))
        {
            hdfPlanIDDel.Value = (gvrow.FindControl("id_plan_mapa") as Label).Text;
            objModal.registrarModal("#deleteModal", "DeleteModalScript", this);
        }

    }

    protected void MostrarModalAgregar(object sender, EventArgs e)
    {
        objModal.registrarModal("#addModal", "AddModalScript", this);
    }
    protected void MostrarModalImprimir(object sender, EventArgs e)
    {
        objModal.registrarModal("#printModal", "printModalScript", this);
    }

    protected void InsertarFila(object sender, EventArgs e)
    {
        if (!flpArchivo.HasFile) { objModal.MostrarMsjModal("Debe elegir un archivo", "ERR", this); }
        else if (txtNombre.Text == "") { objModal.MostrarMsjModal("Ingresar el campo nombre", "ERR", this); }
        else if (TextFechaCreacion.Text == "") { objModal.MostrarMsjModal("Ingresar el campo Fecha", "ERR", this); }
        else if (ddlEmpresa.SelectedValue == "") { objModal.MostrarMsjModal("Seleccionar el campo empresa", "ERR", this); }
        else
        {
            DateTime fechaActual = DateTime.Now;
            string extension = "." + flpArchivo.FileName.Substring(flpArchivo.FileName.LastIndexOf('.') + 1).ToLower();
            string nombreArchivo = ddlEmpresa.SelectedValue + txtNombre.Text + fechaActual.ToString("dd-MM-yyy") + extension;


            flpArchivo.SaveAs(Server.MapPath(strRuta + nombreArchivo));

            strError = "";

            strQuery = "INSERT INTO plan_mapa (nombre,ruta,fecha_creacion,id_empresa,tipo) " +
                       " VALUES ('" + txtNombre.Text + "', '" + nombreArchivo + "','"
                       + TextFechaCreacion.Text + "'," + ddlEmpresa.SelectedValue + ",2)";

            Base_Datos.EjeSQL(strQuery, objBase_Datos_SGSST.getConector(), ref strError, true);


            if (strError == "")
            {
                //Se ejecuto sin problema
                objModal.MostrarMsjModal("Registrado agregado con Éxito", "EXI", this);
                Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);
                objModal.registrarScriptAcciones("closeAdd", "EditHideModalScript", this);
            }
            else
            {
                objModal.MostrarMsjModal("Error al insertar el registro", "ERR", this);
            }
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (!flpArchivoEdit.HasFile) { objModal.MostrarMsjModal("Debe elegir un archivo", "ERR", this); }
        else if (txtNombreEdit.Text == "") { objModal.MostrarMsjModal("Ingresar el campo nombre", "ERR", this); }
        else if (txtFechaEdit.Text == "") { objModal.MostrarMsjModal("Ingresar el campo Fecha", "ERR", this); }
        else if (ddlEmpresaEdit.SelectedValue == "") { objModal.MostrarMsjModal("Seleccionar el campo empresa", "ERR", this); }
        else
        {
            DateTime fechaActual = DateTime.Now;
            string extension = "." + flpArchivo.FileName.Substring(flpArchivo.FileName.LastIndexOf('.') + 1).ToLower();
            string nombreArchivo = ddlEmpresa.SelectedValue + txtNombre.Text + fechaActual.ToString("dd-MM-yyy") + extension;

            flpArchivo.SaveAs(Server.MapPath(strRuta + nombreArchivo));
            strError = "";
            strQuery = "UPDATE plan_mapa SET " +
                        " nombre = '" + txtNombreEdit.Text + "'," +
                        " ruta = '" + nombreArchivo + "'," +
                        " fecha_creacion = '" + txtFechaEdit.Text + "'," +
                        " id_empresa = " + ddlEmpresaEdit.SelectedValue + " " +
                        " WHERE id_plan_mapa = " + hdfPlanID.Value;

            Base_Datos.EjeSQL(strQuery, objBase_Datos_SGSST.getConector(), ref strError, false);

            if (strError == "")
            {
                //Se ejecuto sin problema
                objModal.MostrarMsjModal("Registrado modificado con Éxito", "EXI", this);
                Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);
                objModal.registrarScriptAcciones("closeEdit", "CloseHideModalScript", this);
            }
            else
            {
                objModal.MostrarMsjModal("Error al modificar el registro " + strError, "ERR", this);
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        strQuery = "DELETE FROM plan_mapa WHERE id_plan_mapa = " + hdfPlanIDDel.Value;
        Base_Datos.EjeSQL(strQuery, objBase_Datos_SGSST.getConector(), ref strError, false);
        if (strError == "")
        {
            //Se ejecuto sin problema
            objModal.MostrarMsjModal("Registrado Eliminado con Éxito", "EXI", this);
            Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);
            objModal.registrarScriptAcciones("closeDelete", "DeleteHideModalScript", this);
        }
        else
        {
            objModal.MostrarMsjModal("Error al realizar el Update: " + strError, "ERR", this);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = e.NewPageIndex;
        Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnExportWord_Click(object sender, EventArgs e)
    {
        Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);
        GridView1.Columns[4].Visible = false;
        GridView1.Columns[5].Visible = false;
        GridView1.Columns[6].Visible = false;
        GridView1.Columns[7].Visible = false;

        objExportFiles.ExportarWord(this, GridView1, "Mapa");
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);
        GridView1.Columns[4].Visible = false;
        GridView1.Columns[5].Visible = false;
        GridView1.Columns[6].Visible = false;
        GridView1.Columns[7].Visible = false;

        objExportFiles.ExportarExcel(this, GridView1, "Mapa");
    }
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
        Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);

        GridView1.Columns[4].Visible = false;
        GridView1.Columns[5].Visible = false;
        GridView1.Columns[6].Visible = false;
        GridView1.Columns[7].Visible = false;
        objExportFiles.ExportarPdf(this, GridView1, "Mapa");

    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[6].Attributes.Add("colspan", "2");
        }
    }

    protected void buscarPlan(object sender, EventArgs e)
    {
        Base_Datos.CrearMatrizPrincipal("SELECT * FROM plan_mapa WHERE tipo = 2 AND nombre like '%" + searchPlan.Text + "%'", objBase_Datos_SGSST.getConector(), "id_plan_mapa", GridView1, this);
    }


}