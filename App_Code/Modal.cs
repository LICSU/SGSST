using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

public class Modal
{
    public Modal()
    {
        
    }

    public void MostrarMsjModal(string msj, string tipo, Page _page)
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
        ScriptManager.RegisterStartupScript(_page, GetType(), "MostrarMsjModal", "MostrarMsjModal('" + msj.Replace("'", "").Replace("\r\n", " ") + "','" + sTitulo + "','" + sCcsClase + "');", true);
    }

    public void registrarModal(string nombreModal, string nombreScript, Page _page)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('" + nombreModal + "').modal({ show: true });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(_page, this.GetType(), nombreScript, sb.ToString(), false);
    }

    public void registrarScriptAcciones(string idBoton, string nombreScript, Page _page)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("document.getElementById('"+ idBoton + "').click();");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(_page, this.GetType(), nombreScript, sb.ToString(), false);
    }


}