<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Viajes.aspx.cs" Inherits="transporte_web.Viajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="col-10">
            <div class="h5 mt-3">Seleccioná tu pasaje de IDA</div>
            <ul class="list-inline">
                <li class="list-inline-item">
                    <asp:Label ID="lblCiudadOrigen" runat="server" />
                </li>
                <li class="list-inline-item">→</li>
                <li class="list-inline-item">
                    <asp:Label ID="lblCiudadDestino" runat="server" />
                </li>
                <li class="list-inline-item ms-2">
                    <asp:Label ID="lblFechaSalida" runat="server" />
                </li>
            </ul>
            <!-- Botón Modificar -->
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
                                            <div class="h6 text-body-secondary">Duración</div>
                                            <div class="small text-body-secondary"><%#formatearDuracion(Eval("Duracion"))%></div>
                                        </div>
                                        <div class="col-4">
                                            <div class="h6">Sale</div>
                                            <div><%#((TimeSpan)Eval("HoraSalida")).ToString(@"hh\:mm")%></div>
                                        </div>

                                        <div class="col-4">
                                            <div class="h6">LLega</div>
                                            <div><%# calcularHoraLlegada(Eval("HoraSalida"), Eval("Duracion")) %></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="row align-items-center">
                                        <div class="col-6">
                                            <h6>Precio</h6>
                                            <div><%#Eval("Precio")%></div>
                                        </div>
                                        <div class="col-6">
                                            <asp:Button ID="btnElegir" runat="server" CommandName="Elegir"
                                                CommandArgument='<%# Eval("Id") %>' OnCommand="btnElegir_Command"
                                                CssClass="btn btn-primary" Text="Elegir" />
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
