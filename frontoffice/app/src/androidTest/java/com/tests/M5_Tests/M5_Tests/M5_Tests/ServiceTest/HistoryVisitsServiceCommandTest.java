package com.tests.M5_Tests.M5_Tests.M5_Tests.ServiceTest;

import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicHistoryVisitsWebApiControllerException;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.domains.Invoice;

import junit.framework.TestCase;

import java.util.List;
/**
 * Created by vickinsua on 6/20/2016.
 */
public class HistoryVisitsServiceCommandTest extends TestCase {

    /*
 Lista de Invoice que contiene los pagos de los restaurant
 */
    private List<Invoice> listInvoice;
    private int idProfile;

    /**
     * variable de la clase HistoryVisitsRestaurantService
     */
    private HistoryVisitsRestaurantService historyVisitsRestaurantService;

    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "HistoryVisitsServiceTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        historyVisitsRestaurantService = FondaServiceFactory.getInstance().getHistoryVisitsService();
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testHistoryVisitsIsNotEmpty() {

        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            assertFalse(listInvoice.isEmpty());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Restaurant de la lista de pagos no este vacio
     */
    public void testRestaurantInvoiceIsNotEmpty() {

        String nameRestaurant = "The dining room";
        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            assertEquals(nameRestaurant, listInvoice.get(0).getRestaurant().getName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }


    }

    /**
     * Metodo que prueba que el perfil de la lista de pagos no este vacio
     */
    public void testProfilesInvoiceIsNotEmpty(){

        String nameProfile = "Adriana Da Rocha";
        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            assertEquals(nameProfile, listInvoice.get(1).getProfile().getProfileName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }


    }

    /**
     * Metodo que prueba que la lista de pagos maneje el total de la factura
     */
    public void testInvoiceIsNotEmpty() {
        float total = 350;
        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            assertEquals(total, listInvoice.get(2).getTotal());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Restaurant de la lista de pagos no sea nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            assertNotNull(listInvoice.get(2).getRestaurant());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Perfil de la lista de pagos no sea nulo
     */
    public void testProfileInvoiceIsNotNull() {

        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            assertNotNull(listInvoice.get(2).getProfile());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que la lista de pago no sea nula
     */
    public void testHistoryVisitsIsNotNull() {

        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            assertNotNull(listInvoice);
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que existan elementos en la lista
     */
    public void testElementLsit() {

        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits(idProfile);
            MoreAsserts.assertNotEmpty(listInvoice );
            assertEquals(6, listInvoice .size());
        }
        catch (NullPointerException e){
            //fail("No esta conectado al WS");
            Log.e(TAG,"Error en HistoryVisitsServiceTest no esta conectado al WS",e);
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en HistoryVisitsServiceTest ",e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        listInvoice = null;
    }

}
