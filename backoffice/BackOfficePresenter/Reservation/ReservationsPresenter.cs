﻿using BackOfficeModel.Reservations;
using BackOfficePresenter.FondaMVPException;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaResources.Reservation;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.BackOffice.Presenter.Reservations
{
    public class ReservationsPresenter : BackOfficePresenter.Presenter
    {
        //Enlace entre el Modelo y la Vista
        private IReservationsModel _view;
        private int totalColumns = 5;


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="viewDefault">Interfaz</param>
        public ReservationsPresenter(IReservationsModel viewDefault)
            : base(viewDefault)
        {
            //Se genera el enlace entre el modelo y la vista
            _view = viewDefault;

        }


        /// <summary>
        /// Metodo encargado de llenar la tabla de Reservas
        /// </summary>
        public void GetReservations()
        {
            int result = 0;
         

            try
            {

                //Obtener el parametro
                result = int.Parse(_view.SessionRestaurant);

                //Llama al metodo para el llenado de la tabla
                FillReservationsTable(result);




            }
            catch (MVPExceptionOrdersTable ex)
            {
                Console.WriteLine("No falla");
            }

        }
        /// <summary>
        /// Construye la tabla de Ordenes
        /// </summary>
        /// <param name="data">una lista de ordenes</param>
        private void FillReservationsTable(int restaurantId)
        {

            //Esto puede mejorarse
            _view.ErrorLabel.Visible = false;
            _view.SuccessLabel.Visible = false;
            _view.WarningLabel.Visible = false;

            CleanTable();
            //Genero los objetos para la consulta

            //Define objeto a recibir
            IList<Reservation> listReservation;
            //Invoca a comando del tipo deseado
            Command commandGetReservations;
            
            
            //faltan los comandos de esta parte del restaurant



            //Genero la lista de la consulta
            //Obtiene la instancia del comando enviado el restaurante como parametro
            commandGetReservations = CommandFactory.GetCommandGetReservations(restaurantId);

            //Ejecuta el comando deseado
            commandGetReservations.Execute();

            //Se obtiene el resultado de la operacion
            listReservation = (IList<Reservation>)commandGetReservations.Receiver;

            if (listReservation != null)
            {
                ////Llama al metodo para el llenado de la tabla
                //FillReservationsTable(result);
            }




            int totalRows = data.Count; //tamano de la lista 

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {

                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes[ReservationResources.dataId] =
                    data[i].Id.ToString();
                //Agrega la fila a la tabla existente
                _view.ReservationsTable.Rows.Add(tRow);
                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();

                    //Agrega el numero de orden
                    if (j.Equals(0))
                        tCell.Text = data[i].Number.ToString();

                    //Agrega el correo del comensal
                    else if (j.Equals(1))
                        tCell.Text = data[i].Commensal.Email.ToString();

                    //Agrega el numero de mesa
                    else if (j.Equals(2))
                        tCell.Text = data[i].Table.Number.ToString();

                    //Agrega las acciones de la tabla
                    else if (j.Equals(3))
                    {
                        LinkButton actionInfo = new LinkButton();
                        LinkButton actionInvoices = new LinkButton();

                        actionInfo.Text += OrderAccountResources.ActionInfo;
                        actionInfo.Attributes[OrderAccountResources.href] =
                            OrderAccountResources.detailURL;
                        tCell.Controls.Add(actionInfo);

                        actionInvoices.Text += OrderAccountResources.ActionInvoices;
                        actionInvoices.Attributes[OrderAccountResources.href] =
                            OrderAccountResources.invoicesURL;
                        tCell.Controls.Add(actionInvoices);



                        //Guardamos el recurso de Session del ID de la orden
                        int idAccount = data[i].Id;
                        _view.Session = idAccount.ToString();

                    }
                    //Agrega la celda a la fila
                    tRow.Cells.Add(tCell);

                }

            }

            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            _view.OrdersTable.Rows.AddAt(0, header);
        }

        /// <summary>
        /// Genera el encabezado de la tabla Ordenes
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
            TableHeaderCell h4 = new TableHeaderCell();


            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            //Esto tambien debo mejorarlo
            h1.Text = OrderAccountResources.OrderNumberColumn;
            h1.Scope = TableHeaderScope.Column;
            h2.Text = OrderAccountResources.OrderUserColumn;
            h2.Scope = TableHeaderScope.Column;
            h3.Text = OrderAccountResources.OrderTableColumn;
            h3.Scope = TableHeaderScope.Column;
            h4.Text = OrderAccountResources.ActionColumn;
            h4.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);

            return header;
        }

        /// <summary>
        /// Limpia las filas de la tabla
        /// </summary>
        private void CleanTable()
        {
            _view.OrdersTable.Rows.Clear();

        }

    }
}
