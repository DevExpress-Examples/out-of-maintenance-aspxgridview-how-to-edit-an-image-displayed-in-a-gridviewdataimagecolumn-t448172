<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function onFileUploadComplete(s, e) {
            var path = e.callbackData;
            img.SetImageUrl(path);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="TypeID"
                OnRowUpdating="ASPxGridView1_RowUpdating">
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="TypeID" ReadOnly="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="TypeText" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn FieldName="ImgUrl" VisibleIndex="3">
                        <EditItemTemplate>
                            <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" Width="200px" ClientInstanceName="img"
                                ImageUrl='<%# Eval("ImgUrl") %>'></dx:ASPxImage>
                            <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" UploadMode="Auto" Width="200px" AutoStartUpload="true"
                                OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                <ValidationSettings AllowedFileExtensions=".jpg"></ValidationSettings>
                                <ClientSideEvents FileUploadComplete="onFileUploadComplete" />
                            </dx:ASPxUploadControl>
                        </EditItemTemplate>
                    </dx:GridViewDataImageColumn>
                </Columns>
            </dx:ASPxGridView>
        </div>
    </form>
</body>
</html>
