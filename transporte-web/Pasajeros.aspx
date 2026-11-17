<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pasajeros.aspx.cs" Inherits="transporte_web.Pasajeros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row mt-3">
        <div class="col-1"></div>
        <div class="col-10">
            <div class="h5 my-3">Información de los pasajeros</div>
            <div class="row mt-3">
                <div class="col-8">

                    <!--Comienza el Repeater-->

                    <asp:Repeater ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <div class="card mb-3">
                                <div class="card-header">
                                    <div>Pasajero <%# Eval("OrdenPasajero") %></div>
                                    <!--Pasajero 1-->
                                </div>
                                <div class="card-body pt-1">
                                    <div class="row">
                                        <div class="mb-3">
                                            <div class="card-text">
                                                <div>Asiento <%# Eval("NumeroAsiento") %></div>
                                                <!--Asiento 10-->
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3">
                                                <label for="lblNombre" class="form-label">Nombre</label>
                                                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3">
                                                <label for="lblApellido" class="form-label">Apellido</label>
                                                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3">
                                                <label for="DocumentoTipo" class="form-label">Documento</label>
                                                <asp:DropDownList ID="ddlDocumentoTipo" CssClass="form-select" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-3">
                                            <div class="mb-3">
                                                <label for="lblNumeroDocumento" class="form-label">Número</label>
                                                <asp:TextBox ID="txtDocumentoNumero" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="mb-3">
                                                <label for="ddlNacionalidad" class="form-label">Nacionalidad</label>
                                                <asp:DropDownList ID="ddlNacionalidad" CssClass="form-select" runat="server">
                                                    <asp:ListItem>Argentina</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="mb-3">
                                                <label for="lblFechaNacimiento" class="form-label">Fecha de nacimiento</label>
                                                <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="mb-3">
                                                <label for="lblGenero" class="form-label">Género</label>
                                                <asp:DropDownList ID="ddlGenero" CssClass="form-select" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3">
                                                <label for="lblEmail" class="form-label">Email</label>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3">
                                                <label for="lblPrefijo" class="form-label">Prefijo</label>
                                                <asp:DropDownList ID="ddlPrefijoTel" CssClass="form-select" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-3">
                                            <div class="mb-3">
                                                <label for="lblTelefono" class="form-label">Teléfono</label>
                                                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6"></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>



                    <!--Termina el Repater-->

                </div>
                <div class="col-4">
                    <div class="card mb-3">
                        <div class="card-header">
                            Resumen
                        </div>
                        <div class="card-body">
                            <div class="row mb-1">
                                <!--Manejar col-auto y me-0 pe-0, ms-0 ps-0 -->
                                <div class="col-auto fw-bold pe-1">Ida:</div>
                                <div class="col-auto ps-0">
                                    <asp:Label ID="lblFechaSalida" runat="server" Text="Label"></asp:Label>
                                    <!--30 de octubre-->
                                </div>
                            </div>
                            <div class="row mb-1">

                                <div class="col-auto fw-bold pe-1">Sal.</div>
                                <div class="col-auto fw-bold ps-0">
                                    <div class="d-flex gap-1">
                                        <asp:Label ID="lblHoraSalida" runat="server" Text="Label"></asp:Label>
                                        <span>hs, </span>
                                        <asp:Label ID="lblCiudadOrigen" runat="server" />
                                    </div>
                                </div>
                                <!--11:00 hs, Buenos Aires-->
                            </div>
                            <div class="row mb-1">
                                <div class="col-auto pe-1">Lle.</div>
                                <div class="col-auto ps-0">
                                    <div class="d-flex gap-1">
                                        <asp:Label ID="lblHoraLlegada" runat="server" />
                                        <span>hs,</span>
                                        <asp:Label ID="lblCiudadDestino" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <!--Este bloque permanece oculto hasta que el pasajero no selecciona los asientos-->
                            <div id="divDetalle">
                                <div class="row">
                                    <div class="col-auto">
                                        <asp:Panel ID="pnlDetalleTipos" runat="server"></asp:Panel>
                                    </div>
                                    <!--<div class="col-auto">ARS 20.000</div>-->
                                    <div class="col-auto">
                                    </div>

                                </div>
                            </div>
                            <div class="row justify-content-between mb-1">
                                <div class="col-auto fw-bold">Total:</div>
                                <div class="col-auto fw-bold">
                                    <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="mt-3">
                                <asp:Button CssClass="btn btn-primary" ID="btnContinuar" runat="server"
                                    OnClick="btnContinuar_Click" Text="Continuar" />
                            </div>

                        </div>
                    </div>



                </div>
            </div>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
