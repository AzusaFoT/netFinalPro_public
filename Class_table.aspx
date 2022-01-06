<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Class_table.aspx.cs" Inherits="thinkTwice.Class_table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="align-content: center;font-family:'標楷體'">
    <form id="form1" runat="server">
        <div>
            👉按 Ctrl+P---&gt;列印<br />
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" CssClass="flex">
            <Columns>
                <asp:BoundField DataField="節次" HeaderText="節次" SortExpression="節次" />
                <asp:BoundField DataField="星期一" HeaderText="星期一" SortExpression="星期一" />
                <asp:BoundField DataField="星期二" HeaderText="星期二" SortExpression="星期二" />
                <asp:BoundField DataField="星期三" HeaderText="星期三" SortExpression="星期三" />
                <asp:BoundField DataField="星期四" HeaderText="星期四" SortExpression="星期四" />
                <asp:BoundField DataField="星期五" HeaderText="星期五" SortExpression="星期五" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [節次], [星期一], [星期二], [星期三], [星期四], [星期五] FROM [class]"></asp:SqlDataSource>
    </form>
</body>
</html>
