﻿using BackOfficeModel.OrderAccount;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter.OrderAccount
{
    public class ClosedOrdersPresenter : BackOfficePresenter.Presenter
    {
        //Enlace Modelo - Vista
        private IClosedOrdersModel _view;
        int totalColumns = 2;


        ///<summary>
        ///Constructor
        /// </summary>
        /// <param name="viewClosedOrders">Interfaz</param>
        public ClosedOrdersPresenter(IClosedOrdersModel viewClosedOrders)
            : base(viewClosedOrders)
        {
            //Enlace Modelo - Vista
            _view = viewClosedOrders;
        }

        ///<summary>
        ///Metodo para llenar la tabla de Ordenes Cerradas
        /// </summary>
        public void GetClosedOrders(string restaurantId)
        {
            int result = 0;
            //Define objeto a recibir
            IList<Account> listAccount;
            //Invoca al comando
            Command commandClosedOrders;

            try
            {
                //Obtener el parametro
                result = int.Parse(_view.SessionRestaurant);

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandClosedOrders = CommandFactory.GetCommandClosedOrders(result);
                
                //Ejecuta el comando deseado
                commandClosedOrders.Execute();

                //Se obtiene el resultado de la operacion
                listAccount = (IList<Account>)commandClosedOrders.Receiver;


                //Revisa si la lista no esta vacia
                if (listAccount != null)
                {
                    //Llama al metodo para el llenado de la tabla
                    FillTable(listAccount);
                }
            }
            catch (Exception)
            {
                //TODO: Arrojar excepciones personalizadas
                //TODO: Escribir en el Log la excepcion
                throw;
            }
        }

        private void FillTable(IList<Account> data)
        {

            //Esto puede mejorarse
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabel.Visible = false;

            CleanTable();
            //Genero los objetos para la consulta
            //Genero la lista de la consulta



            int totalRows = data.Count; //tamano de la lista 

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {
                    //Crea una nueva fila de la tabla
                    TableRow tRow = new TableRow();
                    //Le asigna el Id a cada fila de la tabla
                    tRow.Attributes[OrderAccountResources.dataId] = data[i].Id.ToString();
                    //Agrega la fila a la tabla existente
                    _view.ClosedOrdersTable.Rows.Add(tRow);
                    for (int j = 0; j <= totalColumns; j++)
                    {
                        //Crea una nueva celda de la tabla
                        TableCell tCell = new TableCell();

                    //Agrega el numero de la cuenta 
                    if (j.Equals(0))
                        tCell.Text = data[i].Number.ToString();

                    //Agrega la fecha de la orden
                    else if (j.Equals(1))
                        tCell.Text = data[i].Date.ToShortDateString();

                    //Agrega las acciones
                    else if (j.Equals(2))
                    {

                        LinkButton actionInfo = new LinkButton();
                        LinkButton actionInvoices = new LinkButton();
                        LinkButton actionDetailInvoice = new LinkButton();

                        //Detalle de la orden
                        actionInfo.Text += OrderAccountResources.ActionInfo;
                        actionInfo.Attributes[OrderAccountResources.href] = 
                            OrderAccountResources.detailURL;
                        tCell.Controls.Add(actionInfo);

                        //Modal con factura cancelada
                        actionDetailInvoice.Text += OrderAccountResources.ActionInfo;
                        //Esto tengo que mejorarlo
                        actionDetailInvoice.Attributes["href"] = "#";
                        tCell.Controls.Add(actionDetailInvoice);


                        actionInvoices.Text += OrderAccountResources.ActionInvoices;
                        actionInvoices.Attributes[OrderAccountResources.href] = 
                            OrderAccountResources.invoicesURL;
                        tCell.Controls.Add(actionInvoices);


                    }
                        //Agrega la celda a la fila
                        tRow.Cells.Add(tCell);

                    }
            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.ClosedOrdersTable.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Ordenes Cerradas
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        private TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = OrderAccountResources.OrderNumberColumn;
            h1.Scope = TableHeaderScope.Column;
            h2.Text = OrderAccountResources.DateColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = OrderAccountResources.ActionColumn;

            h3.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla
        /// </summary>
        private void CleanTable()
        {
            _view.ClosedOrdersTable.Rows.Clear();

        }

    }

}