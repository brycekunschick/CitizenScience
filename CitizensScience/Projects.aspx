<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="CitizensScience.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Projects</h2>
        <asp:Repeater ID="ProjectsRepeater" runat="server">
            <ItemTemplate>
                <!-- Link to ProjectDetails.aspx with ProjectID as a query parameter -->
                <a href="ProjectDetails.aspx?ProjectID=<%# Eval("ProjectID") %>">
                    <%# Eval("ProjectName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </main>
</asp:Content>
