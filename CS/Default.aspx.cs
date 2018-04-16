using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private DataTable dataTable;
    private DataTable CustomDataSource
    {
        get
        {
            dataTable = Session["CustomTable"] as DataTable;
            if (dataTable != null)
                return dataTable;

            dataTable = new DataTable("CustomDTable");
            dataTable.Columns.Add("TypeID", typeof(Int32));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
            dataTable.Columns.Add("TypeText", typeof(string));
            dataTable.Columns.Add("ImgUrl", typeof(string));
            dataTable.Rows.Add(0, "Type1", "~/Images/Type1.jpg");
            dataTable.Rows.Add(1, "Type2", "~/Images/Type2.jpg");
            dataTable.Rows.Add(2, "Type3", "~/Images/Type3.jpg");
            Session["CustomTable"] = dataTable;
            return dataTable;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Session.Clear();

        ASPxGridView1.DataSource = CustomDataSource;
        ASPxGridView1.DataBind();
    }
    protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
    {
        string path = "/Images/" + e.UploadedFile.FileName;
        using (var fileStream = File.Create(Server.MapPath(path)))
        {
            e.UploadedFile.FileContent.Seek(0, SeekOrigin.Begin);
            e.UploadedFile.FileContent.CopyTo(fileStream);
        }
        e.CallbackData = path;
        Session["lastUploadedFilePAth"] = path;
    }
    protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        int id = (int)e.OldValues["TypeID"];
        DataRow dr = CustomDataSource.Rows.Find(id);
        dr[0] = e.NewValues["TypeID"];
        dr[1] = e.NewValues["TypeText"];
        if (Session["lastUploadedFilePAth"] != null)
          dr[2] = Session["lastUploadedFilePAth"].ToString();
        Session["lastUploadedFilePAth"] = null;
        ASPxGridView1.CancelEdit();
        e.Cancel = true;
    }

}