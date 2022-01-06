<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select_class.aspx.cs" Inherits="thinkTwice.select_class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body style="align-content: center;font-family:'標楷體'">
    <form id="form1" runat="server" class="StyleSheet1.css">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" HorizontalAlign="Center">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="選擇" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="課程名稱" HeaderText="課程名稱" SortExpression="課程名稱" />
                    <asp:BoundField DataField="老師" HeaderText="老師" SortExpression="老師" />
                    <asp:BoundField DataField="星期" HeaderText="星期" SortExpression="星期" />
                    <asp:BoundField DataField="節次" HeaderText="節次" SortExpression="節次" />
                    <asp:BoundField DataField="地點" HeaderText="地點" SortExpression="地點" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle HorizontalAlign="Center" BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
        <p>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" HorizontalAlign="Center" CssClass="flex"></asp:Label>
        </p>
        <p>
            </p>
        <div class="button">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="產生課表" HorizontalAlign="Center" CssClass="button"/>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Schedule]"></asp:SqlDataSource>
        <p>
            <asp:Label ID="Label5" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </p>
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" HorizontalAlign="Center">
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
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [節次], [星期一], [星期二], [星期三], [星期四], [星期五] FROM [class]"></asp:SqlDataSource>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
