﻿<%@ Page Title="Restaurantes" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Restaurante.aspx.cs" Inherits="BackOffice.Seccion.Restaurant.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
Restaurantes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Restaurantes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
   <div>
      <ol class="breadcrumb">
          <li>
              <a href="~/Default.aspx" runat="server">Inicio</a>
          </li>
          <li class="active">
             Restaurante
          </li>
      </ol>
  </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
<div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Restaurantes</h3>
                                <a data-toggle="modal" data-target="#agregar" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="example" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Nombre</th>
                                                <th>Direccion</th>
                                                <th>Tipo</th>
                                                <th>Estado</th>
                                                <th class="no-sort">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>El Cine</td>
                                                <td>Calle Comercio, entre Sucre y Bellavista - El Hatillo</td>
                                                <td>Japonesa</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>
                                            <tr>
                                                
                                                <td>St. Honoré</td>
                                                <td>Transversal 1 - Los Palos Grandes</td>
                                                <td>Cafetería, pastelería</td>
                                                <td class="text-center"><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>                                           
                                            <tr>
                                                
                                                <td>Ávila Burger</td>
                                                <td>4ta Avenida con 6ta Transversal. Cuadra Gastronomica - Los Palos Grandes</td>
                                                <td>Americana</td>
                                                <td class="text-center"><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>
                                                <td class="text-center"><a data-toggle="modal" data-target="#consultar"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modificar"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#modificar"></a><a><i class="fa fa-check" aria-hidden="true"></i></a><a><i class="fa fa-times"></i></a></td>
                                            </tr>
                                        </tbody>
                                    </table>       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            <!-- /.container-fluid -->
            <!-- Modal Consultar-->
           <div class="modal fade" id="consultar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Restaurante</h4>
                        </div>
                <div class="modal-body">
                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                           <img class="img-thumbnail img-responsive img-center" src="http://placehold.it/150x150" alt=""/>
                        </div>
                    </div>

                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="TextBox10" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:TextBox ID="TextBox16" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
          </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:TextBox ID="TextBox17" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="TextBox12" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                            <asp:TextBox ID="TextBox18" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Direccion</label>
                            <asp:TextBox ID="TextBox13" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                            <asp:TextBox ID="TextBox19" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                            <asp:TextBox ID="TextBox14" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Cierre</label>
                            <asp:TextBox ID="TextBox15" CssClass="form-control" readonly="true" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
            <div class="table-responsive">
               <table id="example" class="table table-bordered table-hover table-striped">
               <tbody>
               <td>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3923.9777080448903!2d-66.82724398578782!3d10.423343468463056!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8c2af793ef1430e9%3A0xa4f83f07bee2d359!2sEl+Cine+Restaurant!5e0!3m2!1ses!2sve!4v1462116729521" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
                </td>
                </tbody>
                </table>
            </div>
            </div>
            </div>        
          
                        <div class="modal-footer">
                            <asp:Button id="Button6" Text="Cerrar" CssClass="btn btn-danger" runat="server"/>
                        </div>
 
            </div>
            </div>
            </div>

      
                <!-- Modal Modificar-->
                <div class="modal fade" id="modificar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Restaurante</h4>
                        </div>
                <div class="modal-body">
                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ej. El Budare" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:DropDownList id="DropDownList3" CssClass="form-control" AutoPostBack="True" runat="server">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Venezolana</asp:ListItem>
                                <asp:ListItem>Americana</asp:ListItem>
                                <asp:ListItem>Japonesa</asp:ListItem>
                                <asp:ListItem>China</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:DropDownList id="DropDownList4" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="ej. 965831535-1" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                                <asp:DropDownList id="DropDownList5" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>VEF</asp:ListItem>
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Direccion</label>
                            <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="ej. Calle Madrid con Av. Ppal" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                        <asp:DropDownList id="DropDownList6" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>Altamira</asp:ListItem>
                            <asp:ListItem>Las Mercedes</asp:ListItem>
                            <asp:ListItem>Macaracuay</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Longitud</label>
                            <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Latitud</label>
                            <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Dias de apertura</label>
                            <label>
                            <label class="text-left">
                                    <asp:CheckBox id="Checkbox" runat="server" value="Lunes" text="Lun"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox1" runat="server" value="Martes" text="Mar"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox2" runat="server" value="Miercoles" text="Mie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Checkbox3" runat="server" value="Jueves" text="Jue"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox4" runat="server" value="Viernes" text="Vie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox5" runat="server" value="Sabado" text="Sab"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox6" runat="server" value="Domingo" text="Dom"/>
                            </label>
                            </label>
                            </div>    
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                                <asp:DropDownList id="DropDownList7" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Apertura</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Cierre</label>
                                <asp:DropDownList id="DropDownList12" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Cierre</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                              <label for="ejemplo_archivo_1">Imagen del Restaurante</label>
                              <input type="file" id="ejemplo_archivo_2"/>
                              <p class="help-block">Imagen .jpg o .png</p>
                         </div>
                </div>
             </div>            
          </div>
                        <div class="modal-footer">
                            <asp:Button id="Button3" Text="Modificar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button4" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>

                    </div>
                    </div>
                    </div>
        <!-- /Modal Modificar-->

            <!-- Modal Agregar-->
            <div class="modal fade" id="agregar" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Restaurante</h4>
                        </div>
                <div class="modal-body">
                 <div class="row">
                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="ej. El Budare" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Tipo</label>
                            <asp:DropDownList id="DropDownList1" CssClass="form-control" AutoPostBack="True" runat="server">
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem>Venezolana</asp:ListItem>
                                <asp:ListItem>Americana</asp:ListItem>
                                <asp:ListItem>Japonesa</asp:ListItem>
                                <asp:ListItem>China</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <div class="form-group">
                        <label class="control-label">Nacionalidad</label>
                        <asp:DropDownList id="DropDownList2" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-8 col-sm-8 col-xs-8">
                        <div class="form-group">
                            <label class="control-label">RIF</label>
                            <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="ej. 965831535-1" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Unidad Monetaria</label>
                                <asp:DropDownList id="DropDownList9" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>VEF</asp:ListItem>
                                    <asp:ListItem>USD</asp:ListItem>
                                    <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Direccion</label>
                            <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="ej. Calle Madrid con Av. Ppal" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Zona</label>
                        <asp:DropDownList id="DropDownList8" CssClass="form-control" AutoPostBack="True" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>Altamira</asp:ListItem>
                            <asp:ListItem>Las Mercedes</asp:ListItem>
                            <asp:ListItem>Macaracuay</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Longitud</label>
                            <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Latitud</label>
                            <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="ej. 10.485440 ó -66.821546" MaxLength="3" runat="server"/>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                            <label class="control-label">Dias de apertura</label>
                            <label>
                            <label class="text-left">
                                    <asp:CheckBox id="Checkbox7" runat="server" value="Lunes" text="Lun"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox8" runat="server" value="Martes" text="Mar"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox9" runat="server" value="Miercoles" text="Mie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="Checkbox10" runat="server" value="Jueves" text="Jue"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox11" runat="server" value="Viernes" text="Vie"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox12" runat="server" value="Sabado" text="Sab"/>
                            </label>
                            <label class="text-left">
                                    <asp:CheckBox id="CheckBox13" runat="server" value="Domingo" text="Dom"/>
                            </label>
                            </label>
                            </div>    
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Apertura</label>
                                <asp:DropDownList id="DropDownList10" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Apertura</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                        <div class="form-group">
                            <label class="control-label">Hora Cierre</label>
                                <asp:DropDownList id="DropDownList11" CssClass="form-control" AutoPostBack="True" runat="server">
                                    <asp:ListItem>Cierre</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group">
                              <label for="ejemplo_archivo_1">Imagen del Restaurante</label>
                              <input type="file" id="ejemplo_archivo_3"/>
                              <p class="help-block">Imagen .jpg o .png</p>
                         </div>
                </div>
             </div> 
            </div>
                        <div class="modal-footer">
                            <asp:Button id="Button1" Text="Agregar" CssClass="btn btn-success" runat="server"/>
                            <asp:Button id="Button2" Text="Cancelar" CssClass="btn btn-danger" runat="server"/>
                        </div>
            </div>
            </div>
            </div>

       
          
</asp:Content>
