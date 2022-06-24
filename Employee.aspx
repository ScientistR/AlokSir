<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Test_31jan.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name :</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Address :</td>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Age :</td>
                    <td>
                        <asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Country :</td>
                    <td>
                        <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>State :</td>
                    <td>
                        <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" /></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Employee Address">
                                <ItemTemplate>
                                    <%#Eval("address") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Employee Age">
                                <ItemTemplate>
                                    <%#Eval("age") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Employee Country">
                                <ItemTemplate>
                                    <%#Eval("cname") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="A" CommandArgument='<%#Eval("empid") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                         
                        </Columns>
                        </asp:GridView></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
