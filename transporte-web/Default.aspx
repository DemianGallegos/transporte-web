<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="transporte_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center mt-5">
        <div class="row align-items-start">
            <div class="col">
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Origen</label>
                    <asp:DropDownList ID="ddlCiudadOrigen" CssClass="form-select" aria-label="Default select example" runat="server">
                        <asp:ListItem Text="Open this select menu"></asp:ListItem>
                        <asp:ListItem Text="One"></asp:ListItem>
                        <asp:ListItem Text="Two"></asp:ListItem>
                        <asp:ListItem Text="Three"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col">
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Destino</label>
                    <asp:DropDownList ID="ddlCiudadDestino" CssClass="form-select" aria-label="Default select example" runat="server">
                        <asp:ListItem Text="Open this select menu"></asp:ListItem>
                        <asp:ListItem Text="One"></asp:ListItem>
                        <asp:ListItem Text="Two"></asp:ListItem>
                        <asp:ListItem Text="Three"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col">
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Ida</label>
                    <asp:TextBox ID="txtFechaIda" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col">
                <!--  Este form-control va a estar habilidado o no Dependiendo del Radio rdtSoloIda, por ahora deshabilitdo de forma manual      -->
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label text-black-50">Vuelta</label>
                    <asp:TextBox ID="txtFechaVuelta" TextMode="Date" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="col">
                <div class="mb-3">
                    <label class="form-label">Pasajeros</label>
                    <div class="input-group">
                        <button type="button" id="btnMenos" runat="server"
                            class="btn btn-outline-secondary"
                            onclick="cambiarPasajero(-1)">
                            −
                        </button>
                        <input type="number" id="txtPasajeros" runat="server"
                            class="form-control text-center"
                            value="1" min="1" max="99" readonly />

                        <button type="button" id="btnMas" runat="server"
                            class="btn btn-outline-secondary"
                            onclick="cambiarPasajero(1)">
                            +
                        </button>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="mb-3">
                    <label class="form-label invisible">placeholder</label>
                    <div>
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary w-100" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row align-items-start text-start mt-1">
            <div class="col-auto">
                <div class="mb-3">
                    <div class="form-check">
                        <input class="form-check-input" runat="server" type="radio" name="TipoViaje" id="rbtSoloIda" checked>
                        <label class="form-check-label" for="rbtSoloIda">
                            Sólo ida
                        </label>
                    </div>
                </div>
            </div>
            <div class="col-auto">
                <div class="form-check">
                    <input class="form-check-input" runat="server" type="radio" name="TipoViaje" id="rbtIdaVuelta">
                    <label class="form-check-label" for="rbtIdaVuelta">
                        Ida y vuelta
                    </label>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
