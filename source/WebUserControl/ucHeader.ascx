<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucHeader.ascx.cs" Inherits="source_WebUserControl_ucHeader" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <link rel="stylesheet" href="../../Content/bootstrap.min.css" />
        <link rel="stylesheet" href="../../Content/bootstrap-theme.min.css" />
        <script src="../../../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
        <script src="../../../Scripts/bootstrap.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            function MostrarMsjModal(message, title, ccsclas)
            {
                var vIcoModal = document.getElementById("icoModal");
                vIcoModal.className = ccsclas;
                $('#lblMsjTitle').html(title);
                $('#lblMsjModal').html(message);
                $('#Msjmodal').modal('show');
                return true;
            }
        </script>
        <title>SGSST</title>
</head>
    <body>
    <div>
        <h1>SGSST Sistema de Gestion y Seguridad en el Trabajo</h1>
        <ul>
            <li> <a href="#">Gestionar Datos</a></li>
            <li> <a href="#">Matriz Legal</a></li>
            <li> <a href="#">Enfermedades ocupacionales</a></li>
            <li> <a href="#">Documentos</a></li>
            <li> <a href="#">Obligaciones</a></li>
            <li> <a href="#">Alarmas</a></li>
            <li> <a href="#">Indicadores</a></li>
            <li> <a href="../Plan/index_plan.aspx">Planes</a></li>
            <li> <a href="#">Home</a></li>
            <li> <a href="../MapaRiesgos/index_MapaRiesgo.aspx">Riesgos</a></li>
            <li> <a href="#">Accidentes Laborales</a></li>
            <li> <a href="#">Incidentes Laborales</a></li>
            <li> <a href="#">Mapa de Riesgos</a></li>
            <li> <a href="#">Descripción Sociodemigráfica</a></li>
            <li> <a href="#">Examenes Laborales</a></li>
            <li> <a href="#">Gestiones Laborales</a></li>
            <li> <a href="#">Vigilancia Epidemiologica</a></li>
            <li> <a href="#">Cerrar Sesión</a></li>
        </ul> 
    </div>
    
