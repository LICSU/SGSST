<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditarTrabajador.aspx.cs" Inherits="source_EditarTrabajador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <link rel="stylesheet" href="../Content/bootstrap-theme.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Editar</title>
</head>
<body>
    <div class="pager">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="">
            <div class="col-lg-12">
                <div class="col-lg-2"></div>
                <div class="col-lg-8">
                    <div class="col-lg-12 text-center"><h1>Editar Trabajador</h1></div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12 text-left">
                            <asp:Label runat="server" ID="lblNombre" Text="Nombre(s)"></asp:Label>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtNombre1" CssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtNombre2" CssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12 text-left">
                            <asp:Label runat="server" ID="Label1" Text="Apellido(s)"></asp:Label>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtApellido1" CssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtApellido2" CssClass="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="">
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label3" Text="Cédula"></asp:Label>
                            </div>
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label4" Text="Fecha de Nacimiento"></asp:Label>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtCedula" CssClass="form-control" placeholder="Cédula"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtFechadeNacimiento" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12 text-left">
                            <asp:Label runat="server" ID="Label2" Text="Email"></asp:Label>
                        </div>
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="">
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label5" Text="Sexo"></asp:Label>
                            </div>
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label6" Text="Estado Civil"></asp:Label>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:DropDownList runat="server" ID="ddlSexo" CssClass="form-control">
                                    <asp:ListItem Text="Seleccione un Valor" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                    <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <asp:DropDownList runat="server" ID="ddlEdoCivil" CssClass="form-control">
                                    <asp:ListItem Text="Seleccione un Valor" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Soltero(a)" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Casado(a)" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="Divorciado(a)" Value="D"></asp:ListItem>
                                    <asp:ListItem Text="Viudo(a)" Value="V"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="">
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label7" Text="Télefono de Casa"></asp:Label>
                            </div>
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label8" Text="Teléfono Celular"></asp:Label>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtTelCasa" CssClass="form-control" placeholder="Casa"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtTelCelular" CssClass="form-control" placeholder="Celular"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="">
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label9" Text="EPS"></asp:Label>
                            </div>
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label10" Text="Foto"></asp:Label>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtEps" CssClass="form-control" placeholder="Casa"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <asp:FileUpload runat="server" ID="fuFoto"/>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="">
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label11" Text="Usuario"></asp:Label>
                            </div>
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label12" Text="Área"></asp:Label>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:DropDownList runat="server" ID="ddlUsuario" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <asp:DropDownList runat="server" ID="ddlArea" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="">
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label13" Text="Municipio"></asp:Label>
                            </div>
                            <div class="col-lg-6 text-left">
                                <asp:Label runat="server" ID="Label14" Text="Dirección"></asp:Label>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-lg-6">
                                <asp:DropDownList runat="server" ID="ddlMunicipio" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" Columns="3"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="">
                            <div class="col-lg-6 text-right">
                                <asp:Button runat="server" ID="btnAceptar" Text="Guardar" OnClick="btnAceptar_Click" CssClass="btn btn-default" ></asp:Button>
                            </div>
                            <div class="col-lg-6 text-left">
                                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-default" ></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2"></div>
            </div>
        </div>
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
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>    
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


