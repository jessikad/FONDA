package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */

/**
 * Interfaz para el presentador de AllRestaurants.
 */
public interface AllRestaurantsViewPresenter {

    /**
     * Encuentra todos los restaurantes
     * @return
     */
    List<Restaurant> findAllRestaurants();

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();


}