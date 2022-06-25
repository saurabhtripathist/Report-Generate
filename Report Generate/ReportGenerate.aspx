<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportGenerate.aspx.cs" Inherits="Report_Generate.ReportGenerate" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Report</title>
    <!-- Bootstrap-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.1/font/bootstrap-icons.css">
</head>
<body class=" bg-light">
    <form id="form1" runat="server">
        <div class="container">
            <div class="card mt-5 col-md-8 offset-md-2">
                <div class="container">
                    <div class="card-body text-center">
                        <label class="lblStart" runat="server">
                            <b>Starts From:</b>
                        </label>
                        <asp:TextBox ID="txtStart" CssClass="ms-1" TextMode="Date" runat="server" Style="margin-right: 80pt"></asp:TextBox>
                        <label class="lblEnd" runat="server">
                            <b>End To:</b>
                        </label>
                        <asp:TextBox ID="txtEnd" CssClass="ms-1" TextMode="Date" runat="server"></asp:TextBox>
                        <br />
                        <div class="Container mt-5">
                            <asp:Button ID="generateExcel" CssClass="btn-primary rounded-2" runat="server" Text="Generate to Excel" Style="margin-right: 30pt" OnClick="generateExcel_Click" />

                            <asp:Button ID="generatePdf" CssClass="btn-primary rounded-2" runat="server" Text="Generate to Pdf" OnClick="generatePdf_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="card mt-3">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="ReportList" CssClass="Grid table table-condensed" BorderStyle="Outset" runat="server" GridLines="none" AllowSorting="False">
                            <HeaderStyle CssClass="bg-primary text-white" />
                            <RowStyle CssClass=" bg-light" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
