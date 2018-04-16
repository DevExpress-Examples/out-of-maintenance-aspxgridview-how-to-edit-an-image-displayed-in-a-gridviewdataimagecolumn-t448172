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


