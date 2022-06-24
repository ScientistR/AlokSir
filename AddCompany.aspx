<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="Class26219.AddCompany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            BindData();
        });

        function BindData() {
            $.ajax({
                url: 'AddCompany.aspx/Get',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{}",
                success: function (p) {
                    p = JSON.parse(p.d);
                    $("#kk").find("tr:gt(0)").remove();
                    for (var i = 0; i < p.length; i++) {
                        $("#kk").append('<tr> <td>' + p[i].name + '</td>  <td>' + p[i].address + '</td>  <td>' + p[i].age + '</td> <td><input type="button" id="btndelete" value="Delete" onclick="DeleteData(' + p[i].empid + ')" /></td>  <td><input type="button" id="btnedit" value="Edit" onclick="EditData(' + p[i].empid + ')" /></td> </tr>');
                    }
                },
                error: function () {
                    alert('record nai mila');
                }
            });
        }

        function SaveData() {
            $.ajax({
                url: 'AddCompany.aspx/Insert',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{D :'"+IDD+"',A : '" + $("#txtname").val() + "', B : '" + $("#txtaddress").val() + "', C : '" + $("#txtage").val() + "'}",
                success: function () {
                    alert('Record saved');
                    BindData();
                },
                error: function () {
                    alert('Record not saved');
                }
            });
        }

        function DeleteData(empid) {
            $.ajax({
                url: 'AddCompany.aspx/Delete',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{A : '" + empid + "'}",
                success: function () {
                    alert('Record Deleted');
                    BindData();
                },
                error: function () {
                    alert('Record not Deleted');
                }
            });
        }

        var IDD = 0;
        function EditData(empid) {
            $.ajax({
                url: 'AddCompany.aspx/Edit',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{A : '" + empid + "'}",
                success: function (p) {
                    p = JSON.parse(p.d);
                    $("#txtname").val(p[0].name);
                    $("#txtaddress").val(p[0].address);
                    $("#txtage").val(p[0].age);
                    $("#btnsave").val("Update");
                    IDD = empid;
                },
                error: function () {
                    alert('Record not edited');
                }
            });
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name :</td>
                    <td>
                        <input type="text" id="txtname" /></td>
                </tr>

                <tr>
                    <td>Address :</td>
                    <td>
                        <input type="text" id="txtaddress" /></td>
                </tr>

                <tr>
                    <td>Age :</td>
                    <td>
                        <input type="text" id="txtage" /></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <input type="button" id="btnsave" value="Save" onclick="SaveData()" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <table id="kk" border="1" style="background-color: orange; color: white">
                            <tr style="background-color: green">
                                <th>Employee Name</th>
                                <th>Employee Address</th>
                                <th>Employee Age</th>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>



        </div>
    </form>
</body>
</html>
