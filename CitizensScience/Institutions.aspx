<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Institutions.aspx.cs" Inherits="CitizensScience.Institutions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h2>Institutions</h2>
        <asp:Repeater ID="InstitutionsRepeater" runat="server">
            <ItemTemplate>
                <!-- Link to ResearchAreas.aspx with InstID as a query parameter -->
                <a href="ResearchAreas.aspx?InstID=<%# Eval("InstitutionID") %>">
                    <%# Eval("InstitutionName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>
