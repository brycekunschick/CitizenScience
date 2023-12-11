<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CitizensScience._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<main>
        <h2>Home</h2>
    <p>Click on a category below to continue.</p>
        <!-- Clickable Link to Institutions.aspx -->
        <a href="Institutions.aspx" class="btn btn-secondary" style="margin-bottom: 10px;">Institutions</a>
        <br />
        <!-- Clickable Link to ResearchAreas.aspx -->
        <a href="ResearchAreas.aspx" class="btn btn-secondary" style="margin-bottom: 10px;">Research Areas</a>
        <br />
        <!-- Clickable Link to Projects.aspx -->
        <a href="Projects.aspx" class="btn btn-secondary" style="margin-bottom: 10px;">Projects</a>
    </main>

</asp:Content>
