<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResearchAreas.aspx.cs" Inherits="CitizensScience.ResearchAreas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Research Areas</h2>
        <asp:Repeater ID="ResearchAreasRepeater" runat="server">
            <ItemTemplate>
                <!-- Link to Projects.aspx with RA query parameter -->
                <a href="Projects.aspx?RA=<%# Eval("ResearchID") %>">
                    <%# Eval("ResearchName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </main>
</asp:Content>