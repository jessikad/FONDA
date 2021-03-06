package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.logic.LogicCurrentOrder;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 19/05/2016.
 */

/**
 * Clase De pruebas unitarias de la lista de platos ordenados de una persona en sus visitas a restaurant
 */
public class CurrentOrderLogicTest extends TestCase {

    /*
       Lista de platos ordenados
    */
    private List<DishOrder> listDishOrder;

    /*
       Variable de la clase LogicCurrentOrder
    */
    private LogicCurrentOrder currentOrderLogic;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        currentOrderLogic = new LogicCurrentOrder();
    }


    /**
     *  Metodo para probar que la lista no esta vacia cuando se conecta con el WS
     */
    public void testListDishOrderIsNotEmpty() {

        try {
        listDishOrder = currentOrderLogic.getCurrentOrderSW();
        assertFalse(listDishOrder.isEmpty());
        } catch (RestClientException e) {
            e.printStackTrace();
        }

    }

    /*
     *  Metodo que prueba que existan elementos en la lista
     */
    public void testListDishOrderElements() {

        try {
            listDishOrder = currentOrderLogic.getCurrentOrderSW();
            MoreAsserts.assertNotEmpty(listDishOrder);
            assertEquals(3, listDishOrder.size());
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        } catch (RestClientException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Dish de la lista de platos no este vacio
     */
    public void testDishOrderIsNotEmpty() {

        try {
        String nameDish = "Pasta";
        listDishOrder = currentOrderLogic.getCurrentOrderSW();
        assertEquals(nameDish, listDishOrder.get(0).getDish().getName());
        } catch (RestClientException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que el objeto Dish de la lista de platos no sea nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        try {
        listDishOrder = currentOrderLogic.getCurrentOrderSW();
        assertNotNull(listDishOrder.get(0).getDish());
        } catch (RestClientException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que la lista de platos no sea nula
     */
    public void testListDishOrderIsNotNull() {

        try {
            listDishOrder = currentOrderLogic.getCurrentOrderSW();
            assertNotNull(listDishOrder);
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        } catch (RestClientException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        listDishOrder = null;
        currentOrderLogic = null;
    }



}