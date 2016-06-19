package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.CommandTests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 11/06/2016.
 */

/**
 * Clase De pruebas unitarias del comando AllRestaurantCommandTest
 */
public class AllRestaurantCommandTest extends TestCase {

    /*
       fabrica de comandos
    */
    private FondaCommandFactory facCmd;

    /*
       Variable de tipo Command
    */
    private Command cmd;


    /**
     * Variable lista de restaurantes favoritos
     */
    private List<Restaurant> restaurantList;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        facCmd = FondaCommandFactory.getInstance();
    }


    /**
     *  Metodo para probar que la lista de restaurantes no es nula
     */
    public void testAllRestaurantCommandIsNotNull() {

        try {

            cmd = facCmd.allRestaurantCommand();
            cmd.run();
            restaurantList = (List<Restaurant>) cmd.getResult();

            assertNotNull(restaurantList);
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    /**
     *  Metodo para probar que la lista de restaurantes no esta vacia
     */
    public void testAllRestaurantCommandIsNotEmpty() {

        try {

            cmd = facCmd.allRestaurantCommand();
            cmd.run();
            restaurantList = (List<Restaurant>) cmd.getResult();

           MoreAsserts.assertNotEmpty(restaurantList);
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que los elementos de la lista no estan vacios
     */
    public void testAllRestaurantCommandElements() {

        try {

            cmd = facCmd.allRestaurantCommand();
            cmd.run();
            restaurantList = (List<Restaurant>) cmd.getResult();

            assertEquals("Pizza Familia", restaurantList.get(2).getName());
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }



    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        facCmd = null;
        cmd = null;
        restaurantList = null;
    }


}