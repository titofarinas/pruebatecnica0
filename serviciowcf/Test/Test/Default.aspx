<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <style>
                .mderecho{
                        margin-right:10px;
                }

                .labelfrm{
                        font-size:30px;
                        font-weight:bold;
                }
        </style>

        <main>

                <div runat="server" id="divNewCustomer">                        
                        <asp:Label ID="lblFormCustomer" runat="server" Text="Label" CssClass="labelfrm"></asp:Label>
                        <br />

                        <asp:HiddenField ID="hf_cliente_id" runat="server" />
                        <asp:HiddenField ID="hf_direccion_id" runat="server" />
                        <asp:HiddenField ID="hf_direccion" runat="server" />


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
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" CssClass="btn btn-danger" />
                </div>






                <div runat="server" id="divCustomersList">

                        <h3>Clientes</h3>
                        <br />
                        <asp:Button ID="btnNew" runat="server" Text="Nuevo Cliente" OnClick="btnNew_Click" CssClass="btn btn-primary" />
                        <br />
                        <br />
                        <asp:GridView ID="gvCustomer" CssClass="table table-striped table-bordered table-hover col-xs-12 col-sm-12 col-lg-12" Width="100%" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                        <asp:BoundField DataField="primer_nombre" HeaderText="Primer nombre" />
                                        <asp:BoundField DataField="segundo_nombre" HeaderText="Segundo nombre" />
                                        <asp:BoundField DataField="primer_apellido" HeaderText="Primer apellido" />
                                        <asp:BoundField DataField="segundo_apellido" HeaderText="Segundo apellido" />
                                        <asp:BoundField DataField="numero_identificacion" HeaderText="Identificacion" />
                                        <asp:BoundField DataField="tipo_identificacion" HeaderText="Tipo identificacion" />
                                        <asp:TemplateField HeaderText="Acciones">
                                                <ItemTemplate>
                                                        <div style="display: flex;">

                                                                <asp:LinkButton ID="lnkUpdate" runat="server" Text="Editar" CssClass="btn btn-xs btn-warning mderecho" ToolTip="Editar cliente" CommandArgument='<%#Bind("cliente_id") %>' OnClick="lnkUpdate_Click" />

                                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Eliminar" CssClass="btn btn-xs btn-danger" ToolTip="Eliminar familiar" CommandArgument='<%#Bind("cliente_id") %>' OnClick="lnkDelete_Click" />


                                                        </div>
                                                </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                        No hay datos para mostrar
                                </EmptyDataTemplate>
                        </asp:GridView>
                </div>



        </main>

</asp:Content>
