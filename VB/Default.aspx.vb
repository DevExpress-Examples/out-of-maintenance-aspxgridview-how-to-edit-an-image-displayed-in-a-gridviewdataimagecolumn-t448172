Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private dataTable As DataTable
	Private ReadOnly Property CustomDataSource() As DataTable
		Get
			dataTable = TryCast(Session("CustomTable"), DataTable)
			If dataTable IsNot Nothing Then
				Return dataTable
			End If

			dataTable = New DataTable("CustomDTable")
			dataTable.Columns.Add("TypeID", GetType(Int32))
			dataTable.PrimaryKey = New DataColumn() { dataTable.Columns(0) }
			dataTable.Columns.Add("TypeText", GetType(String))
			dataTable.Columns.Add("ImgUrl", GetType(String))
			dataTable.Rows.Add(0, "Type1", "~/Images/Type1.jpg")
			dataTable.Rows.Add(1, "Type2", "~/Images/Type2.jpg")
			dataTable.Rows.Add(2, "Type3", "~/Images/Type3.jpg")
			Session("CustomTable") = dataTable
			Return dataTable
		End Get
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			Session.Clear()
		End If

		ASPxGridView1.DataSource = CustomDataSource
		ASPxGridView1.DataBind()
	End Sub
	Protected Sub ASPxUploadControl1_FileUploadComplete(ByVal sender As Object, ByVal e As DevExpress.Web.FileUploadCompleteEventArgs)
		Dim path As String = "/Images/" & e.UploadedFile.FileName
		Using fileStream = File.Create(Server.MapPath(path))
			e.UploadedFile.FileContent.Seek(0, SeekOrigin.Begin)
			e.UploadedFile.FileContent.CopyTo(fileStream)
		End Using
		e.CallbackData = path
		Session("lastUploadedFilePAth") = path
	End Sub
	Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
		Dim id As Integer = CInt(Fix(e.OldValues("TypeID")))
		Dim dr As DataRow = CustomDataSource.Rows.Find(id)
		dr(0) = e.NewValues("TypeID")
		dr(1) = e.NewValues("TypeText")
		If Session("lastUploadedFilePAth") IsNot Nothing Then
		  dr(2) = Session("lastUploadedFilePAth").ToString()
		End If
		Session("lastUploadedFilePAth") = Nothing
		ASPxGridView1.CancelEdit()
		e.Cancel = True
	End Sub

End Class