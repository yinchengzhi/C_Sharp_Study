<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPicTest.aspx.cs"
    Inherits="UploadPic.UploadPicTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片自动上传和显示</title>
    <link href="css/UploadPicTest.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function doit() {
            form1.submit();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="pic_image">
        <asp:Image class="picshow" ID="pic" runat="server" /></div>
    <div>
        <div class="file_div">
            <asp:FileUpload ID="pic_upload" runat="server" ToolTip="选择图片" onchange="javascript:doit()" />
            <span id="file_text">选择图片</span>
        </div>

        <asp:Label ID="lbl_pic" runat="server" class="pic_text"></asp:Label></div>
    <div class="pic_label">
        上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过8M</div>
    </form>
</body>
</html>
