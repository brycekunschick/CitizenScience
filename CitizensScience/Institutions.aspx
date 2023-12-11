<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Institutions.aspx.cs" Inherits="CitizensScience.Institutions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h2>Institutions</h2>
        <p>Click on an institution to view its Research Areas.</p>
        <asp:Repeater ID="InstitutionsRepeater" runat="server">
            <ItemTemplate>
                <!-- Link to ResearchAreas.aspx with InstID as a query parameter -->
                <a href="ResearchAreas.aspx?InstID=<%# Eval("InstitutionID") %>" class="btn btn-secondary" style="margin-bottom: 10px;">
                    <%# Eval("InstitutionName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
        <!-- Back to Home Button -->
        <button type="button" onclick="window.location.href='Default.aspx';" class="btn btn-link" style="color: gray;">Back to Home</button>
    </main>

</asp:Content>
