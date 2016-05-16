using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public class ExportFiles
{
    public ExportFiles(){}

    public void ExportarWord(Page _page, GridView _objGridView,string nombreArchivo)
    {
        DateTime fechaActual = DateTime.Now;
        _page.EnableViewState = false;
        _page.Response.Clear();
        _page.Response.Buffer = true;
        _page.Response.Charset = "UTF-8";
        _page.Response.AddHeader("content-disposition", "attachment;filename="+ nombreArchivo + "(" + fechaActual.ToString("dd-MM-yyy h:mm:sss") + ").doc");
        _page.Response.ContentType = "application/vnd.ms-word ";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        _objGridView.AllowSorting = false;
        _objGridView.AllowPaging = false;
        _objGridView.DataBind();
        _objGridView.RenderControl(hw);
        _page.Response.Output.Write(sw.ToString());
        _page.Response.Flush();
        _page.Response.End();
    }

    public void ExportarExcel(Page _page, GridView _objGridView, string nombreArchivo)
    {
        DateTime fechaActual = DateTime.Now;
        _page.EnableViewState = false;
        _page.Response.Clear();
        _page.Response.Buffer = true;
        _page.Response.AddHeader("content-disposition", "attachment;filename="+ nombreArchivo + "(" + fechaActual.ToString("dd-MM-yyy h:mm:sss") + ").xls");
        _page.Response.Charset = "UTF-8";
        _page.Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        _objGridView.AllowSorting = false;
        _objGridView.AllowPaging = false;
        _objGridView.DataBind();

        //Change the Header Row back to white color
        _objGridView.HeaderRow.Style.Add("background-color", "#FFFFFF");

        //Apply style to Individual Cells
        _objGridView.HeaderRow.Cells[0].Style.Add("background-color", "green");
        _objGridView.HeaderRow.Cells[1].Style.Add("background-color", "green");
        _objGridView.HeaderRow.Cells[2].Style.Add("background-color", "green");
        _objGridView.HeaderRow.Cells[3].Style.Add("background-color", "green");

        for (int i = 0; i < _objGridView.Rows.Count; i++)
        {
            GridViewRow row = _objGridView.Rows[i];

            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;

            //Apply text style to each Row
            row.Attributes.Add("class", "textmode");

            //Apply style to Individual Cells of Alternating Row
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#C2D69B");
                row.Cells[1].Style.Add("background-color", "#C2D69B");
                row.Cells[2].Style.Add("background-color", "#C2D69B");
                row.Cells[3].Style.Add("background-color", "#C2D69B");
            }
        }
        _objGridView.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        _page.Response.Write(style);
        _page.Response.Output.Write(sw.ToString());
        _page.Response.Flush();
        _page.Response.End();
    }

    public void ExportarPdf(Page _page, GridView _objGridView, string nombreArchivo)
    {
        DateTime fechaActual = DateTime.Now;
        _page.EnableViewState = false;
        _page.Response.ContentType = "application/pdf";
        _page.Response.AddHeader("content-disposition", "attachment;filename="+ nombreArchivo + "(" + fechaActual.ToString("dd-MM-yyy h:mm:sss") + ").pdf");
        _page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        _objGridView.AllowSorting = false;
        _objGridView.AllowPaging = false;
        _objGridView.DataBind();
        _objGridView.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, _page.Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        _page.Response.Write(pdfDoc);
        _page.Response.End();
    }
}