<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Viajes.aspx.cs" Inherits="transporte_web.Viajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="col-10">
            <div class="h5 pt-3">Seleccioná tu pasaje de IDA</div>
            <div class="h5">Ciudad Ciudad. Provincia --> Ciudad Ciudad. Provincia</div>
            <!-- Botón Modificar -->
            <div class="h5">Lunes 10 de Octubre</div>
        </div>
        <!--<div class="col-1"></div>-->
    </div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col-6">
            <!--  Esto Carga con un asp: Repeater-->

            <asp:Repeater ID="repRepetidor" runat="server">
                <ItemTemplate>
                    <div class="card mb-3 mt-3">
                        <div class="card-body">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <div class="row">
                                        <div class="col-4">
                                            <div class="h5">Sale</div>
                                            <div><%#Eval("HoraSalida")%></div>
                                        </div>
                                        <div class="col-4">
                                            <div>TT hs TT min</div>
                                        </div>
                                        <div class="col-4">
                                            <div class="h5">LLega</div>
                                            <div>HoraLlegada</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="row align-items-center">
                                        <div class="col-6">
                                            <p>Precio desde</p>
                                            <p>$ xxxxx,xx</p>
                                        </div>
                                        <div class="col-6">
                                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Elegir" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <!--Termina el Repeater-->
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
