<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <main>
                <h3>Nuevo Cliente</h3>
                <br />


                <div class="form-group">
                        <label>Primer nombre</label>
                        <asp:TextBox ID="txtNom1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                        <label>Segundo nombre</label>
                        <asp:TextBox ID="txtNom2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                        <label>Primer apellido</label>
                        <asp:TextBox ID="txtApe1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                        <label>Segundo apellido</label>
                        <asp:TextBox ID="txtApe2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                        <label>identificacion</label>
                        <asp:TextBox ID="txtIdent" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                        <label>Tipo identificacion</label>
                        <asp:TextBox ID="txtIdentTpo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

               
                <div class="form-group">
                        <label>Direccion</label>
                        <asp:TextBox ID="txtDir" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
                <br />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />



        </main>

</asp:Content>
