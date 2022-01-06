<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="thinkTwice.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body style="align-content: center;font-family:'標楷體'" >
    <form id="form1" runat="server" >
        <div aria-grabbed="undefined" aria-multiline="False" class="flex">
            <asp:Panel ID="Panel1" runat="server" GroupingText="歡迎來到課表產生器" Height="276px" CssClass="flex" Width="326px">
                <br />
                　　<asp:Label ID="Label2" runat="server" Text="帳號："></asp:Label>
                <asp:TextBox ID="user_1" runat="server" Width="180px" ValidationGroup="AC"></asp:TextBox>
                &nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="user_1" ErrorMessage="請輸入帳號"></asp:RequiredFieldValidator>
                <br />
                　　<asp:Label ID="Label1" runat="server" Text="密碼："></asp:Label>
                <asp:TextBox ID="password_1" runat="server" style="margin-bottom: 0px" Width="180px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password_1" ErrorMessage="請輸入密碼"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="password_2_text" runat="server" Text="密碼確認：" Visible="False"></asp:Label>
                <asp:TextBox ID="password_2" runat="server" Visible="False" Width="180px"></asp:TextBox>
                <br />
                <br />
                <br />
                　　　　&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 　<asp:Button ID="login_button" runat="server" Text="登入" OnClick="Button1_Click" />
                　　<asp:Button ID="Register_button0" runat="server" OnClick="Button3_Click" Text="註冊" />
                <asp:Button ID="Register_button" runat="server" OnClick="Button2_Click" Text="註冊" />
            </asp:Panel>
            <br />
        </div>
        <asp:Label ID="Label3" runat="server" CssClass="flex"></asp:Label>
        <br />
        <br />
        <br />
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p style="margin-left: 160px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</html>
