<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128533962/16.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T448172)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to edit an image displayed in a GridViewDataImageColumn


<p>By design, ASPxGridView's GridViewDataImageColumn is not editable unlike the GridViewDataBinaryImageColumn. <br>To implement its data editing manually, you can define EditItemTemplate for this column and place ASPxUploadControl with ASPxImage into this template to implement new image upload:</p>


```aspx
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
```


<p>Then, save an uploaded image to the required folder in ASPxUploadControl's server-side <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxUploadControl_FileUploadCompletetopic">FileUploadComplete</a> event handler and store its path to the ASPxGridView data source in the ASPxGridView's <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridView_RowUpdatingtopic">RowUpdating</a> event handler.</p>

<br/>


