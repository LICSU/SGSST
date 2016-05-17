<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerPerfil.aspx.cs" Inherits="source_sistema_PerfilSocioDem_VerPerfil" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../../../Content/bootstrap.css" />
    <link rel="stylesheet" href="../../../Content/bootstrap-theme.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Perfil SocioDemográfico</title>
    <style>
        td, th {
            padding-right:50px !important;
        }
    </style>
</head>
<body>
    <div class="pager">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <!-- Inicio del Contenido -->
        <div class="col-lg-12">
            <h3 class="text-center">Consultar Perfil SocioDemografico</h3>
        </div>
        <p>&nbsp;</p>
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="col-lg-12 text-left">
                        Trabajador
                    </div>
                    <div class="col-lg-12 text-left">
                        <asp:DropDownList Enabled="false" runat="server" ID="ddlTrabajador" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="col-lg-12 text-left">
                        Lugar de Nacimiento
                    </div>
                    <div class="col-lg-12 text-left">
                        <asp:Label Enabled="false" runat="server" ID="txtLugar" CssClass="form-label" placeholder="Lugar de Nacimiento"></asp:Label>
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="col-lg-12 text-left">
                        Nivel de escolaridad
                    </div> 
                    <div class="col-lg-12 text-left">
                        <div class="col-lg-6"></div>
                        <div class="col-lg-6"></div>
                        <asp:Label Enabled="false" runat="server" placeholder="Nivel Escolar" ID="txtNivel" CssClass="form-label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Años aprobados en ese último nivel
                    </div>
                    <div class="col-lg-12">
                        <asp:Label Enabled="false" runat="server" ID="txtAnhosApro" CssClass="form-label" placeholder="Años Aprobados"></asp:Label>
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        ¡Es cabeza de familia!
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblCabeza" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Cantidad de hijos
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblHijos" CssClass="control-label"></asp:Label>
                    </div>
                </div>
            </div>         
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        ¿Reparte la responsabilidad económica de su familia?
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblResponsabilidad" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                       ¿Cuantos menores dependen económicamente de ud?
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblMenores" CssClass="control-label"></asp:Label>
                    </div>
                </div>
            </div> 
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        ¿Socialmente en que condición se encuentra usted?
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblCondicion" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        En caso de ser desplazado, ¿Cual fue el motivo del desplazamiento?
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblMotivo" CssClass="control-label"></asp:Label>
                    </div>
                </div>
            </div>         
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        La vivienda donde habita es:
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblVivienda" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Servicios públicos cuenta su vivienda
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblServicios" CssClass="control-label"></asp:Label>
                    </div>
                </div>
            </div>   
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Se encuentra afiliado al sistema de seguridad social en salud
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblSistema" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Régimen de Afiliación
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblRegimen" CssClass="control-label"></asp:Label>
                    </div>
                </div>
            </div>     
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Nivel de SISBEN
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblNivel" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        EPS
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="txtEps" CssClass="control-label" placeholder="EPS"></asp:Label>
                    </div>
                </div>
            </div>   
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Se encuentra afiliado al sistema de seguridad social en pensiones
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblPensiones" CssClass="control-label" placeholder="EPS"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Fondo
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="txtFondo" CssClass="form-control" placeholder="Fondo"></asp:Label>
                    </div>
                </div>
            </div>       
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Se encuentra afiliado a riesgos profesionales
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblRiesgos" CssClass="control-label" placeholder="EPS"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        ARP
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="txtARP" CssClass="form-control" placeholder="ARP"></asp:Label>
                    </div>
                </div>
            </div>   
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        Estrato que registran sus facturas de los servicios públicos de la vivienda donde reside
                    </div>
                    <div class="col-lg-12">
                        <asp:Label runat="server" ID="lblEstrato" CssClass="control-label" placeholder="EPS"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     
                </div>
            </div> 
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <asp:Button runat="server" Text="Volver" CssClass="btn btn-default" ID="btnVolver" OnClick="btnVolver_Click" />
            </div>                          
        </div>
        <div class="col-lg-1"></div>
        <!-- Fin del Contenido -->
    <!-- Msj Modal -->
    <div class="modal fade" id="Msjmodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Cerrar</span></button>
            <h4 class="modal-title"><label id="lblMsjTitle"></label></h4>
          </div>
          <div class="modal-body">
                <div class="row">
                    <div class="col-md-1">
                        <span id="icoModal" class="fa fa-times fa-2x text-danger"></span>
                    </div>
                    <div class="col-md-11">
                        <label id="lblMsjModal"></label>
                    </div>
                </div>
                <div class="clearfix"></div>      </div><!-- /modal-body -->
          <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
          </div>
        </div> 
      </div>
    </div>
    <!-- Fin Mensaje Modal-->
    <script src="../../../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../../Scripts/bootstrap.js" type="text/javascript"></script>    
    <script type="text/javascript">
        function MostrarMsjModal(message, title, ccsclas) {
            var vIcoModal = document.getElementById("icoModal");
            vIcoModal.className = ccsclas;
            $('#lblMsjTitle').html(title);
            $('#lblMsjModal').html(message);
            $('#Msjmodal').modal('show');
            return true;
        }
    </script>
    </form>
  </div>
</body>
</html>


