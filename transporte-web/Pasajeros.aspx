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

                    <asp:Repeater ID="repRepetidor" runat="server">
                        <itemtemplate>
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
                                                    <asp:ListItem Text="DNI"></asp:ListItem>
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
                                                    <asp:ListItem>Seleccionar</asp:ListItem>
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
                                                <asp:DropDownList ID="ddlPrefijo" CssClass="form-select" runat="server">
                                                    <asp:ListItem>Arg(+541)</asp:ListItem>
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
                        </itemtemplate>
                    </asp:Repeater>



                    <!--Termina el Repater-->

                </div>
                <div class="col-4">
                    <h5>Aqui el Resumen</h5>
                    <div class="py-3">
                        <asp:Button ID="IdContinuar" CssClass="btn btn-primary" runat="server" 
                            OnClick="Continuar_Click" Text="Continuar" />
                    </div>

                </div>
            </div>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
