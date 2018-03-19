<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="FCL.Cockerham.Ogsm.Admin.Reports.ViewReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Reports</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Reports - User Details</h2>
        <asp:ScriptManager ID="smReports" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="rptReports" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer> 
    </div>
    </form>
</body>
</html>
