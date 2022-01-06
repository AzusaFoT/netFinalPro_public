<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select_class.aspx.cs" Inherits="thinkTwice.select_class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="選擇" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="課程名稱" HeaderText="課程名稱" SortExpression="課程名稱" />
                    <asp:BoundField DataField="老師" HeaderText="老師" SortExpression="老師" />
                    <asp:BoundField DataField="星期" HeaderText="星期" SortExpression="星期" />
                    <asp:BoundField DataField="節次" HeaderText="節次" SortExpression="節次" />
                    <asp:BoundField DataField="地點" HeaderText="地點" SortExpression="地點" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
        <p>
            &nbsp;</p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Schedule]"></asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="節次" HeaderText="節次" SortExpression="節次" />
                <asp:BoundField DataField="星期一" HeaderText="星期一" SortExpression="星期一" />
                <asp:BoundField DataField="星期二" HeaderText="星期二" SortExpression="星期二" />
                <asp:BoundField DataField="星期三" HeaderText="星期三" SortExpression="星期三" />
                <asp:BoundField DataField="星期四" HeaderText="星期四" SortExpression="星期四" />
                <asp:BoundField DataField="星期五" HeaderText="星期五" SortExpression="星期五" />
            </Columns>
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [節次], [星期一], [星期二], [星期三], [星期四], [星期五] FROM [class]"></asp:SqlDataSource>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
