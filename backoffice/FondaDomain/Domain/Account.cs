﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa una cuenta de un restaurante.
    /// </summary>
    public class Account : BaseEntity
    {
        /// <summary>
        /// Fecha de la cuenta
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Estado de la cuenta
        /// </summary>
        private AccountStatus _status;

        /// <summary>
        /// Mesa de la cuenta 
        /// </summary>
        private Table _table;

        /// <summary>
        /// Commensal de la cuenta
        /// </summary>
        private Commensal _commensal;

        /// <summary>
        /// Lista de ordenes de la cuenta.
        /// </summary>
        private IList<DishOrder> _listDish;

        /// <summary>
		/// El numero unico de la cuenta
		/// </summary>
        private int _number;

        /// <summary>
        /// Constructor
        /// </summary>
        public Account() : base()
        {
            _listDish = new List<DishOrder>();
        }

        /// <summary>
        /// Retorna o asigna la mesa de una cuenta
        /// </summary>
        //[DataMember]
        public virtual Table Table
        {
            get { return _table; }
            set { _table = value; }
        }

        /// <summary>
        /// Obtiene o asigna el numero de la orden
        /// </summary>
        public virtual int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        [DataMember]
        public virtual IList<DishOrder> ListDish
        {
            get { return _listDish; }
            set { _listDish = value; }
        }

        /// <summary>
        /// Obtiene o asigna un estado a la cuenta
        /// </summary>
        public virtual AccountStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Obtiene o asigna un commensal a la cuenta
        /// </summary>
        public virtual Commensal Commensal
        {
            get{ return _commensal; }
            set{ _commensal = value; }
        }

        /// <summary>
        /// Agrega una orden a la cuenta
        /// </summary>
        /// <param name="dish"> orden pedida </param>
        public virtual void addDish(DishOrder dish)
        {
            _listDish.Add(dish);
        }

        /// <summary>
        /// Cambia el eltado actual del cuenta.
        /// </summary>
        public virtual void changeStatus()
        {
            _status = _status.Change();
        }


        /// <summary>
        /// Obtiene el precio total de todas las ordenes
        /// </summary>
        public virtual float getMonto()
        {
            float total = 0;
            for (int i = 0; i < _listDish.Count; i++)
            {
                total = _listDish[i].Dish.Cost + total;
            }
            return total;
        }

        /// <summary>
        /// Retorna o asigna una fecha
        /// </summary>
        public virtual DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

    }
}
