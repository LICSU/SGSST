<%@ Page Title="" Language="C#" MasterPageFile="~/source/plantillas/menu.master" AutoEventWireup="true" CodeFile="nuevo_plan.aspx.cs" Inherits="source_sistema_Plan_nuevo_plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="id_plan_mapa" DataSourceID="DataPlanes" OnItemInserting="FormView1_ItemInserting" >

    <EditItemTemplate>
        id_plan_mapa:
        <asp:Label ID="id_plan_mapaLabel1" runat="server" Text='<%# Eval("id_plan_mapa") %>' />
        <br />
        nombre:
        <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
        <br />
        ruta:
        <asp:TextBox ID="rutaTextBox" runat="server" Text='<%# Bind("ruta") %>' />
        <br />
        fecha_creacion:
        <asp:TextBox ID="fecha_creacionTextBox" runat="server" Text='<%# Bind("fecha_creacion") %>' />
        <br />
        id_empresa:
        <asp:TextBox ID="id_empresaTextBox" runat="server" Text='<%# Bind("id_empresa") %>' />
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
    </EditItemTemplate>
    <InsertItemTemplate>
        <asp:FileUpload ID="FileUpload1" runat="server" /> 
        nombre:
        <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
        <br />
        ruta:
        <asp:TextBox ID="rutaTextBox" runat="server" Text='<%# Bind("ruta") %>' />
        <br />
        fecha_creacion:
        <asp:TextBox ID="fecha_creacionTextBox" runat="server" Text='<%# Bind("fecha_creacion") %>' />
        <br />
        id_empresa:
        <asp:TextBox ID="id_empresaTextBox" runat="server" Text='<%# Bind("id_empresa") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert"/>
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
    </InsertItemTemplate>
    <ItemTemplate>
        id_plan_mapa:
        <asp:Label ID="id_plan_mapaLabel" runat="server" Text='<%# Eval("id_plan_mapa") %>' />
        <br />
        nombre:
        <asp:Label ID="nombreLabel" runat="server" Text='<%# Bind("nombre") %>' />
        <br />
        ruta:
        <asp:Label ID="rutaLabel" runat="server" Text='<%# Bind("ruta") %>' />
        <br />
        fecha_creacion:
        <asp:Label ID="fecha_creacionLabel" runat="server" Text='<%# Bind("fecha_creacion") %>' />
        <br />
        id_empresa:
        <asp:Label ID="id_empresaLabel" runat="server" Text='<%# Bind("id_empresa") %>' />
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
    </ItemTemplate>
    </asp:FormView>

    <asp:SqlDataSource ID="DataPlanes" runat="server" ConnectionString="<%$ ConnectionStrings:sgsstConnectionString %>" DeleteCommand="DELETE FROM [plan_mapa] WHERE [id_plan_mapa] = @id_plan_mapa" InsertCommand="INSERT INTO [plan_mapa] ([nombre], [ruta], [fecha_creacion], [id_empresa]) VALUES (@nombre, @ruta, @fecha_creacion, @id_empresa)" SelectCommand="SELECT * FROM [plan_mapa]" UpdateCommand="UPDATE [plan_mapa] SET [nombre] = @nombre, [ruta] = @ruta, [fecha_creacion] = @fecha_creacion, [id_empresa] = @id_empresa WHERE [id_plan_mapa] = @id_plan_mapa">
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

    </asp:Content>

