using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source_sistema_Plan_nuevo_plan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        FileUpload fileUpload1 = (FileUpload)FormView1.FindControl("FileUpload1");
        String rutaPlan = fileUpload1.FileName;

        if (fileUpload1.HasFile)
        {
            fileUpload1.SaveAs(Server.MapPath("~//source//archivos//planes//" + fileUpload1.FileName));
        }
    }
}