<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Observations.aspx.cs" MasterPageFile="~/Site.Master" Inherits="CitizensScience.Observations" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>Observations</h2>
        <div style="margin-bottom: 10px;">
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </div>
        <div>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" Visible="false" CssClass="btn btn-secondary" />
        </div>
        <asp:GridView ID="ObservationsGridView" runat="server" AutoGenerateColumns="False" CellPadding="10" CellSpacing="10">
            <Columns>
                <asp:BoundField DataField="ObservationID" HeaderText="Observation ID" ItemStyle-Wrap="false" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" ItemStyle-Wrap="false" />
            </Columns>
            <RowStyle VerticalAlign="Top" />
        </asp:GridView>
        <asp:Button ID="AddObservationButton" runat="server" Text="Add Observation" OnClick="AddObservationButton_Click" />
    </main>
</asp:Content>