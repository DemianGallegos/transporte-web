<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Asientos.aspx.cs" Inherits="transporte_web.Asientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .plano-piso {
            background-color: #f0f0f0;
            border: 0.15vw solid #cccccc;
            border-radius: 0.6vw;
            padding: 0.8vw;
            border-collapse: separate;
            border-spacing: 0.3vw;
        }

        .asiento-libre {
            width: 2vw;
            height: 2vw;
            min-width: 2vw;
            max-width: 2vw;
            background-color: #FFFFFF;
            border: 1px solid #333;
            text-align: center;
            vertical-align: middle;
            cursor: pointer;
            font-size: 0.7vw;
        }

            .asiento-libre:hover {
                background-color: #8abcff;
            }

        .asiento-cama {
            width: 2vw;
            height: 2vw;
            min-width: 2vw;
            max-width: 2vw;
            background-color: #ffffff;
            border: 1px solid #6610f2;
            text-align: center;
            vertical-align: middle;
            cursor: pointer;
            font-size: 0.7vw;
            color: #6610f2;
        }

            .asiento-cama:hover {
                background-color: #b99af0 /* violeta muy claro al hover */
            }


        .asiento-seleccionado {
            background-color: #2979ff;
            border: 1px solid #3a006f;
            width: 2vw;
            height: 2vw;
            text-align: center;
            vertical-align: middle;
            cursor: pointer;
            font-size: 0.7vw;
            color: white;
        }

        .asiento-ocupado {
            width: 2vw;
            height: 2vw;
            min-width: 2vw;
            max-width: 2vw;
            background-color: #999999;
            border: 1px solid #666666;
            text-align: center;
            vertical-align: middle;
            font-size: 0.7vw;
        }

        .pasillo {
            width: 2vw;
            height: 2vw;
            min-width: 2vw;
            max-width: 2vw;
            background-color: transparent;
            border: none;
        }

        /* Celdas especiales (escalera, wc, bar) */
        .celda-especial {
            width: 2vw;
            height: 2vw;
            min-width: 2vw;
            max-width: 2vw;
            background-color: #999999;
            border: 1px solid #117a8b;
            text-align: center;
            vertical-align: middle;
            color: white;
            font-size: 0.7vw;
        }
    </style>



    <script>
        var cantidadPasajeros = <%= Convert.ToInt32(Session["cantidadPasajeros"]) %>;
        var precioBase =  <%= precio.ToString(System.Globalization.CultureInfo.InvariantCulture) %>;

        function seleccionarAsiento(btn, idAsiento) {

            var hdn = document.getElementById('<%= hdnIdAsiento.ClientID %>');

            // Si ya está seleccionado, deseleccionarlo
            if (btn.classList.contains('asiento-seleccionado')) {

                btn.classList.remove('asiento-seleccionado');

                // Recuperar la clase original: cama o asiento común
                btn.classList.add(btn.dataset.claseOriginal);

            } else {

                var seleccionados = document.querySelectorAll(
                    '.plano-piso .asiento-seleccionado'
                ).length;

                // Controlar la cantidad de pasajeros
                if (seleccionados >= cantidadPasajeros) {
                    alert('Ya seleccionaste todos los asientos necesarios.');
                    return;
                }

                // Recordar el estilo original antes de seleccionarlo
                if (!btn.dataset.claseOriginal) {
                    btn.dataset.claseOriginal =
                        btn.classList.contains('asiento-cama')
                            ? 'asiento-cama'
                            : 'asiento-libre';
                }

                btn.classList.remove('asiento-libre', 'asiento-cama');
                btn.classList.add('asiento-seleccionado');
            }

            // Obtener todos los asientos seleccionados
            var asientosSeleccionados = document.querySelectorAll(
                '.plano-piso .asiento-seleccionado'
            );

            var tipos = {};

            asientosSeleccionados.forEach(function (asiento) {
                var tipo = asiento.dataset.tipoAsiento;
                tipos[tipo] = (tipos[tipo] || 0) + 1;
            });

            var detalleTipos = Object.entries(tipos)
                .map(([tipo, cantidad]) => cantidad + " x " + tipo)
                .join(", ");


            var ids = [];
            var total = 0;

            asientosSeleccionados.forEach(function (asiento) {

                // Guardar el ID del asiento
                if (asiento.dataset.idAsiento) {
                    ids.push(asiento.dataset.idAsiento);
                }

                // Calcular el precio de este asiento
                var incremento = parseFloat(
                    asiento.dataset.incremento
                );

                if (isNaN(incremento)) {
                    incremento = 1;
                }

                total += precioBase * incremento;
            });

            // Guardar los IDs para continuar a Pasajes.aspx
            hdn.value = ids.join(',');

            // Actualizar la cantidad seleccionada
            document.getElementById(
            '<%= lblCantPasajeros.ClientID %>'
            ).innerText = ids.length;

            // Mostrar el detalle solamente si hay asientos seleccionados
            document.getElementById('divDetalle').style.display =
                ids.length > 0 ? 'block' : 'none';

            // Actualizar el total del Resumen
            document.getElementById(
                '<%= lblSubtotal.ClientID %>'
            ).innerText = 'AR$ ' + total.toLocaleString('es-AR', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            });
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:HiddenField ID="hdnIdAsiento" runat="server" />

    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="col-9">
            <div class="h5 my-3">Seleccioná tu asiento</div>
            <div class="row align-items-start text-start">
                <div class="col-auto">
                    <div class="h6 my-3 text-muted">Piso Superior</div>
                    <asp:Table ID="tblPisoSuperior" runat="server">
                    </asp:Table>
                </div>
                <div class="col-auto">
                    <div class="h6 my-3 text-muted">Piso Inferior</div>
                    <asp:Table ID="tblPisoInferior" runat="server">
                    </asp:Table>
                </div>
                <div class="col-auto ms-5" style="margin-top: 3rem;">

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
                            <div id="divDetalle" style="display: none;">
                                <div class="row">
                                    <div class="col-auto">            
                                        <asp:Label ID="lblCantPasajeros" runat="server" Text="Label"></asp:Label>
                                        <span>Pasajero/s</span>
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

        <div class="col-1">
        </div>
    </div>


</asp:Content>
