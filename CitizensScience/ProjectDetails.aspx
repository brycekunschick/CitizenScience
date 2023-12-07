<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectDetails.aspx.cs" Inherits="CitizensScience.ProjectDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Project Details</h2>
        <div>
            <strong>Project ID:</strong> <asp:Label ID="lblProjectID" runat="server" /><br />
            <strong>Project Name:</strong> <asp:Label ID="lblProjectName" runat="server" /><br />
            <strong>Start Date:</strong> <asp:Label ID="lblStartDate" runat="server" /><br />
            <strong>End Date:</strong> <asp:Label ID="lblEndDate" runat="server" /><br />
            <strong>Coordinator ID:</strong> <asp:Label ID="lblCoordinatorID" runat="server" /><br />
            <strong>Description:</strong> <asp:Label ID="lblDescription" runat="server" /><br />
            <strong>Research ID:</strong> <asp:Label ID="lblResearchID" runat="server" /><br />
        </div>
    </main>
</asp:Content>