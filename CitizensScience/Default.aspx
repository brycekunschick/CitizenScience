<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CitizensScience._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<main>
        <h2>Home</h2>
        <!-- Clickable Link to Institutions.aspx -->
        <a href="Institutions.aspx">Institutions</a>
        <br />
        <!-- Clickable Link to ResearchAreas.aspx -->
        <a href="ResearchAreas.aspx">Research Areas</a>
        <br />
        <!-- Clickable Link to Projects.aspx -->
        <a href="Projects.aspx">Projects</a>
    </main>

</asp:Content>
