<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="CitizensScience.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2><asp:Literal ID="litHeader" runat="server"></asp:Literal></h2>
        <p>Click on a Project to view Details.</p>
        <asp:Repeater ID="ProjectsRepeater" runat="server">
            <ItemTemplate>
                <!-- Link to ProjectDetails.aspx with ProjectID as a query parameter -->
                <a href="ProjectDetails.aspx?ProjectID=<%# Eval("ProjectID") %>" class="btn btn-secondary" style="margin-bottom: 10px;">
                    <%# Eval("ProjectName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>

        <!-- Back to Research Areas Button -->
        <asp:Button ID="btnBackToResearchAreas" runat="server" Text="Back to Research Areas" CssClass="btn btn-link" Style="color: gray;" OnClick="btnBackToResearchAreas_Click" />
    </main>
</asp:Content>
