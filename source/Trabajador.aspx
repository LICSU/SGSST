<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Trabajador.aspx.cs" Inherits="source_Trabajador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <link rel="stylesheet" href="../Content/bootstrap-theme.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Trabajador</title>
</head>
<body>
    <div class="pager">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="upRolSistema" runat="server">
            <ContentTemplate>
                <div class=""><h1 class="text-info text-center">Trabajador</h1></div>
                <div class="">
                    <div class="col-lg-3"></div>
                    <div class="col-lg-3"></div>
                    <div class="col-lg-3"></div>
                    <div class="col-lg-3">
                        <asp:Button Text="Agregar Trabajador" ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" CssClass="btn-default" />
                    </div>
                </div>
                <br />
                <asp:GridView ID="GridView1" CssClass="footable" 
                              runat="server" Width="90%" HorizontalAlign="Center"
                              OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                              DataKeyNames="id_trabajador"  PageSize="20"
                              onpageindexchanging="GridView1_PageIndexChanging"
                              EmptyDataText="No existen Trabajadores Agregados" >
                    <Columns>
                        <asp:TemplateField HeaderText="Cédula">
                            <ItemTemplate>
                                <asp:HiddenField ID="id_trabajador" runat="server" Visible="false" Value='<%# Eval("id_trabajador") %>' />
                                <asp:Label ID="cedula" runat="server" Enabled="false" Text='<%# Eval("cedula") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre(s)">
                            <ItemTemplate>
                                <asp:Label ID="nombres" runat="server" Enabled="false" Text='<%# Eval("primer_nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido(s)">
                            <ItemTemplate>
                                <asp:Label ID="apellidos" runat="server" Enabled="false" Text='<%# Eval("primer_apellido") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="ver"
                            ButtonType="Button" Text="Ver" HeaderText="Ver">
                            <ControlStyle></ControlStyle>
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="editar"
                            ButtonType="Button" Text="Editar" HeaderText="Editar">
                            <ControlStyle></ControlStyle>
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="eliminar"
                            ButtonType="Button" Text="Eliminar" HeaderText="Eliminar">
                            <ControlStyle></ControlStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- Delete Record Modal Starts here-->
        <div id="deleteModal"  class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button id="closeDelete" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="delModalLabel">Eliminar Trabajador</h3>
                    </div>
                    <asp:UpdatePanel ID="upDel" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                ¿Seguro desea eliminar este registro?
                                <asp:HiddenField ID="hdfTrabajadorIDDel" runat="server" />
                                                    
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn-default" OnClick="btnDelete_Click" />
                                <button class="btn-default" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!--Delete Record Modal Ends here -->
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

