<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="transporte_web.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .contenedor-pago {
            min-height: calc(100vh - 56px);
        }
    </style>
    <div class="d-flex justify-content-center align-items-center contenedor-pago">
        <div class="card shadow" style="width: 25rem;">
            <div class="card-body text-center">
                <h5 class="card-title">Pago del pasaje</h5>
                <p class="card-text">Confirmá tu compra para finalizar.</p>
                <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar compra"
                    OnClick="btnConfirmarCompra_Click"
                    CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>

