<%@ Page Title="" Language="C#" MasterPageFile="~/source/plantillas/menu.master" AutoEventWireup="true" CodeFile="index_plan.aspx.cs" Inherits="source_sistema_Plan_index_plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_plan_mapa" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id_plan_mapa" HeaderText="id_plan_mapa" InsertVisible="False" ReadOnly="True" SortExpression="id_plan_mapa" />
            <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
            <asp:BoundField DataField="ruta" HeaderText="ruta" SortExpression="ruta" />
            <asp:BoundField DataField="fecha_creacion" HeaderText="fecha_creacion" SortExpression="fecha_creacion" />
            <asp:BoundField DataField="id_empresa" HeaderText="id_empresa" SortExpression="id_empresa" />
            <asp:CommandField HeaderText="Acciones" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sgsstConnectionString %>" DeleteCommand="DELETE FROM [plan_mapa] WHERE [id_plan_mapa] = @id_plan_mapa" InsertCommand="INSERT INTO [plan_mapa] ([nombre], [ruta], [fecha_creacion], [id_empresa]) VALUES (@nombre, @ruta, @fecha_creacion, @id_empresa)" SelectCommand="SELECT * FROM [plan_mapa]" UpdateCommand="UPDATE [plan_mapa] SET [nombre] = @nombre, [ruta] = @ruta, [fecha_creacion] = @fecha_creacion, [id_empresa] = @id_empresa WHERE [id_plan_mapa] = @id_plan_mapa">
        <DeleteParameters>
            <asp:Parameter Name="id_plan_mapa" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="ruta" Type="String" />
            <asp:Parameter DbType="Date" Name="fecha_creacion" />
            <asp:Parameter Name="id_empresa" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="ruta" Type="String" />
            <asp:Parameter DbType="Date" Name="fecha_creacion" />
            <asp:Parameter Name="id_empresa" Type="Int32" />
            <asp:Parameter Name="id_plan_mapa" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <ul>
        <li> <a href="nuevo_plan.aspx">Nuevo</a></li>
        <li> <a href="#">Carga Masiva</a></li>
        <li> <a href="#">Imprimir Lista</a></li>
        <li> <a href="#">Descargar Lista</a></li>
    </ul>
</asp:Content>

