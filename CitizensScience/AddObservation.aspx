<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddObservation.aspx.cs" MasterPageFile="~/Site.Master"  Inherits="CitizensScience.AddObservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 10px;">
        <label for="txtNotes"><strong>Notes:</strong></label><br />
        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="10" Columns="50" Required="true" style="width: 100%;"></asp:TextBox>
    </div>
    <div style="margin-top: 10px;">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-secondary" />
    </div>
</asp:Content>
