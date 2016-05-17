<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualizarPerfil.aspx.cs" Inherits="source_sistema_PerfilSocioDem_ActualizarPerfil" %>

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
            <h3 class="text-center">Actualizar Perfil SocioDemografico</h3>
        </div>
        <p>&nbsp;</p>
        <div class="col-lg-1"></div>
        <div class="col-lg-10">
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="col-lg-12 text-left">
                        0) Seleccione los datos del Trabajador
                    </div>
                    <div class="col-lg-12 text-left">
                        <asp:DropDownList Enabled="false" runat="server" ID="ddlTrabajador" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="col-lg-12 text-left">
                        1) Lugar de Nacimiento
                    </div>
                    <div class="col-lg-12 text-left">
                        <asp:TextBox runat="server" ID="txtLugar" CssClass="form-control" placeholder="Lugar de Nacimiento"></asp:TextBox>
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <div class="col-lg-12 text-left">
                        2) Seleccione el Nivel de escolaridad
                    </div> 
                    <div class="col-lg-12 text-left">
                        <div class="col-lg-6"></div>
                        <div class="col-lg-6"></div>
                        <asp:RadioButtonList runat="server" ID="rblNivel" CssClass="radio-inline" RepeatColumns="2" AutoPostBack="true" OnSelectedIndexChanged="rblNivel_SelectedIndexChanged">
                            <asp:ListItem Text="Ninguna" Value="Ninguna"></asp:ListItem>
                            <asp:ListItem Text="Primaria Incompleta" Value="Primaria Incompleta"></asp:ListItem>
                            <asp:ListItem Text="Primaria Completa" Value="Primaria Completa"></asp:ListItem>
                            <asp:ListItem Text="Secundaria Incompleta" Value="Secundaria Incompleta"></asp:ListItem>
                            <asp:ListItem Text="Secundaria Completa" Value="Secundaria Completa"></asp:ListItem>
                            <asp:ListItem Text="Tecnica" Value="Texnica"></asp:ListItem>
                            <asp:ListItem Text="Universitaria" Value="Universitario"></asp:ListItem>
                            <asp:ListItem Text="Diplomado" Value="Diplomado"></asp:ListItem>
                            <asp:ListItem Text="Especialización" Value="Especializacion"></asp:ListItem>
                            <asp:ListItem Text="Maestría" Value="Maestria"></asp:ListItem>
                            <asp:ListItem Text="Doctorado" Value="Doctorado"></asp:ListItem>
                            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox Visible="false" runat="server" placeholder="Nivel Escolar" ID="txtNivel" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        3) Años aprobados en ese último nivel
                    </div>
                    <div class="col-lg-12">
                        <asp:TextBox runat="server" ID="txtAnhosApro" CssClass="form-control" placeholder="Años Aprobados"></asp:TextBox>
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        4) ¡Es usted cabeza de familia!
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rdlCabeza" CssClass="radio-inline">
                            <asp:ListItem Text="Si"  Value="SI"></asp:ListItem>
                            <asp:ListItem Text="No" Value="NO"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        5) ¿Cuantos hijos tiene?
                    </div>
                    <div class="col-lg-12">
                        <asp:DropDownList runat="server" ID="ddlHijos" CssClass="form-control">
                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>         
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        6) ¿Con quién reparte la responsabilidad económica de su familia?
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rblResponsabilidad" CssClass="radio-inline">
                            <asp:ListItem Text="Con Nadie" Value="Con Nadie"></asp:ListItem>
                            <asp:ListItem Text="Con el Conyugue" Value="Con el Conyugue"></asp:ListItem>
                            <asp:ListItem Text="Con Otros" Value="Con Otros"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        7) ¿Cuantos menores dependen económicamente de ud?
                    </div>
                    <div class="col-lg-12">
                        <asp:DropDownList runat="server" ID="ddlMenores" CssClass="form-control">
                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div> 
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        8) ¿Socialmente en que condición se encuentra usted?
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rblCondicion" CssClass="radio-inline">
                            <asp:ListItem Text="Desplazado" Value="Desplazado"></asp:ListItem>
                            <asp:ListItem Text="Desmovilizado" Value="Desmovilizado"></asp:ListItem>
                            <asp:ListItem Text="Ninguna" Value="Ninguna"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        9) En caso de ser desplazado, ¿Cual fue el motivo del desplazamiento?
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" Enabled="false" ID="rblMotivo" CssClass="radio-inline" AutoPostBack="true" OnSelectedIndexChanged="rblMotivo_SelectedIndexChanged">
                            <asp:ListItem Text="Violencia sociopolítica" Value="Violencia sociopolítica"></asp:ListItem>
                            <asp:ListItem Text="Desastre natural" Value="Desastre natural"></asp:ListItem>
                            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>         
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        10) La vivienda donde habita es:
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="dblVivienda" CssClass="radio-inline">
                            <asp:ListItem Text="Propia" Value="Propia"></asp:ListItem>
                            <asp:ListItem Text="Alquilada" Value="Alquilada"></asp:ListItem>
                            <asp:ListItem Text="De un Familiar" Value="De un Familiar"></asp:ListItem>
                            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        11) Seleccione con cuales servicios públicos cuenta su vivienda
                    </div>
                    <div class="col-lg-12">
                        <asp:CheckBoxList runat="server" ID="cblServicios" CssClass="checkbox-inline" RepeatColumns="2">
                            <asp:ListItem Text="Energia Electrica" Value="Energia Electrica"></asp:ListItem>
                            <asp:ListItem Text="Agua" Value="Agua"></asp:ListItem>
                            <asp:ListItem Text="Alcantarillado" Value="Alcantarillado"></asp:ListItem>
                            <asp:ListItem Text="Teléfono Fijo" Value="Telefono Fijo"></asp:ListItem>
                            <asp:ListItem Text="Teléfono Móvil" Value="Teléfono Móvil"></asp:ListItem>
                            <asp:ListItem Text="Gas" Value="Gas"></asp:ListItem>
                            <asp:ListItem Text="Internet" Value="Internet"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>   
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        12) Se encuentra afiliado al sistema de seguridad social en salud
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="dblSeguridad" CssClass="radio-inline">
                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                            <asp:ListItem Text="No (pasar a la pregunta 15)" Value="No"></asp:ListItem>
                            <asp:ListItem Text="No sabe" Value="No sabe"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        13) Régimen de Afiliación
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rblRegimen" CssClass="checkbox-inline">
                            <asp:ListItem Text="Contributivo (pasar a la pregunta 14)" Value="Contributivo"></asp:ListItem>
                            <asp:ListItem Text="Subsidiado" Value="Subsidiado"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>     
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        14) Nivel de SISBEN
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rblNivelSisben" CssClass="radio-inline" RepeatColumns="2">
                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="No sabe" Value="No sabe"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        15) ¿A qué EPS pertenece?
                    </div>
                    <div class="col-lg-12">
                        <asp:TextBox runat="server" ID="txtEps" CssClass="form-control" placeholder="EPS"></asp:TextBox>
                    </div>
                </div>
            </div>   
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        16) Se encuentra afiliado al sistema de seguridad social en pensiones
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rblPensiones" CssClass="radio-inline">
                            <asp:ListItem  Text="Si" Value="Si"></asp:ListItem>
                            <asp:ListItem Text="No (pasar a la pregunta 17)" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        17) ¿A qué fondo pertenece?
                    </div>
                    <div class="col-lg-12">
                        <asp:TextBox runat="server" ID="txtFondo" CssClass="form-control" placeholder="Fondo"></asp:TextBox>
                    </div>
                </div>
            </div>       
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        18) Se encuentra afiliado a riesgos profesionales
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rblRiesgos" CssClass="radio-inline">
                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                            <asp:ListItem Text="No (pasar a la pregunta 19)" Value="No"></asp:ListItem>
                            <asp:ListItem Text="No sabe" Value="No sabe"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        19) ¿A qué ARP pertenece?
                    </div>
                    <div class="col-lg-12">
                        <asp:TextBox runat="server" ID="txtARP" CssClass="form-control" placeholder="ARP"></asp:TextBox>
                    </div>
                </div>
            </div>   
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <div class="col-lg-6 text-left">
                     <div class="col-lg-12">
                        20) ¿Cual es el estrato que registran sus facturas de los servicios públicos de la vivienda donde reside?
                    </div>
                    <div class="col-lg-12">
                        <asp:RadioButtonList runat="server" ID="rblEstrato" CssClass="radio-inline" RepeatColumns="2">
                            <asp:ListItem Text="Estrato 1" Value="Estrato 1"></asp:ListItem>
                            <asp:ListItem Text="Estrato 2" Value="Estrato 2"></asp:ListItem>
                            <asp:ListItem Text="Estrato 3" Value="Estrato 3"></asp:ListItem>
                            <asp:ListItem Text="Estrato 4" Value="Estrato 4"></asp:ListItem>
                            <asp:ListItem Text="Estrato 5" Value="Estrato 5"></asp:ListItem>
                            <asp:ListItem Text="Estrato 6" Value="Estrato 6"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-lg-6 text-left">
                     
                </div>
            </div> 
            <p>&nbsp;</p>
            <div class="col-lg-12">
                <asp:Button runat="server" Text="Actualizar" CssClass="btn btn-default" ID="btnActualizar" OnClick="btnActualizar_Click" />
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


