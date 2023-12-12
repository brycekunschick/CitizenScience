<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Observations.aspx.cs" MasterPageFile="~/Site.Master" Inherits="CitizensScience.Observations" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>My Observations</h2>
        <div style="margin-bottom: 10px;">
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </div>
        <div>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" Visible="false" CssClass="btn btn-secondary" />
        </div>
        <!-- Add Observation Button, visible only to logged-in users -->
        <div style="margin-bottom: 10px;">
            <asp:Button ID="AddObservationButton" runat="server" Text="Add Observation" OnClick="AddObservationButton_Click" CssClass="btn btn-secondary" Visible="false" />
        </div>
        <!-- Search Bar for Logged-in Users -->
        <div style="margin-bottom: 20px;">
            <asp:TextBox ID="txtSearch" runat="server" Visible="false" CssClass="form-control" Style="width: auto; display: inline-block; margin-right: 10px;" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-secondary" Visible="false" Style="display: inline-block;" />
        </div>
        <asp:GridView ID="ObservationsGridView" runat="server" AutoGenerateColumns="False" CellPadding="10" CellSpacing="10" Style="width: 500px; table-layout: fixed;">
            <Columns>
                <asp:BoundField DataField="ObservationID" HeaderText="Observation ID" ItemStyle-Wrap="true" ItemStyle-Width="100px" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" ItemStyle-Wrap="true" ItemStyle-Width="400px" />
            </Columns>
            <RowStyle VerticalAlign="Top" />
        </asp:GridView>

        <!-- Back to Home Button, visible only to logged-in users -->
        <div style="text-align: left; margin-top: 20px;">
            <asp:Button ID="btnBackToHome" runat="server" Text="Back to Home" CssClass="btn btn-link" Style="color: gray;" OnClick="btnBackToHome_Click" Visible="false" />
        </div>
    </main>
</asp:Content>