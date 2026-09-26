<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Asientos.aspx.cs" Inherits="transporte_web.Asientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="col-8">
            <asp:Table ID="tblAsientos" runat="server">
            </asp:Table>
        </div>
        <div class="col-2"></div>
    </div>

    
</asp:Content>
