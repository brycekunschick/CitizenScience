<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResearchAreas.aspx.cs" Inherits="CitizensScience.ResearchAreas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2><asp:Literal ID="litHeader" runat="server"></asp:Literal></h2>
        <p><asp:Literal ID="litDescription" runat="server" Text="Click on a Research Area to view Projects."></asp:Literal></p>
        <asp:Repeater ID="ResearchAreasRepeater" runat="server">
            <ItemTemplate>
                <!-- Link to Projects.aspx with RA query parameter -->
                <a href="Projects.aspx?RA=<%# Eval("ResearchID") %>" class="btn btn-secondary" style="margin-bottom: 10px;">
                    <%# Eval("ResearchName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>

        <!-- Dynamic Back Button -->
        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-link" Style="color: gray;" OnClick="btnBack_Click" />
    </main>
</asp:Content>