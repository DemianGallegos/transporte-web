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
                background-color: #6eaaff;
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
        function seleccionarAsiento(btn, idAsiento) {
           
            btn.className = 'asiento-seleccionado';

            document.getElementById('<%= hdnIdAsiento.ClientID %>').value = idAsiento;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:HiddenField ID="hdnCantidadPasajeros" runat="server" />
    <asp:HiddenField ID="hdnIdAsiento" runat="server" />

    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="col-8">
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
            </div>

            <!--   Agregar un botón "CONTINUAR" con la logica mas importante
                   El btn del Asiento solo tendria la función de guardar el id y cambiar de color
                   La consulta a la DB y la redireccion a la otra pagina iría en el btnContiuar
            -->

        </div>
        <div class="col-2"></div>
    </div>


</asp:Content>
