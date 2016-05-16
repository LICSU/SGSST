<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index_MapaRiesgo.aspx.cs" Inherits="source_sistema_MapaRiesgos_index_MapaRiesgo" %>

<%@ Register Src="~/source/WebUserControl/ucHeader.ascx" TagPrefix="uch" TagName="ucHeader" %>
<%@ Register Src="~/source/WebUserControl/ucFooter.ascx" TagPrefix="ucf" TagName="ucFooter" %>
<%@ Register Src="~/source/WebUserControl/ucMsjModal.ascx" TagPrefix="ucm" TagName="ucMsjModal" %>

<uch:ucHeader runat="server" ID="ucHeader" />

<form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="upRolSistema" runat="server">
            <ContentTemplate>
            
                <div class="row"><h1 class="text-info text-center">Mapas</h1></div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <asp:TextBox ID="searchPlan" runat="server" class="col-md-8" PlaceHolder="Ingrese el plan a buscar"></asp:TextBox>
                        <asp:Button ID="btnSearchPlan" runat="server" Text="Buscar" class="col-md-4" CssClass="btn-default"  OnClick="buscarPlan"/>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                
            <br/>
            <asp:GridView 
                ID="GridView1"  CssClass="footable"  runat="server" Width="90%" HorizontalAlign="Center"
                OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="id_plan_mapa"  
                PageSize="20" onpageindexchanging="GridView1_PageIndexChanging" EmptyDataText="No existen Planes Agregados" OnRowCreated="GridView1_RowCreated" 
                >
                
                <Columns>
                    <asp:TemplateField HeaderText="Id Mapa" visible="false">
                        <ItemTemplate><asp:Label ID="id_plan_mapa" runat="server" Enabled="false" Text='<%# Eval("id_plan_mapa") %>' /></ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre del Mapa">
                        <ItemTemplate><asp:Label ID="nombre" runat="server" Enabled="false" Text='<%# Eval("nombre") %>' /></ItemTemplate>
                    </asp:TemplateField>   
                    
                    <asp:TemplateField HeaderText="Nombre del Archivo">
                        <ItemTemplate><asp:Label ID="ruta" runat="server" Enabled="false" Text='<%# Eval("ruta") %>' /></ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Fecha de Creación">
                        <ItemTemplate><asp:Label ID="fecha_creacion" runat="server" Enabled="false" Text='<%# Eval("fecha_creacion") %>' /></ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="Empresa" visible="false">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="id_empresa" Visible="false" Value='<%# Eval("id_empresa") %>' />
                                <asp:Label ID="empresa" runat="server" Enabled="false" Text='<%# Eval("id_empresa") %>' />
                            </ItemTemplate>
                    </asp:TemplateField>  

                    <asp:TemplateField HeaderText="Descargar Mapa" >
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~//source//archivos//planes//"+Eval("ruta") %>' Target="_blank">Descargar</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    
                    <asp:ButtonField HeaderText="Acciones" CommandName="editar" ButtonType="Button" Text="Editar">
                        <ControlStyle></ControlStyle>
                    </asp:ButtonField>
                    
                    <asp:ButtonField CommandName="eliminar" ButtonType="Button" Text="Eliminar" >
                        <ControlStyle></ControlStyle>
                    </asp:ButtonField>
                </Columns>

            </asp:GridView>
            
            <div class="row">
                <div class="col-lg-3">
                    <ul>
                        <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="MostrarModalAgregar">Agregar</asp:LinkButton></li>
                        <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="MostrarModalImprimir">Imprimir Lista</asp:LinkButton></li>
                    </ul>
                </div>
            </div>
        </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    
        <!-- Add Modal Starts here -->
        <div id="addModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                
                    <div class="modal-header">
                        <button id="closeAdd" type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        <h3 id="H1">Agregar Mapa</h3>
                    </div>
                
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>                        
                            <div class="modal-body">   
                                                               
                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Archivo: </label>
                                        <div class="col-xs-6">
                                            <asp:FileUpload ID="flpArchivo" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:FileUpload>
                                        </div>
                                    </div>                                          
                                </div>

                                <br/>                                                   
                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Nombre: </label>
                                        <div class="col-xs-6">
                                            <asp:TextBox ID="txtNombre" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                         </div>
                                    </div>                                          
                                </div>
                                <br/>
                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Fecha de Creación: </label>
                                        <div class="col-xs-6">
                                            <asp:TextBox ID="TextFechaCreacion" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>                                           

                                        </div>
                                    </div>                                          
                                </div>
                                <br />
                                <div class="row">
                                       <div class="form-group col-lg-12">
                                            <label class="col-xs-4 control-label">Empresa: </label>
                                            <div class="col-xs-6">
                                                <asp:DropDownList ID="ddlEmpresa" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:DropDownList>                                                                
                                            </div>
                                        </div>                                          
                                </div>
                            </div>

                            <div class="modal-footer">
                                    <asp:Label ID="Label3" Visible="false" runat="server"></asp:Label>
                                    <asp:Button ID="btnAdd" runat="server" Text="Agregar" CssClass="btn-default"  OnClick="InsertarFila"/>
                                    <button class="btn-default" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnAdd" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <!-- Add Modal Ends here -->        
    
        <!-- Edit Modal Starts here -->
        <div id="editModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button id="closeEdit" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="H2">Editar Mapa</h3>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">

                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Archivo: </label>
                                        <div class="col-xs-6">
                                            <asp:FileUpload ID="flpArchivoEdit" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:FileUpload>
                                        </div>
                                    </div>                                          
                                </div>
                                <br/>

                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <asp:HiddenField ID="hdfPlanID" runat="server" />
                                        <label class="col-xs-4 control-label">Nombre: </label>
                                        <div class="col-xs-6">
                                            <asp:TextBox ID="txtNombreEdit" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                         </div>
                                    </div>                                          
                                </div>
                                <br/>

                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Fecha de Creación: </label>
                                        <div class="col-xs-6">
                                            <asp:TextBox ID="txtFechaEdit" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>                                           

                                        </div>
                                    </div>                                          
                                </div>
                                <br/>

                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Empresa: </label>
                                        <div class="col-xs-6">
                                            <asp:DropDownList ID="ddlEmpresaEdit" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:DropDownList>                                                                
                                        </div>
                                    </div>                                          
                                </div>                                          
                             </div>
                            <div class="modal-footer">
                                <asp:Label ID="Label1" Visible="false" runat="server"></asp:Label>
                                <asp:Button ID="btnEditar" runat="server" Text="Guardar" CssClass="btn-default"  OnClick="btnEditar_Click"/>
                                <button class="btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnEditar" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- Edit Modal Ends here -->
        
        <!-- Delete Record Modal Starts here-->
        <div id="deleteModal"  class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button id="closeDelete" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="delModalLabel">Eliminar Mapa</h3>
                    </div>
                    <asp:UpdatePanel ID="upDel" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                ¿Seguro desea eliminar este registro?
                                <asp:HiddenField ID="hdfPlanIDDel" runat="server" />
                                                    
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

        <!-- Print Modal Starts here -->
        <div id="printModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                
                    <div class="modal-header">
                        <button id="closePrint" type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        <h3 id="H1">Imprimir Lista</h3>
                    </div>
                
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>                        
                            <div class="modal-body">   
                                                               
                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Imprimir en Word: </label>
                                        <div class="col-xs-6">
                                            <asp:Button ID="btnPrintWord" runat="server" Text="Imprimir" OnClick="btnExportWord_Click"></asp:Button>
                                        </div>
                                    </div>                                          
                                </div>
                                <br/>                                                   
                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Imprimir en Excel: </label>
                                        <div class="col-xs-6">
                                            <asp:Button ID="btnPrintExcel" runat="server" Text="Imprimir" OnClick="btnExportExcel_Click"></asp:Button>
                                        </div>
                                    </div>                                          
                                </div>
                                <br/>

                                <div class="row">
                                    <div class="form-group col-lg-12">
                                        <label class="col-xs-4 control-label">Imprimir en PDF: </label>
                                        <div class="col-xs-6">
                                            <asp:Button ID="btnPrintPdf" runat="server" Text="Imprimir" OnClick="btnExportPDF_Click"></asp:Button>
                                        </div>
                                    </div>                                          
                                </div>
                                <br />
                            </div>

                                <div class="modal-footer">
                                    <asp:Label ID="Label2" Visible="false" runat="server"></asp:Label>
                                    <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn-default"  OnClick="InsertarFila"/>
                                    <button class="btn-default" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnPrintWord"/>
                                <asp:PostBackTrigger ControlID="btnPrintExcel"/>
                                <asp:PostBackTrigger ControlID="btnPrintPdf"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        <!-- Print Modal Ends here --> 

        <!-- Msj Modal -->
        <ucm:ucMsjModal runat="server" ID="ucMsjModal" />
        <!-- Fin Mensaje Modal-->
    
</form>

<ucf:ucFooter runat="server" ID="ucFooter" />
